namespace MuhasebeOtomasyonu.Models
{
    public class AylikUcret
    {
        public int AyIndex { get; set; }
        public string AyAdi { get; set; } = string.Empty;
        public decimal Ucret { get; set; }
    }
}