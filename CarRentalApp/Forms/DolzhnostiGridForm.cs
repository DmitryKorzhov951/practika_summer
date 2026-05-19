using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class DolzhnostiGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        private readonly TextBox _f = new() { Width = 140 };
        private readonly TextBox _s = new() { Width = 140 };

        public DolzhnostiGridForm()
        {
            Text = "Должности (табличная)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 480);
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeBanner("Должности — табличная форма", "dolzhnosti"));

            var top = UI.MakeParamsPanel();
            top.Controls.Add(L("Поле:")); top.Controls.Add(_cmb);
            top.Controls.Add(L("Фильтр:")); top.Controls.Add(_f);
            top.Controls.Add(UI.MakeBtn("▲", (s,e)=>Sort(true), 30));
            top.Controls.Add(UI.MakeBtn("▼", (s,e)=>Sort(false), 30));
            top.Controls.Add(L("Поиск:")); top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s,e) => Flt(); _s.TextChanged += (s,e) => Flt();

            _grid.Dock = DockStyle.Fill;
            UI.StyleGrid(_grid);
            _grid.ReadOnly = true;
            _grid.AllowUserToAddRows = false;
            _grid.DataSource = _bs;
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s,e) => new DolzhnostiReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s,e) => Close()));
            Controls.Add(btns);

            const string sql = "SELECT Naimenovanie AS [Наименование], Oklad AS [Оклад], Obyazannosti AS [Обязанности], Trebovaniya AS [Требования] FROM Dolzhnosti";
            var dt = Db.Load(sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }

        private static Label L(string t) => new() { Text = t, AutoSize = true, Padding = new Padding(0, 9, 4, 0), Font = UI.BodyBold, ForeColor = UI.TextDim, BackColor = Color.Transparent };
        private void Sort(bool asc) { if (_cmb.SelectedItem == null) return; try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc?"ASC":"DESC"); } catch { } }
        private void Flt()
        {
            try
            {
                string f = "";
                if (_cmb.SelectedItem != null && !string.IsNullOrEmpty(_f.Text))
                    f = $"CONVERT([{_cmb.SelectedItem}], 'System.String') LIKE '%{_f.Text.Replace("'", "''")}%'";
                if (!string.IsNullOrEmpty(_s.Text))
                {
                    var v = _s.Text.Replace("'", "''");
                    var x = "(" + string.Join(" OR ", _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? x : $"({f}) AND {x}";
                }
                _bs.Filter = f;
            }
            catch { }
        }
    }
}
