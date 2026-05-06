using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    /// <summary>Универсальная табличная форма для запроса (только просмотр).</summary>
    public class QueryGridForm : Form
    {
        protected readonly DataGridView _grid = new();
        protected readonly BindingSource _bs  = new();
        protected readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        protected readonly TextBox _f = new() { Width = 140 };
        protected readonly TextBox _s = new() { Width = 140 };
        private readonly Action _onReport;

        public QueryGridForm(string title, string sql, Action onReport)
        {
            _onReport = onReport;

            Text = "Запрос: " + title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(960, 520);
            Font = UI.Body;

            Controls.Add(UI.MakeHeader("Запрос «" + title + "»"));

            // Панель сорт/фильтр/поиск
            var top = UI.MakeParamsPanel();
            top.Controls.Add(L("Поле:"));
            top.Controls.Add(_cmb);
            top.Controls.Add(L("Фильтр:"));
            top.Controls.Add(_f);
            top.Controls.Add(UI.MakeBtn("▲", (s, e) => Sort(true), 30));
            top.Controls.Add(UI.MakeBtn("▼", (s, e) => Sort(false), 30));
            top.Controls.Add(L("Поиск:"));
            top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s, e) => Flt();
            _s.TextChanged += (s, e) => Flt();

            _grid.Dock = DockStyle.Fill;
            _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            _grid.RowHeadersVisible = false;
            _grid.DataSource = _bs;
            Controls.Add(_grid);

            Controls.Add(new BindingNavigator(_bs)
            {
                Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null
            });

            var btns = UI.MakeButtonsPanel();
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s, e) => _onReport?.Invoke()));
            ExtendButtons(btns);
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s, e) => Close()));
            Controls.Add(btns);

            var dt = Db.Load(sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }

        protected virtual void ExtendButtons(FlowLayoutPanel panel) { }

        private static Label L(string text) => new()
        {
            Text = text, AutoSize = true, Padding = new Padding(0, 6, 4, 0)
        };

        private void Sort(bool asc)
        {
            if (_cmb.SelectedItem == null) return;
            try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc ? "ASC" : "DESC"); } catch { }
        }
        protected void Flt()
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
