using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Гистограмма зарплат сотрудников.</summary>
    public class HistogramForm : Form
    {
        private readonly DataTable _dt;

        public HistogramForm()
        {
            Text          = "Гистограмма зарплат";
            StartPosition = FormStartPosition.CenterParent;
            Size          = new Size(780, 460);
            Font          = UI.Body;

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

        private void Draw(object s, PaintEventArgs e)
        {
            var g = e.Graphics; g.Clear(Color.White);
            if (_dt.Rows.Count == 0) return;

            var p = (Panel)s;
            int left = 220, top = 12, right = 70, bottom = 24;
            int W = p.Width - left - right, H = p.Height - top - bottom;
            if (W < 50 || H < 50) return;

            decimal max = 0;
            foreach (DataRow r in _dt.Rows) if ((decimal)r["Oklad"] > max) max = (decimal)r["Oklad"];

            int n = _dt.Rows.Count, h = Math.Max(12, (H - (n - 1) * 4) / n);
            using var f = new Font("Segoe UI", 8);
            using var fb = new Font("Segoe UI", 8, FontStyle.Bold);
            using var br = new SolidBrush(Color.SteelBlue);

            g.DrawLine(Pens.Black, left, top, left, top + H);
            g.DrawLine(Pens.Black, left, top + H, left + W, top + H);

            for (int i = 0; i < n; i++)
            {
                var row = _dt.Rows[i];
                decimal v = (decimal)row["Oklad"];
                int bw = (int)(W * (double)v / (double)max);
                int y = top + i * (h + 4);

                g.FillRectangle(br, left + 1, y, bw, h);
                g.DrawRectangle(Pens.Black, left + 1, y, bw, h);

                string label = (string)row["FIO"] + " [" + (string)row["Dolzhnost"] + "]";
                g.DrawString(label, f, Brushes.Black, 4, y + 1);
                g.DrawString(v.ToString("N0"), fb, Brushes.Black, left + bw + 4, y + 1);
            }
        }
    }
}
