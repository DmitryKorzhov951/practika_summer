namespace CarRentalApp.Forms
{
    public class DolzhnostiReport : ReportForm
    {
        public DolzhnostiReport() : base("Должности",
            "SELECT Naimenovanie AS [Наименование], Oklad AS [Оклад], Obyazannosti AS [Обязанности], Trebovaniya AS [Требования] FROM Dolzhnosti")
        { }
    }
}
