using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>База для фильтра.</summary>
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
            Size = new Size(960, 520);
            Font = UI.Body;

            Controls.Add(UI.MakeHeader("Фильтр «" + title + "»"));

            var top = UI.MakeParamsPanel();
            BuildFilterPanel(top);
            Controls.Add(top);

            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            _grid.RowHeadersVisible = false;
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Применить", (s, e) => Reload()));
            btns.Controls.Add(UI.MakeBtn("Сброс",     (s, e) => ResetAndReload()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s, e) => ShowReport()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s, e) => Close()));
            Controls.Add(btns);

            Reload();
        }

        protected abstract void BuildFilterPanel(FlowLayoutPanel panel);
        protected abstract (string sql, SqlParameter prm) BuildSql(bool reset);
        protected abstract void ShowReport();

        protected void Reload() => Apply(false);
        protected void ResetAndReload() => Apply(true);

        private void Apply(bool reset)
        {
            try
            {
                var (sql, prm) = BuildSql(reset);
                _bs.DataSource = prm == null ? Db.Load(sql) : Db.Load(sql, prm);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\n" + ex.Message); }
        }

        protected static Label L(string text) => new()
        {
            Text = text, AutoSize = true, Padding = new Padding(0, 8, 4, 0),
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
        };
    }

    // 1. Сотрудники по должности
    public class FilterByDolzhnost : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByDolzhnost() : base("Сотрудники по должности") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(L("Должность:"));
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 220 };
            foreach (DataRow r in Db.Load("SELECT Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie").Rows)
                _cmb.Items.Add(r[0]);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string b = OtdelKadrovForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (b, null);
            return (b + " WHERE Dolzhnost = @v", new SqlParameter("@v", _cmb.SelectedItem));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Сотрудники по должности", sql, prm).Show();
        }
    }

    // 2. Автомобили по марке
    public class FilterByMarka : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByMarka() : base("Автомобили по марке") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(L("Марка:"));
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 220 };
            foreach (DataRow r in Db.Load("SELECT Naimenovanie FROM Marki ORDER BY Naimenovanie").Rows)
                _cmb.Items.Add(r[0]);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string b = AvtoparkForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (b, null);
            return (b + " WHERE Marka = @v", new SqlParameter("@v", _cmb.SelectedItem));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Автомобили по марке", sql, prm).Show();
        }
    }

    // 3. В прокате / свободные
    public class FilterByVozvrachen : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByVozvrachen() : base("Автомобили в прокате / свободные") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(L("Состояние:"));
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 220 };
            _cmb.Items.AddRange(new object[] { "Свободен (возвращён)", "В прокате" });
            _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string b = AvtoparkForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (b, null);
            int v = _cmb.SelectedIndex == 0 ? 1 : 0;
            return (b + " WHERE Vozvrachen = @v", new SqlParameter("@v", v));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("В прокате / свободные", sql, prm).Show();
        }
    }

    // 4. По дате
    public class FilterByDate : FilterFormBase
    {
        private DateTimePicker _dp;
        public FilterByDate() : base("Прокат по дате") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(L("Дата:"));
            _dp = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 130, Value = new DateTime(2025, 4, 25) };
            panel.Controls.Add(_dp);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string b = AvtoVProkateForm.Sql;
            if (reset) return (b, null);
            return (b + @" WHERE [Дата выдачи] = @v OR [Дата возврата] = @v", new SqlParameter("@v", _dp.Value.Date));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Прокат по дате", sql, prm).Show();
        }
    }

    // 5. По оплате
    public class FilterByOplata : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByOplata() : base("Оплачено / не оплачено") { }
        protected override void BuildFilterPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Add(L("Оплата:"));
            _cmb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 200 };
            _cmb.Items.AddRange(new object[] { "Оплачен", "Не оплачен" });
            _cmb.SelectedIndex = 0;
            panel.Controls.Add(_cmb);
        }
        protected override (string sql, SqlParameter prm) BuildSql(bool reset)
        {
            string b = AvtoVProkateForm.Sql;
            if (reset || _cmb?.SelectedItem == null) return (b, null);
            int v = _cmb.SelectedIndex == 0 ? 1 : 0;
            return (b + " WHERE Oplachen = @v", new SqlParameter("@v", v));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Оплата проката", sql, prm).Show();
        }
    }

    // Отчёт с параметром
    public class ReportFormParam : Form
    {
        public ReportFormParam(string title, string sql, SqlParameter prm)
        {
            Text = "Отчёт (фильтр): " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(700, 520);
            Font = UI.Body;

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

            DataTable dt = prm == null ? Db.Load(sql) : Db.Load(sql, prm);

            Color[] back = { Color.FromArgb(248, 248, 248), Color.White };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var card = new Panel
                {
                    Width = 640, Height = 22 + dt.Columns.Count * 18,
                    BackColor = back[i % 2], BorderStyle = BorderStyle.FixedSingle,
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
                        Text = col.ColumnName + ":", Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        AutoSize = false, Top = y, Left = 8, Width = 180, Height = 16
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]), Font = new Font("Segoe UI", 8),
                        AutoSize = false, Top = y, Left = 195, Width = 430, Height = 16
                    });
                    y += 18;
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
