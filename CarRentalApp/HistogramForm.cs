using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Гистограмма зарплат сотрудников по запросу «Отдел кадров».</summary>
    public class HistogramForm : Form
    {
        private readonly DataTable _dt;

        public HistogramForm()
        {
            Text          = "Гистограмма зарплат сотрудников";
            StartPosition = FormStartPosition.CenterParent;
            Size          = new Size(900, 560);

            Controls.Add(new Label
            {
                Text      = "Гистограмма заработной платы сотрудников",
                Dock      = DockStyle.Top, Height = 44,
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            _dt = Db.Load("SELECT FIO, Oklad, Dolzhnost FROM vw_OtdelKadrov ORDER BY Oklad DESC");

            var canvas = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            canvas.Paint  += Draw;
            canvas.Resize += (s, e) => canvas.Invalidate();
            Controls.Add(canvas);

            var btn = new Button { Text = "Закрыть", Dock = DockStyle.Bottom, Height = 36 };
            btn.Click += (s, e) => Close();
            Controls.Add(btn);
        }

        private void Draw(object s, PaintEventArgs e)
        {
            var g = e.Graphics; g.Clear(Color.White);
            if (_dt.Rows.Count == 0) return;

            var p = (Panel)s;
            int left = 240, top = 20, right = 80, bottom = 40;
            int W = p.Width - left - right, H = p.Height - top - bottom;
            if (W < 50 || H < 50) return;

            decimal max = 0;
            foreach (DataRow r in _dt.Rows) if ((decimal)r["Oklad"] > max) max = (decimal)r["Oklad"];

            int n = _dt.Rows.Count, h = Math.Max(14, (H - (n - 1) * 6) / n);
            Color[] colors =
            {
                Color.SteelBlue, Color.IndianRed, Color.MediumSeaGreen,
                Color.Goldenrod, Color.MediumPurple, Color.DarkOrange,
                Color.Teal, Color.Crimson, Color.OliveDrab, Color.SlateBlue
            };
            using var f = new Font("Segoe UI", 9);
            using var fb = new Font("Segoe UI", 9, FontStyle.Bold);

            // Оси
            g.DrawLine(Pens.Black, left, top, left, top + H);
            g.DrawLine(Pens.Black, left, top + H, left + W, top + H);

            for (int i = 0; i < n; i++)
            {
                var row = _dt.Rows[i];
                decimal v = (decimal)row["Oklad"];
                int bw = (int)(W * (double)v / (double)max);
                int y = top + i * (h + 6);

                using var br = new SolidBrush(colors[i % colors.Length]);
                g.FillRectangle(br, left + 1, y, bw, h);
                g.DrawRectangle(Pens.Black, left + 1, y, bw, h);

                string label = (string)row["FIO"] + "  [" + (string)row["Dolzhnost"] + "]";
                g.DrawString(label, f, Brushes.Black, 4, y + 2);
                g.DrawString(v.ToString("N0") + " ₽", fb, Brushes.Black, left + bw + 6, y + 2);
            }
        }
    }
}
