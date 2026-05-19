using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Отчёт - тёмные карточки с цветной полосой слева.</summary>
    public class ReportForm : Form
    {
        public ReportForm(string title, string sql, string poster = null)
        {
            Text          = "Отчёт: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(820, 600);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeBanner("Отчёт «" + title + "»", poster));

            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                BackColor = UI.Bg,
                Padding = new Padding(16)
            };
            Controls.Add(scroll);

            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);

            var dt = Db.Load(sql);

            Color[] strip =
            {
                Color.FromArgb(229,  57,  53), Color.FromArgb(255, 152,   0),
                Color.FromArgb(255, 193,   7), Color.FromArgb(124, 179,  66),
                Color.FromArgb( 41, 182, 246), Color.FromArgb(171,  71, 188)
            };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                Color stripColor = strip[i % strip.Length];

                var card = new Panel
                {
                    Width = 740,
                    Height = 32 + dt.Columns.Count * 22,
                    BackColor = UI.Surface,
                    Margin = new Padding(0, 4, 0, 4)
                };
                card.Paint += (s, e) =>
                {
                    using var border = new Pen(UI.Border);
                    e.Graphics.DrawRectangle(border, 0, 0, card.Width - 1, card.Height - 1);
                    using var br = new SolidBrush(stripColor);
                    e.Graphics.FillRectangle(br, 0, 0, 5, card.Height);
                };

                card.Controls.Add(new Label
                {
                    Text = "ЗАПИСЬ № " + (i + 1),
                    Font = UI.BodyBold,
                    ForeColor = stripColor,
                    BackColor = Color.Transparent,
                    AutoSize = true, Top = 6, Left = 16
                });

                int y = 28;
                foreach (DataColumn col in dt.Columns)
                {
                    card.Controls.Add(new Label
                    {
                        Text = col.ColumnName + ":",
                        Font = UI.BodyBold,
                        ForeColor = UI.TextDim,
                        BackColor = Color.Transparent,
                        AutoSize = false, Top = y, Left = 16, Width = 220, Height = 20
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]),
                        Font = UI.Body,
                        ForeColor = UI.Text,
                        BackColor = Color.Transparent,
                        AutoSize = false, Top = y, Left = 240, Width = 480, Height = 20
                    });
                    y += 22;
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
