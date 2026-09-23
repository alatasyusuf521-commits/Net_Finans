using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using MuhasebeOtomasyonu.Data;
using MuhasebeOtomasyonu.Models;

namespace MuhasebeOtomasyonu.Services
{
    public class MuhasebeService
    {
        private const string OtomatikAciklamaOneki = "Otomatik Aylık Muhasebe Ücreti Borçlandırma";

        public List<Cari> CariHesaplariniGetir(int secilenAySayisi)
        {
            if (secilenAySayisi <= 0) secilenAySayisi = 1;

            var cariler = new List<Cari>();

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    string sqlCariler = @"SELECT 
                                            Id AS CariID, 
                                            CariKod AS CariKodu, 
                                            Unvan, 
                                            YetkiliKisi, 
                                            Telefon, 
                                            Eposta, 
                                            Adres, 
                                            AylikUcret, 
                                            ISNULL(BorclanmaAySayisi, 1) AS BorclanmaAySayisi, 
                                            OlusturmaTarihi AS KayitTarihi, 
                                            Durum 
                                        FROM Cariler WITH (NOLOCK) 
                                        WHERE Durum = 1";

                    using (var cmd = new SqlCommand(sqlCariler, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cari = new Cari
                            {
                                CariID = Convert.ToInt32(reader["CariID"]),
                                CariKodu = reader["CariKodu"]?.ToString() ?? string.Empty,
                                Unvan = reader["Unvan"]?.ToString() ?? string.Empty,
                                YetkiliKisi = reader["YetkiliKisi"] != DBNull.Value ? reader["YetkiliKisi"].ToString() : null,
                                Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : null,
                                Eposta = reader["Eposta"] != DBNull.Value ? reader["Eposta"].ToString() : null,
                                Adres = reader["Adres"] != DBNull.Value ? reader["Adres"].ToString() : null,
                                AylikUcret = reader["AylikUcret"] != DBNull.Value ? Convert.ToDecimal(reader["AylikUcret"]) : 0m,
                                BorclanmaAySayisi = reader["BorclanmaAySayisi"] != DBNull.Value ? Convert.ToInt32(reader["BorclanmaAySayisi"]) : 1,
                                KayitTarihi = reader["KayitTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["KayitTarihi"]) : DateTime.Now,
                                Durum = reader["Durum"] != DBNull.Value ? Convert.ToBoolean(reader["Durum"]) : true
                            };

                            cariler.Add(cari);
                        }
                    }

                    foreach (var cari in cariler)
                    {
                        decimal ekBorclar = GetEkstraBorclar(conn, cari.CariID);
                        decimal tahsilatlar = GetTahsilatToplam(conn, cari.CariID);

                        cari.ToplamBorc = (cari.AylikUcret * secilenAySayisi) + ekBorclar;
                        cari.ToplamTahsilat = tahsilatlar;
                    }
                }
            }
            catch (Exception)
            {
            }

            return cariler;
        }

