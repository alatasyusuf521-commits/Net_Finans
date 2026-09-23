# Proje Dokümantasyonu — Basit Muhasebe & Cari Takip Sistemi

## 1. Problem Tanımı ve Proje Amacı

Ofis ortamında müşteri (cari) kayıtlarının tutulması, her ay düzenli olarak tahakkuk eden muhasebe/hizmet ücretlerinin takibi ve alınan ödemelerin (tahsilatların) eksiksiz işlenmesi gerekmektedir.

Mevcut durumda karmaşık, gereksiz modüller barındıran veya lisans maliyeti yüksek masaüstü yazılımları yerine; **sadece cari hesap yönetimi, aylık borçlandırma ve tahsilat takibine odaklanan**, 4 farklı bilgisayardan eşzamanlı olarak erişilebilen ve anlık **Toplam Borç / Toplam Tahsilat / Genel Bakiye** durumunu raporlayan sade bir otomasyon sistemine ihtiyaç duyulmaktadır.

---

## 2. Kullanılan Teknolojiler ve Mimari

| Katman | Teknoloji |
|---|---|
| Geliştirme Dili | C# (.NET 8, WinForms) |
| Kullanıcı Arayüzü | Windows Forms Application |
| Veritabanı | MS SQL Server Express (ücretsiz, 10 GB limit) |
| Veri Erişim | ADO.NET (ham sorgular) + **Dapper ORM** |
| Bağımlılıklar | `Microsoft.Data.SqlClient`, `Dapper` |
| Mimari | Client–Server (LAN üzerinden ortak SQL Server) |

- **Sunucu Bilgisayar:** SQL Server Express barındırır. TCP/IP port 1433 açık olmalıdır.
- **İstemci Bilgisayarlar (3 adet):** Derlenmiş `.exe` ile `App.config` içindeki bağlantı metni üzerinden sunucuya bağlanır.

---

## 3. Klasör ve Dosya Yapısı

```
MuhasebeOtomasyonu/
|
+-- App.config                       <- SQL baglanti metni (IP, kullanici adi, sifre)
+-- Program.cs                       <- Uygulama giris noktasi
+-- MuhasebeOtomasyonu.csproj        <- Proje yapilandirmasi
+-- database.sql                     <- Tablo & View olusturma SQL scripti
+-- PROJE_REHBERI.md
+-- implementation.md                <- Bu dosya
|
+-- Data/
|   +-- DbHelper.cs                  <- SqlConnection fabrika sinifi
|
+-- Models/
|   +-- Cari.cs                      <- Cari karti; ToplamBorc, ToplamTahsilat, KalanBakiye
|   +-- CariHareket.cs               <- Hareket satiri; Borc, Alacak, YuruyenBakiye
|   +-- CariBakiyeView.cs            <- vw_CariListesiWithBakiye icin DTO
|
+-- Services/
|   +-- CariService.cs               <- Dapper tabanli CRUD + OtomatikCariKoduUret
|   +-- MuhasebeService.cs           <- ADO.NET tabanli bakiye hesaplama, tahsilat, toplu borclandirma
|
+-- Forms/
    +-- FormMain.cs / .Designer.cs         <- Ana ekran; DataGridView + ay filtresi + footer toplamlari
    +-- FormCariEkle.cs / .Designer.cs     <- Yeni/duzenle cari formu
    +-- FormTahsilatGir.cs / .Designer.cs  <- Tahsilat + ek borc ekleme formu
    +-- FormCariEkstre.cs / .Designer.cs   <- Cari bazli hareket ekstresi + yuruyen bakiye
```

---

## 4. Veritabanı Şeması (Gerçek — `database.sql`)

