using System;

namespace MuhasebeOtomasyonu.Models
{
    public class CariCopKutusuView
    {
        public int CariID { get; set; }
        public string CariKodu { get; set; } = string.Empty;
        public string Unvan { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public decimal AylikUcret { get; set; }
        public decimal DevirBakiye { get; set; }
        public decimal ToplamBorc { get; set; }
        public decimal ToplamAlacak { get; set; }
        public decimal Bakiye { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
        public int Donem { get; set; }

        public string SilinmeTarihiFormatli => SilinmeTarihi?.ToString("dd.MM.yyyy HH:mm") ?? "-";

        public int KalanGun
        {
            get
            {
                if (!SilinmeTarihi.HasValue) return 30;
                var gecenGun = (DateTime.Now - SilinmeTarihi.Value).Days;
                var kalan = 30 - gecenGun;
                return kalan < 0 ? 0 : kalan;
            }
        }

        public string KalanSureFormatli => $"{KalanGun} Gün Kaldı";
    }
}
