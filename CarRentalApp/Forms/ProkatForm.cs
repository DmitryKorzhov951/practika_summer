using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная (карточная) форма. Раскладка — в ProkatForm.Designer.cs.</summary>
    public partial class ProkatForm : Form
    {
        private readonly DataTable _dt = new();

        public ProkatForm()
        {
            InitializeComponent();

            // Постер
            try
            {
                string p = Path.Combine(AppContext.BaseDirectory, "Assets", "posters", "prokat.png");
                if (File.Exists(p)) pictureBox.Image = Image.FromFile(p);
            }
            catch { }

            txtDataVydachi.DataBindings.Add("Text", bs, "DataVydachi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSrok.DataBindings.Add("Text", bs, "Srok", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataVozvrata.DataBindings.Add("Text", bs, "DataVozvrata", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCena.DataBindings.Add("Text", bs, "Cena", true, DataSourceUpdateMode.OnPropertyChanged);
            chkOplachen.DataBindings.Add("Checked", bs, "Oplachen", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodAvtomobilya.DataSource = Db.Load("SELECT KodAvtomobilya, RegNomer FROM Avtomobili ORDER BY RegNomer");
            cmbKodAvtomobilya.DisplayMember = "RegNomer";
            cmbKodAvtomobilya.ValueMember = "KodAvtomobilya";
            cmbKodAvtomobilya.DataBindings.Add("SelectedValue", bs, "KodAvtomobilya", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodKlienta.DataSource = Db.Load("SELECT KodKlienta, FIO FROM Klienty ORDER BY FIO");
            cmbKodKlienta.DisplayMember = "FIO";
            cmbKodKlienta.ValueMember = "KodKlienta";
            cmbKodKlienta.DataBindings.Add("SelectedValue", bs, "KodKlienta", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodUslugi1.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            cmbKodUslugi1.DisplayMember = "Naimenovanie";
            cmbKodUslugi1.ValueMember = "KodUslugi";
            cmbKodUslugi1.DataBindings.Add("SelectedValue", bs, "KodUslugi1", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodUslugi2.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            cmbKodUslugi2.DisplayMember = "Naimenovanie";
            cmbKodUslugi2.ValueMember = "KodUslugi";
            cmbKodUslugi2.DataBindings.Add("SelectedValue", bs, "KodUslugi2", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodUslugi3.DataSource = Db.Load("SELECT KodUslugi, Naimenovanie FROM Uslugi ORDER BY Naimenovanie");
            cmbKodUslugi3.DisplayMember = "Naimenovanie";
            cmbKodUslugi3.ValueMember = "KodUslugi";
            cmbKodUslugi3.DataBindings.Add("SelectedValue", bs, "KodUslugi3", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodSotrudnika.DataSource = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            cmbKodSotrudnika.DisplayMember = "FIO";
            cmbKodSotrudnika.ValueMember = "KodSotrudnika";
            cmbKodSotrudnika.DataBindings.Add("SelectedValue", bs, "KodSotrudnika", true, DataSourceUpdateMode.OnPropertyChanged);

            btnFirst.Click  += (s, e) => { if (bs.Count > 0) bs.MoveFirst(); };
            btnPrev.Click   += (s, e) => { if (bs.Count > 0) bs.MovePrevious(); };
            btnNext.Click   += (s, e) => { if (bs.Count > 0) bs.MoveNext(); };
            btnLast.Click   += (s, e) => { if (bs.Count > 0) bs.MoveLast(); };
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
            try
            {
                _dt.Clear();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Prokat", c);
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
                using var da = new SqlDataAdapter("SELECT * FROM Prokat", c);
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
