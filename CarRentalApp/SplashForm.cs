using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Стартовая форма «Заставка» — в стиле гоночного меню.</summary>
    public class SplashForm : Form
    {
        public SplashForm()
        {
            Text            = "Заставка";
            FormBorderStyle = FormBorderStyle.None;
            ControlBox      = false;
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(620, 360);
            DoubleBuffered  = true;

            Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Фон: тёмный градиент с красной засветкой слева
                using (var bg = new LinearGradientBrush(ClientRectangle,
                        Color.FromArgb(70, 18, 22), Color.FromArgb(15, 15, 18),
                        LinearGradientMode.Horizontal))
                    g.FillRectangle(bg, ClientRectangle);

                // Красные полосы-акценты сверху и снизу
                using var red = new SolidBrush(UI.Primary);
                g.FillRectangle(red, 0, 0, ClientSize.Width, 4);
                g.FillRectangle(red, 0, ClientSize.Height - 4, ClientSize.Width, 4);

                // Полупрозрачные диагональные линии (декор)
                using var line = new Pen(Color.FromArgb(40, 255, 0, 0), 2);
                for (int x = -200; x < ClientSize.Width; x += 60)
                    g.DrawLine(line, x, 0, x + ClientSize.Height, ClientSize.Height);

                // Тонкая светлая рамка
                using var frame = new Pen(Color.FromArgb(80, 255, 255, 255));
                g.DrawRectangle(frame, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            };

            var top = new Label
            {
                Text      = "ИНФОРМАЦИОННАЯ СИСТЕМА",
                Dock      = DockStyle.Top, Height = 50,
                Font      = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = UI.Primary,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding   = new Padding(0, 24, 0, 0)
            };
            var title = new Label
            {
                Text      = "ПРОКАТ\nАВТОМОБИЛЕЙ",
                Dock      = DockStyle.Top, Height = 160,
                Font      = new Font("Segoe UI Black", 32, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            var variant = new Label
            {
                Text      = "ВАРИАНТ №17",
                Dock      = DockStyle.Top, Height = 40,
                Font      = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = UI.Accent,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            var hint = new Label
            {
                Text      = "загрузка…",
                Dock      = DockStyle.Bottom, Height = 36,
                Font      = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = UI.TextDim,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(hint);
            Controls.Add(variant);
            Controls.Add(title);
            Controls.Add(top);

            var t = new Timer { Interval = 2200 };
            t.Tick += (s, e) => { t.Stop(); Close(); };
            t.Start();
            Click += (s, e) => Close();
            foreach (Control c in Controls) c.Click += (s, e) => Close();
        }
    }
}
