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
        protected readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        protected readonly TextBox _f = new() { Width = 180 };
        protected readonly TextBox _s = new() { Width = 180 };
        private readonly string _title;
        private readonly string _sql;
        private readonly Action _onReport;

        public QueryGridForm(string title, string sql, Action onReport)
        {
            _title = title; _sql = sql; _onReport = onReport;

            Text = title + " (запрос)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 600);

            Controls.Add(new Label
            {
                Text = "Запрос «" + title + "»", Dock = DockStyle.Top, Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 44, Padding = new Padding(6) };
            top.Controls.Add(new Label { Text = "Поле:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_cmb);
            top.Controls.Add(new Label { Text = " фильтр:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_f);
            var ba = new Button { Text="▲", Width=40 }; ba.Click += (s,e)=>Sort(true);
            var bd = new Button { Text="▼", Width=40 }; bd.Click += (s,e)=>Sort(false);
            top.Controls.Add(ba); top.Controls.Add(bd);
            top.Controls.Add(new Label { Text = " поиск:", AutoSize = true, Padding = new Padding(0,8,4,0) });
            top.Controls.Add(_s);
            Controls.Add(top);
            _f.TextChanged += (s,e) => Flt(); _s.TextChanged += (s,e) => Flt();

            _grid.Dock = DockStyle.Fill; _grid.ReadOnly = true; _grid.AllowUserToAddRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.DataSource = _bs;
            Controls.Add(_grid);
            Controls.Add(new BindingNavigator(_bs) { Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null });

            var btns = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, Padding = new Padding(6) };
            btns.Controls.Add(B("Поиск", Color.SteelBlue, (s,e) => _s.Focus()));
            btns.Controls.Add(B("Отчёт", Color.MediumSeaGreen, (s,e) => _onReport?.Invoke()));
            ExtendButtons(btns);
            btns.Controls.Add(B("Закрыть", Color.Gray, (s,e) => Close()));
            Controls.Add(btns);

            var dt = Db.Load(_sql); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }

        /// <summary>Дополнительные кнопки (для наследников).</summary>
        protected virtual void ExtendButtons(FlowLayoutPanel panel) { }

        protected static Button B(string t, Color c, EventHandler h) { var b = new Button { Text = t, Width = 130, Height = 32, BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) }; b.Click += h; return b; }

        private void Sort(bool asc) { if (_cmb.SelectedItem == null) return; try { _bs.Sort = $"[{_cmb.SelectedItem}] " + (asc?"ASC":"DESC"); } catch { } }
        private void Flt()
        {
            try
            {
                string f = "";
                if (_cmb.SelectedItem != null && !string.IsNullOrEmpty(_f.Text))
                    f = $"CONVERT([{_cmb.SelectedItem}], 'System.String') LIKE '%{_f.Text.Replace("'","''")}%'";
                if (!string.IsNullOrEmpty(_s.Text))
                {
                    var v = _s.Text.Replace("'","''");
                    var x = "(" + string.Join(" OR ", _grid.Columns.Cast<DataGridViewColumn>()
                        .Select(c => $"CONVERT([{c.Name}], 'System.String') LIKE '%{v}%'")) + ")";
                    f = string.IsNullOrEmpty(f) ? x : $"({f}) AND {x}";
                }
                _bs.Filter = f;
            } catch { }
        }
    }
}
