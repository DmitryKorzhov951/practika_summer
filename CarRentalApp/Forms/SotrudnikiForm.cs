using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class SotrudnikiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public SotrudnikiForm()
        {
            Text = "Сотрудники";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(960, 520);
            Font = UI.Body;

            Controls.Add(UI.MakeHeader("Сотрудники"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.RowHeadersVisible = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            _grid.DataSource = _bs;

            _grid.Columns.Add(Tx("FIO",     "ФИО"));
            _grid.Columns.Add(Tx("Vozrast", "Возраст"));
            _grid.Columns.Add(Tx("Pol",     "Пол"));
            _grid.Columns.Add(Tx("Adres",   "Адрес"));
            _grid.Columns.Add(Tx("Telefon", "Телефон"));
            _grid.Columns.Add(Tx("Pasport", "Паспорт"));

            var dolzh = Db.Load("SELECT KodDolzhnosti, Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie");
            _grid.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "KodDolzhnosti", HeaderText = "Должность", Name = "KodDolzhnosti",
                DataSource = dolzh, DisplayMember = "Naimenovanie", ValueMember = "KodDolzhnosti",
                FlatStyle = FlatStyle.Standard
            });
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs)
            {
                Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null
            });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Добавить",       (s, e) => _bs.AddNew()));
            btns.Controls.Add(UI.MakeBtn("Удалить",        (s, e) => DeleteCurrent()));
            btns.Controls.Add(UI.MakeBtn("Сохранить",      (s, e) => SaveAll()));
            btns.Controls.Add(UI.MakeBtn("Табличная",      (s, e) => new SotrudnikiGridForm().Show()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",          (s, e) => new SotrudnikiReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",        (s, e) => Close()));
            Controls.Add(btns);

            LoadData();
        }

        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };

        private void LoadData()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c); da.Fill(_dt); _bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void SaveAll()
        {
            try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c);
                  using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DeleteCurrent()
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _grid.Rows.Remove(_grid.CurrentRow);
        }
    }
}
