using System.Windows.Forms;
using CarRentalApp.Forms;

namespace CarRentalApp
{
    /// <summary>Главная кнопочная форма. Раскладка — в MainForm.Designer.cs.</summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Нижняя панель
            btnExit.Click      += (s, e) => Application.Exit();
            btnAbout.Click     += (s, e) => new AboutForm().ShowDialog(this);
            btnHistogram.Click += (s, e) => new HistogramForm().ShowDialog(this);

            // Вкладка "Формы"
            btnSotrudniki.Click   += (s, e) => new SotrudnikiForm().Show();
            btnDolzhnosti.Click   += (s, e) => new DolzhnostiForm().Show();
            btnMarki.Click        += (s, e) => new MarkiForm().Show();
            btnUslugi.Click       += (s, e) => new UslugiForm().Show();
            btnAvtomobili.Click   += (s, e) => new AvtomobiliForm().Show();
            btnKlienty.Click      += (s, e) => new KlientyForm().Show();
            btnProkat.Click       += (s, e) => new ProkatForm().Show();

            btnOtdelKadrov.Click  += (s, e) => new OtdelKadrovForm().Show();
            btnAvtopark.Click     += (s, e) => new AvtoparkForm().Show();
            btnAvtoVProkate.Click += (s, e) => new AvtoVProkateForm().Show();

            btnFiltDolzh.Click    += (s, e) => new FilterByDolzhnost().Show();
            btnFiltMarka.Click    += (s, e) => new FilterByMarka().Show();
            btnFiltVozvrat.Click  += (s, e) => new FilterByVozvrachen().Show();
            btnFiltDate.Click     += (s, e) => new FilterByDate().Show();
            btnFiltOplata.Click   += (s, e) => new FilterByOplata().Show();

            // Вкладка "Отчёты"
            btnRepSotrudniki.Click   += (s, e) => new SotrudnikiReport().Show();
            btnRepDolzhnosti.Click   += (s, e) => new DolzhnostiReport().Show();
            btnRepMarki.Click        += (s, e) => new MarkiReport().Show();
            btnRepUslugi.Click       += (s, e) => new UslugiReport().Show();
            btnRepAvtomobili.Click   += (s, e) => new AvtomobiliReport().Show();
            btnRepKlienty.Click      += (s, e) => new KlientyReport().Show();
            btnRepProkat.Click       += (s, e) => new ProkatReport().Show();

            btnRepOtdelKadrov.Click  += (s, e) => new OtdelKadrovReport().Show();
            btnRepAvtopark.Click     += (s, e) => new AvtoparkReport().Show();
            btnRepAvtoVProkate.Click += (s, e) => new AvtoVProkateReport().Show();
        }
    }
}
