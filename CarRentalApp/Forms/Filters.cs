using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>
    /// Универсальная форма фильтра. Содержит панель параметров,
    /// сетку с данными и кнопки.
    /// </summary>
    public abstract class FilterFormBase : Form
    {
        protected readonly DataGridView _grid = new();
        protected readonly BindingSource _bs = new();
        protected readonly string _title;

        protected FilterFormBase(string title)
        {
            _title = title;
            Text = "Фильтр: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 600);

            Controls.Add(new Label
            {
                Text = "Фильтр «" + title + "»",
                Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Панель параметра фильтра — заполняют наследники
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 50, Padding = new Padding(8), BackColor = Color.WhiteSmoke };
            BuildFilterPanel(top);
            Controls.Add(top);

            _grid.Dock = DockStyle.Fill; _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Применить", Color.MediumSeaGreen, (s,e) => Reload()));
            btns.Controls.Add(B("Сброс",     Color.Orange,         (s,e) => ResetAndReload()));
            btns.Controls.Add(B("Отчёт",     Color.SteelBlue,      (s,e) => ShowReport()));
            btns.Controls.Add(B("Закрыть",   Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);

            Reload(); // изначально без фильтра
        }

        protected abstract void BuildFilterPanel(FlowLayoutPanel panel);

        /// <summary>SQL и параметр текущего фильтра.</summary>
        protected abstract (string sql, SqlParameter prm) BuildSql(bool reset);

        protected void Reload() => Apply(reset: false);
        protected void ResetAndReload() => Apply(reset: true);

        private void Apply(bool reset)
        {
            try
            {
                var (sql, prm) = BuildSql(reset);
                _bs.DataSource = prm == null ? Db.Load(sql) : Db.Load(sql, prm);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\n" + ex.Message); }
        }

        protected abstract void ShowReport();

        protected static Button B(string t, Color c, EventHandler h) { var b = new Button { Text = t, Width = 130, Height = 32, BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; b.Click += h; return b; }
    }

    // =================== 1. Сотрудники по должности ===================
    public class FilterByDolzhnost : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByDolzhnost() : base("Сотрудники по должности") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(new Label { Text = "Должность:", AutoSize = true, Padding = new Padding(0,10,4,0), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 250 };
            foreach (DataRow r in Db.Load("SELECT Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie").Rows) _cmb.Items.Add(r[0]);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string baseSql = OtdelKadrovForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (baseSql, null);
            return (baseSql + " WHERE Dolzhnost = @v", new SqlParameter("@v", _cmb.SelectedItem));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Сотрудники по должности", sql, prm).Show();
        }
    }

    // =================== 2. Автомобили по марке ===================
    public class FilterByMarka : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByMarka() : base("Автомобили по марке") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(new Label { Text = "Марка:", AutoSize = true, Padding = new Padding(0,10,4,0), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 250 };
            foreach (DataRow r in Db.Load("SELECT Naimenovanie FROM Marki ORDER BY Naimenovanie").Rows) _cmb.Items.Add(r[0]);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string baseSql = AvtoparkForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (baseSql, null);
            return (baseSql + " WHERE Marka = @v", new SqlParameter("@v", _cmb.SelectedItem));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Автомобили по марке", sql, prm).Show();
        }
    }

    // =================== 3. В прокате / свободные ===================
    public class FilterByVozvrachen : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByVozvrachen() : base("Автомобили в прокате / свободные") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(new Label { Text = "Состояние:", AutoSize = true, Padding = new Padding(0,10,4,0), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 220 };
            _cmb.Items.AddRange(new object[] { "Свободен (возвращён)", "В прокате" });
            _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string baseSql = AvtoparkForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (baseSql, null);
            int v = _cmb.SelectedIndex == 0 ? 1 : 0;
            return (baseSql + " WHERE Vozvrachen = @v", new SqlParameter("@v", v));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("В прокате / свободные", sql, prm).Show();
        }
    }

    // =================== 4. Прокат по дате ===================
    public class FilterByDate : FilterFormBase
    {
        private DateTimePicker _dp;
        public FilterByDate() : base("Автомобили выданные / возвращённые в дату") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(new Label { Text = "Дата:", AutoSize = true, Padding = new Padding(0,10,4,0), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            _dp = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 150, Value = new DateTime(2025, 4, 25) };
            panel.Controls.Add(_dp);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string baseSql = AvtoVProkateForm.Sql;
            if (reset) return (baseSql, null);
            return (baseSql + @" WHERE [Дата выдачи] = @v OR [Дата возврата] = @v",
                    new SqlParameter("@v", _dp.Value.Date));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Прокат по дате", sql, prm).Show();
        }
    }

    // =================== 5. Оплачено / не оплачено ===================
    public class FilterByOplata : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByOplata() : base("Оплаченные / неоплаченные прокаты") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(new Label { Text = "Оплата:", AutoSize = true, Padding = new Padding(0,10,4,0), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 200 };
            _cmb.Items.AddRange(new object[] { "Оплачен", "Не оплачен" });
            _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string baseSql = AvtoVProkateForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (baseSql, null);
            int v = _cmb.SelectedIndex == 0 ? 1 : 0;
            return (baseSql + " WHERE Oplachen = @v", new SqlParameter("@v", v));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Оплата проката", sql, prm).Show();
        }
    }

    // =================== Отчёт с параметром ===================
    public class ReportFormParam : Form
    {
        public ReportFormParam(string title, string sql, SqlParameter prm)
        {
            Text = "Отчёт (фильтр): " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 640);
            Controls.Add(new Label
            {
                Text = "Отчёт «" + title + "»", Dock = DockStyle.Top, Height = 44,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter
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

            DataTable dt = prm == null ? Db.Load(sql) : Db.Load(sql, prm);

            Color[] back   = { Color.FromArgb(245, 250, 255), Color.FromArgb(255, 248, 240) };
            Color[] border = { Color.SteelBlue,               Color.DarkOrange };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i]; int idx = i;
                var card = new Panel { Width = 820, Height = 28 + dt.Columns.Count * 22, BackColor = back[i % 2], Margin = new Padding(0, 4, 0, 4) };
                card.Paint += (s, e) => { using var p = new Pen(border[idx % 2], 2); e.Graphics.DrawRectangle(p, 1, 1, card.Width - 3, card.Height - 3); };
                card.Controls.Add(new Label { Text = "Запись № " + (i + 1), Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = border[i % 2], AutoSize = true, Top = 4, Left = 8 });
                int y = 26;
                foreach (DataColumn col in dt.Columns)
                {
                    card.Controls.Add(new Label { Text = col.ColumnName + ":", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = false, Top = y, Left = 12, Width = 220, Height = 20 });
                    card.Controls.Add(new Label { Text = Format(row[col]), Font = new Font("Segoe UI", 9), AutoSize = false, Top = y, Left = 240, Width = 560, Height = 20 });
                    y += 22;
                }
                scroll.Controls.Add(card);
            }
        }
        private static string Format(object v)
        {
            if (v == null || v is DBNull) return "—";
            if (v is bool b) return b ? "Да" : "Нет";
            if (v is DateTime d) return d.ToString("dd.MM.yyyy");
            if (v is decimal m) return m.ToString("N2");
            return v.ToString();
        }
    }
}
