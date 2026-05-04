-- БД "Прокат автомобилей" - минимальная версия

IF DB_ID('CarRentalDB') IS NOT NULL
BEGIN
    ALTER DATABASE CarRentalDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CarRentalDB;
END
GO
CREATE DATABASE CarRentalDB;
GO
USE CarRentalDB;
GO

-- ----- Клиенты -----
CREATE TABLE Klienty (
    KodKlienta INT IDENTITY(1,1) PRIMARY KEY,
    FIO        NVARCHAR(150) NOT NULL,
    Telefon    NVARCHAR(20)  NOT NULL,
    Pasport    NVARCHAR(50)  NOT NULL
);

-- ----- Автомобили -----
CREATE TABLE Avtomobili (
    KodAvto    INT IDENTITY(1,1) PRIMARY KEY,
    Marka      NVARCHAR(100) NOT NULL,
    RegNomer   NVARCHAR(20)  NOT NULL,
    Cena       MONEY         NOT NULL,   -- цена за день
    Svoboden   BIT           NOT NULL DEFAULT 1
);

-- ----- Прокат -----
CREATE TABLE Prokat (
    KodProkata   INT IDENTITY(1,1) PRIMARY KEY,
    KodKlienta   INT  NOT NULL FOREIGN KEY REFERENCES Klienty(KodKlienta),
    KodAvto      INT  NOT NULL FOREIGN KEY REFERENCES Avtomobili(KodAvto),
    DataVydachi  DATE NOT NULL,
    DataVozvrata DATE NOT NULL,
    Cena         MONEY NOT NULL
);
GO

-- ----- Данные -----
INSERT INTO Klienty (FIO, Telefon, Pasport) VALUES
(N'Иванов Иван Иванович',     N'+7(900)111-11-11', N'4510 123456'),
(N'Петрова Анна Сергеевна',   N'+7(900)222-22-22', N'4511 234567'),
(N'Сидоров Олег Викторович',  N'+7(900)333-33-33', N'4512 345678'),
(N'Кузнецова Мария Павловна', N'+7(900)444-44-44', N'4513 456789'),
(N'Морозов Алексей Юрьевич',  N'+7(900)555-55-55', N'4514 567890');

INSERT INTO Avtomobili (Marka, RegNomer, Cena, Svoboden) VALUES
(N'Toyota Camry',     N'А123БВ77', 3000, 0),
(N'Kia Rio',          N'В456ГД77', 1500, 1),
(N'BMW X5',           N'Е789ЖЗ77', 8000, 0),
(N'Lada Vesta',       N'И012КЛ77', 1200, 1),
(N'Hyundai Solaris',  N'М345НО77', 1800, 1);

INSERT INTO Prokat (KodKlienta, KodAvto, DataVydachi, DataVozvrata, Cena) VALUES
(1, 1, '2025-04-01', '2025-04-06', 15000),
(2, 3, '2025-04-15', '2025-04-22', 56000),
(3, 2, '2025-04-20', '2025-04-23', 4500),
(4, 5, '2025-04-25', '2025-04-28', 5400),
(5, 4, '2025-05-01', '2025-05-03', 2400);
GO

-- ----- Запрос: прокаты с именами клиентов и марками авто -----
CREATE OR ALTER VIEW vw_Prokat AS
SELECT p.KodProkata,
       k.FIO          AS Klient,
       a.Marka,
       a.RegNomer,
       p.DataVydachi,
       p.DataVozvrata,
       p.Cena
FROM Prokat p
JOIN Klienty    k ON p.KodKlienta = k.KodKlienta
JOIN Avtomobili a ON p.KodAvto    = a.KodAvto;
GO

PRINT 'БД CarRentalDB готова.';
