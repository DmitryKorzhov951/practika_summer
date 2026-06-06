using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Заставка приложения. Раскладка и отрисовка — в SplashForm.Designer.cs.</summary>
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            timer.Tick += (s, e) => { timer.Stop(); Close(); };
            timer.Start();
            Click += (s, e) => Close();
        }
    }
}
