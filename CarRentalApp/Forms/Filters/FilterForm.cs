using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms.Filters
{
    /// <summary>Форма фильтра по запросу.</summary>
    public class FilterForm : Form
    {
        private readonly FilterConfig _cfg;
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();
        private readonly Control _filterControl;

        public FilterForm(FilterConfig cfg)
        {
            _cfg = cfg;
            Text = cfg.Title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 640);
            MinimumSize = new Size(800, 500);

            var lblHeader = new Label
            {
                Text      = cfg.Title,
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 60, 120),
                ForeColor = Color.White,
                Dock      = DockStyle.Top,
                Height    = 44,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var top = new TableLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50, ColumnCount = 4, Padding = new Padding(8),
                BackColor = Color.WhiteSmoke
            };
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,  100));

            top.Controls.Add(new Label
            {
                Text = cfg.FilterCaption, AutoSize = true,
                Padding = new Padding(0,8,0,0), Font = new Font("Segoe UI", 10, FontStyle.Bold)
            }, 0, 0);

            _filterControl = FilterDataLoader.BuildFilterControl(cfg);
            top.Controls.Add(_filterControl, 1, 0);

            var btnApply = new Button
            {
                Text = "Применить", Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(80, 170, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnApply.Click += (s, e) => LoadData(applyFilter: true);
            top.Controls.Add(btnApply, 2, 0);

            var btnReset = new Button { Text = "Сброс (показать всё)", Dock = DockStyle.Fill };
            btnReset.Click += (s, e) => LoadData(applyFilter: false);
            top.Controls.Add(btnReset, 3, 0);

            _grid.Dock = DockStyle.Fill;
            _grid.AllowUserToAddRows = false;
            _grid.ReadOnly = true;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;

            var nav = new BindingNavigator(_bs)
            {
                Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null
            };

            var bottom = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 50, BackColor = Color.Gainsboro,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8)
            };

            var btnReport = new Button
            {
                Text = "Открыть отчёт", Width = 150, Height = 32,
                BackColor = Color.FromArgb(80, 170, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnReport.Click += (s, e) =>
                new FilterReportForm(_cfg, FilterDataLoader.GetValue(_cfg, _filterControl)).Show();

            var btnPage = new Button
            {
                Text = "Открыть страницу", Width = 170, Height = 32,
                BackColor = Color.FromArgb(80, 130, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnPage.Click += (s, e) =>
            {
                var data = FilterDataLoader.LoadData(_cfg, FilterDataLoader.GetValue(_cfg, _filterControl));
                new PageForm("Страница (фильтр): " + _cfg.Title, data).Show();
            };

            var btnClose = new Button
            {
                Text = "Закрыть", Width = 110, Height = 32,
                BackColor = Color.FromArgb(200, 80, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnClose.Click += (s, e) => Close();
            bottom.Controls.AddRange(new Control[] { btnReport, btnPage, btnClose });

            Controls.Add(_grid);
            Controls.Add(bottom);
            Controls.Add(nav);
            Controls.Add(top);
            Controls.Add(lblHeader);

            LoadData(applyFilter: false);
        }

        private void LoadData(bool applyFilter)
        {
            try
            {
                var val = applyFilter ? FilterDataLoader.GetValue(_cfg, _filterControl) : null;
                _bs.DataSource = FilterDataLoader.LoadData(_cfg, val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>Отчёт по фильтру (с заданным значением фильтра или без).</summary>
    public class FilterReportForm : ReportForm
    {
        public FilterReportForm(FilterConfig cfg)
            : base("Отчёт (фильтр): " + cfg.Title, FilterDataLoader.LoadData(cfg, null)) { }

        public FilterReportForm(FilterConfig cfg, object filterValue)
            : base("Отчёт (фильтр): " + cfg.Title, FilterDataLoader.LoadData(cfg, filterValue)) { }
    }

    /// <summary>Утилитный класс для работы с данными фильтров.</summary>
    internal static class FilterDataLoader
    {
        public static Control BuildFilterControl(FilterConfig cfg)
        {
            switch (cfg.ControlType)
            {
                case FilterControlType.Dropdown:
                {
                    var cb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
                    var dt = Db.LoadTable(cfg.LookupSql);
                    foreach (DataRow r in dt.Rows) cb.Items.Add(r[0]?.ToString() ?? "");
                    if (cb.Items.Count > 0) cb.SelectedIndex = 0;
                    return cb;
                }
                case FilterControlType.Date:
                    return new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
                case FilterControlType.Bit:
                {
                    var cb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
                    cb.Items.Add(cfg.BitTrueText);
                    cb.Items.Add(cfg.BitFalseText);
                    cb.SelectedIndex = 0;
                    return cb;
                }
            }
            return new Label();
        }

        public static object GetValue(FilterConfig cfg, Control ctl)
        {
            return cfg.ControlType switch
            {
                FilterControlType.Dropdown => (ctl as ComboBox)?.SelectedItem,
                FilterControlType.Date     => (ctl as DateTimePicker)?.Value.Date,
                FilterControlType.Bit      => (ctl as ComboBox)?.SelectedIndex == 0,
                _ => null
            };
        }

        public static DataTable LoadData(FilterConfig cfg, object filterValue)
        {
            var cols = cfg.Fields.Select(f => $"[{f.Column}] AS [{f.Caption}]");
            var sql = "SELECT " + string.Join(", ", cols) + " FROM " + cfg.ViewName;

            SqlParameter prm = null;
            string where = null;
            if (filterValue != null)
            {
                switch (cfg.ControlType)
                {
                    case FilterControlType.Dropdown:
                        where = $"[{cfg.FilterColumn}] = @v";
                        prm = new SqlParameter("@v", filterValue);
                        break;
                    case FilterControlType.Date:
                        where = "(DataVydachi = @v OR DataVozvrata = @v)";
                        prm = new SqlParameter("@v", (DateTime)filterValue);
                        break;
                    case FilterControlType.Bit:
                        where = $"[{cfg.FilterColumn}] = @v";
                        prm = new SqlParameter("@v", (bool)filterValue ? 1 : 0);
                        break;
                }
            }

            if (where != null) sql += " WHERE " + where;
            if (!string.IsNullOrEmpty(cfg.OrderBy)) sql += " ORDER BY " + cfg.OrderBy;

            return prm != null ? Db.LoadTable(sql, prm) : Db.LoadTable(sql);
        }
    }
}
