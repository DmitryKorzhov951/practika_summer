using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Табличная форма Клиенты. Раскладка — в KlientyGridForm.Designer.cs.</summary>
    public partial class KlientyGridForm : Form
    {
        private const string Sql =
            @"SELECT FIO AS [ФИО], Pol AS [Пол], DataRozhdeniya AS [Дата рождения],
                     Adres AS [Адрес], Telefon AS [Телефон], Pasport AS [Паспорт] FROM Klienty";

        public KlientyGridForm()
        {
            InitializeComponent();

            grid.Rows.Clear();
            grid.AutoGenerateColumns = false;
            grid.DataSource = bs;

            btnSortAsc.Click  += (s, e) => Sort(true);
            btnSortDesc.Click += (s, e) => Sort(false);
            btnReport.Click   += (s, e) => new KlientyReport().Show();
            btnClose.Click    += (s, e) => Close();

            txtFilter.TextChanged += (s, e) => Flt();
            txtSearch.TextChanged += (s, e) => Flt();

            Load_();
        }

        private void Load_()
        {
            try { bs.DataSource = Db.Load(Sql); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Sort(bool asc)
        {
            if (cmbPole.SelectedItem == null) return;
            try { bs.Sort = $"[{cmbPole.SelectedItem}] " + (asc ? "ASC" : "DESC"); }
            catch { }
        }

        private void Flt()
        {
            try
            {
                string f = "";
                if (cmbPole.SelectedItem != null && !string.IsNullOrEmpty(txtFilter.Text))
                    f = $"CONVERT([{cmbPole.SelectedItem}], 'System.String') LIKE '%{txtFilter.Text.Replace("'", "''")}%'";
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    var v = txtSearch.Text.Replace("'", "''");
                    var x = "(" + string.Join(" OR ", grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.DataPropertyName}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? x : $"({f}) AND {x}";
                }
                bs.Filter = f;
            }
            catch { }
        }
    }

    public class KlientyReport : ReportForm
    {
        public KlientyReport() : base("Клиенты",
            @"SELECT FIO AS [ФИО], Pol AS [Пол], DataRozhdeniya AS [Дата рождения],
                     Adres AS [Адрес], Telefon AS [Телефон], Pasport AS [Паспорт] FROM Klienty", "klienty") { }
    }
}
