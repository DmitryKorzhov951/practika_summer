using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Универсальный отчёт - карточки с цветной полосой слева.</summary>
    public class ReportForm : Form
    {
        public ReportForm(string title, string sql)
        {
            Text          = "Отчёт: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(760, 560);
            Font          = UI.Body;
            BackColor     = UI.Surface;

            Controls.Add(UI.MakeHeader("Отчёт «" + title + "»"));

            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                BackColor = UI.Surface,
                Padding = new Padding(12)
            };
            Controls.Add(scroll);

            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);

            var dt = Db.Load(sql);

            // палитра полос карточек (по индексу)
            Color[] strip = { UI.PrimaryLt, UI.Accent, Color.FromArgb(214, 158, 46),
                              Color.FromArgb(159, 122, 234), UI.Danger };

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                Color stripColor = strip[i % strip.Length];

                var card = new Panel
                {
                    Width = 680,
                    Height = 28 + dt.Columns.Count * 20,
                    BackColor = Color.White,
                    Margin = new Padding(0, 4, 0, 4)
                };
                // тонкая граница и цветная полоса слева
                card.Paint += (s, e) =>
                {
                    using var border = new Pen(Color.FromArgb(226, 232, 240));
                    e.Graphics.DrawRectangle(border, 0, 0, card.Width - 1, card.Height - 1);
                    using var br = new SolidBrush(stripColor);
                    e.Graphics.FillRectangle(br, 0, 0, 4, card.Height);
                };

                card.Controls.Add(new Label
                {
                    Text = "Запись № " + (i + 1),
                    Font = UI.BodyBold,
                    ForeColor = stripColor,
                    AutoSize = true, Top = 6, Left = 14
                });

                int y = 24;
                foreach (DataColumn col in dt.Columns)
                {
                    card.Controls.Add(new Label
                    {
                        Text = col.ColumnName + ":",
                        Font = UI.BodyBold,
                        ForeColor = UI.TextDim,
                        AutoSize = false, Top = y, Left = 14, Width = 200, Height = 18
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]),
                        Font = UI.Body,
                        ForeColor = Color.FromArgb(45, 55, 72),
                        AutoSize = false, Top = y, Left = 220, Width = 450, Height = 18
                    });
                    y += 20;
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
