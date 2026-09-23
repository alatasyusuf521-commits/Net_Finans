# Proje Rehberi ve Kurulum Dokümanı — Muhasebe & Cari Takip Otomasyonu

## 📌 Proje Genel Bilgileri
Bu proje; ofis ortamında müşteri (cari) kayıtlarının tutulması, her ay düzenli olarak tahakkuk eden muhasebe/hizmet ücretlerinin takibi ve alınan ödemelerin (tahsilatların) eksiksiz işlenmesi amacıyla **C# WinForms** ve **MS SQL Server Express** mimarisinde geliştirilmiştir.

---

## 🛠️ Klasör ve Dosya Yapısı

```text
MuhasebeOtomasyonu/
│
├── App.config                       <-- SQL Connection String (IP & Şifre ayarları)
├── Program.cs                       <-- Uygulama Giriş Noktası
├── MuhasebeOtomasyonu.csproj        <-- C# .NET 8 WinForms Proje Yapılandırması
├── implementation.md                <-- Proje Gereksinim Dokümanı
├── PROJE_REHBERI.md                 <-- Bu Kurulum ve Kullanım Rehberi
│
├── Data/                            <-- Veritabanı & SQL Katmanı
│   ├── DbHelper.cs                  <-- SQL Server Bağlantı Yönetimi
│   └── DatabaseScript.sql           <-- Tablo ve View Oluşturma SQL Scripti
│
├── Models/                          <-- Veri Modelleri (POCO)
│   ├── Cari.cs                      <-- Cari Kartı Modeli
│   ├── CariHareket.cs               <-- Borç / Alacak Hareket Modeli
│   └── CariBakiyeView.cs            <-- DataGridView ve Özet Liste Modeli
│
├── Forms/                           <-- WinForms Arayüz Ekranları
│   ├── FormMain.cs & Designer       <-- Ana Ekran (DataGridView + Alt Toplam Kutuları)
│   ├── FormCariEkle.cs & Designer   <-- Yeni Cari / Müşteri Ekleme Ekranı
│   ├── FormTahsilatGir.cs & Designer<-- Ödeme / Tahsilat Alımı Ekranı
│   └── FormCariEkstre.cs & Designer <-- Geçmiş Hareket Dökümü ve Yazdırma Ekranı
│
└── Services/                        <-- İş Mantığı & SQL Sorgu Katmanı
    ├── CariService.cs               <-- Cari Ekleme, Arama, Güncelleme, Pasife Alma
    └── MuhasebeService.cs           <-- Tahsilat Ekleme, Toplu Borçlandırma, Ekstre
```

---

## 💻 Sunucu (Server) ve SQL Server Express Kurulum Adımları

1. **SQL Server Express Kurulumu:**
   * Ana bilgisayara **MS SQL Server Express** kurulumunu tamamlayın.
   * `SQL Server Management Studio (SSMS)` veya VS Code SQL Eklentisi ile sunucuya bağlanın.
   * Proje içerisindeki `Data/DatabaseScript.sql` dosyasını çalıştırarak `MuhasebeDB` veritabanını, `Cariler`, `CariHareketler` tablolarını ve `vw_CariListesiWithBakiye` view'ını oluşturun.

2. **Çoklu Kullanıcı (LAN Ağ Bağlantısı) Ayarları:**
   * **SQL Server Configuration Manager** uygulamasını açın.
   * `SQL Server Network Configuration` -> `Protocols for SQLEXPRESS` seçeneğinden **TCP/IP** protokolünü **Enabled (Etkin)** duruma getirin.
   * TCP/IP Özelliklerinde `IP Addresses` sekmesine gelin ve `IPAll` bölümündeki `TCP Port` değerini **1433** olarak ayarlayın.
   * SQL Server servisini yeniden başlatın (`SQL Server Services` -> `Restart`).

3. **Windows Güvenlik Duvarı İzni:**
   * Denetim Masası -> Windows Güvenlik Duvarı -> Gelişmiş Ayarlar.
   * **Gelen Kuralları (Inbound Rules)** -> **Yeni Kural (New Rule)** -> **Port**.
   * `TCP` ve `1433` port numarasını girip bağlantıya izin verin (`Allow the connection`).

---

## 🖥️ İstemci Bilgisayarlar (3 Adet) İçin Konfigürasyon

1. **`App.config` Düzenlemesi:**
   İstemci bilgisayarlardaki `App.config` dosyasındaki `connectionString` alanına **Sunucu Bilgisayarın Yerel IP Adresini** yazın:
   ```xml
   <connectionStrings>
     <add name="MuhasebeDB" 
          connectionString="Server=192.168.1.100;Database=MuhasebeDB;User Id=sa;Password=SunucuSifreniz;TrustServerCertificate=True;Encrypt=False;" 
          providerName="Microsoft.Data.SqlClient" />
   </connectionStrings>
   ```

2. Projenin derlenmiş çıktısını (`bin/Release/net8.0-windows/`) veya `.exe` dosyasını istemci bilgisayarlara kopyalayın.

---

## 🚀 Öne Çıkan Özellikler ve Kullanım Mantığı

### 1. Ana Ekran ve Alt Özet Kutuları (Footer)
- DataGridView üzerinde tüm carilerin **Aylık Ücreti, Toplam Borcu, Toplam Alacağı ve Net Kalan Bakiyesi** anlık görüntülenir.
- Ekranın en altında bulunan dinamik kartlarda:
  - **Toplam Borç (TL)**
  - **Toplam Alacak (TL)**
  - **Net Kalan Genel Bakiye (TL)**
  değerleri anlık olarak `SUM` hesaplamalarıyla güncellenir.

### 2. Toplu Ay Başı Borçlandırma
- **`⚡ Toplu Borçlandır`** butonuna basıldığında, sistemdeki tüm aktif cariler tek tıkla otomatik olarak döngüye alınır ve anlaşılan `AylikUcret` tutarı kadar borç kaydı (`Aylık Ücret Borcu`) işlenir.

### 3. Tahsilat Girme
- **`💵 Tahsilat Gir`** butonuna basılarak müşteriden alınan nakit/havale ödemesi girilir ve cari hesabına `Alacak` kaydı olarak yansıtılır.

### 4. Cari Ekstre & Raporlama
- Seçilen cari için **`📄 Cari Ekstre`** butonuna basılarak yürüyen bakiye detayları görüntülenir ve **`🖨️ Yazdır / Rapor`** butonu ile çıktı/önizleme alınabilir.
