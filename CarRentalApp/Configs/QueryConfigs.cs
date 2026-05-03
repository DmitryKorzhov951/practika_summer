using System.Collections.Generic;

namespace CarRentalApp.Configs
{
    /// <summary>Конфигурации трёх запросов.</summary>
    public static class QueryConfigs
    {
        public static QueryConfig OtdelKadrov() => new()
        {
            Title    = "Запрос «Отдел кадров»",
            ViewName = "vw_OtdelKadrov",
            OrderBy  = "FIO",
            Fields   = new List<FieldConfig>
            {
                new() { Column = "FIO",              Caption = "ФИО" },
                new() { Column = "Vozrast",          Caption = "Возраст",     Type = FieldType.Int },
                new() { Column = "Pol",              Caption = "Пол" },
                new() { Column = "Adres",            Caption = "Адрес" },
                new() { Column = "Telefon",          Caption = "Телефон" },
                new() { Column = "PasportnyeDannye", Caption = "Паспорт" },
                new() { Column = "Dolzhnost",        Caption = "Должность" },
                new() { Column = "Oklad",            Caption = "Оклад",       Type = FieldType.Money },
                new() { Column = "Obyazannosti",     Caption = "Обязанности", Type = FieldType.Text },
                new() { Column = "Trebovaniya",      Caption = "Требования",  Type = FieldType.Text },
            }
        };

        public static QueryConfig Avtopark() => new()
        {
            Title    = "Запрос «Автопарк»",
            ViewName = "vw_Avtopark",
            OrderBy  = "Marka, RegNomer",
            Fields   = new List<FieldConfig>
            {
                new() { Column = "Marka",              Caption = "Марка" },
                new() { Column = "TehnHarakteristiki", Caption = "Технические характеристики", Type = FieldType.Text },
                new() { Column = "RegNomer",           Caption = "Рег. номер" },
                new() { Column = "NomerKuzova",        Caption = "Номер кузова" },
                new() { Column = "NomerDvigatelya",    Caption = "Номер двигателя" },
                new() { Column = "GodVypuska",         Caption = "Год выпуска",            Type = FieldType.Int },
                new() { Column = "Probeg",             Caption = "Пробег",                 Type = FieldType.Int },
                new() { Column = "CenaAvtomobilya",    Caption = "Цена",                   Type = FieldType.Money },
                new() { Column = "DataPoslednegoTO",   Caption = "Дата последнего ТО",     Type = FieldType.Date },
                new() { Column = "MehanikFIO",         Caption = "Механик" },
                new() { Column = "SpecialnyeOtmetki",  Caption = "Специальные отметки" },
                new() { Column = "OtmetkaOVozvrate",   Caption = "Возвращён",              Type = FieldType.Bit },
            }
        };

        public static QueryConfig AvtoVProkate() => new()
        {
            Title    = "Запрос «Автомобили в прокате»",
            ViewName = "vw_AvtoVProkate",
            OrderBy  = "DataVydachi DESC",
            Fields   = new List<FieldConfig>
            {
                new() { Column = "DataVydachi",     Caption = "Дата выдачи",   Type = FieldType.Date },
                new() { Column = "SrokProkata",     Caption = "Срок (дн.)",    Type = FieldType.Int },
                new() { Column = "DataVozvrata",    Caption = "Дата возврата", Type = FieldType.Date },
                new() { Column = "Marka",           Caption = "Марка" },
                new() { Column = "RegNomer",        Caption = "Рег. номер" },
                new() { Column = "Klient",          Caption = "Клиент" },
                new() { Column = "Usluga1",         Caption = "Услуга 1" },
                new() { Column = "Usluga2",         Caption = "Услуга 2" },
                new() { Column = "Usluga3",         Caption = "Услуга 3" },
                new() { Column = "CenaProkata",     Caption = "Цена",          Type = FieldType.Money },
                new() { Column = "OtmetkaObOplate", Caption = "Оплачен",       Type = FieldType.Bit },
                new() { Column = "Sotrudnik",       Caption = "Сотрудник" },
            }
        };
    }
}
