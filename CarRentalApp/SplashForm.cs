using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Стартовая форма "Заставка".</summary>
    public class SplashForm : Form
    {
        public SplashForm()
        {
            Text            = "Заставка";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(640, 360);
            BackColor       = Color.SteelBlue;

            Controls.Add(new Label
            {
                Text      = "База данных\n«Прокат автомобилей»\n\nВариант №17",
                Font      = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var t = new Timer { Interval = 2500 };
            t.Tick += (s, e) => { t.Stop(); Close(); };
            t.Start();
            Click += (s, e) => Close();
        }
    }
}
