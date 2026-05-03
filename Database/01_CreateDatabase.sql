-- =============================================
-- БД "Прокат автомобилей" (Вариант №17)
-- Создание базы данных и таблиц
-- =============================================

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

-- ---------- Должности ----------
CREATE TABLE Dolzhnosti (
    KodDolzhnosti      INT IDENTITY(1,1) PRIMARY KEY,
    NaimenovanieDolzh  NVARCHAR(100) NOT NULL,
    Oklad              MONEY        NOT NULL,
    Obyazannosti       NVARCHAR(500) NOT NULL,
    Trebovaniya        NVARCHAR(500) NOT NULL
);
GO

-- ---------- Сотрудники ----------
CREATE TABLE Sotrudniki (
    KodSotrudnika      INT IDENTITY(1,1) PRIMARY KEY,
    FIO                NVARCHAR(150) NOT NULL,
    Vozrast            INT           NOT NULL,
    Pol                NVARCHAR(10)  NOT NULL,
    Adres              NVARCHAR(200) NOT NULL,
    Telefon            NVARCHAR(20)  NOT NULL,
    PasportnyeDannye   NVARCHAR(50)  NOT NULL,
    KodDolzhnosti      INT           NOT NULL,
    CONSTRAINT FK_Sotr_Dolzh FOREIGN KEY (KodDolzhnosti)
        REFERENCES Dolzhnosti(KodDolzhnosti)
);
GO

-- ---------- Марки автомобилей ----------
CREATE TABLE MarkiAvto (
    KodMarki           INT IDENTITY(1,1) PRIMARY KEY,
    Naimenovanie       NVARCHAR(100) NOT NULL,
    TehnHarakteristiki NVARCHAR(500) NOT NULL,
    Opisanie           NVARCHAR(500) NOT NULL
);
GO

-- ---------- Дополнительные услуги ----------
CREATE TABLE DopUslugi (
    KodUslugi          INT IDENTITY(1,1) PRIMARY KEY,
    Naimenovanie       NVARCHAR(100) NOT NULL,
    Opisanie           NVARCHAR(500) NOT NULL,
    Cena               MONEY         NOT NULL
);
GO

-- ---------- Автомобили ----------
CREATE TABLE Avtomobili (
    KodAvtomobilya     INT IDENTITY(1,1) PRIMARY KEY,
    KodMarki           INT           NOT NULL,
    RegNomer           NVARCHAR(20)  NOT NULL,
    NomerKuzova        NVARCHAR(30)  NOT NULL,
    NomerDvigatelya    NVARCHAR(30)  NOT NULL,
    GodVypuska         INT           NOT NULL,
    Probeg             INT           NOT NULL,
    CenaAvtomobilya    MONEY         NOT NULL,
    DataPoslednegoTO   DATE          NOT NULL,
    KodSotrudnikaMeh   INT           NOT NULL,
    SpecialnyeOtmetki  NVARCHAR(200) NULL,
    OtmetkaOVozvrate   BIT           NOT NULL DEFAULT 1,
    CONSTRAINT FK_Avto_Marki  FOREIGN KEY (KodMarki)         REFERENCES MarkiAvto(KodMarki),
    CONSTRAINT FK_Avto_Sotr   FOREIGN KEY (KodSotrudnikaMeh) REFERENCES Sotrudniki(KodSotrudnika)
);
GO

-- ---------- Клиенты ----------
CREATE TABLE Klienty (
    KodKlienta         INT IDENTITY(1,1) PRIMARY KEY,
    FIO                NVARCHAR(150) NOT NULL,
    Pol                NVARCHAR(10)  NOT NULL,
    DataRozhdeniya     DATE          NOT NULL,
    Adres              NVARCHAR(200) NOT NULL,
    PasportnyeDannye   NVARCHAR(50)  NOT NULL
);
GO

-- ---------- Прокат ----------
CREATE TABLE Prokat (
    KodProkata         INT IDENTITY(1,1) PRIMARY KEY,
    DataVydachi        DATE          NOT NULL,
    SrokProkata        INT           NOT NULL,
    DataVozvrata       DATE          NOT NULL,
    KodAvtomobilya     INT           NOT NULL,
    KodKlienta         INT           NOT NULL,
    KodUslugi1         INT           NULL,
    KodUslugi2         INT           NULL,
    KodUslugi3         INT           NULL,
    CenaProkata        MONEY         NOT NULL,
    OtmetkaObOplate    BIT           NOT NULL DEFAULT 0,
    KodSotrudnika      INT           NOT NULL,
    CONSTRAINT FK_Prok_Avto  FOREIGN KEY (KodAvtomobilya) REFERENCES Avtomobili(KodAvtomobilya),
    CONSTRAINT FK_Prok_Klient FOREIGN KEY (KodKlienta)    REFERENCES Klienty(KodKlienta),
    CONSTRAINT FK_Prok_U1    FOREIGN KEY (KodUslugi1)     REFERENCES DopUslugi(KodUslugi),
    CONSTRAINT FK_Prok_U2    FOREIGN KEY (KodUslugi2)     REFERENCES DopUslugi(KodUslugi),
    CONSTRAINT FK_Prok_U3    FOREIGN KEY (KodUslugi3)     REFERENCES DopUslugi(KodUslugi),
    CONSTRAINT FK_Prok_Sotr  FOREIGN KEY (KodSotrudnika)  REFERENCES Sotrudniki(KodSotrudnika)
);
GO
