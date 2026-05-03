using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms.Tables
{
    /// <summary>Табличная форма для произвольной таблицы (с сортировкой, поиском и фильтрацией).</summary>
    public class TableGridForm : Form
    {
        private readonly TableConfig _cfg;
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();
        private readonly ComboBox _cmbSortField = new();
        private readonly ComboBox _cmbFilterField = new();
        private readonly TextBox  _txtFilterValue = new();
        private readonly TextBox  _txtSearch = new();

        public TableGridForm(TableConfig cfg)
        {
            _cfg = cfg;
            Text = "Таблица: " + cfg.Title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 640);
            MinimumSize = new Size(800, 500);

            // ---- заголовок ----
            var lblHeader = new Label
            {
                Text      = "Табличная форма: " + cfg.Title,
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 60, 120),
                ForeColor = Color.White,
                Dock      = DockStyle.Top,
                Height    = 44,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ---- панель управления (сортировка, поиск, фильтр) ----
            var topPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top, Height = 80, ColumnCount = 6, RowCount = 2,
                Padding = new Padding(8), BackColor = Color.WhiteSmoke
            };
            for (int i = 0; i < 6; i++) topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));

            // строка 1: сортировка + поиск
            topPanel.Controls.Add(new Label { Text = "Сортировка по:", AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(0,6,0,0) }, 0, 0);
            _cmbSortField.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbSortField.Dock = DockStyle.Fill;
            _cmbSortField.SelectedIndexChanged += (s,e) => ApplySort();
            topPanel.Controls.Add(_cmbSortField, 1, 0);

            var btnSortAsc = new Button { Text = "▲ A→Я", Dock = DockStyle.Fill };
            btnSortAsc.Click += (s,e) => ApplySort(asc: true);
            topPanel.Controls.Add(btnSortAsc, 2, 0);

            var btnSortDesc = new Button { Text = "▼ Я→A", Dock = DockStyle.Fill };
            btnSortDesc.Click += (s,e) => ApplySort(asc: false);
            topPanel.Controls.Add(btnSortDesc, 3, 0);

            topPanel.Controls.Add(new Label { Text = "Поиск:", AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(0,6,0,0) }, 4, 0);
            _txtSearch.Dock = DockStyle.Fill;
            _txtSearch.TextChanged += (s,e) => ApplyFilter();
            topPanel.Controls.Add(_txtSearch, 5, 0);

            // строка 2: фильтр по полю
            topPanel.Controls.Add(new Label { Text = "Фильтр по полю:", AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(0,6,0,0) }, 0, 1);
            _cmbFilterField.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbFilterField.Dock = DockStyle.Fill;
            _cmbFilterField.SelectedIndexChanged += (s,e) => ApplyFilter();
            topPanel.Controls.Add(_cmbFilterField, 1, 1);

            topPanel.Controls.Add(new Label { Text = "Значение содержит:", AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(0,6,0,0) }, 2, 1);
            _txtFilterValue.Dock = DockStyle.Fill;
            _txtFilterValue.TextChanged += (s,e) => ApplyFilter();
            topPanel.Controls.Add(_txtFilterValue, 3, 1);

            var btnReset = new Button { Text = "Сброс фильтров", Dock = DockStyle.Fill };
            btnReset.Click += (s,e) => { _txtFilterValue.Clear(); _txtSearch.Clear(); _bs.RemoveFilter(); };
            topPanel.Controls.Add(btnReset, 4, 1);

            var btnRefresh = new Button { Text = "Обновить", Dock = DockStyle.Fill };
            btnRefresh.Click += (s,e) => LoadData();
            topPanel.Controls.Add(btnRefresh, 5, 1);

            // ---- сетка ----
            _grid.Dock = DockStyle.Fill;
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.ReadOnly = true;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.RowHeadersWidth = 30;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;

            // ---- нижняя панель (навигация и кнопки) ----
            var nav = new BindingNavigator(_bs)
            {
                Dock = DockStyle.Bottom,
                AddNewItem = null,
                DeleteItem = null
            };

            var bottom = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 50, BackColor = Color.Gainsboro,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8)
            };

            var btnFind = new Button { Text = "Поиск", Width = 110, Height = 32 };
            btnFind.Click += (s, e) => { _txtSearch.Focus(); _txtSearch.SelectAll(); };

            var btnReport = new Button { Text = "Открыть отчёт", Width = 150, Height = 32, BackColor = Color.FromArgb(80, 170, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnReport.Click += (s, e) => new ReportForm(cfg).Show();

            var btnPage = new Button { Text = "Открыть страницу", Width = 170, Height = 32, BackColor = Color.FromArgb(80, 130, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnPage.Click += (s, e) => new PageForm(cfg).Show();

            var btnClose = new Button { Text = "Закрыть", Width = 110, Height = 32, BackColor = Color.FromArgb(200, 80, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClose.Click += (s, e) => Close();

            bottom.Controls.AddRange(new Control[] { btnFind, btnReport, btnPage, btnClose });

            Controls.Add(_grid);
            Controls.Add(bottom);
            Controls.Add(nav);
            Controls.Add(topPanel);
            Controls.Add(lblHeader);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dt = Db.LoadTable(BuildSelectSql());
                _bs.DataSource = dt;
                ApplyColumnHeaders();
                FillFieldCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildSelectSql()
        {
            // Для лукапов добавляем JOIN'ы и подменяем коды на имена.
            var selectParts = _cfg.Fields
                .Where(f => !f.IsPrimaryKey)
                .Select(f => f.Type == FieldType.Lookup
                    ? $"L_{f.Column}.{f.LookupNameCol} AS [{f.Caption}]"
                    : $"T.{f.Column} AS [{f.Caption}]")
                .ToList();

            var sql = "SELECT " + string.Join(", ", selectParts) + " FROM " + _cfg.TableName + " T";
            foreach (var f in _cfg.Fields.Where(x => x.Type == FieldType.Lookup))
            {
                var join = f.LookupNullable ? "LEFT JOIN" : "INNER JOIN";
                sql += $" {join} {f.LookupTable} L_{f.Column} ON T.{f.Column} = L_{f.Column}.{f.LookupKeyCol}";
            }
            return sql;
        }

        private void ApplyColumnHeaders()
        {
            // Имена колонок уже = caption, дополнительная настройка не нужна
            foreach (DataGridViewColumn col in _grid.Columns)
                col.HeaderText = col.Name;
        }

        private void FillFieldCombos()
        {
            var captions = _cfg.Fields.Where(f => !f.IsPrimaryKey).Select(f => f.Caption).ToArray();
            _cmbSortField.Items.Clear();
            _cmbFilterField.Items.Clear();
            _cmbSortField.Items.AddRange(captions);
            _cmbFilterField.Items.AddRange(captions);
            if (captions.Length > 0)
            {
                _cmbSortField.SelectedIndex = 0;
                _cmbFilterField.SelectedIndex = 0;
            }
        }

        private void ApplySort(bool? asc = null)
        {
            if (_cmbSortField.SelectedItem == null) return;
            string col = _cmbSortField.SelectedItem.ToString();
            string dir = asc == false ? "DESC" : "ASC";
            try { _bs.Sort = $"[{col}] {dir}"; } catch { }
        }

        private void ApplyFilter()
        {
            try
            {
                string filter = "";

                // фильтр по выбранному полю
                if (_cmbFilterField.SelectedItem != null && !string.IsNullOrWhiteSpace(_txtFilterValue.Text))
                {
                    string col = _cmbFilterField.SelectedItem.ToString();
                    string val = _txtFilterValue.Text.Replace("'", "''");
                    filter = $"CONVERT([{col}], 'System.String') LIKE '%{val}%'";
                }

                // глобальный поиск по всем полям
                if (!string.IsNullOrWhiteSpace(_txtSearch.Text))
                {
                    string val = _txtSearch.Text.Replace("'", "''");
                    var parts = _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{val}%'");
                    string searchExpr = "(" + string.Join(" OR ", parts) + ")";
                    filter = string.IsNullOrEmpty(filter) ? searchExpr : "(" + filter + ") AND " + searchExpr;
                }

                _bs.Filter = filter;
            }
            catch { }
        }
    }
}
