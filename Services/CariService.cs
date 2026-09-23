using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using MuhasebeOtomasyonu.Data;
using MuhasebeOtomasyonu.Models;

namespace MuhasebeOtomasyonu.Services
{
    public class CariService
    {
        public List<CariBakiyeView> Listele(int yil)
        {
            string sql = @"
                SELECT 
                    Id AS CariID, 
                    CariKod AS CariKodu, 
                    Unvan, 
                    Telefon, 
                    AylikUcret,
                    BorclanmaAySayisi, 
                    DevirBakiye, 
                    ToplamBorc, 
                    ToplamAlacak,
                    (ToplamBorc - ToplamAlacak) AS Bakiye
                FROM Cariler
                WHERE Durum = 1";

            // Donem kolonu devir sonrası hedef yıla set edilir — en güvenli filtre
            sql += " AND Donem = @Yil";

            sql += " ORDER BY Id ASC;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    return conn.Query<CariBakiyeView>(sql, new { Yil = yil }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari listesi yüklenirken veritabanı hatası oluştu: " + ex.Message, ex);
            }
        }

        public List<CariBakiyeView> AramaYap(string aramaMetni, int yil)
        {
            if (string.IsNullOrWhiteSpace(aramaMetni))
            {
                return Listele(yil);
            }

            string sql = @"
                SELECT 
                    Id AS CariID, 
                    CariKod AS CariKodu, 
                    Unvan, 
                    Telefon, 
                    AylikUcret,
                    BorclanmaAySayisi, 
                    DevirBakiye, 
                    ToplamBorc, 
                    ToplamAlacak,
                    (ToplamBorc - ToplamAlacak) AS Bakiye
                FROM Cariler
                WHERE Durum = 1
                  AND (Unvan LIKE @Metin OR CariKod LIKE @Metin)";

            // Donem kolonu devir sonrası hedef yıla set edilir — en güvenli filtre
            sql += " AND Donem = @Yil";

            sql += " ORDER BY Id ASC;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    return conn.Query<CariBakiyeView>(sql, new { Metin = $"%{aramaMetni.Trim()}%", Yil = yil }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari araması yapılırken hatası oluştu: " + ex.Message, ex);
            }
        }

        public Cari? GetById(int cariId)
        {
            const string sql = @"SELECT 
                    Id AS CariID, CariKod AS CariKodu, Unvan, YetkiliKisi, Telefon,
                    Eposta, Adres, AylikUcret, BorclanmaAySayisi, DevirBakiye,
                    ToplamBorc, ToplamAlacak AS ToplamTahsilat,
                    OlusturmaTarihi AS KayitTarihi, Durum, SonDevirTarihi
                FROM Cariler WHERE Id = @CariID;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    return conn.QueryFirstOrDefault<Cari>(sql, new { CariID = cariId });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari detayları alınırken hata oluştu: " + ex.Message, ex);
            }
        }

        public bool Ekle(Cari cari)
        {
            // INSERT sonrası yeni ID'yi SCOPE_IDENTITY ile alıyoruz
            const string sql = @"
                INSERT INTO Cariler 
                (CariKod, Unvan, YetkiliKisi, Telefon, Eposta, Adres, AylikUcret, 
                 BorclanmaAySayisi, DevirBakiye, ToplamBorc, ToplamAlacak, Bakiye, 
                 OlusturmaTarihi, Durum, Donem)
                VALUES 
                (@CariKodu, @Unvan, @YetkiliKisi, @Telefon, @Eposta, @Adres, @AylikUcret, 
                 @BorclanmaAySayisi, @DevirBakiye, @ToplamBorc, @ToplamTahsilat, @Bakiye, 
                 GETDATE(), 1, @Donem);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    var parametreler = new
                    {
                        cari.CariKodu,
                        cari.Unvan,
                        cari.YetkiliKisi,
                        cari.Telefon,
                        cari.Eposta,
                        cari.Adres,
                        cari.AylikUcret,
                        cari.BorclanmaAySayisi,
                        cari.DevirBakiye,
                        cari.ToplamBorc,
                        cari.ToplamTahsilat,
                        Bakiye = cari.ToplamBorc - cari.ToplamTahsilat,
                        Donem = DateTime.Now.Year
                    };

                    // Yeni ID'yi al ve modele set et
                    object? result = conn.ExecuteScalar(sql, parametreler);
                    if (result != null && result != DBNull.Value)
                    {
                        cari.CariID = Convert.ToInt32(result);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari kaydedilirken hata oluştu: " + ex.Message, ex);
            }
        }

        public bool Guncelle(Cari cari)
        {
            const string sql = @"
                UPDATE Cariler 
                SET 
                    Unvan = @Unvan,
                    YetkiliKisi = @YetkiliKisi,
                    Telefon = @Telefon,
                    Eposta = @Eposta,
                    Adres = @Adres,
                    AylikUcret = @AylikUcret,
                    BorclanmaAySayisi = @BorclanmaAySayisi,
                    DevirBakiye = @DevirBakiye,
                    ToplamBorc = @ToplamBorc,
                    ToplamAlacak = @ToplamTahsilat,
                    Bakiye = @Bakiye
                WHERE Id = @CariID;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    var parametreler = new
                    {
                        cari.CariID,
                        cari.Unvan,
                        cari.YetkiliKisi,
                        cari.Telefon,
                        cari.Eposta,
                        cari.Adres,
                        cari.AylikUcret,
                        cari.BorclanmaAySayisi,
                        cari.DevirBakiye,
                        cari.ToplamBorc,
                        cari.ToplamTahsilat,
                        Bakiye = cari.ToplamBorc - cari.ToplamTahsilat
                    };

                    int rows = conn.Execute(sql, parametreler);
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari güncellenirken hata oluştu: " + ex.Message, ex);
            }
        }

        private static bool _kolonKontrolYapildi = false;

        private static void SilinmeTarihiKolonKontrol(IDbConnection conn, IDbTransaction? transaction = null)
        {
            if (_kolonKontrolYapildi) return;
            try
            {
                string sql = @"
                    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('Cariler') AND name = 'SilinmeTarihi')
                    BEGIN
                        ALTER TABLE Cariler ADD SilinmeTarihi DATETIME NULL;
                    END";
                conn.Execute(sql, transaction: transaction);
                _kolonKontrolYapildi = true;
            }
            catch { }
        }

        public bool Sil(int cariId)
        {
            if (cariId <= 0) return false;

            using (var conn = DbHelper.GetConnection())
            {
                SilinmeTarihiKolonKontrol(conn);
                const string sql = "UPDATE Cariler SET Durum = 0, SilinmeTarihi = GETDATE() WHERE Id = @CariID";
                int rows = conn.Execute(sql, new { CariID = cariId });
                return rows > 0;
            }
        }

        public bool GeriYukle(int cariId)
        {
            if (cariId <= 0) return false;

            using (var conn = DbHelper.GetConnection())
            {
                SilinmeTarihiKolonKontrol(conn);
                const string sql = "UPDATE Cariler SET Durum = 1, SilinmeTarihi = NULL WHERE Id = @CariID";
                int rows = conn.Execute(sql, new { CariID = cariId });
                return rows > 0;
            }
        }

        public bool KaliciSil(int cariId)
        {
            if (cariId <= 0) return false;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHareketler = "DELETE FROM CariHareketler WHERE CariId = @CariID";
                        conn.Execute(sqlHareketler, new { CariID = cariId }, transaction: transaction);

                        string sqlArsiv = "DELETE FROM CariDevirArsiv WHERE CariID = @CariID";
                        conn.Execute(sqlArsiv, new { CariID = cariId }, transaction: transaction);

                        string sqlAylikUcret = "DELETE FROM CariAylikUcretler WHERE CariID = @CariID";
                        conn.Execute(sqlAylikUcret, new { CariID = cariId }, transaction: transaction);

                        string sqlCari = "DELETE FROM Cariler WHERE Id = @CariID";
                        int rows = conn.Execute(sqlCari, new { CariID = cariId }, transaction: transaction);

                        transaction.Commit();
                        return rows > 0;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int CopKutusunuBosalt()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHareketler = "DELETE FROM CariHareketler WHERE CariId IN (SELECT Id FROM Cariler WHERE Durum = 0)";
                        conn.Execute(sqlHareketler, transaction: transaction);

                        string sqlArsiv = "DELETE FROM CariDevirArsiv WHERE CariID IN (SELECT Id FROM Cariler WHERE Durum = 0)";
                        conn.Execute(sqlArsiv, transaction: transaction);

                        string sqlAylikUcret = "DELETE FROM CariAylikUcretler WHERE CariID IN (SELECT Id FROM Cariler WHERE Durum = 0)";
                        conn.Execute(sqlAylikUcret, transaction: transaction);

                        string sqlCari = "DELETE FROM Cariler WHERE Durum = 0";
                        int rows = conn.Execute(sqlCari, transaction: transaction);

                        transaction.Commit();
                        return rows;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<CariCopKutusuView> CopKutusunuListele()
        {
            string sql = @"
                SELECT 
                    Id AS CariID, 
                    CariKod AS CariKodu, 
                    Unvan, 
                    Telefon, 
                    AylikUcret,
                    DevirBakiye, 
                    ToplamBorc, 
                    ToplamAlacak,
                    (ToplamBorc - ToplamAlacak) AS Bakiye,
                    SilinmeTarihi,
                    Donem
                FROM Cariler
                WHERE Durum = 0
                ORDER BY SilinmeTarihi DESC;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    SilinmeTarihiKolonKontrol(conn);
                    return conn.Query<CariCopKutusuView>(sql).ToList();
                }
            }
            catch
            {
                return new List<CariCopKutusuView>();
            }
        }

        public int CopKutusuAdetGetir()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    SilinmeTarihiKolonKontrol(conn);
                    return conn.ExecuteScalar<int>("SELECT COUNT(*) FROM Cariler WHERE Durum = 0");
                }
            }
            catch
            {
                return 0;
            }
        }

        public int OtomatikCopKutusuTemizle()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    SilinmeTarihiKolonKontrol(conn);
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlEskiSilinenler = @"
                                SELECT Id FROM Cariler 
                                WHERE Durum = 0 AND SilinmeTarihi IS NOT NULL AND SilinmeTarihi < DATEADD(day, -30, GETDATE())";

                            var silinecekIdler = conn.Query<int>(sqlEskiSilinenler, transaction: transaction).ToList();

                            if (silinecekIdler.Count == 0)
                            {
                                transaction.Commit();
                                return 0;
                            }

                            string sqlHareketler = "DELETE FROM CariHareketler WHERE CariId IN @Idler";
                            conn.Execute(sqlHareketler, new { Idler = silinecekIdler }, transaction: transaction);

                            string sqlArsiv = "DELETE FROM CariDevirArsiv WHERE CariID IN @Idler";
                            conn.Execute(sqlArsiv, new { Idler = silinecekIdler }, transaction: transaction);

                            string sqlAylikUcret = "DELETE FROM CariAylikUcretler WHERE CariID IN @Idler";
                            conn.Execute(sqlAylikUcret, new { Idler = silinecekIdler }, transaction: transaction);

                            string sqlCari = "DELETE FROM Cariler WHERE Id IN @Idler";
                            int rows = conn.Execute(sqlCari, new { Idler = silinecekIdler }, transaction: transaction);

                            transaction.Commit();
                            return rows;
                        }
                        catch
                        {
                            transaction.Rollback();
                            return 0;
                        }
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool PasifeAl(int cariId)
        {
            const string sql = @"UPDATE Cariler SET Durum = 0 WHERE Id = @CariID;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    int rows = conn.Execute(sql, new { CariID = cariId });
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cari pasife alınırken hata oluştu: " + ex.Message, ex);
            }
        }

        public string OtomatikCariKoduUret()
        {
            const string sql = @"
                SELECT MAX(CAST(SUBSTRING(CariKod, 5, LEN(CariKod)-4) AS INT)) 
                FROM Cariler;";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    object? result = conn.ExecuteScalar(sql);
                    int lastNum = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                    if (lastNum == 0)
                        return "CAR-001";

                    return $"CAR-{(lastNum + 1):D3}";
                }
            }
            catch
            {
                return "CAR-001";
            }
        }

        public bool BuYilDevirYapilmisMi(int yil)
        {
            const string sql = @"
                SELECT COUNT(*) 
                FROM CariDevirArsiv 
                WHERE DevirYili = @HedefYil";
            
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    int count = conn.ExecuteScalar<int>(sql, new { HedefYil = yil + 1 });
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public int YilSonuDevir(int kaynakYil, int hedefYil)
        {
            int islenenSayi = 0;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // CariDevirArsiv tablosunda EskiToplamBorc ve EskiToplamAlacak kolonları yoksa dinamik ekle
                        string sqlKolonEklemeler = @"
                            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('CariDevirArsiv') AND name = 'EskiToplamBorc')
                            BEGIN
                                ALTER TABLE CariDevirArsiv ADD EskiToplamBorc DECIMAL(18,2) NULL;
                            END
                            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('CariDevirArsiv') AND name = 'EskiToplamAlacak')
                            BEGIN
                                ALTER TABLE CariDevirArsiv ADD EskiToplamAlacak DECIMAL(18,2) NULL;
                            END";
                        conn.Execute(sqlKolonEklemeler, transaction: transaction);

                        string sqlCariler = @"
                            SELECT 
                                Id, 
                                ISNULL(AylikUcret, 0) AS AylikUcret,
                                ISNULL(DevirBakiye, 0) AS DevirBakiye,
                                ISNULL(ToplamBorc, 0) AS ToplamBorc,
                                ISNULL(ToplamAlacak, 0) AS ToplamAlacak,
                                ISNULL(Bakiye, 0) AS Bakiye
                            FROM Cariler 
                            WHERE Durum = 1 
                              AND (SonDevirTarihi IS NULL OR YEAR(SonDevirTarihi) < @KaynakYil)";

                        var cariler = conn.Query<dynamic>(sqlCariler, new { KaynakYil = kaynakYil }, transaction: transaction).ToList();

                        foreach (var cari in cariler)
                        {
                            int cariId = cari.Id;
                            decimal aylikUcret = Convert.ToDecimal(cari.AylikUcret);
                            decimal eskiDevirBakiye = Convert.ToDecimal(cari.DevirBakiye);
                            decimal eskiToplamAlacak = Convert.ToDecimal(cari.ToplamAlacak);
                            
                            // Gerçek Eski Toplam Borç: Yıllık Ücret + Devir Bakiye
                            decimal eskiToplamBorc = aylikUcret + eskiDevirBakiye;
                            
                            // Yeni Devir Bakiye = Devreden Net Kalan Bakiye
                            decimal kalanBakiye = eskiToplamBorc - eskiToplamAlacak;
                            decimal yeniDevirBakiye = kalanBakiye;

                            string sqlUpdate = @"
                                UPDATE Cariler 
                                SET 
                                    DevirBakiye = @YeniDevirBakiye,
                                    ToplamBorc = @YeniDevirBakiye,
                                    ToplamAlacak = 0,
                                    Bakiye = @YeniDevirBakiye,
                                    SonDevirTarihi = GETDATE(),
                                    Donem = @HedefYil
                                WHERE Id = @CariID";

                            conn.Execute(sqlUpdate, new
                            {
                                CariID = cariId,
                                YeniDevirBakiye = yeniDevirBakiye,
                                HedefYil = hedefYil
                            }, transaction: transaction);

                            string sqlArsiv = @"
                                INSERT INTO CariDevirArsiv (CariID, EskiDevirBakiye, YeniDevirBakiye, KalanBakiye, EskiToplamBorc, EskiToplamAlacak, DevirYili, DevirTarihi)
                                VALUES (@CariID, @EskiDevirBakiye, @YeniDevirBakiye, @KalanBakiye, @EskiToplamBorc, @EskiToplamAlacak, @DevirYili, GETDATE())";

                            conn.Execute(sqlArsiv, new
                            {
                                CariID = cariId,
                                EskiDevirBakiye = eskiDevirBakiye,
                                YeniDevirBakiye = yeniDevirBakiye,
                                KalanBakiye = kalanBakiye,
                                EskiToplamBorc = eskiToplamBorc,
                                EskiToplamAlacak = eskiToplamAlacak,
                                DevirYili = hedefYil
                            }, transaction: transaction);

                            islenenSayi++;
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

            return islenenSayi;
        }

        public int DevirGeriAl()
        {
            int geriAlinanSayi = 0;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlCariler = @"
                            SELECT 
                                Id, 
                                ISNULL(AylikUcret, 0) AS AylikUcret,
                                ISNULL(DevirBakiye, 0) AS DevirBakiye,
                                ISNULL(ToplamBorc, 0) AS ToplamBorc,
                                ISNULL(ToplamAlacak, 0) AS ToplamAlacak,
                                ISNULL(Bakiye, 0) AS Bakiye,
                                SonDevirTarihi 
                            FROM Cariler 
                            WHERE SonDevirTarihi IS NOT NULL AND Durum = 1";

                        var cariler = conn.Query<dynamic>(sqlCariler, transaction: transaction).ToList();

                        foreach (var cari in cariler)
                        {
                            string sqlArsiv = @"
                                SELECT TOP 1 
                                    EskiDevirBakiye,
                                    YeniDevirBakiye,
                                    KalanBakiye,
                                    EskiToplamBorc,
                                    EskiToplamAlacak,
                                    DevirYili,
                                    Id AS ArsivID
                                FROM CariDevirArsiv 
                                WHERE CariID = @CariID 
                                ORDER BY Id DESC";

                            var arsiv = conn.QueryFirstOrDefault<dynamic>(sqlArsiv, new { CariID = cari.Id }, transaction: transaction);

                            if (arsiv != null)
                            {
                                decimal eskiDevirBakiye = Convert.ToDecimal(arsiv.EskiDevirBakiye);
                                decimal eskiToplamAlacak = arsiv.EskiToplamAlacak != null ? Convert.ToDecimal(arsiv.EskiToplamAlacak) : 0m;
                                decimal eskiToplamBorc = arsiv.EskiToplamBorc != null && Convert.ToDecimal(arsiv.EskiToplamBorc) > 0
                                    ? Convert.ToDecimal(arsiv.EskiToplamBorc)
                                    : (Convert.ToDecimal(cari.AylikUcret) + eskiDevirBakiye);
                                
                                decimal eskiBakiye = eskiToplamBorc - eskiToplamAlacak;
                                int eskiDonem = Convert.ToInt32(arsiv.DevirYili) - 1;

                                string sqlUpdate = @"
                                    UPDATE Cariler 
                                    SET 
                                        DevirBakiye = @EskiDevirBakiye,
                                        ToplamBorc = @EskiToplamBorc,
                                        ToplamAlacak = @EskiToplamAlacak,
                                        Bakiye = @EskiBakiye,
                                        SonDevirTarihi = NULL,
                                        Donem = @EskiDonem
                                    WHERE Id = @CariID";

                                conn.Execute(sqlUpdate, new
                                {
                                    CariID = cari.Id,
                                    EskiDevirBakiye = eskiDevirBakiye,
                                    EskiToplamBorc = eskiToplamBorc,
                                    EskiToplamAlacak = eskiToplamAlacak,
                                    EskiBakiye = eskiBakiye,
                                    EskiDonem = eskiDonem
                                }, transaction: transaction);

                                string sqlArsivSil = "DELETE FROM CariDevirArsiv WHERE Id = @ArsivID";
                                conn.Execute(sqlArsivSil, new { ArsivID = arsiv.ArsivID }, transaction: transaction);

                                geriAlinanSayi++;
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

            return geriAlinanSayi;
        }

        public bool DevirYapilmisMi()
        {
            const string sql = "SELECT COUNT(*) FROM Cariler WHERE SonDevirTarihi IS NOT NULL AND Durum = 1";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    int count = conn.ExecuteScalar<int>(sql);
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public DateTime? SonDevirTarihiKontrol()
        {
            const string sql = "SELECT MAX(SonDevirTarihi) FROM Cariler WHERE Durum = 1";

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    return conn.QueryFirstOrDefault<DateTime?>(sql);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<decimal> AylikUcretleriGetir(int cariId)
        {
            var sonuc = new List<decimal>();
            
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    string sql = @"
                        SELECT Ucret 
                        FROM CariAylikUcretler 
                        WHERE CariID = @CariID 
                        ORDER BY AyIndex ASC";
                    
                    var list = conn.Query<decimal>(sql, new { CariID = cariId }).ToList();
                    
                    for (int i = 0; i < 12; i++)
                    {
                        if (i < list.Count)
                            sonuc.Add(list[i]);
                        else
                            sonuc.Add(0);
                    }
                }
            }
            catch
            {
                for (int i = 0; i < 12; i++)
                    sonuc.Add(0);
            }
            
            return sonuc;
        }

        public bool AylikUcretleriGuncelle(int cariId, List<AylikUcret> aylikUcretler)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        string sqlDelete = "DELETE FROM CariAylikUcretler WHERE CariID = @CariID";
                        conn.Execute(sqlDelete, new { CariID = cariId }, transaction);
                        
                        string sqlInsert = @"
                            INSERT INTO CariAylikUcretler (CariID, AyIndex, AyAdi, Ucret)
                            VALUES (@CariID, @AyIndex, @AyAdi, @Ucret)";
                        
                        foreach (var item in aylikUcretler)
                        {
                            conn.Execute(sqlInsert, new
                            {
                                CariID = cariId,
                                item.AyIndex,
                                item.AyAdi,
                                item.Ucret
                            }, transaction);
                        }
                        
                        decimal toplam = aylikUcretler.Sum(x => x.Ucret);
                        
                        string sqlUpdate = @"
                            UPDATE Cariler 
                            SET AylikUcret = @Toplam 
                            WHERE Id = @CariID";
                        
                        conn.Execute(sqlUpdate, new { CariID = cariId, Toplam = toplam }, transaction);
                        
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Aylık ücretler güncellenirken hata oluştu: " + ex.Message);
            }
        }
    }
}