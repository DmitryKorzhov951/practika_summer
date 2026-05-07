using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Гистограмма зарплат сотрудников (тёмная тема).</summary>
    public class HistogramForm : Form
    {
        private readonly DataTable _dt;

        public HistogramForm()
        {
            Text          = "Гистограмма зарплат";
            StartPosition = FormStartPosition.CenterParent;
            Size          = new Size(880, 540);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("Гистограмма заработной платы сотрудников"));

            _dt = Db.Load("SELECT FIO, Oklad, Dolzhnost FROM vw_OtdelKadrov ORDER BY Oklad DESC");

            var canvas = new Panel { Dock = DockStyle.Fill, BackColor = UI.Bg };
            canvas.Paint  += Draw;
            canvas.Resize += (s, e) => canvas.Invalidate();
            Controls.Add(canvas);

            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);
        }

        private static readonly Color[] Palette =
        {
            Color.FromArgb(229,  57,  53),  // red
            Color.FromArgb(255, 152,   0),  // orange
            Color.FromArgb(255, 193,   7),  // amber
            Color.FromArgb(124, 179,  66),  // green
            Color.FromArgb( 41, 182, 246),  // blue
            Color.FromArgb(171,  71, 188),  // purple
        };

        private void Draw(object s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(UI.Bg);
            if (_dt.Rows.Count == 0) return;

            var p = (Panel)s;
            int left = 240, top = 24, right = 100, bottom = 56;
            int W = p.Width - left - right, H = p.Height - top - bottom;
            if (W < 50 || H < 50) return;

            decimal max = 0;
            foreach (DataRow r in _dt.Rows) if ((decimal)r["Oklad"] > max) max = (decimal)r["Oklad"];

            int n = _dt.Rows.Count;
            int h = Math.Max(14, (H - (n - 1) * 6) / n);

            using var labelFont = new Font("Segoe UI", 9);
            using var boldFont  = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            using var axisPen   = new Pen(UI.Border, 1.5f);
            using var gridPen   = new Pen(Color.FromArgb(60, 60, 66)) { DashStyle = DashStyle.Dash };

            // Сетка
            for (int i = 1; i <= 5; i++)
            {
                int x = left + W * i / 5;
                g.DrawLine(gridPen, x, top, x, top + H);
                decimal v = max * i / 5m;
                using var txt = new SolidBrush(UI.TextDim);
                g.DrawString(v.ToString("N0"), labelFont, txt, x - 24, top + H + 6);
            }
            g.DrawLine(axisPen, left, top, left, top + H);
            g.DrawLine(axisPen, left, top + H, left + W, top + H);

            for (int i = 0; i < n; i++)
            {
                var row = _dt.Rows[i];
                decimal v = (decimal)row["Oklad"];
                int bw = (int)(W * (double)v / (double)max);
                int y = top + i * (h + 6);

                Color c1 = Palette[i % Palette.Length];
                Color c2 = ControlPaint.Dark(c1, 0.2f);

                if (bw > 1)
                {
                    var rect = new Rectangle(left + 1, y, bw, h);
                    using var br = new LinearGradientBrush(rect, c1, c2, LinearGradientMode.Vertical);
                    g.FillRectangle(br, rect);
                }

                string fio = (string)row["FIO"];
                string dlz = "[" + (string)row["Dolzhnost"] + "]";
                using var fioBr = new SolidBrush(UI.Text);
                using var dlzBr = new SolidBrush(UI.TextDim);
                g.DrawString(fio, boldFont,  fioBr, 8, y + (h - 14) / 2 - 6);
                g.DrawString(dlz, labelFont, dlzBr, 8, y + (h - 14) / 2 + 8);

                using var sumBr = new SolidBrush(c1);
                g.DrawString(v.ToString("N0") + " ₽", boldFont, sumBr, left + bw + 8, y + (h - 14) / 2);
            }
        }
    }
}
