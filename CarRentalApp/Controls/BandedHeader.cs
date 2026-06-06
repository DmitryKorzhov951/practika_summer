using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp.Controls
{
    /// <summary>Шапка ленточной/табличной формы: тёмный градиент, красные полосы по краям, заголовок слева.</summary>
    [DesignerCategory("Code")]
    public class BandedHeader : Panel
    {
        private string _title = "ЗАГОЛОВОК";

        [Category("BandedHeader"), DefaultValue("ЗАГОЛОВОК")]
        public string Title
        {
            get => _title;
            set { _title = value ?? string.Empty; Invalidate(); }
        }

        public BandedHeader()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            Dock = DockStyle.Top;
            Height = 56;
            BackColor = Color.FromArgb(12, 12, 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var r = ClientRectangle;
            if (r.Width <= 0 || r.Height <= 0) return;

            using (var grad = new LinearGradientBrush(r,
                Color.FromArgb(20, 10, 14),
                Color.FromArgb(120, 28, 34),
                LinearGradientMode.Horizontal))
                g.FillRectangle(grad, r);

            using (var red = new SolidBrush(Color.FromArgb(229, 57, 53)))
            {
                g.FillRectangle(red, 0, 0, r.Width, 2);
                g.FillRectangle(red, 0, 0, 5, r.Height);
                g.FillRectangle(red, 0, r.Height - 4, r.Width, 4);
            }

            using var font = new Font("Segoe UI Black", 13F, FontStyle.Bold);
            TextRenderer.DrawText(g, _title ?? string.Empty, font,
                new Rectangle(22, 0, r.Width - 44, r.Height - 4),
                Color.White,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
        }
    }
}
