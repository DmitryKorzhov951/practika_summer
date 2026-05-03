using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms.Queries
{
    /// <summary>Табличная форма для запроса (view).</summary>
    public class QueryGridForm : Form
    {
        protected readonly QueryConfig Cfg;
        protected readonly DataGridView Grid = new();
        protected readonly BindingSource Bs  = new();
        protected readonly ComboBox CmbSort  = new();
        protected readonly ComboBox CmbFilterField = new();
        protected readonly TextBox  TxtFilterValue = new();
        protected readonly TextBox  TxtSearch = new();

        public QueryGridForm(QueryConfig cfg)
        {
            Cfg = cfg;
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

            var topPanel = BuildTopPanel();

            Grid.Dock = DockStyle.Fill;
            Grid.AllowUserToAddRows = false;
            Grid.ReadOnly = true;
            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            Grid.DataSource = Bs;

            var nav = new BindingNavigator(Bs)
            {
                Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null
            };

            var bottom = BuildButtonsPanel();

            Controls.Add(Grid);
            Controls.Add(bottom);
            Controls.Add(nav);
            Controls.Add(topPanel);
            Controls.Add(lblHeader);

            LoadData();
        }

        protected virtual TableLayoutPanel BuildTopPanel()
        {
            var p = new TableLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50, ColumnCount = 6, Padding = new Padding(8),
                BackColor = Color.WhiteSmoke
            };
            for (int i = 0; i < 6; i++) p.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));

            p.Controls.Add(new Label { Text = "Сортировка:", AutoSize = true, Padding = new Padding(0,6,0,0) }, 0, 0);
            CmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbSort.Dock = DockStyle.Fill;
            CmbSort.SelectedIndexChanged += (s, e) => ApplySort(true);
            p.Controls.Add(CmbSort, 1, 0);

            p.Controls.Add(new Label { Text = "Фильтр поле:", AutoSize = true, Padding = new Padding(0,6,0,0) }, 2, 0);
            CmbFilterField.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFilterField.Dock = DockStyle.Fill;
            CmbFilterField.SelectedIndexChanged += (s, e) => ApplyFilter();
            p.Controls.Add(CmbFilterField, 3, 0);

            TxtFilterValue.Dock = DockStyle.Fill;
            TxtFilterValue.TextChanged += (s, e) => ApplyFilter();
            p.Controls.Add(TxtFilterValue, 4, 0);

            TxtSearch.Dock = DockStyle.Fill;
            TxtSearch.TextChanged += (s, e) => ApplyFilter();
            p.Controls.Add(TxtSearch, 5, 0);

            return p;
        }

        protected virtual FlowLayoutPanel BuildButtonsPanel()
        {
            var bottom = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 50, BackColor = Color.Gainsboro,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8)
            };

            var btnFind = new Button { Text = "Поиск", Width = 100, Height = 32 };
            btnFind.Click += (s, e) => { TxtSearch.Focus(); TxtSearch.SelectAll(); };

            var btnReport = new Button { Text = "Открыть отчёт", Width = 150, Height = 32, BackColor = Color.FromArgb(80, 170, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnReport.Click += (s, e) => new ReportForm(Cfg).Show();

            var btnPage = new Button { Text = "Открыть страницу", Width = 170, Height = 32, BackColor = Color.FromArgb(80, 130, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnPage.Click += (s, e) => new PageForm(Cfg).Show();

            var btnClose = new Button { Text = "Закрыть", Width = 100, Height = 32, BackColor = Color.FromArgb(200, 80, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClose.Click += (s, e) => Close();

            // Для запроса "Отдел кадров" добавим кнопку гистограммы
            if (Cfg.ViewName == "vw_OtdelKadrov")
            {
                var btnHist = new Button { Text = "Гистограмма", Width = 130, Height = 32, BackColor = Color.FromArgb(230, 170, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnHist.Click += (s, e) => new HistogramForm().Show();
                bottom.Controls.Add(btnHist);
            }

            bottom.Controls.AddRange(new Control[] { btnFind, btnReport, btnPage, btnClose });
            return bottom;
        }

        protected virtual void LoadData()
        {
            try
            {
                var cols = Cfg.Fields.Select(f => $"[{f.Column}] AS [{f.Caption}]");
                var sql = "SELECT " + string.Join(", ", cols) + " FROM " + Cfg.ViewName;
                if (!string.IsNullOrEmpty(Cfg.OrderBy)) sql += " ORDER BY " + Cfg.OrderBy;
                var dt = Db.LoadTable(sql);
                Bs.DataSource = dt;
                FillCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCombos()
        {
            var captions = Cfg.Fields.Select(f => f.Caption).ToArray();
            CmbSort.Items.Clear();
            CmbFilterField.Items.Clear();
            CmbSort.Items.AddRange(captions);
            CmbFilterField.Items.AddRange(captions);
            if (captions.Length > 0)
            {
                CmbSort.SelectedIndex = 0;
                CmbFilterField.SelectedIndex = 0;
            }
        }

        private void ApplySort(bool asc)
        {
            if (CmbSort.SelectedItem == null) return;
            try { Bs.Sort = $"[{CmbSort.SelectedItem}] {(asc ? "ASC" : "DESC")}"; } catch { }
        }

        protected void ApplyFilter()
        {
            try
            {
                string filter = "";
                if (CmbFilterField.SelectedItem != null && !string.IsNullOrWhiteSpace(TxtFilterValue.Text))
                {
                    var col = CmbFilterField.SelectedItem.ToString();
                    var val = TxtFilterValue.Text.Replace("'", "''");
                    filter = $"CONVERT([{col}], 'System.String') LIKE '%{val}%'";
                }
                if (!string.IsNullOrWhiteSpace(TxtSearch.Text))
                {
                    var val = TxtSearch.Text.Replace("'", "''");
                    var parts = Grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{val}%'");
                    string s = "(" + string.Join(" OR ", parts) + ")";
                    filter = string.IsNullOrEmpty(filter) ? s : "(" + filter + ") AND " + s;
                }
                Bs.Filter = filter;
            }
            catch { }
        }
    }
}
