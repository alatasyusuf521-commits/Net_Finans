namespace MuhasebeOtomasyonu.Models
{
    public class CariBakiyeView
    {
        public int CariID { get; set; }
        public string CariKodu { get; set; } = string.Empty;
        public string Unvan { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public decimal AylikUcret { get; set; }
        public int BorclanmaAySayisi { get; set; }
        public decimal DevirBakiye { get; set; }
        public decimal ToplamBorc { get; set; }
        public decimal ToplamAlacak { get; set; }
        public decimal Bakiye { get; set; }
    }
}