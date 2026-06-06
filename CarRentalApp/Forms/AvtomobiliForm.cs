using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная форма. Раскладка — в AvtomobiliForm.Designer.cs.</summary>
    public partial class AvtomobiliForm : Form
    {
        private readonly DataTable _dt = new();

        public AvtomobiliForm()
        {
            InitializeComponent();
            grid.Rows.Clear();
            colKodMarki.Items.Clear(); colKodMarki.DataSource = Db.Load("SELECT KodMarki, Naimenovanie FROM Marki ORDER BY Naimenovanie");
            colKodMehanika.Items.Clear(); colKodMehanika.DataSource = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            grid.DataSource = bs;

            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new AvtomobiliGridForm().Show();
            btnReport.Click += (s, e) => new AvtomobiliReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c); da.Fill(_dt); bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) grid.Rows.Remove(grid.CurrentRow);
        }
    }
}
