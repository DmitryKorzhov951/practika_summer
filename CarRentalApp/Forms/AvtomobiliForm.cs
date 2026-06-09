using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная (карточная) форма. Раскладка — в AvtomobiliForm.Designer.cs.</summary>
    public partial class AvtomobiliForm : Form
    {
        private readonly DataTable _dt = new();

        public AvtomobiliForm()
        {
            InitializeComponent();

            // Постер
            try
            {
                string p = Path.Combine(AppContext.BaseDirectory, "Assets", "posters", "avtomobili.png");
                if (File.Exists(p)) pictureBox.Image = Image.FromFile(p);
            }
            catch { }

            txtRegNomer.DataBindings.Add("Text", bs, "RegNomer", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNomerKuzova.DataBindings.Add("Text", bs, "NomerKuzova", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNomerDvigatelya.DataBindings.Add("Text", bs, "NomerDvigatelya", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGodVypuska.DataBindings.Add("Text", bs, "GodVypuska", true, DataSourceUpdateMode.OnPropertyChanged);
            txtProbeg.DataBindings.Add("Text", bs, "Probeg", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCenaAvto.DataBindings.Add("Text", bs, "CenaAvto", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCenaDnyaProkata.DataBindings.Add("Text", bs, "CenaDnyaProkata", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataTO.DataBindings.Add("Text", bs, "DataTO", true, DataSourceUpdateMode.OnPropertyChanged);
            txtOtmetki.DataBindings.Add("Text", bs, "Otmetki", true, DataSourceUpdateMode.OnPropertyChanged);
            chkVozvrachen.DataBindings.Add("Checked", bs, "Vozvrachen", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodMarki.DataSource = Db.Load("SELECT KodMarki, Naimenovanie FROM Marki ORDER BY Naimenovanie");
            cmbKodMarki.DisplayMember = "Naimenovanie";
            cmbKodMarki.ValueMember = "KodMarki";
            cmbKodMarki.DataBindings.Add("SelectedValue", bs, "KodMarki", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbKodMehanika.DataSource = Db.Load("SELECT KodSotrudnika, FIO FROM Sotrudniki ORDER BY FIO");
            cmbKodMehanika.DisplayMember = "FIO";
            cmbKodMehanika.ValueMember = "KodSotrudnika";
            cmbKodMehanika.DataBindings.Add("SelectedValue", bs, "KodMehanika", true, DataSourceUpdateMode.OnPropertyChanged);

            btnFirst.Click  += (s, e) => { if (bs.Count > 0) bs.MoveFirst(); };
            btnPrev.Click   += (s, e) => { if (bs.Count > 0) bs.MovePrevious(); };
            btnNext.Click   += (s, e) => { if (bs.Count > 0) bs.MoveNext(); };
            btnLast.Click   += (s, e) => { if (bs.Count > 0) bs.MoveLast(); };
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
            try
            {
                _dt.Clear();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c);
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
                using var da = new SqlDataAdapter("SELECT * FROM Avtomobili", c);
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
