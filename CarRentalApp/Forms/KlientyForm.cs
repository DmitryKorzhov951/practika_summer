using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная форма. Раскладка — в KlientyForm.Designer.cs.</summary>
    public partial class KlientyForm : Form
    {
        private readonly DataTable _dt = new();

        public KlientyForm()
        {
            InitializeComponent();
            grid.Rows.Clear();

            grid.DataSource = bs;

            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new KlientyGridForm().Show();
            btnReport.Click += (s, e) => new KlientyReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); da.Fill(_dt); bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) grid.Rows.Remove(grid.CurrentRow);
        }
    }
}
