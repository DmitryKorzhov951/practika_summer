using System.Collections.Generic;

namespace CarRentalApp.Configs
{
    /// <summary>Конфигурации всех 7 таблиц БД.</summary>
    public static class TableConfigs
    {
        public static TableConfig Dolzhnosti() => new()
        {
            Title = "Должности",
            TableName = "Dolzhnosti",
            PrimaryKeyCol = "KodDolzhnosti",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodDolzhnosti",     Caption = "Код",            Type = FieldType.Int,    IsPrimaryKey = true },
                new() { Column = "NaimenovanieDolzh", Caption = "Наименование",   Type = FieldType.String },
                new() { Column = "Oklad",             Caption = "Оклад",          Type = FieldType.Money },
                new() { Column = "Obyazannosti",      Caption = "Обязанности",    Type = FieldType.Text },
                new() { Column = "Trebovaniya",       Caption = "Требования",     Type = FieldType.Text },
            }
        };

        public static TableConfig Sotrudniki() => new()
        {
            Title = "Сотрудники",
            TableName = "Sotrudniki",
            PrimaryKeyCol = "KodSotrudnika",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodSotrudnika",    Caption = "Код",         Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "FIO",              Caption = "ФИО",         Type = FieldType.String },
                new() { Column = "Vozrast",          Caption = "Возраст",     Type = FieldType.Int },
                new() { Column = "Pol",              Caption = "Пол",         Type = FieldType.String },
                new() { Column = "Adres",            Caption = "Адрес",       Type = FieldType.String },
                new() { Column = "Telefon",          Caption = "Телефон",     Type = FieldType.String },
                new() { Column = "PasportnyeDannye", Caption = "Паспорт",     Type = FieldType.String },
                new() { Column = "KodDolzhnosti",    Caption = "Должность",   Type = FieldType.Lookup,
                        LookupTable = "Dolzhnosti", LookupKeyCol = "KodDolzhnosti", LookupNameCol = "NaimenovanieDolzh" },
            }
        };

        public static TableConfig Marki() => new()
        {
            Title = "Марки автомобилей",
            TableName = "MarkiAvto",
            PrimaryKeyCol = "KodMarki",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodMarki",           Caption = "Код",                       Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "Naimenovanie",       Caption = "Наименование",              Type = FieldType.String },
                new() { Column = "TehnHarakteristiki", Caption = "Технические характеристики", Type = FieldType.Text },
                new() { Column = "Opisanie",           Caption = "Описание",                  Type = FieldType.Text },
            }
        };

        public static TableConfig Uslugi() => new()
        {
            Title = "Дополнительные услуги",
            TableName = "DopUslugi",
            PrimaryKeyCol = "KodUslugi",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodUslugi",     Caption = "Код",          Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "Naimenovanie",  Caption = "Наименование", Type = FieldType.String },
                new() { Column = "Opisanie",      Caption = "Описание",     Type = FieldType.Text },
                new() { Column = "Cena",          Caption = "Цена",         Type = FieldType.Money },
            }
        };

        public static TableConfig Avtomobili() => new()
        {
            Title = "Автомобили",
            TableName = "Avtomobili",
            PrimaryKeyCol = "KodAvtomobilya",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodAvtomobilya",     Caption = "Код",                  Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "KodMarki",           Caption = "Марка",                Type = FieldType.Lookup,
                        LookupTable = "MarkiAvto", LookupKeyCol = "KodMarki", LookupNameCol = "Naimenovanie" },
                new() { Column = "RegNomer",           Caption = "Рег. номер",           Type = FieldType.String },
                new() { Column = "NomerKuzova",        Caption = "Номер кузова",         Type = FieldType.String },
                new() { Column = "NomerDvigatelya",    Caption = "Номер двигателя",      Type = FieldType.String },
                new() { Column = "GodVypuska",         Caption = "Год выпуска",          Type = FieldType.Int },
                new() { Column = "Probeg",             Caption = "Пробег",               Type = FieldType.Int },
                new() { Column = "CenaAvtomobilya",    Caption = "Цена",                 Type = FieldType.Money },
                new() { Column = "DataPoslednegoTO",   Caption = "Дата последнего ТО",   Type = FieldType.Date },
                new() { Column = "KodSotrudnikaMeh",   Caption = "Сотрудник-механик",    Type = FieldType.Lookup,
                        LookupTable = "Sotrudniki", LookupKeyCol = "KodSotrudnika", LookupNameCol = "FIO" },
                new() { Column = "SpecialnyeOtmetki",  Caption = "Специальные отметки",  Type = FieldType.String },
                new() { Column = "OtmetkaOVozvrate",   Caption = "Отметка о возврате",   Type = FieldType.Bit },
            }
        };

        public static TableConfig Klienty() => new()
        {
            Title = "Клиенты",
            TableName = "Klienty",
            PrimaryKeyCol = "KodKlienta",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodKlienta",       Caption = "Код",            Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "FIO",              Caption = "ФИО",            Type = FieldType.String },
                new() { Column = "Pol",              Caption = "Пол",            Type = FieldType.String },
                new() { Column = "DataRozhdeniya",   Caption = "Дата рождения",  Type = FieldType.Date },
                new() { Column = "Adres",            Caption = "Адрес",          Type = FieldType.String },
                new() { Column = "PasportnyeDannye", Caption = "Паспорт",        Type = FieldType.String },
            }
        };

        public static TableConfig Prokat() => new()
        {
            Title = "Прокат",
            TableName = "Prokat",
            PrimaryKeyCol = "KodProkata",
            Fields = new List<FieldConfig>
            {
                new() { Column = "KodProkata",      Caption = "Код",           Type = FieldType.Int, IsPrimaryKey = true },
                new() { Column = "DataVydachi",     Caption = "Дата выдачи",   Type = FieldType.Date },
                new() { Column = "SrokProkata",     Caption = "Срок (дн.)",    Type = FieldType.Int },
                new() { Column = "DataVozvrata",    Caption = "Дата возврата", Type = FieldType.Date },
                new() { Column = "KodAvtomobilya",  Caption = "Автомобиль",    Type = FieldType.Lookup,
                        LookupTable = "Avtomobili", LookupKeyCol = "KodAvtomobilya", LookupNameCol = "RegNomer" },
                new() { Column = "KodKlienta",      Caption = "Клиент",        Type = FieldType.Lookup,
                        LookupTable = "Klienty", LookupKeyCol = "KodKlienta", LookupNameCol = "FIO" },
                new() { Column = "KodUslugi1",      Caption = "Услуга 1",      Type = FieldType.Lookup, LookupNullable = true,
                        LookupTable = "DopUslugi", LookupKeyCol = "KodUslugi", LookupNameCol = "Naimenovanie" },
                new() { Column = "KodUslugi2",      Caption = "Услуга 2",      Type = FieldType.Lookup, LookupNullable = true,
                        LookupTable = "DopUslugi", LookupKeyCol = "KodUslugi", LookupNameCol = "Naimenovanie" },
                new() { Column = "KodUslugi3",      Caption = "Услуга 3",      Type = FieldType.Lookup, LookupNullable = true,
                        LookupTable = "DopUslugi", LookupKeyCol = "KodUslugi", LookupNameCol = "Naimenovanie" },
                new() { Column = "CenaProkata",     Caption = "Цена проката",  Type = FieldType.Money },
                new() { Column = "OtmetkaObOplate", Caption = "Оплачен",       Type = FieldType.Bit },
                new() { Column = "KodSotrudnika",   Caption = "Сотрудник",     Type = FieldType.Lookup,
                        LookupTable = "Sotrudniki", LookupKeyCol = "KodSotrudnika", LookupNameCol = "FIO" },
            }
        };
    }
}
