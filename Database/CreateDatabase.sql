-- =====================================================
-- БД "Прокат автомобилей" (Вариант №17)
-- Создание базы CarRentalDB.mdf в папке проекта
-- =====================================================
-- Запустить в SQL Server Management Studio или sqlcmd.
-- ВАЖНО: укажите свой путь к папке с .mdf в переменной @path.

USE master;
GO

IF DB_ID('CarRentalDB') IS NOT NULL
BEGIN
    ALTER DATABASE CarRentalDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CarRentalDB;
END
GO

DECLARE @path NVARCHAR(400) = N'C:\Users\123\Desktop\practika_summer-claude-design-info-system-dkxK7\Database\';
DECLARE @sql NVARCHAR(MAX) = N'
CREATE DATABASE CarRentalDB
ON PRIMARY (
    NAME     = N''CarRentalDB'',
    FILENAME = N''' + @path + N'CarRentalDB.mdf'',
    SIZE     = 8MB, FILEGROWTH = 8MB
)
LOG ON (
    NAME     = N''CarRentalDB_log'',
    FILENAME = N''' + @path + N'CarRentalDB_log.ldf'',
    SIZE     = 8MB, FILEGROWTH = 8MB
);';
EXEC sp_executesql @sql;
GO

USE CarRentalDB;
GO

-- ============== ПЕРВИЧНЫЕ ТАБЛИЦЫ (с IDENTITY) ==============

CREATE TABLE Dolzhnosti (
    KodDolzhnosti      INT IDENTITY(1,1) PRIMARY KEY,
    Naimenovanie       NVARCHAR(100) NOT NULL,
    Oklad              MONEY         NOT NULL,
    Obyazannosti       NVARCHAR(300) NOT NULL,
    Trebovaniya        NVARCHAR(300) NOT NULL
);

CREATE TABLE Marki (
    KodMarki           INT IDENTITY(1,1) PRIMARY KEY,
    Naimenovanie       NVARCHAR(100) NOT NULL,
    Harakteristiki     NVARCHAR(300) NOT NULL,
    Opisanie           NVARCHAR(300) NOT NULL
);

CREATE TABLE Uslugi (
    KodUslugi          INT IDENTITY(1,1) PRIMARY KEY,
    Naimenovanie       NVARCHAR(100) NOT NULL,
    Opisanie           NVARCHAR(300) NOT NULL,
    Cena               MONEY         NOT NULL
);

CREATE TABLE Klienty (
    KodKlienta         INT IDENTITY(1,1) PRIMARY KEY,
    FIO                NVARCHAR(150) NOT NULL,
    Pol                NVARCHAR(10)  NOT NULL,
    DataRozhdeniya     DATE          NOT NULL,
    Adres              NVARCHAR(200) NOT NULL,
    Telefon            NVARCHAR(20)  NOT NULL,
    Pasport            NVARCHAR(50)  NOT NULL
);

-- ============== ВТОРИЧНЫЕ ТАБЛИЦЫ (FK = INT, "числовой") ==============

CREATE TABLE Sotrudniki (
    KodSotrudnika      INT IDENTITY(1,1) PRIMARY KEY,
    FIO                NVARCHAR(150) NOT NULL,
    Vozrast            INT           NOT NULL,
    Pol                NVARCHAR(10)  NOT NULL,
    Adres              NVARCHAR(200) NOT NULL,
    Telefon            NVARCHAR(20)  NOT NULL,
    Pasport            NVARCHAR(50)  NOT NULL,
    KodDolzhnosti      INT           NOT NULL FOREIGN KEY REFERENCES Dolzhnosti(KodDolzhnosti)
);

CREATE TABLE Avtomobili (
    KodAvtomobilya     INT IDENTITY(1,1) PRIMARY KEY,
    KodMarki           INT           NOT NULL FOREIGN KEY REFERENCES Marki(KodMarki),
    RegNomer           NVARCHAR(20)  NOT NULL,
    NomerKuzova        NVARCHAR(30)  NOT NULL,
    NomerDvigatelya    NVARCHAR(30)  NOT NULL,
    GodVypuska         INT           NOT NULL,
    Probeg             INT           NOT NULL,
    CenaAvto           MONEY         NOT NULL,
    CenaDnyaProkata    MONEY         NOT NULL,
    DataTO             DATE          NOT NULL,
    KodMehanika        INT           NOT NULL FOREIGN KEY REFERENCES Sotrudniki(KodSotrudnika),
    Otmetki            NVARCHAR(200) NULL,
    Vozvrachen         BIT           NOT NULL DEFAULT 1
);

