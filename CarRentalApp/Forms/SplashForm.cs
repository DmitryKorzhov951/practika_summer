using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Стартовая форма "Заставка". Закрывается через 3 секунды или по клику.</summary>
    public class SplashForm : Form
    {
        private readonly Timer _timer;

        public SplashForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(640, 360);
            BackColor       = Color.FromArgb(30, 60, 120);
            DoubleBuffered  = true;

            var lblTitle = new Label
            {
                Text      = "Информационная система",
                Font      = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Top,
                Height    = 80
            };

            var lblSub = new Label
            {
                Text      = "«Прокат автомобилей»",
                Font      = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.Gold,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Top,
                Height    = 80
            };

            var lblVariant = new Label
            {
                Text      = "Вариант №17",
                Font      = new Font("Segoe UI", 14),
                ForeColor = Color.White,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Top,
                Height    = 40
            };

            var lblHint = new Label
            {
                Text      = "Загрузка...  (нажмите для продолжения)",
                Font      = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.LightGray,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Bottom,
                Height    = 40
            };

            Controls.Add(lblHint);
            Controls.Add(lblVariant);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);

            Click += (s, e) => Close();
            foreach (Control c in Controls) c.Click += (s, e) => Close();

            _timer = new Timer { Interval = 3000 };
            _timer.Tick += (s, e) => { _timer.Stop(); Close(); };
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.Gold, 4))
                e.Graphics.DrawRectangle(pen, 2, 2, Width - 5, Height - 5);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _timer?.Dispose();
            base.Dispose(disposing);
        }
    }
}
