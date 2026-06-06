using System;
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
            Click += (s, e) => Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }
    }
}