CREATE TABLE Prokat (
    KodProkata         INT IDENTITY(1,1) PRIMARY KEY,
    DataVydachi        DATE          NOT NULL,
    Srok               INT           NOT NULL,
    DataVozvrata       DATE          NOT NULL,
    KodAvtomobilya     INT           NOT NULL FOREIGN KEY REFERENCES Avtomobili(KodAvtomobilya),
    KodKlienta         INT           NOT NULL FOREIGN KEY REFERENCES Klienty(KodKlienta),
    KodUslugi1         INT           NULL     FOREIGN KEY REFERENCES Uslugi(KodUslugi),
    KodUslugi2         INT           NULL     FOREIGN KEY REFERENCES Uslugi(KodUslugi),
    KodUslugi3         INT           NULL     FOREIGN KEY REFERENCES Uslugi(KodUslugi),
    Cena               MONEY         NOT NULL,
    Oplachen           BIT           NOT NULL DEFAULT 0,
    KodSotrudnika      INT           NOT NULL FOREIGN KEY REFERENCES Sotrudniki(KodSotrudnika)
);
GO

-- ============== ДАННЫЕ ==============

INSERT INTO Dolzhnosti (Naimenovanie, Oklad, Obyazannosti, Trebovaniya) VALUES
(N'Директор',         120000, N'Руководство компанией',                N'Высшее, опыт от 5 лет'),
(N'Менеджер',          65000, N'Оформление договоров проката',         N'Высшее, коммуникабельность'),
(N'Механик',           55000, N'Обслуживание и ремонт автомобилей',    N'Среднее спец., опыт от 3 лет'),
(N'Бухгалтер',         70000, N'Бухгалтерский учёт',                    N'Высшее, знание 1С'),
(N'Администратор',     45000, N'Приём звонков, работа с документами',   N'ПК-грамотность');

INSERT INTO Marki (Naimenovanie, Harakteristiki, Opisanie) VALUES
(N'Toyota Camry',    N'2.5л, 181 л.с., автомат',         N'Бизнес-седан'),
(N'Kia Rio',         N'1.6л, 123 л.с., механика',        N'Компактный седан'),
(N'BMW X5',          N'3.0л, 340 л.с., автомат, 4WD',    N'Премиальный кроссовер'),
(N'Lada Vesta',      N'1.6л, 106 л.с., механика',        N'Отечественный седан'),
(N'Hyundai Solaris', N'1.6л, 123 л.с., автомат',         N'Седан класса В');

INSERT INTO Uslugi (Naimenovanie, Opisanie, Cena) VALUES
(N'Детское кресло',    N'Установка детского автокресла',  500),
(N'GPS-навигатор',     N'Аренда GPS-навигатора',          300),
(N'Полная страховка',  N'КАСКО на период проката',        2000),
(N'Доставка авто',     N'Доставка авто клиенту',          1500),
(N'Зимняя резина',     N'Зимний комплект шин',            1000);

INSERT INTO Klienty (FIO, Pol, DataRozhdeniya, Adres, Telefon, Pasport) VALUES
(N'Александров Павел Викторович', N'М', '1985-06-12', N'Москва, ул. Профсоюзная, 45', N'+7(900)100-10-10', N'4520 111222'),
(N'Белова Татьяна Николаевна',    N'Ж', '1990-09-25', N'Москва, пр. Вернадского, 78', N'+7(900)200-20-20', N'4521 222333'),
(N'Григорьев Максим Андреевич',   N'М', '1988-03-08', N'Москва, ул. Ленинский, 100',  N'+7(900)300-30-30', N'4522 333444'),
(N'Дроздова Светлана Юрьевна',    N'Ж', '1992-11-17', N'Москва, ул. Шаболовка, 23',   N'+7(900)400-40-40', N'4523 444555'),
(N'Ермаков Виктор Степанович',    N'М', '1978-01-30', N'Москва, ул. Красная, 5',      N'+7(900)500-50-50', N'4524 555666');

