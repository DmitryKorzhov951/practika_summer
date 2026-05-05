using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    // ========= Отдел кадров =========
    public class OtdelKadrovForm : QueryGridForm
    {
        public const string Sql = @"
            SELECT FIO AS [ФИО], Vozrast AS [Возраст], Pol AS [Пол], Adres AS [Адрес],
                   Telefon AS [Телефон], Pasport AS [Паспорт],
                   Dolzhnost AS [Должность], Oklad AS [Оклад],
                   Obyazannosti AS [Обязанности], Trebovaniya AS [Требования]
            FROM vw_OtdelKadrov";
        public OtdelKadrovForm() : base("Отдел кадров", Sql, () => new OtdelKadrovReport().Show()) { }

        protected override void ExtendButtons(FlowLayoutPanel panel)
        {
            // По требованию задания (п. 25) — кнопка гистограммы на форме «Отдел кадров»
            panel.Controls.Add(B("Гистограмма", Color.Goldenrod, (s,e) => new HistogramForm().Show()));
        }
    }
    public class OtdelKadrovReport : ReportForm
    {
        public OtdelKadrovReport() : base("Отдел кадров", OtdelKadrovForm.Sql) { }
    }

    // ========= Автопарк =========
    public class AvtoparkForm : QueryGridForm
    {
        public const string Sql = @"
            SELECT Marka AS [Марка], Harakteristiki AS [Характеристики],
                   RegNomer AS [Рег. номер], NomerKuzova AS [Номер кузова],
                   NomerDvigatelya AS [Номер двигателя],
                   GodVypuska AS [Год выпуска], Probeg AS [Пробег],
                   CenaAvto AS [Цена авто], CenaDnyaProkata AS [Цена дня],
                   DataTO AS [Дата ТО], Mehanik AS [Механик],
                   Otmetki AS [Отметки], Vozvrachen AS [Возвращён]
            FROM vw_Avtopark";
        public AvtoparkForm() : base("Автопарк", Sql, () => new AvtoparkReport().Show()) { }
    }
    public class AvtoparkReport : ReportForm
    {
        public AvtoparkReport() : base("Автопарк", AvtoparkForm.Sql) { }
    }

    // ========= Автомобили в прокате =========
    public class AvtoVProkateForm : QueryGridForm
    {
        public const string Sql = @"
            SELECT DataVydachi AS [Дата выдачи], Srok AS [Срок],
                   DataVozvrata AS [Дата возврата],
                   Marka AS [Марка], RegNomer AS [Рег. номер],
                   Klient AS [Клиент],
                   Usluga1 AS [Услуга 1], Usluga2 AS [Услуга 2], Usluga3 AS [Услуга 3],
                   Cena AS [Цена], Oplachen AS [Оплачен],
                   Sotrudnik AS [Сотрудник]
            FROM vw_AvtoVProkate";
        public AvtoVProkateForm() : base("Автомобили в прокате", Sql, () => new AvtoVProkateReport().Show()) { }
    }
    public class AvtoVProkateReport : ReportForm
    {
        public AvtoVProkateReport() : base("Автомобили в прокате", AvtoVProkateForm.Sql) { }
    }
}
