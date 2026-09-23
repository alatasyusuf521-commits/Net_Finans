USE MuhasebeDB;
GO

-- ============================================
-- 1. CAR-004'ün mevcut durumunu kontrol et
-- ============================================
SELECT 
    Id,
    CariKod,
    Unvan,
    AylikUcret,
    DevirBakiye,
    ToplamBorc,
    ToplamAlacak,
    Bakiye
FROM Cariler 
WHERE Id = 4;
GO

-- ============================================
-- 2. CAR-004 için Toplam Borç ve Bakiye'yi düzelt
-- (DOĞRU FORMÜL: ToplamBorc = AylikUcret + DevirBakiye, çarpan yok)
-- ============================================
UPDATE Cariler 
SET 
    ToplamBorc = AylikUcret + DevirBakiye,
    Bakiye = (AylikUcret + DevirBakiye) - ToplamAlacak
WHERE Id = 4;
GO

-- ============================================
-- 3. CAR-004'ün güncel durumunu kontrol et
-- ============================================
SELECT 
    Id,
    CariKod,
    Unvan,
    AylikUcret,
    DevirBakiye,
    ToplamBorc AS [Toplam Borç],
    ToplamAlacak AS [Toplam Tahsilat],
    Bakiye,
    CASE 
        WHEN ToplamBorc = AylikUcret + DevirBakiye THEN '✅ DOGRU'
        ELSE '❌ HATALI'
    END AS Kontrol
FROM Cariler 
WHERE Id = 4;
GO

-- ============================================
-- 4. CAR-004 için aylık ücretleri kontrol et
-- ============================================
SELECT 
    CariID,
    AyIndex,
    AyAdi,
    Ucret
FROM CariAylikUcretler 
WHERE CariID = 4 
ORDER BY AyIndex ASC;
GO

-- ============================================
-- 5. CAR-004 için aylık toplam kontrol
-- ============================================
SELECT 
    CariID,
    SUM(Ucret) AS AylikToplam
FROM CariAylikUcretler 
WHERE CariID = 4 
GROUP BY CariID;
GO

-- ============================================
-- 6. TÜM CARİLERİ kontrol et (CAR-002, CAR-003, CAR-004)
-- ============================================
SELECT 
    Id,
    CariKod,
    Unvan,
    AylikUcret,
    DevirBakiye,
    ToplamBorc AS [Toplam Borç],
    ToplamAlacak AS [Toplam Tahsilat],
    Bakiye,
    CASE 
        WHEN ToplamBorc = AylikUcret + DevirBakiye THEN '✅ DOGRU'
        ELSE '❌ HATALI'
    END AS Kontrol
FROM Cariler 
WHERE Id IN (2, 3, 4)
ORDER BY Id ASC;
GO

-- ============================================
-- 7. Yıllık Ücret Kontrolü (Tüm cariler)
-- ============================================
SELECT 
    c.CariKod,
    c.Unvan,
    c.AylikUcret AS [Yillik Ucret (Cariler)],
    SUM(a.Ucret) AS [Aylik Toplam],
    CASE 
        WHEN c.AylikUcret = SUM(a.Ucret) THEN '✅ ESLESIYOR'
        ELSE '❌ ESLESMIYOR'
    END AS Kontrol
FROM Cariler c
INNER JOIN CariAylikUcretler a ON c.Id = a.CariID
WHERE c.Id IN (2, 3, 4)
GROUP BY c.CariKod, c.Unvan, c.AylikUcret
ORDER BY c.CariKod ASC;
GO

-- ============================================
-- 8. Özet bilgi
-- ============================================
SELECT 
    Donem,
    COUNT(*) AS CariSayisi,
    SUM(ToplamBorc) AS ToplamBorc,
    SUM(ToplamAlacak) AS ToplamTahsilat,
    SUM(Bakiye) AS ToplamBakiye
FROM Cariler
WHERE Id IN (2, 3, 4)
GROUP BY Donem
ORDER BY Donem ASC;
GO

-- ============================================
-- 9. CAR-004 Özel Kontrol
-- ============================================
SELECT 
    'CAR-004 KONTROL' AS Mesaj,
    AylikUcret AS [Yillik Ucret],
    DevirBakiye AS [Devir Bakiye],
    ToplamBorc AS [Toplam Borc],
    ToplamAlacak AS [Toplam Tahsilat],
    Bakiye AS [Bakiye],
    CASE 
        WHEN ToplamBorc = AylikUcret + DevirBakiye THEN '✅ ToplamBorc DOGRU'
        ELSE '❌ ToplamBorc HATALI'
    END AS Kontrol
FROM Cariler 
WHERE Id = 4;
GO

-- ============================================
-- 10. CAR-002 Özel Kontrol (Doğrulama)
-- ============================================
SELECT 
    'CAR-002 KONTROL' AS Mesaj,
    AylikUcret AS [Yillik Ucret],
    DevirBakiye AS [Devir Bakiye],
    ToplamBorc AS [Toplam Borc],
    ToplamAlacak AS [Toplam Tahsilat],
    Bakiye AS [Bakiye],
    CASE 
        WHEN ToplamBorc = AylikUcret + DevirBakiye THEN '✅ ToplamBorc DOGRU'
        ELSE '❌ ToplamBorc HATALI'
    END AS Kontrol
FROM Cariler 
WHERE Id = 2;
GO

-- ============================================
-- 11. Tüm carilerin son durumu (Özet)
-- ============================================
SELECT 
    'TÜM CARİLER ÖZET' AS Bilgi,
    COUNT(*) AS ToplamCari,
    SUM(ToplamBorc) AS GenelToplamBorc,
    SUM(ToplamAlacak) AS GenelToplamTahsilat,
    SUM(Bakiye) AS GenelToplamBakiye
FROM Cariler
WHERE Id IN (2, 3, 4);
GO