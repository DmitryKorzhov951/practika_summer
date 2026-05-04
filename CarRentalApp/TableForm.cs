using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>
    /// Универсальная форма для редактирования таблицы:
    /// сетка с данными, добавление / удаление / сохранение.
    /// </summary>
    public class TableForm : Form
    {
        private readonly string _table;
        private readonly DataTable _data = new();
        private readonly DataGridView _grid = new()
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        private readonly BindingSource _bs = new();

        public TableForm(string tableName, string title)
        {
            _table = tableName;

            Text          = title;
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(800, 500);

            Controls.Add(new Label
            {
                Text      = title,
                Dock      = DockStyle.Top, Height = 36,
                Font      = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            _grid.DataSource = _bs;
            Controls.Add(_grid);

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 44, Padding = new Padding(6) };
            btns.Controls.Add(Btn("Добавить",  () => _bs.AddNew()));
            btns.Controls.Add(Btn("Удалить",   Delete));
            btns.Controls.Add(Btn("Сохранить", Save));
            btns.Controls.Add(Btn("Закрыть",   Close));
            Controls.Add(btns);

            LoadData();
        }

        private static Button Btn(string text, Action onClick)
        {
            var b = new Button { Text = text, Width = 100, Height = 32 };
            b.Click += (s, e) => onClick();
            return b;
        }

        private void LoadData()
        {
            try
            {
                _data.Clear();
                using var conn = new SqlConnection(Db.ConnStr);
                using var da   = new SqlDataAdapter("SELECT * FROM " + _table, conn);
                da.Fill(_data);
                _bs.DataSource = _data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки:\n" + ex.Message);
            }
        }

        private void Save()
        {
            try
            {
                _bs.EndEdit();
                using var conn = new SqlConnection(Db.ConnStr);
                using var da   = new SqlDataAdapter("SELECT * FROM " + _table, conn);
                using var bld  = new SqlCommandBuilder(da);
                da.Update(_data);
                MessageBox.Show("Сохранено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения:\n" + ex.Message);
            }
        }

        private void Delete()
        {
            if (_grid.CurrentRow != null && !_grid.CurrentRow.IsNewRow &&
                MessageBox.Show("Удалить запись?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _grid.Rows.Remove(_grid.CurrentRow);
        }
    }
}
