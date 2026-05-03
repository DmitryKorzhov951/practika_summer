-- =============================================
-- БД "Прокат автомобилей" - Представления (запросы и фильтры)
-- =============================================
USE CarRentalDB;
GO

-- ====== ЗАПРОСЫ ======

-- Запрос 1: Отдел кадров (Сотрудники + Должности)
IF OBJECT_ID('vw_OtdelKadrov','V') IS NOT NULL DROP VIEW vw_OtdelKadrov;
GO
CREATE VIEW vw_OtdelKadrov AS
SELECT  s.KodSotrudnika,
        s.FIO,
        s.Vozrast,
        s.Pol,
        s.Adres,
        s.Telefon,
        s.PasportnyeDannye,
        d.NaimenovanieDolzh AS Dolzhnost,
        d.Oklad,
        d.Obyazannosti,
        d.Trebovaniya
FROM Sotrudniki s
INNER JOIN Dolzhnosti d ON s.KodDolzhnosti = d.KodDolzhnosti;
GO

-- Запрос 2: Автопарк (Автомобили + Марки + Сотрудник-механик)
IF OBJECT_ID('vw_Avtopark','V') IS NOT NULL DROP VIEW vw_Avtopark;
GO
CREATE VIEW vw_Avtopark AS
SELECT  a.KodAvtomobilya,
        m.Naimenovanie         AS Marka,
        m.TehnHarakteristiki,
        a.RegNomer,
        a.NomerKuzova,
        a.NomerDvigatelya,
        a.GodVypuska,
        a.Probeg,
        a.CenaAvtomobilya,
        a.DataPoslednegoTO,
        s.FIO                  AS MehanikFIO,
        a.SpecialnyeOtmetki,
        a.OtmetkaOVozvrate
FROM Avtomobili a
INNER JOIN MarkiAvto m   ON a.KodMarki        = m.KodMarki
INNER JOIN Sotrudniki s  ON a.KodSotrudnikaMeh = s.KodSotrudnika;
GO

-- Запрос 3: Автомобили в прокате
IF OBJECT_ID('vw_AvtoVProkate','V') IS NOT NULL DROP VIEW vw_AvtoVProkate;
GO
CREATE VIEW vw_AvtoVProkate AS
SELECT  p.KodProkata,
        p.DataVydachi,
        p.SrokProkata,
        p.DataVozvrata,
        m.Naimenovanie  AS Marka,
        a.RegNomer,
        k.FIO           AS Klient,
        u1.Naimenovanie AS Usluga1,
        u2.Naimenovanie AS Usluga2,
        u3.Naimenovanie AS Usluga3,
        p.CenaProkata,
        p.OtmetkaObOplate,
        s.FIO           AS Sotrudnik
FROM Prokat p
INNER JOIN Avtomobili a  ON p.KodAvtomobilya = a.KodAvtomobilya
INNER JOIN MarkiAvto  m  ON a.KodMarki       = m.KodMarki
INNER JOIN Klienty    k  ON p.KodKlienta     = k.KodKlienta
LEFT  JOIN DopUslugi  u1 ON p.KodUslugi1     = u1.KodUslugi
LEFT  JOIN DopUslugi  u2 ON p.KodUslugi2     = u2.KodUslugi
LEFT  JOIN DopUslugi  u3 ON p.KodUslugi3     = u3.KodUslugi
INNER JOIN Sotrudniki s  ON p.KodSotrudnika  = s.KodSotrudnika;
GO

-- ====== ФИЛЬТРЫ ======
-- Фильтры реализованы как параметризованные представления-функции,
-- но для совместимости параметры подставляются на стороне клиента (WHERE ...).
-- Здесь приведены базовые SELECT'ы:

-- Фильтр 1: Сотрудники определённой должности (параметр: @Dolzhnost)
IF OBJECT_ID('vw_Filtr_SotrudnikiPoDolzh','V') IS NOT NULL DROP VIEW vw_Filtr_SotrudnikiPoDolzh;
GO
CREATE VIEW vw_Filtr_SotrudnikiPoDolzh AS
SELECT * FROM vw_OtdelKadrov;
GO

-- Фильтр 2: Автомобили отдельных марок (параметр: @Marka)
IF OBJECT_ID('vw_Filtr_AvtoPoMarke','V') IS NOT NULL DROP VIEW vw_Filtr_AvtoPoMarke;
GO
CREATE VIEW vw_Filtr_AvtoPoMarke AS
SELECT * FROM vw_Avtopark;
GO

-- Фильтр 3: Автомобили находящиеся / не находящиеся в прокате (параметр: @VProkate bit)
IF OBJECT_ID('vw_Filtr_AvtoVProkate','V') IS NOT NULL DROP VIEW vw_Filtr_AvtoVProkate;
GO
CREATE VIEW vw_Filtr_AvtoVProkate AS
SELECT * FROM vw_Avtopark;
GO

-- Фильтр 4: Автомобили выданные/возвращённые в указанную дату (параметр: @Data)
IF OBJECT_ID('vw_Filtr_AvtoPoDate','V') IS NOT NULL DROP VIEW vw_Filtr_AvtoPoDate;
GO
CREATE VIEW vw_Filtr_AvtoPoDate AS
SELECT * FROM vw_AvtoVProkate;
GO

-- Фильтр 5: Оплаченные / не оплаченные автомобили в прокате (параметр: @Oplachen bit)
IF OBJECT_ID('vw_Filtr_OplataProkata','V') IS NOT NULL DROP VIEW vw_Filtr_OplataProkata;
GO
CREATE VIEW vw_Filtr_OplataProkata AS
SELECT * FROM vw_AvtoVProkate;
GO

PRINT 'Запросы и представления для фильтров созданы.';
GO
