using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>
    /// Ленточная форма "Сотрудники".
    /// Все поля кроме PK; внешний ключ "Должность" — выпадающим списком.
    /// </summary>
    public class SotrudnikiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public SotrudnikiForm()
        {
            Text          = "Сотрудники (ленточная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(1100, 600);

            // Заголовок
            Controls.Add(new Label
            {
                Text      = "Сотрудники",
                Dock      = DockStyle.Top, Height = 40,
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Сетка
            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.AllowUserToDeleteRows = false;
            _grid.RowTemplate.Height = 30;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);

            // Навигатор перемещения по записям
            Controls.Add(new BindingNavigator(_bs)
            {
                Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null
            });

            // Кнопки
            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(Btn("Добавить",        Color.MediumSeaGreen, (s,e) => _bs.AddNew()));
            btns.Controls.Add(Btn("Удалить",         Color.IndianRed,      (s,e) => DeleteCurrent()));
            btns.Controls.Add(Btn("Сохранить",       Color.SteelBlue,      (s,e) => SaveAll()));
            btns.Controls.Add(Btn("Табличная форма", Color.DarkSlateGray,  (s,e) => new SotrudnikiGridForm().Show()));
            btns.Controls.Add(Btn("Отчёт",           Color.DarkSlateBlue,  (s,e) => new SotrudnikiReport().Show()));
            btns.Controls.Add(Btn("Закрыть",         Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);

            BuildColumns();
            LoadData();
        }

        private static Button Btn(string text, Color color, EventHandler h)
        {
            var b = new Button
            {
                Text = text, Width = 140, Height = 32,
                BackColor = color, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            b.Click += h;
            return b;
        }

        private void BuildColumns()
        {
            // Все поля кроме KodSotrudnika (счётчик-PK)
            _grid.Columns.Add(NewText("FIO",     "ФИО"));
            _grid.Columns.Add(NewText("Vozrast", "Возраст"));
            _grid.Columns.Add(NewText("Pol",     "Пол"));
            _grid.Columns.Add(NewText("Adres",   "Адрес"));
            _grid.Columns.Add(NewText("Telefon", "Телефон"));
            _grid.Columns.Add(NewText("Pasport", "Паспорт"));

            // FK "Должность" — выпадающим списком
            var dolzh = Db.Load("SELECT KodDolzhnosti, Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie");
            var combo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "KodDolzhnosti",
                HeaderText       = "Должность",
                Name             = "KodDolzhnosti",
                DataSource       = dolzh,
                DisplayMember    = "Naimenovanie",
                ValueMember      = "KodDolzhnosti",
                FlatStyle        = FlatStyle.Flat
            };
            _grid.Columns.Add(combo);
        }

        private static DataGridViewTextBoxColumn NewText(string col, string header) => new()
        {
            DataPropertyName = col, HeaderText = header, Name = col
        };

        private void LoadData()
        {
            try
            {
                _dt.Clear();
                using var conn = Db.Open();
                using var da   = new SqlDataAdapter("SELECT * FROM Sotrudniki", conn);
                da.Fill(_dt);
                _bs.DataSource = _dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки:\n" + ex.Message);
            }
        }

        private void SaveAll()
        {
            try
            {
                _bs.EndEdit();
                using var conn = Db.Open();
                using var da   = new SqlDataAdapter("SELECT * FROM Sotrudniki", conn);
                using var bld  = new SqlCommandBuilder(da);
                _ = bld;
                da.Update(_dt);
                MessageBox.Show("Сохранено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения:\n" + ex.Message);
            }
        }

        private void DeleteCurrent()
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить запись?", "?", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            _grid.Rows.Remove(_grid.CurrentRow);
        }
    }
}
