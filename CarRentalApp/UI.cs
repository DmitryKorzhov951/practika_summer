using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Палитра и стили для тёмной «гоночной» темы.</summary>
    static class UI
    {
        // ---- Палитра (тёмная тема, красный акцент) ----
        public static readonly Color Bg          = Color.FromArgb( 18,  18,  20);  // глубокий фон
        public static readonly Color Surface     = Color.FromArgb( 30,  30,  34);  // карточки/панели
        public static readonly Color SurfaceAlt  = Color.FromArgb( 38,  38,  44);  // чередование
        public static readonly Color SurfaceHi   = Color.FromArgb( 50,  50,  56);  // hover
        public static readonly Color Border      = Color.FromArgb( 60,  60,  66);

        public static readonly Color Primary     = Color.FromArgb(229,  57,  53);  // фирменный красный
        public static readonly Color PrimaryDk   = Color.FromArgb(183,  28,  28);
        public static readonly Color PrimaryLt   = Color.FromArgb(255,  82,  82);

        public static readonly Color Accent      = Color.FromArgb(255, 193,   7);  // янтарный
        public static readonly Color Success     = Color.FromArgb( 67, 160,  71);
        public static readonly Color Danger      = PrimaryDk;

        public static readonly Color Text        = Color.FromArgb(240, 240, 244);
        public static readonly Color TextDim     = Color.FromArgb(160, 160, 168);
        public static readonly Color OnPrimary   = Color.White;

        public static readonly Font Header   = new("Segoe UI Semibold", 14, FontStyle.Bold);
        public static readonly Font Body     = new("Segoe UI", 9);
        public static readonly Font BodyBold = new("Segoe UI Semibold", 9, FontStyle.Bold);

        /// <summary>Применить тёмную тему к форме.</summary>
        public static void ApplyTheme(Form f)
        {
            f.BackColor = Bg;
            f.ForeColor = Text;
            f.Font = Body;
        }

        /// <summary>Шапка формы — чёрная плашка с красной акцентной линией снизу.</summary>
        public static Panel MakeHeader(string text)
        {
            var p = new Panel
            {
                Dock = DockStyle.Top, Height = 50,
                BackColor = Color.FromArgb(10, 10, 12)
            };
            // Градиентная подложка
            p.Paint += (s, e) =>
            {
                using var bg = new LinearGradientBrush(p.ClientRectangle,
                    Color.FromArgb(10, 10, 12),
                    Color.FromArgb(30, 30, 36),
                    LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(bg, p.ClientRectangle);
                // Тонкая красная полоса сверху и снизу
                using var top = new SolidBrush(Primary);
                e.Graphics.FillRectangle(top, 0, 0, p.Width, 2);
                e.Graphics.FillRectangle(top, 0, p.Height - 3, p.Width, 3);
            };

            p.Controls.Add(new Label
            {
                Text       = text.ToUpperInvariant(),
                Dock       = DockStyle.Fill,
                Font       = Header,
                ForeColor  = Color.White,
                BackColor  = Color.Transparent,
                TextAlign  = ContentAlignment.MiddleLeft,
                Padding    = new Padding(20, 0, 0, 0)
            });
            return p;
        }

        // ---- Загрузка постеров ----
        private static readonly Dictionary<string, Image> _posters = new();

        public static Image LoadPoster(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (_posters.TryGetValue(key, out var c)) return c;
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory,
                    "Assets", "posters", key + ".png");
                if (!File.Exists(path)) { _posters[key] = null; return null; }
                using var tmp = Image.FromFile(path);
                var copy = new Bitmap(tmp);
                _posters[key] = copy;
                return copy;
            }
            catch { _posters[key] = null; return null; }
        }

        /// <summary>Шапка-баннер с постером на фоне.</summary>
        public static Panel MakeBanner(string text, string posterKey)
        {
            var p = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = Color.FromArgb(12, 12, 14) };
            var img = LoadPoster(posterKey);
            p.Resize += (s, e) => p.Invalidate();
            p.Paint += (s, e) =>
            {
                var g = e.Graphics;
                var rect = p.ClientRectangle;
                if (img != null)
                {
                    // центральная горизонтальная полоса постера, растянутая по ширине
                    int srcH = Math.Max(1, Math.Min(img.Height,
                        (int)(img.Width * (double)p.Height / Math.Max(1, p.Width))));
                    var src = new Rectangle(0, (img.Height - srcH) / 2, img.Width, srcH);
                    g.DrawImage(img, rect, src, GraphicsUnit.Pixel);
                }
                // тёмный градиент слева для читаемости текста
                using (var grad = new LinearGradientBrush(rect,
                        Color.FromArgb(240, 12, 12, 14), Color.FromArgb(90, 12, 12, 14),
                        LinearGradientMode.Horizontal))
                    g.FillRectangle(grad, rect);
                // красные акцентные полосы
                using var red = new SolidBrush(Primary);
                g.FillRectangle(red, 0, 0, p.Width, 2);
                g.FillRectangle(red, 0, p.Height - 3, p.Width, 3);
                g.FillRectangle(red, 0, 0, 5, p.Height);
                // заголовок
                TextRenderer.DrawText(g, text.ToUpperInvariant(), Header,
                    new Rectangle(22, 0, p.Width - 44, p.Height), Color.White,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            };
            return p;
        }

        public enum BtnStyle { Default, Primary, Accent, Danger }

        public static Button MakeBtn(string text, EventHandler onClick, int width = 110, BtnStyle style = BtnStyle.Default)
        {
            var b = new Button
            {
                Text   = text,
                Width  = width,
                Height = 32,
                Font   = BodyBold,
                FlatStyle = FlatStyle.Flat,
                Cursor  = Cursors.Hand,
                Margin  = new Padding(2)
            };
            b.FlatAppearance.BorderSize = 1;

            switch (style)
            {
                case BtnStyle.Primary:
                    b.BackColor = Primary;
                    b.ForeColor = OnPrimary;
                    b.FlatAppearance.BorderColor = Primary;
                    b.FlatAppearance.MouseOverBackColor = PrimaryLt;
                    b.FlatAppearance.MouseDownBackColor = PrimaryDk;
                    break;
                case BtnStyle.Accent:
                    b.BackColor = Accent;
                    b.ForeColor = Color.FromArgb(40, 28, 0);
                    b.FlatAppearance.BorderColor = Accent;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 213, 79);
                    break;
                case BtnStyle.Danger:
                    b.BackColor = PrimaryDk;
                    b.ForeColor = OnPrimary;
                    b.FlatAppearance.BorderColor = PrimaryDk;
                    b.FlatAppearance.MouseOverBackColor = Primary;
                    break;
                default:
                    b.BackColor = Surface;
                    b.ForeColor = Text;
                    b.FlatAppearance.BorderColor = Border;
                    b.FlatAppearance.MouseOverBackColor = SurfaceHi;
                    break;
            }
            b.Click += onClick;
            return b;
        }

        public static FlowLayoutPanel MakeButtonsPanel()
        {
            var p = new FlowLayoutPanel
            {
                Dock          = DockStyle.Bottom,
                Height        = 50,
                Padding       = new Padding(12, 8, 12, 8),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor     = Color.FromArgb(22, 22, 26)
            };
            p.Paint += (s, e) =>
            {
                using var pen = new Pen(Border, 1);
                e.Graphics.DrawLine(pen, 0, 0, p.Width, 0);
                using var red = new Pen(Primary, 2);
                e.Graphics.DrawLine(red, 0, 1, 60, 1);
            };
            return p;
        }

        public static FlowLayoutPanel MakeParamsPanel()
        {
            var p = new FlowLayoutPanel
            {
                Dock          = DockStyle.Top,
                Height        = 46,
                Padding       = new Padding(12, 8, 12, 8),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor     = Color.FromArgb(22, 22, 26)
            };
            p.Paint += (s, e) =>
            {
                using var pen = new Pen(Border, 1);
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            };
            return p;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Bg;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Border;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowTemplate.Height = 28;

            // Заголовки колонок — чёрный с красной акцентной полосой
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 15, 18);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.Font = BodyBold;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(15, 15, 18);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersHeight = 36;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle.Font = Body;
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = PrimaryDk;
            grid.DefaultCellStyle.SelectionForeColor = OnPrimary;
            grid.DefaultCellStyle.Padding = new Padding(6, 2, 6, 2);

            grid.AlternatingRowsDefaultCellStyle.BackColor = SurfaceAlt;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Text;
        }

        public static Label SmallLabel(string t) => new()
        {
            Text = t, AutoSize = true, Padding = new Padding(0, 9, 4, 0),
            Font = BodyBold, ForeColor = TextDim
        };
    }
}
