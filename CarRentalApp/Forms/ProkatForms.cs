using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class ProkatForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public ProkatForm()
        {
            Text = "Прокат";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 520);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("Прокат"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            UI.StyleGrid(_grid);
            _grid.AllowUserToAddRows = true;
            _grid.DataSource = _bs;

            _grid.Columns.Add(Tx("DataVydachi",  "Дата выдачи"));
            _grid.Columns.Add(Tx("Srok",         "Срок"));
            _grid.Columns.Add(Tx("DataVozvrata", "Дата возврата"));

            var auto = Db.Load("SELECT KodAvtomobilya, RegNomer FROM Avtomobili ORDER BY RegNomer");
            _grid.Columns.Add(Combo("KodAvtomobilya", "Авто", auto, "RegNomer", "KodAvtomobilya"));

            var kli = Db.Load("SELECT KodKlienta, FIO FROM Klienty ORDER BY FIO");
            _grid.Columns.Add(Combo("KodKlienta", "Клиент", kli, "FIO", "KodKlienta"));

            var usl = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            _grid.Columns.Add(Combo("KodUslugi1", "Усл. 1", usl, "Naimenovanie", "KodUslugi"));
            _grid.Columns.Add(Combo("KodUslugi2", "Усл. 2", usl, "Naimenovanie", "KodUslugi"));
            _grid.Columns.Add(Combo("KodUslugi3", "Усл. 3", usl, "Naimenovanie", "KodUslugi"));

            _grid.Columns.Add(Tx("Cena", "Цена"));
            _grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Oplachen", HeaderText = "Оплачен", Name = "Oplachen" });

            var sotr = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            _grid.Columns.Add(Combo("KodSotrudnika", "Сотрудник", sotr, "FIO", "KodSotrudnika"));

            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Добавить",  (s,e) => _bs.AddNew(), 110, UI.BtnStyle.Accent));
            btns.Controls.Add(UI.MakeBtn("Удалить",   (s,e) => Del(),  110, UI.BtnStyle.Danger));
            btns.Controls.Add(UI.MakeBtn("Сохранить", (s,e) => Save(), 110, UI.BtnStyle.Primary));
            btns.Controls.Add(UI.MakeBtn("Табличная", (s,e) => new ProkatGridForm().Show()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s,e) => new ProkatReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s,e) => Close()));
            Controls.Add(btns);
            Load_();
        }
        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };
        private static DataGridViewComboBoxColumn Combo(string p, string h, DataTable src, string disp, string val) =>
            new() { DataPropertyName = p, HeaderText = h, Name = p, DataSource = src, DisplayMember = disp, ValueMember = val, FlatStyle = FlatStyle.Standard };
        private void Load_() { try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Prokat", c); da.Fill(_dt); _bs.DataSource = _dt; } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Save() { try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Prokat", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Del() { if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return; if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow); }
    }

    public class ProkatGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        private readonly TextBox _f = new() { Width = 140 };
        private readonly TextBox _s = new() { Width = 140 };

        public ProkatGridForm()
        {
            Text = "Прокат (табличная)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 520);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("Прокат — табличная форма"));

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
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s,e) => new ProkatReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s,e) => Close()));
            Controls.Add(btns);

            var dt = Db.Load(SqlText); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        public const string SqlText = @"
            SELECT p.DataVydachi  AS [Дата выдачи],
                   p.Srok          AS [Срок],
                   p.DataVozvrata  AS [Дата возврата],
                   a.RegNomer      AS [Авто],
                   k.FIO           AS [Клиент],
                   u1.Naimenovanie AS [Усл. 1],
                   u2.Naimenovanie AS [Усл. 2],
                   u3.Naimenovanie AS [Усл. 3],
                   p.Cena          AS [Цена],
                   p.Oplachen      AS [Оплачен],
                   s.FIO           AS [Сотрудник]
            FROM Prokat p
            JOIN Avtomobili a ON p.KodAvtomobilya = a.KodAvtomobilya
            JOIN Klienty    k ON p.KodKlienta     = k.KodKlienta
            LEFT JOIN Uslugi u1 ON p.KodUslugi1 = u1.KodUslugi
            LEFT JOIN Uslugi u2 ON p.KodUslugi2 = u2.KodUslugi
            LEFT JOIN Uslugi u3 ON p.KodUslugi3 = u3.KodUslugi
            JOIN Sotrudniki s ON p.KodSotrudnika = s.KodSotrudnika";
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

    public class ProkatReport : ReportForm
    {
        public ProkatReport() : base("Прокат", ProkatGridForm.SqlText) { }
    }
}
