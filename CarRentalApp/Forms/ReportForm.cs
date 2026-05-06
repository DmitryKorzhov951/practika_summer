using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Универсальный отчёт - простые карточки с тонкой рамкой.</summary>
    public class ReportForm : Form
    {
        public ReportForm(string title, string sql)
        {
            Text          = "Отчёт: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(700, 520);
            Font          = UI.Body;

            Controls.Add(UI.MakeHeader("Отчёт «" + title + "»"));

            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, BackColor = Color.White,
                Padding = new Padding(8)
            };
            Controls.Add(scroll);

            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);

            var dt = Db.Load(sql);

            Color[] back = { Color.FromArgb(248, 248, 248), Color.White };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var card = new Panel
                {
                    Width = 640,
                    Height = 22 + dt.Columns.Count * 18,
                    BackColor = back[i % 2],
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0, 2, 0, 2)
                };
                card.Controls.Add(new Label
                {
                    Text = "№ " + (i + 1),
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = SystemColors.ControlDarkDark,
                    AutoSize = true, Top = 2, Left = 6
                });
                int y = 20;
                foreach (DataColumn col in dt.Columns)
                {
                    card.Controls.Add(new Label
                    {
                        Text = col.ColumnName + ":",
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        AutoSize = false, Top = y, Left = 8, Width = 180, Height = 16
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]),
                        Font = new Font("Segoe UI", 8),
                        AutoSize = false, Top = y, Left = 195, Width = 430, Height = 16
                    });
                    y += 18;
                }
                scroll.Controls.Add(card);
            }
        }

        protected static string Format(object v)
        {
            if (v == null || v is System.DBNull) return "—";
            if (v is bool b)                       return b ? "Да" : "Нет";
            if (v is System.DateTime d)            return d.ToString("dd.MM.yyyy");
            if (v is decimal m)                    return m.ToString("N2");
            return v.ToString();
        }
    }
}
