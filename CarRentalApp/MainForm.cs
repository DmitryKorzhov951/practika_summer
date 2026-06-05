using System.Windows.Forms;
using CarRentalApp.Forms;

namespace CarRentalApp
{
    /// <summary>Главная форма в Netflix-стиле. Раскладка — в MainForm.Designer.cs.</summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // ToolTip для подсказок на карточках
            var tip = new ToolTip();
            tip.SetToolTip(cardSotrudniki,   "Сотрудники");
            tip.SetToolTip(cardDolzhnosti,   "Должности");
            tip.SetToolTip(cardMarki,        "Марки автомобилей");
            tip.SetToolTip(cardUslugi,       "Дополнительные услуги");
            tip.SetToolTip(cardAvtomobili,   "Автомобили");
            tip.SetToolTip(cardKlienty,      "Клиенты");
            tip.SetToolTip(cardProkat,       "Прокат");
            tip.SetToolTip(cardOtdelKadrov,  "Отдел кадров");
            tip.SetToolTip(cardAvtopark,     "Автопарк");
            tip.SetToolTip(cardAvtoVProkate, "Автомобили в прокате");
            tip.SetToolTip(cardFiltDolzh,    "Сотрудники по должности");
            tip.SetToolTip(cardFiltMarka,    "Автомобили по марке");
            tip.SetToolTip(cardFiltVozvrat,  "В прокате / свободные");
            tip.SetToolTip(cardFiltDate,     "Прокат по дате");
            tip.SetToolTip(cardFiltOplata,   "Оплачено / не оплачено");

            tip.SetToolTip(cardRepSotrudniki,    "Отчёт: Сотрудники");
            tip.SetToolTip(cardRepDolzhnosti,    "Отчёт: Должности");
            tip.SetToolTip(cardRepMarki,         "Отчёт: Марки автомобилей");
            tip.SetToolTip(cardRepUslugi,        "Отчёт: Дополнительные услуги");
            tip.SetToolTip(cardRepAvtomobili,    "Отчёт: Автомобили");
            tip.SetToolTip(cardRepKlienty,       "Отчёт: Клиенты");
            tip.SetToolTip(cardRepProkat,        "Отчёт: Прокат");
            tip.SetToolTip(cardRepOtdelKadrov,   "Отчёт: Отдел кадров");
            tip.SetToolTip(cardRepAvtopark,      "Отчёт: Автопарк");
            tip.SetToolTip(cardRepAvtoVProkate,  "Отчёт: Автомобили в прокате");

            // Нижние кнопки
            btnExit.Click      += (s, e) => Application.Exit();
            btnAbout.Click     += (s, e) => new AboutForm().ShowDialog(this);
            btnHistogram.Click += (s, e) => new HistogramForm().ShowDialog(this);

            // Формы — таблицы
            cardSotrudniki.Click  += (s, e) => new SotrudnikiForm().Show();
            cardDolzhnosti.Click  += (s, e) => new DolzhnostiForm().Show();
            cardMarki.Click       += (s, e) => new MarkiForm().Show();
            cardUslugi.Click      += (s, e) => new UslugiForm().Show();
            cardAvtomobili.Click  += (s, e) => new AvtomobiliForm().Show();
            cardKlienty.Click     += (s, e) => new KlientyForm().Show();
            cardProkat.Click      += (s, e) => new ProkatForm().Show();

            // Запросы
            cardOtdelKadrov.Click  += (s, e) => new OtdelKadrovForm().Show();
            cardAvtopark.Click     += (s, e) => new AvtoparkForm().Show();
            cardAvtoVProkate.Click += (s, e) => new AvtoVProkateForm().Show();

            // Фильтры
            cardFiltDolzh.Click   += (s, e) => new FilterByDolzhnost().Show();
            cardFiltMarka.Click   += (s, e) => new FilterByMarka().Show();
            cardFiltVozvrat.Click += (s, e) => new FilterByVozvrachen().Show();
            cardFiltDate.Click    += (s, e) => new FilterByDate().Show();
            cardFiltOplata.Click  += (s, e) => new FilterByOplata().Show();

            // Отчёты
            cardRepSotrudniki.Click   += (s, e) => new SotrudnikiReport().Show();
            cardRepDolzhnosti.Click   += (s, e) => new DolzhnostiReport().Show();
            cardRepMarki.Click        += (s, e) => new MarkiReport().Show();
            cardRepUslugi.Click       += (s, e) => new UslugiReport().Show();
            cardRepAvtomobili.Click   += (s, e) => new AvtomobiliReport().Show();
            cardRepKlienty.Click      += (s, e) => new KlientyReport().Show();
            cardRepProkat.Click       += (s, e) => new ProkatReport().Show();
            cardRepOtdelKadrov.Click  += (s, e) => new OtdelKadrovReport().Show();
            cardRepAvtopark.Click     += (s, e) => new AvtoparkReport().Show();
            cardRepAvtoVProkate.Click += (s, e) => new AvtoVProkateReport().Show();
        }
    }
}
