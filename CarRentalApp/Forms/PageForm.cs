using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms
{
    /// <summary>"Страница" - представление в виде карточек на форме (read-only).</summary>
    public class PageForm : Form
    {
        public PageForm(TableConfig cfg) : this("Страница: " + cfg.Title, LoadFromTable(cfg)) { }
        public PageForm(QueryConfig cfg) : this("Страница: " + cfg.Title, LoadFromQuery(cfg)) { }

        public PageForm(string title, DataTable dt)
        {
            Text = title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 640);

            var lblHeader = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(60, 100, 160),
                ForeColor = Color.White,
                Dock      = DockStyle.Top, Height = 44,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                DataSource = dt,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(245, 250, 255) }
            };

            var btnClose = new Button { Text = "Закрыть", Dock = DockStyle.Bottom, Height = 36 };
            btnClose.Click += (s, e) => Close();

            Controls.Add(grid);
            Controls.Add(btnClose);
            Controls.Add(lblHeader);
        }

        private static DataTable LoadFromTable(TableConfig cfg)
        {
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
    }
}
