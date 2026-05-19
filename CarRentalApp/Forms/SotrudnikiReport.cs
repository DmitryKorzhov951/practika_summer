namespace CarRentalApp.Forms
{
    public class SotrudnikiReport : ReportForm
    {
        public SotrudnikiReport() : base("Сотрудники", @"
            SELECT s.FIO          AS [ФИО],
                   s.Vozrast      AS [Возраст],
                   s.Pol          AS [Пол],
                   s.Adres        AS [Адрес],
                   s.Telefon      AS [Телефон],
                   s.Pasport      AS [Паспорт],
                   d.Naimenovanie AS [Должность]
            FROM Sotrudniki s
            JOIN Dolzhnosti d ON s.KodDolzhnosti = d.KodDolzhnosti", "sotrudniki") { }
    }
}
