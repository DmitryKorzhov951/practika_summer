using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Ленточная форма "Клиенты". Раскладка контролов — в KlientyForm.Designer.cs.</summary>
    public partial class KlientyForm : Form
    {
        private readonly DataTable _dt = new();
        private readonly BindingSource _bs = new();

        public KlientyForm()
        {
            InitializeComponent();

            // Тёмная тема и стиль таблицы поверх дизайнерской раскладки
            UI.ApplyTheme(this);
            UI.StyleGrid(grid);
            grid.DataSource = _bs;

            // Навигатор перемещения по записям (под шапкой)
            Controls.Add(new BindingNavigator(_bs)
            {
                Dock = DockStyle.Top, AddNewItem = null, DeleteItem = null
            });

            // Стилизация кнопок + обработчики
            Style(btnAdd,   UI.BtnStyle.Accent,  (s, e) => _bs.AddNew());
            Style(btnDel,   UI.BtnStyle.Danger,  (s, e) => Del());
            Style(btnSave,  UI.BtnStyle.Primary, (s, e) => Save());
            Style(btnTable, UI.BtnStyle.Default, (s, e) => new KlientyGridForm().Show());
            Style(btnReport,UI.BtnStyle.Default, (s, e) => new KlientyReport().Show());
            Style(btnClose, UI.BtnStyle.Default, (s, e) => Close());

            Load_();
        }

        private static void Style(Button b, UI.BtnStyle st, EventHandler onClick)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.Font = UI.BodyBold;
            b.FlatAppearance.BorderSize = 1;
            switch (st)
            {
                case UI.BtnStyle.Primary: b.BackColor = UI.Primary;   b.ForeColor = UI.OnPrimary; b.FlatAppearance.BorderColor = UI.Primary; break;
                case UI.BtnStyle.Accent:  b.BackColor = UI.Accent;    b.ForeColor = System.Drawing.Color.FromArgb(40,28,0); b.FlatAppearance.BorderColor = UI.Accent; break;
                case UI.BtnStyle.Danger:  b.BackColor = UI.PrimaryDk; b.ForeColor = UI.OnPrimary; b.FlatAppearance.BorderColor = UI.PrimaryDk; break;
                default:                  b.BackColor = UI.Surface;   b.ForeColor = UI.Text;      b.FlatAppearance.BorderColor = UI.Border; break;
            }
            b.Click += onClick;
        }

        private void Load_()
        {
            try { _dt.Clear(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); da.Fill(_dt); _bs.DataSource = _dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Save()
        {
            try { _bs.EndEdit(); using var c = Db.Open(); using var da = new SqlDataAdapter("SELECT * FROM Klienty", c); using var b = new SqlCommandBuilder(da); _ = b; da.Update(_dt); MessageBox.Show("Сохранено."); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Del()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Удалить?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes) grid.Rows.Remove(grid.CurrentRow);
        }
    }
}