INSERT INTO Sotrudniki (FIO, Vozrast, Pol, Adres, Telefon, Pasport, KodDolzhnosti) VALUES
(N'Иванов Сергей Петрович',       45, N'М', N'Москва, ул. Ленина, 12',    N'+7(495)123-45-67', N'4510 123456', 1),
(N'Петрова Ольга Ивановна',       32, N'Ж', N'Москва, ул. Тверская, 25',  N'+7(495)234-56-78', N'4511 234567', 2),
(N'Сидоров Андрей Михайлович',    28, N'М', N'Москва, пр. Мира, 45',      N'+7(495)345-67-89', N'4512 345678', 3),
(N'Кузнецов Дмитрий Олегович',    35, N'М', N'Москва, ул. Арбат, 7',      N'+7(495)456-78-90', N'4513 456789', 3),
(N'Морозова Анна Викторовна',     29, N'Ж', N'Москва, ул. Покровка, 33',  N'+7(495)567-89-01', N'4514 567890', 4),
(N'Васильев Игорь Юрьевич',       41, N'М', N'Москва, ул. Садовая, 15',   N'+7(495)678-90-12', N'4515 678901', 2),
(N'Новикова Елена Сергеевна',     26, N'Ж', N'Москва, ул. Полянка, 18',   N'+7(495)789-01-23', N'4516 789012', 5),
(N'Фёдоров Алексей Иванович',     38, N'М', N'Москва, ул. Якиманка, 5',   N'+7(495)890-12-34', N'4517 890123', 3),
(N'Соколова Мария Александровна', 31, N'Ж', N'Москва, ул. Остоженка, 22', N'+7(495)901-23-45', N'4518 901234', 5),
(N'Михайлов Олег Дмитриевич',     47, N'М', N'Москва, ул. Пречистенка, 9',N'+7(495)012-34-56', N'4519 012345', 2);

INSERT INTO Avtomobili (KodMarki, RegNomer, NomerKuzova, NomerDvigatelya, GodVypuska, Probeg, CenaAvto, CenaDnyaProkata, DataTO, KodMehanika, Otmetki, Vozvrachen) VALUES
(1, N'А123БВ77', N'XW7BF4FK20S001234', N'2AR1234567',  2021, 45000, 2200000, 3000, '2025-03-15', 3, N'Кожаный салон',     1),
(1, N'А456БВ77', N'XW7BF4FK20S005678', N'2AR2345678',  2022, 28000, 2400000, 3200, '2025-04-10', 4, N'Подогрев сидений',  0),
(2, N'В789ГД77', N'KNADM412LK6123456', N'G4FC1234567', 2020, 67000, 1100000, 1500, '2025-02-20', 3, N'',                   1),
(2, N'В012ГД77', N'KNADM412LK6234567', N'G4FC2345678', 2021, 52000, 1200000, 1600, '2025-05-05', 8, N'',                   1),
(3, N'Е345ЖЗ77', N'WBAKR4C50DC987654', N'N55B30A123',  2023, 18000, 7800000, 8000, '2025-04-25', 8, N'Панорамная крыша',   0),
(3, N'Е678ЖЗ77', N'WBAKR4C50DC876543', N'N55B30A234',  2022, 31000, 7200000, 7500, '2025-03-30', 4, N'Премиум аудио',      1),
(4, N'И901КЛ77', N'XTAGFK330LY123456', N'21179_1234',  2022, 38000, 950000,  1200, '2025-01-15', 3, N'',                   1),
(4, N'И234КЛ77', N'XTAGFK330LY234567', N'21179_2345',  2023, 22000, 1050000, 1300, '2025-04-18', 8, N'',                   0),
(5, N'М567НО77', N'Z94K241CBLR123456', N'G4FC3456789', 2021, 56000, 1300000, 1800, '2025-02-28', 4, N'Камера заднего вида',1),
(5, N'М890НО77', N'Z94K241CBLR234567', N'G4FC4567890', 2022, 41000, 1400000, 1900, '2025-03-22', 3, N'',                   1);

