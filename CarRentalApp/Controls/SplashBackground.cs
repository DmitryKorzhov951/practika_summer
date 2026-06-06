using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp.Controls
{
    /// <summary>Фон заставки: градиент, красные полосы, декор-линии, рамка и весь текст. Dock=Fill.</summary>
    [DesignerCategory("Code")]
    public class SplashBackground : Panel
    {
        public SplashBackground()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint
                   | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.FromArgb(15, 15, 18);
            Dock = DockStyle.Fill;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = ClientRectangle;
            if (r.Width <= 0 || r.Height <= 0) return;

            using (var bg = new LinearGradientBrush(r,
                Color.FromArgb(70, 18, 22),
                Color.FromArgb(15, 15, 18),
                LinearGradientMode.Horizontal))
                g.FillRectangle(bg, r);

            using (var red = new SolidBrush(Color.FromArgb(229, 57, 53)))
            {
                g.FillRectangle(red, 0, 0, r.Width, 4);
                g.FillRectangle(red, 0, r.Height - 4, r.Width, 4);
            }

            using (var line = new Pen(Color.FromArgb(40, 255, 0, 0), 2))
                for (int x = -200; x < r.Width; x += 60)
                    g.DrawLine(line, x, 0, x + r.Height, r.Height);

            using (var frame = new Pen(Color.FromArgb(80, 255, 255, 255)))
                g.DrawRectangle(frame, 0, 0, r.Width - 1, r.Height - 1);

            var center = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using var fTop     = new Font("Segoe UI",          12F, FontStyle.Bold);
            using var fTitle   = new Font("Segoe UI Black",    32F, FontStyle.Bold);
            using var fVariant = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            using var fHint    = new Font("Segoe UI",           9F, FontStyle.Italic);
            using var brRed   = new SolidBrush(Color.FromArgb(229,  57,  53));
            using var brWhite = new SolidBrush(Color.White);
            using var brAmber = new SolidBrush(Color.FromArgb(255, 193,   7));
            using var brDim   = new SolidBrush(Color.FromArgb(160, 160, 168));

            g.DrawString("ИНФОРМАЦИОННАЯ СИСТЕМА", fTop,     brRed,   new RectangleF(0, 30,            r.Width,  30), center);
            g.DrawString("ПРОКАТ\nАВТОМОБИЛЕЙ",     fTitle,   brWhite, new RectangleF(0, 70,            r.Width, 160), center);
            g.DrawString("ВАРИАНТ №17",             fVariant, brAmber, new RectangleF(0, 230,           r.Width,  40), center);
            g.DrawString("загрузка…",               fHint,    brDim,   new RectangleF(0, r.Height - 36, r.Width,  30), center);
        }
    }
}