        public List<CariHareket> CariEkstreGetir(int cariId, int aktifDonem = 2026)
        {
            var hareketler = new List<CariHareket>();

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    string cariUnvan = string.Empty;
                    decimal devirBakiye = 0m;
                    using (var cmdCari = new SqlCommand(
                        "SELECT Unvan, ISNULL(DevirBakiye, 0) AS DevirBakiye FROM Cariler WITH (NOLOCK) WHERE Id = @CariID", conn))
                    {
                        cmdCari.Parameters.AddWithValue("@CariID", cariId);
                        using (var readerCari = cmdCari.ExecuteReader())
                        {
                            if (readerCari.Read())
                            {
                                cariUnvan   = readerCari["Unvan"]       != DBNull.Value ? readerCari["Unvan"].ToString()!            : string.Empty;
                                devirBakiye = readerCari["DevirBakiye"] != DBNull.Value ? Convert.ToDecimal(readerCari["DevirBakiye"]) : 0m;
                            }
                        }
                    }

                    // Devir bakiyesi varsa en başa açılış satırı ekle
                    if (devirBakiye > 0)
                    {
                        hareketler.Add(new CariHareket
                        {
                            HareketID         = -1,
                            CariID            = cariId,
                            CariUnvan         = cariUnvan,
                            IslemTarihi       = new DateTime(aktifDonem, 1, 1, 0, 0, 0),
                            IslemTuru         = "Devir Bakiye",
                            Aciklama          = $"{aktifDonem - 1} yılından devreden bakiye",
                            Borc              = devirBakiye,
                            Alacak            = 0m,
                            YuruyenBakiye     = 0m,
                            KaydedenKullanici = "Sistem"
                        });
                    }

                    // ✅ 1. CariAylikUcretler tablosundan aylık ücretleri al
                    string sqlAylik = @"
                        SELECT AyIndex, Ucret 
                        FROM CariAylikUcretler 
                        WHERE CariID = @CariID 
                        ORDER BY AyIndex ASC";

                    using (var cmd = new SqlCommand(sqlAylik, conn))
                    {
                        cmd.Parameters.AddWithValue("@CariID", cariId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ay = Convert.ToInt32(reader["AyIndex"]);
                                decimal tutar = Convert.ToDecimal(reader["Ucret"]);

                                if (tutar > 0)
                                {
                                    DateTime borcTarihi = new DateTime(aktifDonem, ay, 1, 8, 0, 0);
                                    string ayAdi = borcTarihi.ToString("MMMM yyyy");

                                    hareketler.Add(new CariHareket
                                    {
                                        HareketID = 0,
                                        CariID = cariId,
                                        CariUnvan = cariUnvan,
                                        IslemTarihi = borcTarihi,
                                        IslemTuru = "Borçlandırma",
                                        Aciklama = $"{ayAdi} Muhasebe Hizmet Ücreti",
                                        Borc = tutar,
                                        Alacak = 0m,
                                        YuruyenBakiye = 0m,
                                        KaydedenKullanici = "Sistem"
                                    });
                                }
                            }
                        }
                    }

                    // ✅ 2. CariHareketler tablosundan tahsilatları al
                    string sqlTahsilat = @"
                        SELECT 
                            Id AS HareketID,
                            CariId AS CariID,
                            IslemTipi,
                            Tutar,
                            Aciklama,
                            IslemTarihi AS Tarih,
                            KaydedenKullanici
                        FROM CariHareketler WITH (NOLOCK)
                        WHERE CariId = @CariID
                          AND IslemTipi = 'Tahsilat'
                          AND YEAR(IslemTarihi) = @Donem
                        ORDER BY IslemTarihi ASC";