INSERT INTO Prokat (DataVydachi, Srok, DataVozvrata, KodAvtomobilya, KodKlienta, KodUslugi1, KodUslugi2, KodUslugi3, Cena, Oplachen, KodSotrudnika) VALUES
('2025-04-01', 5,  '2025-04-06', 1,  1, 2,    3,    NULL, 15000, 1, 2),
('2025-04-15', 7,  '2025-04-22', 2,  2, 1,    NULL, NULL, 21000, 1, 6),
('2025-04-20', 3,  '2025-04-23', 3,  3, NULL, NULL, NULL, 6000,  0, 10),
('2025-04-25', 10, '2025-05-05', 5,  4, 3,    4,    NULL, 80000, 1, 2),
('2025-04-28', 2,  '2025-04-30', 7,  5, NULL, NULL, NULL, 5000,  0, 6),
('2025-05-01', 14, '2025-05-15', 6,  1, 3,    5,    NULL, 95000, 0, 10),
('2025-05-02', 1,  '2025-05-03', 9,  2, 1,    NULL, NULL, 3500,  1, 2),
('2025-04-10', 4,  '2025-04-14', 4,  3, 2,    4,    NULL, 12000, 1, 6),
('2025-05-03', 7,  '2025-05-10', 8,  4, NULL, NULL, NULL, 16000, 0, 10),
('2025-04-22', 6,  '2025-04-28', 10, 5, 5,    NULL, NULL, 14000, 1, 2);
GO

-- ============== ЗАПРОСЫ (VIEWS) ==============

CREATE OR ALTER VIEW vw_OtdelKadrov AS
SELECT s.KodSotrudnika, s.FIO, s.Vozrast, s.Pol, s.Adres, s.Telefon, s.Pasport,
       d.Naimenovanie AS Dolzhnost, d.Oklad, d.Obyazannosti, d.Trebovaniya
FROM Sotrudniki s
JOIN Dolzhnosti d ON s.KodDolzhnosti = d.KodDolzhnosti;
GO

CREATE OR ALTER VIEW vw_Avtopark AS
SELECT a.KodAvtomobilya,
       m.Naimenovanie AS Marka, m.Harakteristiki,
       a.RegNomer, a.NomerKuzova, a.NomerDvigatelya,
       a.GodVypuska, a.Probeg, a.CenaAvto, a.CenaDnyaProkata, a.DataTO,
       s.FIO AS Mehanik, a.Otmetki, a.Vozvrachen
FROM Avtomobili a
JOIN Marki      m ON a.KodMarki    = m.KodMarki
JOIN Sotrudniki s ON a.KodMehanika = s.KodSotrudnika;
GO

CREATE OR ALTER VIEW vw_AvtoVProkate AS
SELECT p.KodProkata, p.DataVydachi, p.Srok, p.DataVozvrata,
       m.Naimenovanie AS Marka, a.RegNomer,
       k.FIO AS Klient,
       u1.Naimenovanie AS Usluga1, u2.Naimenovanie AS Usluga2, u3.Naimenovanie AS Usluga3,
       p.Cena, p.Oplachen, s.FIO AS Sotrudnik
FROM Prokat p
JOIN Avtomobili a  ON p.KodAvtomobilya = a.KodAvtomobilya
JOIN Marki      m  ON a.KodMarki       = m.KodMarki
JOIN Klienty    k  ON p.KodKlienta     = k.KodKlienta
LEFT JOIN Uslugi u1 ON p.KodUslugi1 = u1.KodUslugi
LEFT JOIN Uslugi u2 ON p.KodUslugi2 = u2.KodUslugi
LEFT JOIN Uslugi u3 ON p.KodUslugi3 = u3.KodUslugi
JOIN Sotrudniki s  ON p.KodSotrudnika  = s.KodSotrudnika;
GO

PRINT 'БД CarRentalDB готова. Файл .mdf лежит в указанной папке.';