```sql
-- Cariler Tablosu
CREATE TABLE Cariler (
    Id               INT PRIMARY KEY IDENTITY(1,1),
    CariKod          NVARCHAR(50) NOT NULL UNIQUE,   -- Orn: CAR-001
    Unvan            NVARCHAR(150) NOT NULL,
    YetkiliKisi      NVARCHAR(100),
    Telefon          NVARCHAR(20),
    Eposta           NVARCHAR(100),
    Adres            NVARCHAR(MAX),
    AylikUcret       DECIMAL(18,2) DEFAULT 0.00,
    BorclanmaAySayisi INT,                           -- Sonradan eklendi (ALTER TABLE)
    Borc             DECIMAL(18,2) DEFAULT 0.00,     -- Kullanilmiyor
    Alacak           DECIMAL(18,2) DEFAULT 0.00,     -- Kullanilmiyor
    Durum            BIT DEFAULT 1,
    OlusturmaTarihi  DATETIME DEFAULT GETDATE()
);

-- CariHareketler Tablosu
CREATE TABLE CariHareketler (
    Id          INT PRIMARY KEY IDENTITY(1,1),
    CariId      INT NOT NULL,
    IslemTipi   NVARCHAR(30) NOT NULL,  -- 'Borc' veya 'Tahsilat'
    IslemTarihi DATETIME DEFAULT GETDATE(),
    Aciklama    NVARCHAR(250),
    Borc        DECIMAL(18,2) DEFAULT 0.00,
    Alacak      DECIMAL(18,2) DEFAULT 0.00,
    Tutar       DECIMAL(18,2) DEFAULT 0.00,
    FOREIGN KEY (CariId) REFERENCES Cariler(Id) ON DELETE CASCADE
);

-- Bakiye Ozet View
CREATE VIEW vw_CariListesiWithBakiye AS
SELECT
    c.Id AS CariID,
    c.CariKod,
    c.CariKod AS CariKodu,
    c.Unvan, c.Telefon, c.AylikUcret,
    ISNULL(SUM(h.Borc),   0) AS ToplamBorc,
    ISNULL(SUM(h.Alacak), 0) AS ToplamAlacak,
    (ISNULL(SUM(h.Borc), 0) - ISNULL(SUM(h.Alacak), 0)) AS Bakiye
FROM Cariler c
LEFT JOIN CariHareketler h ON c.Id = h.CariId
WHERE c.Durum = 1
GROUP BY c.Id, c.CariKod, c.Unvan, c.Telefon, c.AylikUcret;
```

> **Not:** `BorclanmaAySayisi` kolonu `database.sql` icinde eksik; sonradan `ALTER TABLE` ile eklenmelidir (bkz. Kurulum Adim 2).

---

## 5. Is Mantigi Mimarisi

### 5.1 CariService (Dapper tabanli)

| Metot | Aciklama |
|---|---|
| `Listele()` | `vw_CariListesiWithBakiye` üzerinden tüm aktif carileri getirir |
| `AramaYap(metin)` | Unvan veya CariKod üzerinde `LIKE` araması yapar |
| `GetById(id)` | Tek cari kaydını döner |
| `Ekle(cari)` | `Cariler` tablosuna yeni kayıt ekler |
| `Guncelle(cari)` | Unvan, Telefon, Ücret, AySayisi vb. günceller |
| `PasifeAl(id)` | `Durum = 0` ile cariyi soft-delete eder |
| `OtomatikCariKoduUret()` | En yüksek `CAR-NNN`i çekip +1 artırır |

### 5.2 MuhasebeService (ADO.NET tabanli)

**Bakiye Hesaplama Formülü:**

```
ToplamBorc = (AylikUcret x SecilenAySayisi) + EkBorclar
```

- **EkBorclar:** `TopluBorclandir` tarafından eklenen *otomatik* kayıtlar **hariç**, diğer tüm Borc hareketlerinin toplamı.
- **Otomatik kayıt öneki:** `"Otomatik Aylık Muhasebe Ücreti Borçlandırma"` — bu metinle başlayan Borc kayıtları çift sayımı önlemek için hariç tutulur.

| Metot | Aciklama |
|---|---|
| `CariHesaplariniGetir(aySayisi)` | Seçili ay sayısına göre tüm carilerin borç/tahsilat özetini hesaplar |
| `CariEkstreGetir(cariId, aySayisi)` | Sentetik aylık borç satırları + gerçek DB hareketleri birleşik ekstre |
| `TopluBorclandir()` | Tüm aktif cari için `AylikUcret` tutarında Borc hareketi ekler |
| `BorcEkle(cariId, tutar, aciklama, kullanici)` | Manuel ekstra borç ekler |
| `TahsilatEkle(cariId, tutar, aciklama, kullanici)` | Tahsilat (ödeme) kaydı ekler |

### 5.3 Cift Sayim Onleme Tasarimi

`TopluBorclandir()` DB ye kayit yazarken, `CariHesaplariniGetir()` bu otomatik kayitlari `NOT LIKE @OtomatikOnek` filtresiyle dislar. Ayni filtre `CariEkstreGetir()` icinde de uygulanir. Bu sayede ayni ay borcu iki kez sayilmaz.

---

## 6. Ekranlar ve Islevler

### FormMain — Ana Ekran

- **Sol panel (yan menu):** Cari Kartlar / Muhasebe modulleri arasinda gecis
- **Ay Filtresi (CheckedListBox):** 12 ay listelenir; isaretlen ay adedi = SecilenAySayisi
- **DataGridView kolonlari:** Cari Kodu, Unvan, Telefon, Aylik Ucret, Toplam Borc (kirmizi), Toplam Tahsilat (yesil), Bakiye (kalin)
- **Footer Paneli:** Toplam Borc / Toplam Tahsilat / Genel Bakiye (bakiye > 0 ise kirmizi, 0 veya eksi ise yesil arka plan)
- **Hizli Arama:** Unvan, Cari Kodu veya Telefon uzerinde anlik filtreleme
- **Butonlar:** Yeni Cari, Tahsilat Gir, Ekstre, Yenile, Toplu Borclandir, Cikis

