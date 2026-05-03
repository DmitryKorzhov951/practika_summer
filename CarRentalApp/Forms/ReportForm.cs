using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms
{
    /// <summary>
    /// Универсальная форма отчёта - содержит все поля кроме первичных ключей,
    /// записи выделяются цветом и рамкой. Поддерживает печать и предпросмотр.
    /// </summary>
    public class ReportForm : Form
    {
        private readonly DataTable _data;
        private readonly string _title;
        private readonly Panel _scroll = new() { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };

        public ReportForm(TableConfig cfg)
            : this("Отчёт: " + cfg.Title, LoadFromTable(cfg)) { }

        public ReportForm(QueryConfig cfg)
            : this("Отчёт: " + cfg.Title, LoadFromQuery(cfg)) { }

        public ReportForm(string title, DataTable data)
        {
            _title = title;
            _data  = data;

            Text = title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 700);
            MinimumSize = new Size(700, 500);

            var lblHeader = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 60, 120),
                ForeColor = Color.White,
                Dock      = DockStyle.Top,
                Height    = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var bottom = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 50, BackColor = Color.Gainsboro,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8)
            };
            var btnPrint = new Button { Text = "Печать", Width = 110, Height = 32 };
            btnPrint.Click += (s, e) => Print();
            var btnClose = new Button { Text = "Закрыть", Width = 110, Height = 32 };
            btnClose.Click += (s, e) => Close();
            bottom.Controls.AddRange(new Control[] { btnPrint, btnClose });

            Controls.Add(_scroll);
            Controls.Add(bottom);
            Controls.Add(lblHeader);

            BuildReport();
        }

        private static DataTable LoadFromTable(TableConfig cfg)
        {
            // Используем тот же SQL, что и табличная форма (с лукапами)
            var selectParts = cfg.Fields
                .Where(f => !f.IsPrimaryKey)
                .Select(f => f.Type == FieldType.Lookup
                    ? $"L_{f.Column}.{f.LookupNameCol} AS [{f.Caption}]"
                    : $"T.{f.Column} AS [{f.Caption}]")
                .ToList();
            var sql = "SELECT " + string.Join(", ", selectParts) + " FROM " + cfg.TableName + " T";
            foreach (var f in cfg.Fields.Where(x => x.Type == FieldType.Lookup))
            {
                var join = f.LookupNullable ? "LEFT JOIN" : "INNER JOIN";
                sql += $" {join} {f.LookupTable} L_{f.Column} ON T.{f.Column} = L_{f.Column}.{f.LookupKeyCol}";
            }
            return Db.LoadTable(sql);
        }

        private static DataTable LoadFromQuery(QueryConfig cfg)
        {
            var cols = cfg.Fields.Select(f => $"[{f.Column}] AS [{f.Caption}]");
            var sql = "SELECT " + string.Join(", ", cols) + " FROM " + cfg.ViewName;
            if (!string.IsNullOrEmpty(cfg.OrderBy)) sql += " ORDER BY " + cfg.OrderBy;
            return Db.LoadTable(sql);
        }

        protected void BuildReport()
        {
            _scroll.Controls.Clear();
            int y = 10;
            var altColors = new[] { Color.FromArgb(245, 250, 255), Color.FromArgb(255, 250, 240) };
            var borderColors = new[] { Color.FromArgb(80, 130, 200), Color.FromArgb(220, 140, 60) };

            for (int r = 0; r < _data.Rows.Count; r++)
            {
                var row = _data.Rows[r];
                var card = new Panel
                {
                    Width = _scroll.ClientSize.Width - 30,
                    Left  = 10,
                    Top   = y,
                    BackColor = altColors[r % 2],
                    BorderStyle = BorderStyle.None,
                    Padding = new Padding(10),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                int color = r;
                card.Paint += (s, e) =>
                {
                    using var pen = new Pen(borderColors[color % 2], 2);
                    e.Graphics.DrawRectangle(pen, 1, 1, card.Width - 3, card.Height - 3);
                };

                var lblNum = new Label
                {
                    Text = $"Запись № {r + 1}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = borderColors[r % 2],
                    AutoSize = true,
                    Top = 4, Left = 8
                };
                card.Controls.Add(lblNum);

                int innerY = 28;
                foreach (DataColumn col in _data.Columns)
                {
                    var lblK = new Label
                    {
                        Text = col.ColumnName + ":",
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        AutoSize = false, Width = 220, Height = 20,
                        Top = innerY, Left = 14, TextAlign = ContentAlignment.MiddleLeft
                    };
                    var lblV = new Label
                    {
                        Text = FormatValue(row[col]),
                        Font = new Font("Segoe UI", 9),
                        AutoSize = false, Top = innerY, Left = 240,
                        Width = card.Width - 260, Height = 20,
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    card.Controls.Add(lblK);
                    card.Controls.Add(lblV);
                    innerY += 22;
                }
                card.Height = innerY + 8;

                _scroll.Controls.Add(card);
                y += card.Height + 8;
            }

            if (_data.Rows.Count == 0)
            {
                _scroll.Controls.Add(new Label
                {
                    Text = "Нет данных для отображения",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true, Top = 10, Left = 10
                });
            }
        }

        private static string FormatValue(object v)
        {
            if (v == null || v is DBNull) return "—";
            if (v is bool b) return b ? "Да" : "Нет";
            if (v is DateTime dt) return dt.ToString("dd.MM.yyyy");
            if (v is decimal d) return d.ToString("N2");
            return v.ToString();
        }

        private void Print()
        {
            var pd = new PrintDocument();
            int rowIdx = 0;
            int colY = 0;

            pd.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                using var headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
                using var keyFont    = new Font("Segoe UI", 9, FontStyle.Bold);
                using var valFont    = new Font("Segoe UI", 9);
                using var pen        = new Pen(Color.Black, 1);

                if (colY == 0)
                {
                    g.DrawString(_title, headerFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
                    colY = e.MarginBounds.Top + 40;
                }

                while (rowIdx < _data.Rows.Count)
                {
                    var row = _data.Rows[rowIdx];
                    int cardH = 26 + _data.Columns.Count * 18;
                    if (colY + cardH > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        colY = e.MarginBounds.Top;
                        return;
                    }

                    g.DrawRectangle(pen, e.MarginBounds.Left, colY, e.MarginBounds.Width, cardH);
                    g.DrawString($"Запись № {rowIdx + 1}", keyFont, Brushes.DarkBlue, e.MarginBounds.Left + 4, colY + 4);
                    int y = colY + 22;
                    foreach (DataColumn col in _data.Columns)
                    {
                        g.DrawString(col.ColumnName + ":", keyFont, Brushes.Black, e.MarginBounds.Left + 8, y);
                        g.DrawString(FormatValue(row[col]), valFont, Brushes.Black, e.MarginBounds.Left + 220, y);
                        y += 18;
                    }
                    colY += cardH + 8;
                    rowIdx++;
                }
                e.HasMorePages = false;
            };

            using var dlg = new PrintPreviewDialog { Document = pd, Width = 900, Height = 700 };
            dlg.ShowDialog(this);
        }
    }
}
