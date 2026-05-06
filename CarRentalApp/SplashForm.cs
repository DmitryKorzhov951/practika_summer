using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Стартовая форма «Заставка».</summary>
    public class SplashForm : Form
    {
        public SplashForm()
        {
            Text            = "Заставка";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox      = false;
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(440, 240);
            BackColor       = Color.White;

            Controls.Add(new Label
            {
                Text      = "База данных\n«Прокат автомобилей»\n\nВариант №17",
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var t = new Timer { Interval = 2000 };
            t.Tick += (s, e) => { t.Stop(); Close(); };
            t.Start();
            Click += (s, e) => Close();
        }
    }
}
