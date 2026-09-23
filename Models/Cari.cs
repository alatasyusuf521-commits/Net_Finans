using System;

namespace MuhasebeOtomasyonu.Models
{
    public class Cari
    {
        public int CariID { get; set; }
        public string CariKodu { get; set; } = string.Empty;
        public string Unvan { get; set; } = string.Empty;
        public string? YetkiliKisi { get; set; }
        public string? Telefon { get; set; }
        public string? Eposta { get; set; }
        public string? Adres { get; set; }
        public decimal AylikUcret { get; set; }
        public int BorclanmaAySayisi { get; set; } = 1;
        public decimal DevirBakiye { get; set; } = 0.00m;
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public bool Durum { get; set; } = true;
        public DateTime? SilinmeTarihi { get; set; }
        public decimal ToplamBorc { get; set; }
        public decimal ToplamTahsilat { get; set; }
        public decimal KalanBakiye => ToplamBorc - ToplamTahsilat;

        public void ToplamBorcHesapla()
        {
            if (AylikUcret < 0)
                throw new InvalidOperationException("Aylık ücret negatif olamaz.");
            if (BorclanmaAySayisi < 0)
                throw new InvalidOperationException("Borçlanma ay sayısı negatif olamaz.");

            ToplamBorc = AylikUcret * BorclanmaAySayisi;
        }

        public override string ToString()
        {
            return Unvan;
        }
    }
}