using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>
    /// Табличная форма "Сотрудники".
    /// Сортировка по выбранному полю, поиск, фильтрация по полю.
    /// </summary>
    public class SotrudnikiGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmbField  = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        private readonly TextBox  _txtFilter = new() { Width = 200 };
        private readonly TextBox  _txtSearch = new() { Width = 200 };

        public SotrudnikiGridForm()
        {
            Text          = "Сотрудники (табличная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(1100, 600);

            // Заголовок
            Controls.Add(new Label
            {
                Text      = "Сотрудники — табличная форма",
                Dock      = DockStyle.Top, Height = 40,
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Панель сортировки/поиска/фильтра
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 44, Padding = new Padding(6) };
            top.Controls.Add(new Label { Text = "Поле:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_cmbField);
            top.Controls.Add(new Label { Text = " фильтр содержит:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_txtFilter);
            var btnSortAsc  = new Button { Text = "Сорт ▲", Width = 80 };
            var btnSortDesc = new Button { Text = "Сорт ▼", Width = 80 };
            top.Controls.Add(btnSortAsc);
            top.Controls.Add(btnSortDesc);
            top.Controls.Add(new Label { Text = "  поиск:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_txtSearch);
            Controls.Add(top);

            _txtFilter.TextChanged += (s,e) => ApplyFilter();
            _txtSearch.TextChanged += (s,e) => ApplyFilter();
            btnSortAsc.Click  += (s,e) => Sort(true);
            btnSortDesc.Click += (s,e) => Sort(false);

            // Сетка
            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);

            // Навигатор
            Controls.Add(new BindingNavigator(_bs)
            {
                Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null
            });

            // Кнопки
            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(Btn("Поиск",   Color.SteelBlue,     (s,e) => { _txtSearch.Focus(); _txtSearch.SelectAll(); }));
            btns.Controls.Add(Btn("Отчёт",   Color.MediumSeaGreen,(s,e) => new SotrudnikiReport().Show()));
            btns.Controls.Add(Btn("Закрыть", Color.Gray,          (s,e) => Close()));
            Controls.Add(btns);

            LoadData();
        }

        private static Button Btn(string text, Color color, EventHandler h)
        {
            var b = new Button
            {
                Text = text, Width = 120, Height = 32,
                BackColor = color, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            b.Click += h;
            return b;
        }

        private void LoadData()
        {
            // Берём все поля кроме PK через JOIN с Должности (FK подменяем на наименование)
            const string sql = @"
                SELECT s.FIO          AS [ФИО],
                       s.Vozrast      AS [Возраст],
                       s.Pol          AS [Пол],
                       s.Adres        AS [Адрес],
                       s.Telefon      AS [Телефон],
                       s.Pasport      AS [Паспорт],
                       d.Naimenovanie AS [Должность]
                FROM Sotrudniki s
                JOIN Dolzhnosti d ON s.KodDolzhnosti = d.KodDolzhnosti";
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
                {
                    var col = _cmbField.SelectedItem.ToString();
                    var val = _txtFilter.Text.Replace("'", "''");
                    f = $"CONVERT([{col}], 'System.String') LIKE '%{val}%'";
                }
                if (!string.IsNullOrEmpty(_txtSearch.Text))
                {
                    var val = _txtSearch.Text.Replace("'", "''");
                    var parts = _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{val}%'");
                    var s = "(" + string.Join(" OR ", parts) + ")";
                    f = string.IsNullOrEmpty(f) ? s : $"({f}) AND {s}";
                }
                _bs.Filter = f;
            }
            catch { }
        }
    }
}
