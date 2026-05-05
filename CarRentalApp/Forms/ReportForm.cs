using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Универсальный отчёт - карточки с цветом и рамкой.</summary>
    public class ReportForm : Form
    {
        public ReportForm(string title, string sql)
        {
            Text          = "Отчёт: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(900, 640);

            Controls.Add(new Label
            {
                Text      = "Отчёт «" + title + "»",
                Dock      = DockStyle.Top, Height = 44,
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, BackColor = Color.White,
                Padding = new Padding(10)
            };
            Controls.Add(scroll);

            var btn = new Button { Text = "Закрыть", Dock = DockStyle.Bottom, Height = 36 };
            btn.Click += (s, e) => Close();
            Controls.Add(btn);

            var dt = Db.Load(sql);

            Color[] back   = { Color.FromArgb(245, 250, 255), Color.FromArgb(255, 248, 240) };
            Color[] border = { Color.SteelBlue,               Color.DarkOrange };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                int idx = i;
                var card = new Panel
                {
                    Width = 820, Height = 28 + dt.Columns.Count * 22,
                    BackColor = back[i % 2], Margin = new Padding(0, 4, 0, 4)
                };
                card.Paint += (s, e) =>
                {
                    using var p = new Pen(border[idx % 2], 2);
                    e.Graphics.DrawRectangle(p, 1, 1, card.Width - 3, card.Height - 3);
                };
                card.Controls.Add(new Label
                {
                    Text = "Запись № " + (i + 1),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = border[i % 2],
                    AutoSize = true, Top = 4, Left = 8
                });
                int y = 26;
                foreach (DataColumn col in dt.Columns)
                {
                    card.Controls.Add(new Label
                    {
                        Text = col.ColumnName + ":",
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        AutoSize = false, Top = y, Left = 12, Width = 220, Height = 20
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]),
                        Font = new Font("Segoe UI", 9),
                        AutoSize = false, Top = y, Left = 240, Width = 560, Height = 20
                    });
                    y += 22;
                }
                scroll.Controls.Add(card);
            }
        }

        private static string Format(object v)
        {
            if (v == null || v is System.DBNull)  return "—";
            if (v is bool b)                       return b ? "Да" : "Нет";
            if (v is System.DateTime d)            return d.ToString("dd.MM.yyyy");
            if (v is decimal m)                    return m.ToString("N2");
            return v.ToString();
        }
    }
}
