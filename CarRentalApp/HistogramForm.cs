using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Гистограмма зарплат сотрудников (запрос «Отдел кадров»).</summary>
    public class HistogramForm : Form
    {
        private readonly DataTable _dt;

        public HistogramForm()
        {
            Text          = "Гистограмма зарплат";
            StartPosition = FormStartPosition.CenterParent;
            Size          = new Size(880, 540);
            Font          = UI.Body;
            BackColor     = UI.Surface;

            Controls.Add(UI.MakeHeader("Гистограмма заработной платы сотрудников"));

            _dt = Db.Load("SELECT FIO, Oklad, Dolzhnost FROM vw_OtdelKadrov ORDER BY Oklad DESC");

            var canvas = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            canvas.Paint  += Draw;
            canvas.Resize += (s, e) => canvas.Invalidate();
            Controls.Add(canvas);

            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);
        }

        private static readonly Color[] Palette =
        {
            Color.FromArgb( 49, 130, 206), // синий
            Color.FromArgb( 56, 161, 105), // зелёный
            Color.FromArgb(214, 158,  46), // жёлтый
            Color.FromArgb(159, 122, 234), // фиолетовый
            Color.FromArgb(229,  62,  62), // красный
            Color.FromArgb( 49, 151, 149), // бирюзовый
        };

        private void Draw(object s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            if (_dt.Rows.Count == 0) return;

            var p = (Panel)s;
            int left = 240, top = 20, right = 90, bottom = 50;
            int W = p.Width - left - right, H = p.Height - top - bottom;
            if (W < 50 || H < 50) return;

            decimal max = 0;
            foreach (DataRow r in _dt.Rows) if ((decimal)r["Oklad"] > max) max = (decimal)r["Oklad"];

            int n = _dt.Rows.Count;
            int h = Math.Max(14, (H - (n - 1) * 6) / n);

            using var labelFont = new Font("Segoe UI", 9);
            using var boldFont  = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            using var axisPen   = new Pen(Color.FromArgb(160, 174, 192), 1.5f);
            using var gridPen   = new Pen(Color.FromArgb(226, 232, 240)) { DashStyle = DashStyle.Dash };

            // Сетка по X (5 шагов) и подписи
            for (int i = 1; i <= 5; i++)
            {
                int x = left + W * i / 5;
                g.DrawLine(gridPen, x, top, x, top + H);
                decimal v = max * i / 5m;
                g.DrawString(v.ToString("N0"), labelFont, Brushes.Gray, x - 24, top + H + 4);
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
                Color c2 = ControlPaint.Light(c1, 0.4f);

                // Полоса с лёгким градиентом
                if (bw > 1)
                {
                    var rect = new Rectangle(left + 1, y, bw, h);
                    using var br = new LinearGradientBrush(rect, c1, c2, LinearGradientMode.Vertical);
                    g.FillRectangle(br, rect);
                    using var bp = new Pen(c1);
                    g.DrawRectangle(bp, rect);
                }

                // ФИО + должность слева
                string fio = (string)row["FIO"];
                string dlz = "[" + (string)row["Dolzhnost"] + "]";
                g.DrawString(fio, boldFont,  Brushes.Black, 8, y + (h - 14) / 2 - 6);
                g.DrawString(dlz, labelFont, Brushes.Gray,  8, y + (h - 14) / 2 + 8);

                // Сумма справа
                g.DrawString(v.ToString("N0") + " ₽", boldFont, Brushes.Black, left + bw + 6, y + (h - 14) / 2);
            }
        }
    }
}
