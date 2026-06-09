using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная (карточная) форма. Раскладка — в SotrudnikiForm.Designer.cs.</summary>
    public partial class SotrudnikiForm : Form
    {
        private readonly DataTable _dt = new();

        public SotrudnikiForm()
        {
            InitializeComponent();

            // Постер
            try
            {
                string p = Path.Combine(AppContext.BaseDirectory, "Assets", "posters", "sotrudniki.png");
                if (File.Exists(p)) pictureBox.Image = Image.FromFile(p);
            }
            catch { }

            txtFIO.DataBindings.Add("Text", bs, "FIO", true, DataSourceUpdateMode.OnPropertyChanged);
            txtVozrast.DataBindings.Add("Text", bs, "Vozrast", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPol.DataBindings.Add("Text", bs, "Pol", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAdres.DataBindings.Add("Text", bs, "Adres", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTelefon.DataBindings.Add("Text", bs, "Telefon", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPasport.DataBindings.Add("Text", bs, "Pasport", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodDolzhnosti.DataSource = Db.Load("SELECT KodDolzhnosti, Naimenovanie FROM Dolzhnosti ORDER BY Naimenovanie");
            cmbKodDolzhnosti.DisplayMember = "Naimenovanie";
            cmbKodDolzhnosti.ValueMember = "KodDolzhnosti";
            cmbKodDolzhnosti.DataBindings.Add("SelectedValue", bs, "KodDolzhnosti", true, DataSourceUpdateMode.OnPropertyChanged);

            btnFirst.Click  += (s, e) => { if (bs.Count > 0) bs.MoveFirst(); };
            btnPrev.Click   += (s, e) => { if (bs.Count > 0) bs.MovePrevious(); };
            btnNext.Click   += (s, e) => { if (bs.Count > 0) bs.MoveNext(); };
            btnLast.Click   += (s, e) => { if (bs.Count > 0) bs.MoveLast(); };
            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new SotrudnikiGridForm().Show();
            btnReport.Click += (s, e) => new SotrudnikiReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try
            {
                _dt.Clear();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c);
                da.Fill(_dt);
                bs.DataSource = _dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Save()
        {
            try
            {
                bs.EndEdit();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Sotrudniki", c);
                using var b = new SqlCommandBuilder(da);
                da.Update(_dt);
                MessageBox.Show("Сохранено.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Del()
        {
            if (bs.Current == null) return;
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                bs.RemoveCurrent();
        }
    }
}
