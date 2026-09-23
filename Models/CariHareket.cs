using System;

namespace MuhasebeOtomasyonu.Models
{
    public class CariHareket
    {
        public int HareketID { get; set; }
        public int CariID { get; set; }
        public DateTime IslemTarihi { get; set; } = DateTime.Now;
        public string IslemTuru { get; set; } = string.Empty;
        public string IslemTipi { get; set; } = string.Empty;
        public string? Aciklama { get; set; }
        public decimal Borc { get; set; }
        public decimal Alacak { get; set; }
        public string? KaydedenKullanici { get; set; }
        public string? CariUnvan { get; set; }
        public decimal YuruyenBakiye { get; set; }
    }
}