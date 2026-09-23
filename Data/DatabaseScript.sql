-- Muhasebe ve Cari Takip Otomasyonu - SQL Server Kurulum Scripti

-- 1. VERİTABANI OLUŞTURMA (Var değilse oluşturur)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MuhasebeDB')
BEGIN
    CREATE DATABASE MuhasebeDB;
END
GO

USE MuhasebeDB;
GO

-- 2. CARİ KARTLARI TABLOSU
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cariler]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cariler (
        CariID INT PRIMARY KEY IDENTITY(1,1),
        CariKodu VARCHAR(20) UNIQUE NOT NULL,
        Unvan NVARCHAR(150) NOT NULL,
        YetkiliKisi NVARCHAR(100),
        Telefon VARCHAR(20),
        Eposta VARCHAR(100),
        Adres NVARCHAR(250),
        AylikUcret DECIMAL(18,2) DEFAULT 0.00,
        KayitTarihi DATETIME DEFAULT GETDATE(),
        Durum BIT DEFAULT 1
    );
END
GO

-- 3. CARİ HAREKETLERİ TABLOSU
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CariHareketler]') AND type in (N'U'))
BEGIN
    CREATE TABLE CariHareketler (
        HareketID INT PRIMARY KEY IDENTITY(1,1),
        CariID INT FOREIGN KEY REFERENCES Cariler(CariID) ON DELETE CASCADE,
        IslemTarihi DATETIME DEFAULT GETDATE(),
        IslemTuru NVARCHAR(30) NOT NULL, -- 'Aylık Ücret Borcu', 'Tahsilat', 'Düzeltme'
        Aciklama NVARCHAR(250),
        Borc DECIMAL(18,2) DEFAULT 0.00,
        Alacak DECIMAL(18,2) DEFAULT 0.00,
        KaydedenKullanici NVARCHAR(50)
    );
END
GO

-- 4. CARİ LİSTE VE GENEL TOPLAMLAR İÇİN VIEW
IF OBJECT_ID('vw_CariListesiWithBakiye', 'V') IS NOT NULL
    DROP VIEW vw_CariListesiWithBakiye;
GO

CREATE VIEW vw_CariListesiWithBakiye AS
SELECT 
    c.CariID,
    c.CariKodu,
    c.Unvan,
    c.Telefon,
    c.AylikUcret,
    ISNULL(SUM(h.Borc), 0) AS ToplamBorc,
    ISNULL(SUM(h.Alacak), 0) AS ToplamAlacak,
    (ISNULL(SUM(h.Borc), 0) - ISNULL(SUM(h.Alacak), 0)) AS Bakiye
FROM Cariler c
LEFT JOIN CariHareketler h ON c.CariID = h.CariID
WHERE c.Durum = 1
GROUP BY c.CariID, c.CariKodu, c.Unvan, c.Telefon, c.AylikUcret;
GO

-- 5. ÖRNEK DEMO VERİLERİ (İsteğe bağlı test verileri)
IF NOT EXISTS (SELECT * FROM Cariler)
BEGIN
    INSERT INTO Cariler (CariKodu, Unvan, YetkiliKisi, Telefon, Eposta, Adres, AylikUcret)
    VALUES 
    ('CAR-001', N'ABC Teknoloji Ltd. Şti.', N'Ahmet Yılmaz', '0532 111 22 33', 'info@abcteknoloji.com', N'Kadıköy / İstanbul', 2500.00),
    ('CAR-002', N'XYZ Mimarlık A.Ş.', N'Ayşe Kaya', '0544 999 88 77', 'contact@xyzmimarlik.com', N'Çankaya / Ankara', 3500.00),
    ('CAR-003', N'Yılmaz Lojistik ve Ticaret', N'Mehmet Yılmaz', '0555 444 33 22', 'mehmet@yilmazlojistik.com', N'Nilüfer / Bursa', 2000.00);

    -- İlk Ay Borçlandırmaları
    INSERT INTO CariHareketler (CariID, IslemTuru, Aciklama, Borc, Alacak, KaydedenKullanici)
    VALUES 
    (1, N'Aylık Ücret Borcu', N'Ağustos 2026 Muhasebe Hizmet Bedeli', 2500.00, 0.00, N'Sistem'),
    (2, N'Aylık Ücret Borcu', N'Ağustos 2026 Muhasebe Hizmet Bedeli', 3500.00, 0.00, N'Sistem'),
    (3, N'Aylık Ücret Borcu', N'Ağustos 2026 Muhasebe Hizmet Bedeli', 2000.00, 0.00, N'Sistem');

    -- Örnek Tahsilat
    INSERT INTO CariHareketler (CariID, IslemTuru, Aciklama, Borc, Alacak, KaydedenKullanici)
    VALUES 
    (1, N'Tahsilat', N'Banka Havalesi ile Ödeme Alındı', 0.00, 2500.00, N'Ahmet');
END
GO
