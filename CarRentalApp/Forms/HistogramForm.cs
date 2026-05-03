using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Форма с гистограммой заработной платы сотрудников ("Отдел кадров").</summary>
    public class HistogramForm : Form
    {
        private readonly Panel _chartPanel;
        private List<(string FIO, decimal Oklad, string Dolzhnost)> _data = new();

        public HistogramForm()
        {
            Text            = "Гистограмма заработной платы сотрудников";
            StartPosition   = FormStartPosition.CenterParent;
            Size            = new Size(900, 600);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize     = new Size(700, 450);

            var lblHeader = new Label
            {
                Text      = "Гистограмма заработной платы сотрудников (запрос «Отдел кадров»)",
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize  = false,
                Dock      = DockStyle.Top,
                Height    = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(30, 60, 120),
                ForeColor = Color.White
            };

            _chartPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            _chartPanel.Paint += ChartPanel_Paint;
            _chartPanel.Resize += (s, e) => _chartPanel.Invalidate();

            var btnClose = new Button
            {
                Text   = "Закрыть",
                Dock   = DockStyle.Bottom,
                Height = 36,
                Font   = new Font("Segoe UI", 10)
            };
            btnClose.Click += (s, e) => Close();

            Controls.Add(_chartPanel);
            Controls.Add(lblHeader);
            Controls.Add(btnClose);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dt = Db.LoadTable("SELECT FIO, Oklad, Dolzhnost FROM vw_OtdelKadrov ORDER BY Oklad DESC");
                _data.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    _data.Add(((string)r["FIO"],
                               (decimal)r["Oklad"],
                               (string)r["Dolzhnost"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChartPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (_data == null || _data.Count == 0)
            {
                g.DrawString("Нет данных", new Font("Segoe UI", 12), Brushes.Gray, 20, 20);
                return;
            }

            int marginLeft = 220, marginTop = 30, marginRight = 80, marginBottom = 40;
            int chartW = _chartPanel.ClientSize.Width  - marginLeft - marginRight;
            int chartH = _chartPanel.ClientSize.Height - marginTop  - marginBottom;
            if (chartW <= 50 || chartH <= 50) return;

            decimal maxOklad = _data.Max(d => d.Oklad);
            int n = _data.Count;
            int barH = Math.Max(14, (chartH - (n - 1) * 6) / n);

            using var axisPen   = new Pen(Color.Black, 2);
            using var gridPen   = new Pen(Color.LightGray) { DashStyle = DashStyle.Dash };
            using var labelFont = new Font("Segoe UI", 9);
            using var valueFont = new Font("Segoe UI", 9, FontStyle.Bold);

            // Оси
            g.DrawLine(axisPen, marginLeft, marginTop, marginLeft, marginTop + chartH);
            g.DrawLine(axisPen, marginLeft, marginTop + chartH, marginLeft + chartW, marginTop + chartH);

            // Сетка по X (5 шагов)
            for (int i = 1; i <= 5; i++)
            {
                int x = marginLeft + chartW * i / 5;
                g.DrawLine(gridPen, x, marginTop, x, marginTop + chartH);
                decimal v = maxOklad * i / 5m;
                g.DrawString(v.ToString("N0"), labelFont, Brushes.Black,
                    x - 20, marginTop + chartH + 4);
            }

            Color[] palette =
            {
                Color.FromArgb(70, 130, 200),  Color.FromArgb(220, 90, 90),
                Color.FromArgb(80, 170, 100),  Color.FromArgb(230, 170, 60),
                Color.FromArgb(150, 100, 200), Color.FromArgb(60, 180, 180),
                Color.FromArgb(200, 120, 60),  Color.FromArgb(120, 160, 60),
                Color.FromArgb(180, 80, 140),  Color.FromArgb(60, 100, 160)
            };

            for (int i = 0; i < n; i++)
            {
                var item = _data[i];
                int y = marginTop + i * (barH + 6);
                int barW = (int)(chartW * (double)item.Oklad / (double)maxOklad);
                using var brush = new SolidBrush(palette[i % palette.Length]);
                g.FillRectangle(brush, marginLeft + 1, y, barW, barH);
                g.DrawRectangle(Pens.Black, marginLeft + 1, y, barW, barH);

                // ФИО + должность слева
                string label = $"{Trim(item.FIO, 22)}\n[{Trim(item.Dolzhnost, 20)}]";
                g.DrawString(label, labelFont, Brushes.Black,
                    new RectangleF(4, y - 2, marginLeft - 8, barH + 4));

                // Значение оклада справа от полосы
                g.DrawString(item.Oklad.ToString("N0") + " ₽", valueFont, Brushes.Black,
                    marginLeft + barW + 6, y + (barH - 14) / 2);
            }
        }

        private static string Trim(string s, int max) =>
            string.IsNullOrEmpty(s) ? "" : (s.Length <= max ? s : s.Substring(0, max - 1) + "…");
    }
}