### FormCariEkle — Cari Ekle / Duzenle

- Yeni cari: Cari Kodu otomatik uretilir (CAR-001, CAR-002 ...)
- Duzenleme modu: `cariId > 0` ile acilir, mevcut veriler doldurulur
- Alanlar: Cari Kodu, Unvan, Yetkili Kisi, Telefon, E-posta, Adres, Aylik Ucret, Borclanma Ay Sayisi
- Kayit basarili olursa `DialogResult.OK` donerFormMain listeyi yeniler

### FormTahsilatGir — Tahsilat / Borc Ekleme

- ComboBox ile aktif cari secimi
- Islem tipi: Tahsilat veya Ek Borc
- Tutar, Aciklama, Giren Kullanici adi alanlari
- Kullanici adi aciklamaya eklenir: "... (Giren: AdSoyad)"

### FormCariEkstre — Cari Hareket Ekstresi

- Secilen cari icin birlesik ekstre (sentetik aylik borc + gercek DB hareketleri)
- Tarih sirali, yuruyen bakiyeli liste
- Yazdirma / PDF cikti destegi (gelistirme surecinde)

---

## 7. Uygulama Akisi

```
Program.cs
  +-- Application.Run(new FormMain())
        +-- FormMain_Load
              +-- AylariYukle()         <- CheckedListBox doldurulur, mevcut ay isaretlenir
              +-- ListeyiYukle(aySayisi)
                    +-- MuhasebeService.CariHesaplariniGetir(aySayisi)
                          +-- DataGridGuncelle() -> AltToplamlariGuncelle()
```

---

## 8. Baglanti Yapilandirmasi (App.config)

```xml
<connectionStrings>
  <add name="MuhasebeDB"
       connectionString="Server=SUNUCU_IP\SQLEXPRESS;Database=MuhasebeDB;
                         User Id=KULLANICI;Password=SIFRE;
                         TrustServerCertificate=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

`DbHelper.GetConnection()` bu connection stringi okur ve `SqlConnection` nesnesi doner.

---

## 9. Kurulum ve Dagitim Adimlari

### Adim 1 — SQL Server Kurulumu (Sunucu Bilgisayar)
1. MS SQL Server Express kur (ucretsiz).
2. SQL Server Configuration Manager uzerinden TCP/IP protokolunu etkinlestir.
3. Windows Guvenlik Duvari inda 1433 portuna gelen TCP baglantisina izin ver.
4. `database.sql` scriptini SSMS ile calistir — `MuhasebeDB` veritabani olusur.

### Adim 2 — BorclanmaAySayisi Kolonunu Ekle
```sql
-- database.sql de eksik olan bu kolon, tek seferlik manuel calistirilmalidir:
ALTER TABLE Cariler ADD BorclanmaAySayisi INT DEFAULT 1;
```

### Adim 3 — Projeyi Derle
```powershell
dotnet build -c Release
```

### Adim 4 — Istemci Bilgisayarlara Dagit
1. `bin\Release\net8.0-windows\` klasorunu diger 3 bilgisayara kopyala.
2. Her bilgisayardaki `App.config` icindeki `Server=` kismini sunucu IP si ile guncelle.
3. .NET 8 Desktop Runtime yuklu oldugunden emin ol.

---

## 10. Bilinen Sorunlar ve Cozumleri

| Sorun | Sebep | Cozum |
|---|---|---|
| `Invalid column name CariKodu` | Tabloda kolon adi `CariKod`, C# model `CariKodu` bekliyordu | View a `CariKod AS CariKodu` alias eklendi |
| `BorclanmaAySayisi` kolonu bulunamiyor | `database.sql` de bu kolon tanimli degil | `ALTER TABLE Cariler ADD BorclanmaAySayisi INT DEFAULT 1;` calistir |
| Toplu borclandirma sonrasi borc iki katina cikiyor | `GetEkstraBorclar` otomatik kayitlari da sayiyordu | `NOT LIKE Otomatik Aylik%` filtresi eklendi |
| Yeni cari kodu her seferinde CAR-001 uretiyor | `CariKodu` kolonu yoktu, sorgu hata verip catch e dusuyordu | `CariKod` ile duzeltildi |

---

## 11. Gelistirme Yol Haritasi

- [ ] `database.sql` scriptine `BorclanmaAySayisi` kolonunun eklenmesi
- [ ] Toplu borclandirma oncesi "bu ay zaten borclandirildi mi?" kontrolu
- [ ] Ekstre ekraninda yazdirma / PDF export
- [ ] Pasif carileri ayri sekmede goruntuleme
- [ ] Kullanici girisi ve yetki sistemi (opsiyonel)
- [ ] Otomatik veritabani yedekleme
