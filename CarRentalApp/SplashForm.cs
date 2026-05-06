using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Стартовая форма «Заставка».</summary>
    public class SplashForm : Form
    {
        public SplashForm()
        {
            Text            = "Заставка";
            FormBorderStyle = FormBorderStyle.None;
            ControlBox      = false;
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(520, 300);
            DoubleBuffered  = true;

            // тонкая рамка
            Paint += (s, e) =>
            {
                using var brush = new LinearGradientBrush(
                    ClientRectangle, UI.Primary, UI.PrimaryLt, 60f);
                e.Graphics.FillRectangle(brush, ClientRectangle);
                using var pen = new Pen(Color.FromArgb(50, 0, 0, 0), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            };

            var lblTop = new Label
            {
                Text      = "Информационная система",
                Dock      = DockStyle.Top, Height = 36,
                Font      = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(220, 230, 244),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding   = new Padding(0, 10, 0, 0)
            };
            var lblTitle = new Label
            {
                Text      = "Прокат автомобилей",
                Dock      = DockStyle.Top, Height = 70,
                Font      = new Font("Segoe UI Black", 24, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lblVar = new Label
            {
                Text      = "Вариант №17",
                Dock      = DockStyle.Top, Height = 30,
                Font      = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.FromArgb(255, 220, 130),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lblHint = new Label
            {
                Text      = "загрузка…",
                Dock      = DockStyle.Bottom, Height = 30,
                Font      = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(220, 230, 244),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblHint);
            Controls.Add(lblVar);
            Controls.Add(lblTitle);
            Controls.Add(lblTop);

            var t = new Timer { Interval = 2000 };
            t.Tick += (s, e) => { t.Stop(); Close(); };
            t.Start();
            Click += (s, e) => Close();
            foreach (Control c in Controls) c.Click += (s, e) => Close();
        }
    }
}
