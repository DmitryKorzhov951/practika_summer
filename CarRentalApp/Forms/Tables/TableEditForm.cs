using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarRentalApp.Configs;

namespace CarRentalApp.Forms.Tables
{
    /// <summary>
    /// Ленточная форма редактирования таблицы.
    /// Показывает все записи одновременно в DataGridView с редактируемыми ячейками.
    /// Внешние ключи отображаются выпадающими списками (DataGridViewComboBoxColumn).
    /// Поля связи (счётчики - первичные ключи) на форме не отображаются.
    /// </summary>
    public class TableEditForm : Form
    {
        private readonly TableConfig _cfg;
        private readonly DataTable _data = new();
        private readonly DataGridView _grid = new();
        private readonly BindingSource _bs = new();

        public TableEditForm(TableConfig cfg)
        {
            _cfg = cfg;
            Text = "Ленточная форма: " + cfg.Title;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 660);
            MinimumSize = new Size(800, 500);

            var lblHeader = new Label
            {
                Text      = "Ленточная форма: " + cfg.Title,
                Font      = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 60, 120),
                ForeColor = Color.White,
                Dock      = DockStyle.Top, Height = 44,
                TextAlign = ContentAlignment.MiddleCenter
            };

            _grid.Dock = DockStyle.Fill;
            _grid.AutoGenerateColumns = false;
            _grid.AllowUserToAddRows = true;
            _grid.AllowUserToDeleteRows = false;
            _grid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            _grid.RowHeadersWidth = 40;
            _grid.RowTemplate.Height = 32;
            _grid.DataSource = _bs;

            var nav = new BindingNavigator(_bs)
            {
                Dock = DockStyle.Bottom, AddNewItem = null, DeleteItem = null
            };

            var bottom = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom, Height = 50, BackColor = Color.Gainsboro,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8)
            };

            var btnAdd  = MakeBtn("Добавить",        Color.FromArgb(80, 170, 100), () => _bs.AddNew());
            var btnSave = MakeBtn("Сохранить",       Color.FromArgb(80, 130, 200), SaveAll);
            var btnDel  = MakeBtn("Удалить",         Color.FromArgb(200, 80, 80),  DeleteRecord);
            var btnGrid = MakeBtn("Табличная форма", Color.Empty,                  () => new TableGridForm(_cfg).Show(), 150);
            var btnRep  = MakeBtn("Открыть отчёт",   Color.Empty,                  () => new ReportForm(_cfg).Show(),     140);
            var btnPage = MakeBtn("Страница",        Color.Empty,                  () => new PageForm(_cfg).Show(),       110);
            var btnClose= MakeBtn("Закрыть",         Color.Empty,                  Close);

            bottom.Controls.AddRange(new Control[] { btnAdd, btnSave, btnDel, btnGrid, btnRep, btnPage, btnClose });

            Controls.Add(_grid);
            Controls.Add(bottom);
            Controls.Add(nav);
            Controls.Add(lblHeader);

            BuildColumns();
            LoadData();
        }

        private static Button MakeBtn(string text, Color back, Action onClick, int width = 120)
        {
            var b = new Button
            {
                Text = text, Width = width, Height = 32,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            if (back != Color.Empty)
            {
                b.BackColor = back; b.ForeColor = Color.White; b.FlatStyle = FlatStyle.Flat;
            }
            b.Click += (s, e) => onClick();
            return b;
        }

        private void BuildColumns()
        {
            _grid.Columns.Clear();
            foreach (var f in _cfg.Fields)
            {
                if (f.IsPrimaryKey) continue; // PK не отображаем
                DataGridViewColumn col;
                if (f.Type == FieldType.Lookup)
                {
                    var combo = new DataGridViewComboBoxColumn
                    {
                        DataPropertyName = f.Column,
                        HeaderText       = f.Caption,
                        Name             = f.Column,
                        DataSource       = LoadLookupData(f),
                        DisplayMember    = f.LookupNameCol,
                        ValueMember      = f.LookupKeyCol,
                        FlatStyle        = FlatStyle.Flat
                    };
                    col = combo;
                }
                else if (f.Type == FieldType.Bit)
                {
                    col = new DataGridViewCheckBoxColumn
                    {
                        DataPropertyName = f.Column,
                        HeaderText       = f.Caption,
                        Name             = f.Column
                    };
                }
                else
                {
                    col = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = f.Column,
                        HeaderText       = f.Caption,
                        Name             = f.Column
                    };
                    if (f.Type == FieldType.Date)
                        col.DefaultCellStyle.Format = "dd.MM.yyyy";
                    if (f.Type == FieldType.Money)
                        col.DefaultCellStyle.Format = "N2";
                }
                _grid.Columns.Add(col);
            }
        }

        private DataTable LoadLookupData(FieldConfig f)
        {
            var dt = Db.LoadTable($"SELECT {f.LookupKeyCol}, {f.LookupNameCol} FROM {f.LookupTable} ORDER BY {f.LookupNameCol}");
            if (f.LookupNullable)
            {
                var r = dt.NewRow();
                r[f.LookupKeyCol]  = DBNull.Value;
                r[f.LookupNameCol] = "(не выбрано)";
                dt.Rows.InsertAt(r, 0);
            }
            return dt;
        }

        private void LoadData()
        {
            try
            {
                _data.Clear();
                using var conn = Db.Open();
                using var cmd = new SqlCommand($"SELECT * FROM {_cfg.TableName}", conn);
                using var da = new SqlDataAdapter(cmd);
                da.Fill(_data);
                _bs.DataSource = _data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord()
        {
            if (_bs.Current is not DataRowView drv) return;
            if (MessageBox.Show("Удалить текущую запись?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                int id = Convert.ToInt32(drv[_cfg.PrimaryKeyCol]);
                Db.Exec($"DELETE FROM {_cfg.TableName} WHERE {_cfg.PrimaryKeyCol} = @id",
                    new SqlParameter("@id", id));
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAll()
        {
            try
            {
                _bs.EndEdit();
                using var conn = Db.Open();
                using var cmd = new SqlCommand($"SELECT * FROM {_cfg.TableName}", conn);
                using var da = new SqlDataAdapter(cmd);
                using var bld = new SqlCommandBuilder(da);
                _ = bld; // подсказка компилятору, что bld нужен (привязывается к da)
                da.Update(_data);
                MessageBox.Show("Изменения сохранены.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
