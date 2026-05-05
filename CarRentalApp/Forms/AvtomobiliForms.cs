using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class AvtomobiliForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public AvtomobiliForm()
        {
            Text = "Автомобили (ленточная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1300, 600);
            Controls.Add(new Label { Text = "Автомобили", Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold), BackColor = Color.SteelBlue, ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter });

            _grid.Dock = DockStyle.Fill; _grid.AutoGenerateColumns = false; _grid.AllowUserToAddRows = true;
            _grid.RowTemplate.Height = 30; _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;

            // Внешний ключ "Марка"
            var marki = Db.Load("SELECT KodMarki, Naimenovanie FROM Marki ORDER BY Naimenovanie");
            _grid.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "KodMarki", HeaderText = "Марка", Name = "KodMarki",
                DataSource = marki, DisplayMember = "Naimenovanie", ValueMember = "KodMarki", FlatStyle = FlatStyle.Flat
            });

            _grid.Columns.Add(Tx("RegNomer",        "Рег. номер"));
            _grid.Columns.Add(Tx("NomerKuzova",     "Номер кузова"));
            _grid.Columns.Add(Tx("NomerDvigatelya", "Номер двигателя"));
            _grid.Columns.Add(Tx("GodVypuska",      "Год выпуска"));
            _grid.Columns.Add(Tx("Probeg",          "Пробег"));
            _grid.Columns.Add(Tx("CenaAvto",        "Цена авто"));
            _grid.Columns.Add(Tx("CenaDnyaProkata", "Цена дня"));
            _grid.Columns.Add(Tx("DataTO",          "Дата ТО"));

            // Внешний ключ "Сотрудник-механик"
            var meh = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            _grid.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "KodMehanika", HeaderText = "Механик", Name = "KodMehanika",
                DataSource = meh, DisplayMember = "FIO", ValueMember = "KodSotrudnika", FlatStyle = FlatStyle.Flat
            });

            _grid.Columns.Add(Tx("Otmetki",    "Отметки"));
            _grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Vozvrachen", HeaderText = "Возвращён", Name = "Vozvrachen" });

            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Добавить",        Color.MediumSeaGreen, (s,e) => _bs.AddNew()));
            btns.Controls.Add(B("Удалить",         Color.IndianRed,      (s,e) => Del()));
            btns.Controls.Add(B("Сохранить",       Color.SteelBlue,      (s,e) => Save()));
            btns.Controls.Add(B("Табличная форма", Color.DarkSlateGray,  (s,e) => new AvtomobiliGridForm().Show()));
            btns.Controls.Add(B("Отчёт",           Color.DarkSlateBlue,  (s,e) => new AvtomobiliReport().Show()));
            btns.Controls.Add(B("Закрыть",         Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);
            Load_();
        }
        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };
        private void Load_()
        { try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c); da.Fill(_dt); _bs.DataSource = _dt; }
          catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Save()
        { try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c);
                using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
          catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Del()
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow);
        }
        private static Button B(string t, Color c, EventHandler h) { var b = new Button { Text = t, Width = 140, Height = 32, BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; b.Click += h; return b; }
    }

    public class AvtomobiliGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        private readonly TextBox _f = new() { Width = 180 };
        private readonly TextBox _s = new() { Width = 180 };

        public AvtomobiliGridForm()
        {
            Text = "Автомобили (табличная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1300, 600);
            Controls.Add(new Label { Text = "Автомобили — табличная форма", Dock = DockStyle.Top, Height = 40,
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
            _f.TextChanged += (s,e) => Flt(); _s.TextChanged += (s,e) => Flt();

            _grid.Dock = DockStyle.Fill; _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Поиск", Color.SteelBlue, (s,e) => _s.Focus()));
            btns.Controls.Add(B("Отчёт", Color.MediumSeaGreen, (s,e) => new AvtomobiliReport().Show()));
            btns.Controls.Add(B("Закрыть", Color.Gray, (s,e) => Close()));
            Controls.Add(btns);

            var dt = Db.Load(SqlText); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        public const string SqlText = @"
            SELECT m.Naimenovanie  AS [Марка],
                   a.RegNomer       AS [Рег. номер],
                   a.NomerKuzova    AS [Номер кузова],
                   a.NomerDvigatelya AS [Номер двигателя],
                   a.GodVypuska     AS [Год выпуска],
                   a.Probeg         AS [Пробег],
                   a.CenaAvto       AS [Цена авто],
                   a.CenaDnyaProkata AS [Цена дня],
                   a.DataTO         AS [Дата ТО],
                   s.FIO            AS [Механик],
                   a.Otmetki        AS [Отметки],
                   a.Vozvrachen     AS [Возвращён]
            FROM Avtomobili a
            JOIN Marki      m ON a.KodMarki    = m.KodMarki
            JOIN Sotrudniki s ON a.KodMehanika = s.KodSotrudnika";
        private void Sort(bool asc) { if (_cmb.SelectedItem == null) return; try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc?"ASC":"DESC"); } catch { } }
        private void Flt()
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

    public class AvtomobiliReport : ReportForm
    {
        public AvtomobiliReport() : base("Автомобили", AvtomobiliGridForm.SqlText) { }
    }
}