                    using (var cmd = new SqlCommand(sqlTahsilat, conn))
                    {
                        cmd.Parameters.AddWithValue("@CariID", cariId);
                        cmd.Parameters.AddWithValue("@Donem", aktifDonem);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal tutar = Convert.ToDecimal(reader["Tutar"]);

                                var hareket = new CariHareket
                                {
                                    HareketID = Convert.ToInt32(reader["HareketID"]),
                                    CariID = Convert.ToInt32(reader["CariID"]),
                                    CariUnvan = cariUnvan,
                                    IslemTarihi = reader["Tarih"] != DBNull.Value ? Convert.ToDateTime(reader["Tarih"]) : DateTime.Now,
                                    IslemTuru = "Tahsilat",
                                    Aciklama = reader["Aciklama"] != DBNull.Value ? reader["Aciklama"].ToString()! : string.Empty,
                                    Borc = 0m,
                                    Alacak = tutar,
                                    YuruyenBakiye = 0m,
                                    KaydedenKullanici = reader["KaydedenKullanici"] != DBNull.Value ? reader["KaydedenKullanici"].ToString() : string.Empty
                                };

                                hareketler.Add(hareket);
                            }
                        }
                    }

                    // ✅ 3. CariHareketler tablosundan manuel borçları al (Otomatik olanlar hariç)
                    string sqlBorc = @"
                        SELECT 
                            Id AS HareketID,
                            CariId AS CariID,
                            IslemTipi,
                            Tutar,
                            Aciklama,
                            IslemTarihi AS Tarih,
                            KaydedenKullanici
                        FROM CariHareketler WITH (NOLOCK)
                        WHERE CariId = @CariID
                          AND IslemTipi = 'Borc'
                          AND YEAR(IslemTarihi) = @Donem
                          AND Aciklama NOT LIKE @OtomatikOnek
                        ORDER BY IslemTarihi ASC";

                    using (var cmd = new SqlCommand(sqlBorc, conn))
                    {
                        cmd.Parameters.AddWithValue("@CariID", cariId);
                        cmd.Parameters.AddWithValue("@Donem", aktifDonem);
                        cmd.Parameters.AddWithValue("@OtomatikOnek", OtomatikAciklamaOneki + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal tutar = Convert.ToDecimal(reader["Tutar"]);

                                var hareket = new CariHareket
                                {
                                    HareketID = Convert.ToInt32(reader["HareketID"]),
                                    CariID = Convert.ToInt32(reader["CariID"]),
                                    CariUnvan = cariUnvan,
                                    IslemTarihi = reader["Tarih"] != DBNull.Value ? Convert.ToDateTime(reader["Tarih"]) : DateTime.Now,
                                    IslemTuru = "Borçlandırma",
                                    Aciklama = reader["Aciklama"] != DBNull.Value ? reader["Aciklama"].ToString()! : string.Empty,
                                    Borc = tutar,
                                    Alacak = 0m,
                                    YuruyenBakiye = 0m,
                                    KaydedenKullanici = reader["KaydedenKullanici"] != DBNull.Value ? reader["KaydedenKullanici"].ToString() : string.Empty
                                };

                                hareketler.Add(hareket);
                            }
                        }
                    }

                    // Tüm hareketleri tarihe göre sırala
                    hareketler = hareketler.OrderBy(h => h.IslemTarihi).ThenBy(h => h.HareketID).ToList();

                    // Yürüyen bakiyeyi hesapla
                    decimal yuruyenBakiye = 0m;
                    foreach (var item in hareketler)
                    {
                        yuruyenBakiye += (item.Borc - item.Alacak);
                        item.YuruyenBakiye = yuruyenBakiye;
                    }
                }
            }
            catch (Exception)
            {
            }

            return hareketler;
        }

        public int TopluBorclandir()
        {
            int islenenSayisi = 0;
            var now = DateTime.Now;
            string aciklama = $"{OtomatikAciklamaOneki} - {now:yyyy MMMM}";

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                var cariListesi = new List<(int CariId, decimal AylikUcret, int BorclanmaAySayisi)>();

                string sqlCariler = "SELECT Id, AylikUcret, ISNULL(BorclanmaAySayisi, 1) AS BorclanmaAySayisi FROM Cariler WITH (NOLOCK) WHERE Durum = 1";
                using (var cmd = new SqlCommand(sqlCariler, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        decimal ucret = reader["AylikUcret"] != DBNull.Value ? Convert.ToDecimal(reader["AylikUcret"]) : 0m;
                        int aySayisi = reader["BorclanmaAySayisi"] != DBNull.Value ? Convert.ToInt32(reader["BorclanmaAySayisi"]) : 1;
                        cariListesi.Add((id, ucret, aySayisi));
                    }
                }

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var cari in cariListesi)
                        {
                            if (cari.AylikUcret <= 0) continue;

                            string sqlKontrol = @"SELECT COUNT(1) 
                                                  FROM CariHareketler WITH (NOLOCK)
                                                  WHERE CariId = @CariID 
                                                    AND IslemTipi = 'Borc' 
                                                    AND MONTH(IslemTarihi) = @Ay 
                                                    AND YEAR(IslemTarihi) = @Yil";

                            using (var cmdKontrol = new SqlCommand(sqlKontrol, conn, transaction))
                            {
                                cmdKontrol.Parameters.AddWithValue("@CariID", cari.CariId);
                                cmdKontrol.Parameters.AddWithValue("@Ay", now.Month);
                                cmdKontrol.Parameters.AddWithValue("@Yil", now.Year);

                                int varMi = Convert.ToInt32(cmdKontrol.ExecuteScalar());
                                if (varMi > 0) continue;
                            }

                            decimal borcTutari = cari.AylikUcret * cari.BorclanmaAySayisi;

                            string sqlInsert = @"INSERT INTO CariHareketler (CariId, IslemTipi, IslemTarihi, Aciklama, Borc, Alacak, Tutar) 
                                                  VALUES (@CariID, 'Borc', GETDATE(), @Aciklama, @BorcTutari, 0, @BorcTutari)";

                            using (var cmdInsert = new SqlCommand(sqlInsert, conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@CariID", cari.CariId);
                                cmdInsert.Parameters.AddWithValue("@BorcTutari", borcTutari);
                                cmdInsert.Parameters.AddWithValue("@Aciklama", aciklama);

                                if (cmdInsert.ExecuteNonQuery() > 0)
                                {
                                    islenenSayisi++;
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return islenenSayisi;
        }

        public bool TekilBorclandir(int cariId, decimal tutar)
        {
            if (cariId <= 0 || tutar <= 0) return false;

            var now = DateTime.Now;
            string aciklama = $"{now:yyyy MMMM} Muhasebe Ücreti (Tekil)";

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHareket = @"INSERT INTO CariHareketler 
                            (CariId, IslemTipi, IslemTarihi, Aciklama, Borc, Alacak, Tutar) 
                            VALUES (@CariID, 'Borc', GETDATE(), @Aciklama, @Tutar, 0, @Tutar)";

                        using (var cmdHareket = new SqlCommand(sqlHareket, conn, transaction))
                        {
                            cmdHareket.Parameters.AddWithValue("@CariID", cariId);
                            cmdHareket.Parameters.AddWithValue("@Tutar", tutar);
                            cmdHareket.Parameters.AddWithValue("@Aciklama", aciklama);
                            cmdHareket.ExecuteNonQuery();
                        }

                        string sqlCari = @"UPDATE Cariler 
                                           SET ToplamBorc = ToplamBorc + @Tutar 
                                           WHERE Id = @CariID";

                        using (var cmdCari = new SqlCommand(sqlCari, conn, transaction))
                        {
                            cmdCari.Parameters.AddWithValue("@CariID", cariId);
                            cmdCari.Parameters.AddWithValue("@Tutar", tutar);
                            cmdCari.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private decimal GetEkstraBorclar(SqlConnection conn, int cariId)
        {
            string sql = @"SELECT ISNULL(SUM(Tutar), 0) 
                           FROM CariHareketler WITH (NOLOCK) 
                           WHERE CariId = @CariID 
                             AND IslemTipi = 'Borc' 
                             AND Aciklama NOT LIKE @OtomatikOnek";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CariID", cariId);
                cmd.Parameters.AddWithValue("@OtomatikOnek", OtomatikAciklamaOneki + "%");
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private decimal GetTahsilatToplam(SqlConnection conn, int cariId)
        {
            string sql = "SELECT ISNULL(SUM(Tutar), 0) FROM CariHareketler WITH (NOLOCK) WHERE CariId = @CariID AND IslemTipi = 'Tahsilat'";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CariId", cariId);
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        public bool BorcEkle(int cariId, decimal tutar, string aciklama, string kullanici)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string aciklamaFinal = string.IsNullOrWhiteSpace(kullanici)
                    ? aciklama
                    : $"{aciklama} (Giren: {kullanici})";

                string sql = @"INSERT INTO CariHareketler (CariId, IslemTipi, IslemTarihi, Aciklama, Borc, Alacak, Tutar) 
                            VALUES (@CariID, 'Borc', GETDATE(), @Aciklama, @Tutar, 0, @Tutar)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CariID", cariId);
                    cmd.Parameters.AddWithValue("@Tutar", tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)aciklamaFinal ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool TahsilatEkle(int cariId, decimal tutar, string aciklama, string kullanici)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string aciklamaFinal = string.IsNullOrWhiteSpace(kullanici)
                    ? aciklama
                    : $"{aciklama} (Giren: {kullanici})";

                string sql = @"INSERT INTO CariHareketler (CariId, IslemTipi, IslemTarihi, Aciklama, Borc, Alacak, Tutar) 
                            VALUES (@CariID, 'Tahsilat', GETDATE(), @Aciklama, 0, @Tutar, @Tutar)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CariID", cariId);
                    cmd.Parameters.AddWithValue("@Tutar", tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)aciklamaFinal ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}