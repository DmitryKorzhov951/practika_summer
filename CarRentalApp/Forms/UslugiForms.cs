using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    // ====================== Ленточная ======================
    public class UslugiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public UslugiForm()
        {
            Text = "Дополнительные услуги (ленточная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 600);

            Controls.Add(Header("Дополнительные услуги"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.RowTemplate.Height = 30;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Naimenovanie", HeaderText = "Наименование", Name = "Naimenovanie" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Opisanie",     HeaderText = "Описание",     Name = "Opisanie" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cena",         HeaderText = "Цена",         Name = "Cena" });
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Добавить",        Color.MediumSeaGreen, (s,e) => _bs.AddNew()));
            btns.Controls.Add(B("Удалить",         Color.IndianRed,      (s,e) => Del()));
            btns.Controls.Add(B("Сохранить",       Color.SteelBlue,      (s,e) => Save()));
            btns.Controls.Add(B("Табличная форма", Color.DarkSlateGray,  (s,e) => new UslugiGridForm().Show()));
            btns.Controls.Add(B("Отчёт",           Color.DarkSlateBlue,  (s,e) => new UslugiReport().Show()));
            btns.Controls.Add(B("Закрыть",         Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);
            Load_();
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Uslugi", c); da.Fill(_dt); _bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Uslugi", c);
                  using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow);
        }
        private static Button B(string t, Color c, EventHandler h) { var b = new Button { Text = t, Width = 140, Height = 32, BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; b.Click += h; return b; }
        private static Label Header(string t) => new()
        {
            Text = t, Dock = DockStyle.Top, Height = 40,
            Font = new Font("Segoe UI", 14, FontStyle.Bold),
            BackColor = Color.SteelBlue, ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter
        };
    }

    // ====================== Табличная ======================
    public class UslugiGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        private readonly TextBox _f = new() { Width = 180 };
        private readonly TextBox _s = new() { Width = 180 };

        public UslugiGridForm()
        {
            Text = "Дополнительные услуги (табличная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 600);
            Controls.Add(new Label { Text = "Дополнительные услуги — табличная форма", Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold), BackColor = Color.SteelBlue, ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter });
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 44, Padding = new Padding(6) };
            top.Controls.Add(new Label { Text = "Поле:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_cmb);
            top.Controls.Add(new Label { Text = " фильтр:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_f);
            var ba = new Button { Text="▲", Width=40 }; ba.Click += (s,e)=>Sort(true);
            var bd = new Button { Text="▼", Width=40 }; bd.Click += (s,e)=>Sort(false);
            top.Controls.Add(ba); top.Controls.Add(bd);
            top.Controls.Add(new Label { Text = " поиск:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s,e) => Filter(); _s.TextChanged += (s,e) => Filter();

            _grid.Dock = DockStyle.Fill; _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Поиск", Color.SteelBlue, (s,e) => _s.Focus()));
            btns.Controls.Add(B("Отчёт", Color.MediumSeaGreen, (s,e) => new UslugiReport().Show()));
            btns.Controls.Add(B("Закрыть", Color.Gray, (s,e) => Close()));
            Controls.Add(btns);

            const string sql = "SELECT Naimenovanie AS [Наименование], Opisanie AS [Описание], Cena AS [Цена] FROM Uslugi";
            var dt = Db.Load(sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        private void Sort(bool asc) { if (_cmb.SelectedItem == null) return; try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc?"ASC":"DESC"); } catch { } }
        private void Filter()
        {
            try
            {
                string f = "";
                if (_cmb.SelectedItem != null && !string.IsNullOrEmpty(_f.Text))
                    f = $"CONVERT([{_cmb.SelectedItem}], 'System.String') LIKE '%{_f.Text.Replace("'","''")}%'";
                if (!string.IsNullOrEmpty(_s.Text))
                {
                    var v = _s.Text.Replace("'","''");
                    var x = "(" + string.Join(" OR ", _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? x : $"({f}) AND {x}";
                }
                _bs.Filter = f;
            } catch { }
        }
        private static Button B(string t, Color c, EventHandler h) { var b = new Button { Text = t, Width = 120, Height = 32, BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; b.Click += h; return b; }
    }

    // ====================== Отчёт ======================
    public class UslugiReport : ReportForm
    {
        public UslugiReport() : base("Дополнительные услуги",
            "SELECT Naimenovanie AS [Наименование], Opisanie AS [Описание], Cena AS [Цена] FROM Uslugi")
        { }
    }
}
