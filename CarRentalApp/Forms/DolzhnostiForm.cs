using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная (карточная) форма «Должности». Раскладка — в DolzhnostiForm.Designer.cs.</summary>
    public partial class DolzhnostiForm : Form
    {
        private readonly DataTable _dt = new();

        public DolzhnostiForm()
        {
            InitializeComponent();

            // Постер из Assets/posters
            try
            {
                string p = Path.Combine(AppContext.BaseDirectory, "Assets", "posters", "dolzhnosti.png");
                if (File.Exists(p)) pictureBox.Image = Image.FromFile(p);
            }
            catch { }

            // Привязка полей к BindingSource
            txtNaim.DataBindings.Add("Text", bs, "Naimenovanie", true, DataSourceUpdateMode.OnPropertyChanged);
            txtOklad.DataBindings.Add("Text", bs, "Oklad",        true, DataSourceUpdateMode.OnPropertyChanged);
            txtObyaz.DataBindings.Add("Text", bs, "Obyazannosti", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTreb.DataBindings.Add("Text", bs, "Trebovaniya",   true, DataSourceUpdateMode.OnPropertyChanged);

            btnFirst.Click  += (s, e) => { if (bs.Count > 0) bs.MoveFirst(); };
            btnPrev.Click   += (s, e) => { if (bs.Count > 0) bs.MovePrevious(); };
            btnNext.Click   += (s, e) => { if (bs.Count > 0) bs.MoveNext(); };
            btnLast.Click   += (s, e) => { if (bs.Count > 0) bs.MoveLast(); };
            btnAdd.Click    += (s, e) => bs.AddNew();
            btnDel.Click    += (s, e) => Del();
            btnSave.Click   += (s, e) => Save();
            btnTable.Click  += (s, e) => new DolzhnostiGridForm().Show();
            btnReport.Click += (s, e) => new DolzhnostiReport().Show();
            btnClose.Click  += (s, e) => Close();

            Load_();
        }

        private void Load_()
        {
            try
            {
                _dt.Clear();
                using var c = Db.Open();
                using var da = new SqlDataAdapter("SELECT * FROM Dolzhnosti", c);
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
                using var da = new SqlDataAdapter("SELECT * FROM Dolzhnosti", c);
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
