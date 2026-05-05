using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class DolzhnostiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public DolzhnostiForm()
        {
            Text = "Должности (ленточная форма)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 600);

            Controls.Add(new Label
            {
                Text = "Должности", Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.RowTemplate.Height = 30;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Naimenovanie", HeaderText = "Наименование", Name = "Naimenovanie" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Oklad",        HeaderText = "Оклад",        Name = "Oklad" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Obyazannosti", HeaderText = "Обязанности",  Name = "Obyazannosti" });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Trebovaniya",  HeaderText = "Требования",   Name = "Trebovaniya" });
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(Btn("Добавить",        Color.MediumSeaGreen, (s,e) => _bs.AddNew()));
            btns.Controls.Add(Btn("Удалить",         Color.IndianRed,      (s,e) => DeleteCurrent()));
            btns.Controls.Add(Btn("Сохранить",       Color.SteelBlue,      (s,e) => SaveAll()));
            btns.Controls.Add(Btn("Табличная форма", Color.DarkSlateGray,  (s,e) => new DolzhnostiGridForm().Show()));
            btns.Controls.Add(Btn("Отчёт",           Color.DarkSlateBlue,  (s,e) => new DolzhnostiReport().Show()));
            btns.Controls.Add(Btn("Закрыть",         Color.Gray,           (s,e) => Close()));
            Controls.Add(btns);

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
            b.Click += h; return b;
        }

        private void LoadData()
        {
            try
            {
                _dt.Clear();
                using var conn = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Dolzhnosti", conn);
                da.Fill(_dt);
                _bs.DataSource = _dt;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\n" + ex.Message); }
        }

        private void SaveAll()
        {
            try
            {
                _bs.EndEdit();
                using var conn = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Dolzhnosti", conn);
                using var bld = new SqlCommandBuilder(da); _ = bld;
                da.Update(_dt);
                MessageBox.Show("Сохранено.");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка:\n" + ex.Message); }
        }

        private void DeleteCurrent()
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _grid.Rows.Remove(_grid.CurrentRow);
        }
    }
}
