using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class KlientyForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public KlientyForm()
        {
            Text = "Клиенты";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(960, 480);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("Клиенты"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            UI.StyleGrid(_grid);
            _grid.AllowUserToAddRows = true;
            _grid.DataSource = _bs;
            _grid.Columns.Add(Tx("FIO",            "ФИО"));
            _grid.Columns.Add(Tx("Pol",            "Пол"));
            _grid.Columns.Add(Tx("DataRozhdeniya", "Дата рождения"));
            _grid.Columns.Add(Tx("Adres",          "Адрес"));
            _grid.Columns.Add(Tx("Telefon",        "Телефон"));
            _grid.Columns.Add(Tx("Pasport",        "Паспорт"));
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Добавить",  (s,e) => _bs.AddNew(), 110, UI.BtnStyle.Accent));
            btns.Controls.Add(UI.MakeBtn("Удалить",   (s,e) => Del(),  110, UI.BtnStyle.Danger));
            btns.Controls.Add(UI.MakeBtn("Сохранить", (s,e) => Save(), 110, UI.BtnStyle.Primary));
            btns.Controls.Add(UI.MakeBtn("Табличная", (s,e) => new KlientyGridForm().Show()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s,e) => new KlientyReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s,e) => Close()));
            Controls.Add(btns);
            Load_();
        }
        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };
        private void Load_() { try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); da.Fill(_dt); _bs.DataSource = _dt; } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Save() { try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Del() { if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return; if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow); }
    }

    public class KlientyGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        private readonly TextBox _f = new() { Width = 140 };
        private readonly TextBox _s = new() { Width = 140 };

        public KlientyGridForm()
        {
            Text = "Клиенты (табличная)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(960, 480);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("Клиенты — табличная форма"));

            var top = UI.MakeParamsPanel();
            top.Controls.Add(L("Поле:")); top.Controls.Add(_cmb);
            top.Controls.Add(L("Фильтр:")); top.Controls.Add(_f);
            top.Controls.Add(UI.MakeBtn("▲", (s,e)=>Sort(true), 30));
            top.Controls.Add(UI.MakeBtn("▼", (s,e)=>Sort(false), 30));
            top.Controls.Add(L("Поиск:")); top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s,e) => Flt(); _s.TextChanged += (s,e) => Flt();

            _grid.Dock = DockStyle.Fill;
            UI.StyleGrid(_grid);
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s,e) => new KlientyReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s,e) => Close()));
            Controls.Add(btns);

            const string sql = @"SELECT FIO AS [ФИО], Pol AS [Пол], DataRozhdeniya AS [Дата рождения],
                                        Adres AS [Адрес], Telefon AS [Телефон], Pasport AS [Паспорт] FROM Klienty";
            var dt = Db.Load(sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        private static Label L(string t) => new() { Text = t, AutoSize = true, Padding = new Padding(0, 9, 4, 0), Font = UI.BodyBold, ForeColor = UI.TextDim, BackColor = Color.Transparent };
        private void Sort(bool asc) { if (_cmb.SelectedItem == null) return; try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc?"ASC":"DESC"); } catch { } }
        private void Flt()
        {
            try
            {
                string f = "";
                if (_cmb.SelectedItem != null && !string.IsNullOrEmpty(_f.Text))
                    f = $"CONVERT([{_cmb.SelectedItem}], 'System.String') LIKE '%{_f.Text.Replace("'", "''")}%'";
                if (!string.IsNullOrEmpty(_s.Text))
                {
                    var v = _s.Text.Replace("'", "''");
                    var x = "(" + string.Join(" OR ", _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? x : $"({f}) AND {x}";
                }
                _bs.Filter = f;
            }
            catch { }
        }
    }

    public class KlientyReport : ReportForm
    {
        public KlientyReport() : base("Клиенты",
            @"SELECT FIO AS [ФИО], Pol AS [Пол], DataRozhdeniya AS [Дата рождения],
                     Adres AS [Адрес], Telefon AS [Телефон], Pasport AS [Паспорт] FROM Klienty") { }
    }
}
