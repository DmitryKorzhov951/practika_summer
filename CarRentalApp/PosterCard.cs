using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Карточка-постер в стиле Netflix: картинка + затемнение + hover-подсветка.</summary>
    public class PosterCard : Panel
    {
        private bool _hover;

        public PosterCard(string posterFile, Action onClick)
        {
            Width  = 236;
            Height = 132;
            Margin = new Padding(0, 0, 14, 0);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            BackColor = UI.Surface;

            var img = UI.LoadPoster(posterFile);
            if (img != null)
            {
                BackgroundImage = img;
                BackgroundImageLayout = ImageLayout.Stretch;
            }

            MouseEnter += (s, e) => { _hover = true;  Invalidate(); };
            MouseLeave += (s, e) => { _hover = false; Invalidate(); };
            Click += (s, e) => onClick();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;

            if (_hover)
            {
                // Яркая красная рамка вокруг выделенной карточки
                using var pen = new Pen(UI.Primary, 3);
                g.DrawRectangle(pen, 1, 1, rect.Width - 3, rect.Height - 3);
            }
            else
            {
                // Невыделенные карточки чуть затемнены (эффект Netflix)
                using var shade = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
                g.FillRectangle(shade, rect);
                using var pen = new Pen(UI.Border, 1);
                g.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
            }
        }
    }
}
