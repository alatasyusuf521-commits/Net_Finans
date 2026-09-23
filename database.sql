USE master;
GO

-- Eğer veritabanı varsa bağlantıları kesip sil
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'MuhasebeDB')
BEGIN
    ALTER DATABASE MuhasebeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MuhasebeDB;
END
GO

CREATE DATABASE MuhasebeDB;
GO

USE MuhasebeDB;
GO

-- Cariler Tablosu
CREATE TABLE Cariler (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CariKod NVARCHAR(50) NOT NULL UNIQUE,
    Unvan NVARCHAR(150) NOT NULL,
    YetkiliKisi NVARCHAR(100),
    Telefon NVARCHAR(20),
    Eposta NVARCHAR(100),
    Adres NVARCHAR(MAX),
    AylikUcret DECIMAL(18,2) DEFAULT 0.00,
    BorclanmaAySayisi INT DEFAULT 1,
    DevirBakiye DECIMAL(18,2) DEFAULT 0.00,
    ToplamBorc DECIMAL(18,2) DEFAULT 0.00,
    ToplamAlacak DECIMAL(18,2) DEFAULT 0.00,
    Bakiye DECIMAL(18,2) DEFAULT 0.00,
    Durum BIT DEFAULT 1,
    OlusturmaTarihi DATETIME DEFAULT GETDATE(),
    Donem INT DEFAULT 2026,
    SonDevirTarihi DATETIME NULL
);
GO

-- Cari Hareketler Tablosu
CREATE TABLE CariHareketler (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CariId INT NOT NULL,
    IslemTipi NVARCHAR(30) NOT NULL,
    IslemTarihi DATETIME DEFAULT GETDATE(),
    Aciklama NVARCHAR(250),
    Borc DECIMAL(18,2) DEFAULT 0.00,
    Alacak DECIMAL(18,2) DEFAULT 0.00,
    Tutar DECIMAL(18,2) DEFAULT 0.00,
    KaydedenKullanici NVARCHAR(50),
    FOREIGN KEY (CariId) REFERENCES Cariler(Id) ON DELETE CASCADE
);
GO

-- Cari Aylık Ücretler Tablosu
CREATE TABLE CariAylikUcretler (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CariID INT NOT NULL,
    AyIndex INT NOT NULL,
    AyAdi NVARCHAR(20) NOT NULL,
    Ucret DECIMAL(18,2) DEFAULT 0.00,
    FOREIGN KEY (CariID) REFERENCES Cariler(Id) ON DELETE CASCADE
);
GO

-- Cari Devir Arşiv Tablosu
CREATE TABLE CariDevirArsiv (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CariID INT NOT NULL,
    EskiDevirBakiye DECIMAL(18,2) DEFAULT 0.00,
    YeniDevirBakiye DECIMAL(18,2) DEFAULT 0.00,
    KalanBakiye DECIMAL(18,2) DEFAULT 0.00,
    EskiToplamBorc DECIMAL(18,2) DEFAULT 0.00,
    EskiToplamAlacak DECIMAL(18,2) DEFAULT 0.00,
    DevirYili INT NOT NULL,
    DevirTarihi DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CariID) REFERENCES Cariler(Id) ON DELETE CASCADE
);
GO

-- Bakiye View
CREATE VIEW vw_CariListesiWithBakiye AS
SELECT 
    c.Id,
    c.Id AS CariID,
    c.CariKod,
    c.CariKod AS CariKodu,
    c.Unvan,
    c.Telefon,
    c.AylikUcret,
    ISNULL(SUM(h.Borc), 0) AS ToplamBorc,
    ISNULL(SUM(h.Alacak), 0) AS ToplamAlacak,
    (ISNULL(SUM(h.Borc), 0) - ISNULL(SUM(h.Alacak), 0)) AS Bakiye
FROM Cariler c
LEFT JOIN CariHareketler h ON c.Id = h.CariId
WHERE c.Durum = 1
GROUP BY c.Id, c.CariKod, c.Unvan, c.Telefon, c.AylikUcret;
GO