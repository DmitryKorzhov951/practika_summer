namespace CarRentalApp.Configs
{
    public static class FilterConfigs
    {
        public static FilterConfig SotrudnikiPoDolzh()
        {
            var q = QueryConfigs.OtdelKadrov();
            return new FilterConfig
            {
                Title          = "Фильтр: сотрудники по должности",
                ViewName       = q.ViewName,
                OrderBy        = q.OrderBy,
                Fields         = q.Fields,
                FilterCaption  = "Должность:",
                FilterColumn   = "Dolzhnost",
                ControlType    = FilterControlType.Dropdown,
                LookupSql      = "SELECT NaimenovanieDolzh FROM Dolzhnosti ORDER BY NaimenovanieDolzh"
            };
        }

        public static FilterConfig AvtoPoMarke()
        {
            var q = QueryConfigs.Avtopark();
            return new FilterConfig
            {
                Title          = "Фильтр: автомобили по марке",
                ViewName       = q.ViewName,
                OrderBy        = q.OrderBy,
                Fields         = q.Fields,
                FilterCaption  = "Марка:",
                FilterColumn   = "Marka",
                ControlType    = FilterControlType.Dropdown,
                LookupSql      = "SELECT Naimenovanie FROM MarkiAvto ORDER BY Naimenovanie"
            };
        }

        public static FilterConfig AvtoVProkate()
        {
            var q = QueryConfigs.Avtopark();
            return new FilterConfig
            {
                Title          = "Фильтр: автомобили (в прокате / свободные)",
                ViewName       = q.ViewName,
                OrderBy        = q.OrderBy,
                Fields         = q.Fields,
                FilterCaption  = "Возвращён:",
                FilterColumn   = "OtmetkaOVozvrate",
                ControlType    = FilterControlType.Bit,
                BitTrueText    = "Свободен (возвращён)",
                BitFalseText   = "В прокате (не возвращён)"
            };
        }

        public static FilterConfig ProkatPoDate()
        {
            var q = QueryConfigs.AvtoVProkate();
            return new FilterConfig
            {
                Title          = "Фильтр: автомобили выданные/возвращённые в дату",
                ViewName       = q.ViewName,
                OrderBy        = q.OrderBy,
                Fields         = q.Fields,
                FilterCaption  = "Дата (выдача или возврат):",
                FilterColumn   = "DataVydachi",
                ControlType    = FilterControlType.Date
            };
        }

        public static FilterConfig OplataProkata()
        {
            var q = QueryConfigs.AvtoVProkate();
            return new FilterConfig
            {
                Title          = "Фильтр: оплаченные / неоплаченные прокаты",
                ViewName       = q.ViewName,
                OrderBy        = q.OrderBy,
                Fields         = q.Fields,
                FilterCaption  = "Оплачен:",
                FilterColumn   = "OtmetkaObOplate",
                ControlType    = FilterControlType.Bit,
                BitTrueText    = "Оплачен",
                BitFalseText   = "Не оплачен"
            };
        }
    }
}
