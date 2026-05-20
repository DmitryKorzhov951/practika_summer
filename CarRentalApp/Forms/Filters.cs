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

        protected FilterFormBase(string title, string poster = null)
        {
            _title = title;
            Text = "Фильтр: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(960, 520);
            UI.ApplyTheme(this);


            var top = UI.MakeParamsPanel();
            BuildFilterPanel(top);
            Controls.Add(top);

            _grid.Dock = DockStyle.Fill;
            UI.StyleGrid(_grid);
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Применить", (s, e) => Reload(),         110, UI.BtnStyle.Primary));
            btns.Controls.Add(UI.MakeBtn("Сброс",     (s, e) => ResetAndReload()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s, e) => ShowReport(),     110, UI.BtnStyle.Accent));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s, e) => Close()));
            Controls.Add(btns);
            Controls.Add(UI.MakeBanner("Фильтр «" + title + "»", poster));

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
            Text = text, AutoSize = true, Padding = new Padding(0, 9, 4, 0),
            Font = UI.BodyBold, ForeColor = UI.TextDim,
            BackColor = System.Drawing.Color.Transparent
        };
    }

    // 1. Сотрудники по должности
    public class FilterByDolzhnost : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByDolzhnost() : base("Сотрудники по должности", "f_dolzh") { }
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
            new ReportFormParam("Сотрудники по должности", sql, prm, "f_dolzh").Show();
        }
    }

    // 2. Автомобили по марке
    public class FilterByMarka : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByMarka() : base("Автомобили по марке", "f_marka") { }
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
            new ReportFormParam("Автомобили по марке", sql, prm, "f_marka").Show();
        }
    }

    // 3. В прокате / свободные
    public class FilterByVozvrachen : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByVozvrachen() : base("Автомобили в прокате / свободные", "f_vozvrat") { }
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
            new ReportFormParam("В прокате / свободные", sql, prm, "f_vozvrat").Show();
        }
    }

    // 4. По дате
    public class FilterByDate : FilterFormBase
    {
        private DateTimePicker _dp;
        public FilterByDate() : base("Прокат по дате", "f_data") { }
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
            return (b + " WHERE DataVydachi = @v OR DataVozvrata = @v", new SqlParameter("@v", _dp.Value.Date));
        }
        protected override void ShowReport()
        {
            var (sql, prm) = BuildSql(false);
            new ReportFormParam("Прокат по дате", sql, prm, "f_data").Show();
        }
    }

    // 5. По оплате
    public class FilterByOplata : FilterFormBase
    {
        private ComboBox _cmb;
        public FilterByOplata() : base("Оплачено / не оплачено", "f_oplata") { }
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
            new ReportFormParam("Оплата проката", sql, prm, "f_oplata").Show();
        }
    }

    // Отчёт с параметром (тёмная тема)
    public class ReportFormParam : Form
    {
        public ReportFormParam(string title, string sql, SqlParameter prm, string poster = null)
        {
            Text = "Отчёт (фильтр): " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(820, 600);
            UI.ApplyTheme(this);


            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                BackColor = UI.Bg, Padding = new Padding(16)
            };
            Controls.Add(scroll);
            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(bottom);
            Controls.Add(UI.MakeBanner("Отчёт «" + title + "»", poster));

            DataTable dt = prm == null ? Db.Load(sql) : Db.Load(sql, prm);

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
                    Width = 740, Height = 32 + dt.Columns.Count * 22,
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
                        Text = col.ColumnName + ":", Font = UI.BodyBold,
                        ForeColor = UI.TextDim, BackColor = Color.Transparent,
                        AutoSize = false, Top = y, Left = 16, Width = 220, Height = 20
                    });
                    card.Controls.Add(new Label
                    {
                        Text = Format(row[col]), Font = UI.Body,
                        ForeColor = UI.Text, BackColor = Color.Transparent,
                        AutoSize = false, Top = y, Left = 240, Width = 480, Height = 20
                    });
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
