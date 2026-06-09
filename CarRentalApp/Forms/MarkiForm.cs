using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная (карточная) форма. Раскладка — в MarkiForm.Designer.cs.</summary>
    public partial class MarkiForm : Form
    {
        private readonly DataTable _dt = new();

        public MarkiForm()
        {
            InitializeComponent();

            // Постер
            try
            {
                string p = Path.Combine(AppContext.BaseDirectory, "Assets", "posters", "marki.png");
                if (File.Exists(p)) pictureBox.Image = Image.FromFile(p);
            }
            catch { }

            txtNaimenovanie.DataBindings.Add("Text", bs, "Naimenovanie", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHarakteristiki.DataBindings.Add("Text", bs, "Harakteristiki", true, DataSourceUpdateMode.OnPropertyChanged);
            txtOpisanie.DataBindings.Add("Text", bs, "Opisanie", true, DataSourceUpdateMode.OnPropertyChanged);

            btnFirst.Click  += (s, e) => { if (bs.Count > 0) bs.MoveFirst(); };
            btnPrev.Click   += (s, e) => { if (bs.Count > 0) bs.MovePrevious(); };
            btnNext.Click   += (s, e) => { if (bs.Count > 0) bs.MoveNext(); };
            btnLast.Click   += (s, e) => { if (bs.Count > 0) bs.MoveLast(); };
            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new MarkiGridForm().Show();
            btnReport.Click += (s, e) => new MarkiReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try
            {
                _dt.Clear();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Marki", c);
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
                using var da = new SqlDataAdapter("SELECT * FROM Marki", c);
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
