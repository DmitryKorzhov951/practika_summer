using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    // AvtomobiliForm перенесена в AvtomobiliForm.cs + AvtomobiliForm.Designer.cs

    public class AvtomobiliGridForm : Form
    {
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs  = new();
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
        private readonly TextBox _f = new() { Width = 140 };
        private readonly TextBox _s = new() { Width = 140 };

        public AvtomobiliGridForm()
        {
            Text = "Автомобили (табличная)";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 520);
            UI.ApplyTheme(this);

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
            btns.Controls.Add(UI.MakeBtn("Отчёт",   (s,e) => new AvtomobiliReport().Show()));
            btns.Controls.Add(UI.MakeBtn("Закрыть", (s,e) => Close()));
            Controls.Add(btns);
            Controls.Add(UI.MakeBanner("Автомобили — табличная форма", "avtomobili"));

            var dt = Db.Load(SqlText); _bs.DataSource = dt;
            foreach (DataColumn c in dt.Columns) _cmb.Items.Add(c.ColumnName);
            if (_cmb.Items.Count > 0) _cmb.SelectedIndex = 0;
        }
        public const string SqlText = @"
            SELECT m.Naimenovanie  AS [Марка],
                   a.RegNomer       AS [Рег. номер],
                   a.NomerKuzova    AS [Кузов],
                   a.NomerDvigatelya AS [Двигатель],
                   a.GodVypuska     AS [Год],
                   a.Probeg         AS [Пробег],
                   a.CenaAvto       AS [Цена],
                   a.CenaDnyaProkata AS [Цена/день],
                   a.DataTO         AS [Дата ТО],
                   s.FIO            AS [Механик],
                   a.Otmetki        AS [Отметки],
                   a.Vozvrachen     AS [Возвращён]
            FROM Avtomobili a
            JOIN Marki      m ON a.KodMarki    = m.KodMarki
            JOIN Sotrudniki s ON a.KodMehanika = s.KodSotrudnika";
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

    public class AvtomobiliReport : ReportForm
    {
        public AvtomobiliReport() : base("Автомобили", AvtomobiliGridForm.SqlText, "avtomobili") { }
    }
}
