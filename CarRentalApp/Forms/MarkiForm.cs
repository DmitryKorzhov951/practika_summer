using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class MarkiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public MarkiForm()
        {
            Text = "Марки автомобилей";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(880, 460);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeBanner("Марки автомобилей", "marki"));

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            UI.StyleGrid(_grid);
            _grid.AllowUserToAddRows = true;
            _grid.DataSource = _bs;
            _grid.Columns.Add(Tx("Naimenovanie",   "Наименование"));
            _grid.Columns.Add(Tx("Harakteristiki", "Характеристики"));
            _grid.Columns.Add(Tx("Opisanie",       "Описание"));
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Добавить",  (s,e) => _bs.AddNew(), 110, UI.BtnStyle.Accent));
            btns.Controls.Add(UI.MakeBtn("Удалить",   (s,e) => Del(),  110, UI.BtnStyle.Danger));
            btns.Controls.Add(UI.MakeBtn("Сохранить", (s,e) => Save(), 110, UI.BtnStyle.Primary));
            btns.Controls.Add(UI.MakeBtn("Табличная", (s,e) => new MarkiGridForm().Show()));
            btns.Controls.Add(UI.MakeBtn("Отчёт",     (s,e) => new MarkiReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть",   (s,e) => Close()));
            Controls.Add(btns);

            Load_();
        }
        private static DataGridViewTextBoxColumn Tx(string p, string h) => new() { DataPropertyName = p, HeaderText = h, Name = p };
        private void Load_() { try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Marki", c); da.Fill(_dt); _bs.DataSource = _dt; } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Save() { try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Marki", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private void Del() { if (_grid.CurrentRow == null || _grid.CurrentRow.IsNewRow) return; if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) _grid.Rows.Remove(_grid.CurrentRow); }
    }
}
