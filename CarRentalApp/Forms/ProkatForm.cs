using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная форма. Раскладка — в ProkatForm.Designer.cs.</summary>
    public partial class ProkatForm : Form
    {
        private readonly DataTable _dt = new();

        public ProkatForm()
        {
            InitializeComponent();
            // Очищаем образцы строк из дизайнера перед привязкой к реальным данным
            grid.Rows.Clear();
            colKodAvtomobilya.Items.Clear(); colKodAvtomobilya.DataSource = Db.Load("SELECT KodAvtomobilya, RegNomer FROM Avtomobili ORDER BY RegNomer");
            colKodKlienta.Items.Clear(); colKodKlienta.DataSource = Db.Load("SELECT KodKlienta, FIO FROM Klienty ORDER BY FIO");
            colKodUslugi1.Items.Clear(); colKodUslugi1.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            colKodUslugi2.Items.Clear(); colKodUslugi2.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            colKodUslugi3.Items.Clear(); colKodUslugi3.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            colKodSotrudnika.Items.Clear(); colKodSotrudnika.DataSource = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            grid.DataSource = bs;

            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new ProkatGridForm().Show();
            btnReport.Click += (s, e) => new ProkatReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Prokat", c); da.Fill(_dt); bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Prokat", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) grid.Rows.Remove(grid.CurrentRow);
        }
    }
}
