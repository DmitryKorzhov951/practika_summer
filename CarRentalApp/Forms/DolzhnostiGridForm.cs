using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class DolzhnostiGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmbField  = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        private readonly TextBox  _txtFilter = new() { Width = 180 };
        private readonly TextBox  _txtSearch = new() { Width = 180 };

        public DolzhnostiGridForm()
        {
            Text = "Должности (табличная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 600);

            Controls.Add(new Label
            {
                Text = "Должности — табличная форма",
                Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 44, Padding = new Padding(6) };
            top.Controls.Add(new Label { Text = "Поле:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_cmbField);
            top.Controls.Add(new Label { Text = " фильтр:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_txtFilter);
            var bAsc = new Button { Text = "▲", Width = 40 };  bAsc.Click  += (s,e) => Sort(true);
            var bDesc= new Button { Text = "▼", Width = 40 };  bDesc.Click += (s,e) => Sort(false);
            top.Controls.Add(bAsc); top.Controls.Add(bDesc);
            top.Controls.Add(new Label { Text = " поиск:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_txtSearch);
            Controls.Add(top);

            _txtFilter.TextChanged += (s,e) => ApplyFilter();
            _txtSearch.TextChanged += (s,e) => ApplyFilter();

            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(Btn("Поиск",   Color.SteelBlue,      (s,e) => _txtSearch.Focus()));
            btns.Controls.Add(Btn("Отчёт",   Color.MediumSeaGreen, (s,e) => new DolzhnostiReport().Show()));
            btns.Controls.Add(Btn("Закрыть", Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);

            Load_();
        }

        private static Button Btn(string text, Color color, EventHandler h)
        {
            var b = new Button { Text = text, Width = 120, Height = 32, BackColor = color, ForeColor = Color.White,
                                 FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            b.Click += h; return b;
        }

        private void Load_()
        {
            const string sql = "SELECT Naimenovanie AS [Наименование], Oklad AS [Оклад], Obyazannosti AS [Обязанности], Trebovaniya AS [Требования] FROM Dolzhnosti";
            var dt = Db.Load(sql);
            _bs.DataSource = dt;
            _cmbField.Items.Clear();
            foreach (DataColumn c in dt.Columns) _cmbField.Items.Add(c.ColumnName);
            if (_cmbField.Items.Count > 0) _cmbField.SelectedIndex = 0;
        }

        private void Sort(bool asc)
        {
            if (_cmbField.SelectedItem == null) return;
            try { _bs.Sort = $"[{_cmbField.SelectedItem}] " + (asc ? "ASC" : "DESC"); } catch { }
        }

        private void ApplyFilter()
        {
            try
            {
                string f = "";
                if (_cmbField.SelectedItem != null && !string.IsNullOrEmpty(_txtFilter.Text))
                    f = $"CONVERT([{_cmbField.SelectedItem}], 'System.String') LIKE '%{_txtFilter.Text.Replace("'", "''")}%'";
                if (!string.IsNullOrEmpty(_txtSearch.Text))
                {
                    var v = _txtSearch.Text.Replace("'", "''");
                    var s = "(" + string.Join(" OR ", _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? s : $"({f}) AND {s}";
                }
                _bs.Filter = f;
            }
            catch { }
        }
    }
}
