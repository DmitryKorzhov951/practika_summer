using System.Collections.Generic;

namespace CarRentalApp.Configs
{
    public enum FieldType { Int, String, Money, Date, Bit, Text, Lookup }

    public class FieldConfig
    {
        public string Column   { get; set; }
        public string Caption  { get; set; }
        public FieldType Type  { get; set; } = FieldType.String;
        public bool IsPrimaryKey { get; set; }

        // Только для Lookup
        public string LookupTable    { get; set; }
        public string LookupKeyCol   { get; set; }
        public string LookupNameCol  { get; set; }
        public bool   LookupNullable { get; set; }
    }

    public class TableConfig
    {
        public string Title           { get; set; }   // "Сотрудники"
        public string TableName       { get; set; }   // "Sotrudniki"
        public string PrimaryKeyCol   { get; set; }   // "KodSotrudnika"
        public List<FieldConfig> Fields { get; set; } = new();
    }

    public class QueryConfig
    {
        public string Title    { get; set; }
        public string ViewName { get; set; }
        public string OrderBy  { get; set; }
        public List<FieldConfig> Fields { get; set; } = new();
    }

    public enum FilterControlType { Dropdown, Date, Bit }

    public class FilterConfig : QueryConfig
    {
        public string            FilterCaption  { get; set; }
        public string            FilterColumn   { get; set; }   // имя столбца в SELECT, по которому фильтр
        public FilterControlType ControlType    { get; set; }
        public string            LookupSql      { get; set; }   // для Dropdown - "SELECT distinct ..."
        public string            BitTrueText    { get; set; } = "Да";
        public string            BitFalseText   { get; set; } = "Нет";
    }
}
