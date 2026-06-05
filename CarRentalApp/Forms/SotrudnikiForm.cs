using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная форма. Раскладка — в SotrudnikiForm.Designer.cs.</summary>
    public partial class SotrudnikiForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly BindingSource _bs = new();

        public SotrudnikiForm()
        {
            InitializeComponent();
            colKodDolzhnosti.DataSource = Db.Load("SELECT KodDolzhnosti, Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie");
            grid.DataSource = _bs;

            btnAdd.Click    += (s, e) => _bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new SotrudnikiGridForm().Show();
            btnReport.Click += (s, e) => new SotrudnikiReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c); da.Fill(_dt); _bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) grid.Rows.Remove(grid.CurrentRow);
        }
    }
}
