using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    // ====== Ленточная ======
    public class UslugiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public UslugiForm()
        {
            Text = "Дополнительные услуги";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(880, 460);
            Font = UI.Body;

            Controls.Add(UI.MakeHeader("Дополнительные услуги"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.RowHeadersVisible = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            _grid.DataSource = _bs;
            _grid.Columns.Add(Tx("Naimenovanie", "Наименование"));
            _grid.Columns.Add(Tx("Opisanie",     "Описание"));
            _grid.Columns.Add(Tx("Cena",         "Цена"));
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Добавить",  (s,e) => _bs.AddNew()));
            btns.Controls.Add(UI.MakeBtn("Удалить",   (s,e) => Del()));
            btns.Controls.Add(UI.MakeBtn("Сохранить", (s,e) => Save()));
            btns.Controls.Add(UI.MakeBtn("Табличная", (s,e) => new UslugiGridForm().Show()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s,e) => new UslugiReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s,e) => Close()));
            Controls.Add(btns);

            Load_();
        }
        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };
        private void Load_() { try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Uslugi", c); da.Fill(_dt); _bs.DataSource = _dt; } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Save() { try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Uslugi", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Del() { if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return; if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow); }
    }

    // ====== Табличная ======
    public class UslugiGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        private readonly TextBox _f = new() { Width = 140 };
        private readonly TextBox _s = new() { Width = 140 };

        public UslugiGridForm()
        {
            Text = "Дополнительные услуги (табличная)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(880, 460);
            Font = UI.Body;

            Controls.Add(UI.MakeHeader("Дополнительные услуги — табличная форма"));

            var top = UI.MakeParamsPanel();
            top.Controls.Add(L("Поле:")); top.Controls.Add(_cmb);
            top.Controls.Add(L("Фильтр:")); top.Controls.Add(_f);
            top.Controls.Add(UI.MakeBtn("▲", (s,e)=>Sort(true), 30));
            top.Controls.Add(UI.MakeBtn("▼", (s,e)=>Sort(false), 30));
            top.Controls.Add(L("Поиск:")); top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s,e) => Flt(); _s.TextChanged += (s,e) => Flt();

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
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s,e) => new UslugiReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s,e) => Close()));
            Controls.Add(btns);

            const string sql = "SELECT Naimenovanie AS [Наименование], Opisanie AS [Описание], Cena AS [Цена] FROM Uslugi";
            var dt = Db.Load(sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        private static Label L(string t) => new() { Text = t, AutoSize = true, Padding = new Padding(0, 6, 4, 0) };
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

    public class UslugiReport : ReportForm
    {
        public UslugiReport() : base("Дополнительные услуги",
            "SELECT Naimenovanie AS [Наименование], Opisanie AS [Описание], Cena AS [Цена] FROM Uslugi") { }
    }
}
