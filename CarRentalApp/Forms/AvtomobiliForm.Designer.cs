namespace CarRentalApp.Forms
{
    partial class AvtomobiliForm
    {
        private System.ComponentModel.IContainer components = null;
        private CarRentalApp.Controls.BandedHeader header;
        private System.Windows.Forms.BindingNavigator nav;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton navMoveFirst;
        private System.Windows.Forms.ToolStripButton navMovePrev;
        private System.Windows.Forms.ToolStripTextBox navPosition;
        private System.Windows.Forms.ToolStripLabel navCount;
        private System.Windows.Forms.ToolStripButton navMoveNext;
        private System.Windows.Forms.ToolStripButton navMoveLast;
        private System.Windows.Forms.ToolStripSeparator navSep1;
        private System.Windows.Forms.ToolStripButton navAddNew;
        private System.Windows.Forms.ToolStripButton navDelete;
        private CarRentalApp.Controls.StyledGrid grid;
        private System.Windows.Forms.Panel panelButtons;
        private CarRentalApp.Controls.ColoredButton btnAdd;
        private CarRentalApp.Controls.ColoredButton btnDel;
        private CarRentalApp.Controls.ColoredButton btnSave;
        private CarRentalApp.Controls.ColoredButton btnTable;
        private CarRentalApp.Controls.ColoredButton btnReport;
        private CarRentalApp.Controls.ColoredButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegNomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomerKuzova;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomerDvigatelya;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGodVypuska;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProbeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCenaAvto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCenaDnyaProkata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtmetki;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVozvrachen;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodMarki;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodMehanika;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.header = new CarRentalApp.Controls.BandedHeader();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.nav = new System.Windows.Forms.BindingNavigator(this.components);
            this.navMoveFirst = new System.Windows.Forms.ToolStripButton();
            this.navMovePrev = new System.Windows.Forms.ToolStripButton();
            this.navPosition = new System.Windows.Forms.ToolStripTextBox();
            this.navCount = new System.Windows.Forms.ToolStripLabel();
            this.navMoveNext = new System.Windows.Forms.ToolStripButton();
            this.navMoveLast = new System.Windows.Forms.ToolStripButton();
            this.navSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.navAddNew = new System.Windows.Forms.ToolStripButton();
            this.navDelete = new System.Windows.Forms.ToolStripButton();
            this.grid = new CarRentalApp.Controls.StyledGrid();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new CarRentalApp.Controls.ColoredButton();
            this.btnDel = new CarRentalApp.Controls.ColoredButton();
            this.btnSave = new CarRentalApp.Controls.ColoredButton();
            this.btnTable = new CarRentalApp.Controls.ColoredButton();
            this.btnReport = new CarRentalApp.Controls.ColoredButton();
            this.btnClose = new CarRentalApp.Controls.ColoredButton();
            this.colRegNomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomerKuzova = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomerDvigatelya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGodVypuska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProbeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCenaAvto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCenaDnyaProkata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtmetki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVozvrachen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKodMarki = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodMehanika = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка =====
            this.header.Title = "АВТОМОБИЛИ";
            this.header.Size = new System.Drawing.Size(1200, 56);

            // ===== BindingNavigator =====
            this.nav.AddNewItem = this.navAddNew;
            this.nav.BindingSource = this.bs;
            this.nav.CountItem = this.navCount;
            this.nav.DeleteItem = this.navDelete;
            this.nav.Dock = System.Windows.Forms.DockStyle.Top;
            this.nav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.navMoveFirst, this.navMovePrev, this.navPosition, this.navCount,
                this.navMoveNext, this.navMoveLast, this.navSep1, this.navAddNew, this.navDelete});
            this.nav.MoveFirstItem = this.navMoveFirst;
            this.nav.MoveLastItem = this.navMoveLast;
            this.nav.MoveNextItem = this.navMoveNext;
            this.nav.MovePreviousItem = this.navMovePrev;
            this.nav.Name = "nav";
            this.nav.PositionItem = this.navPosition;
            this.nav.Size = new System.Drawing.Size(1200, 25);
            this.navMoveFirst.Name = "navMoveFirst"; this.navMoveFirst.Text = "|<"; this.navMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMovePrev.Name = "navMovePrev"; this.navMovePrev.Text = "<"; this.navMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navPosition.Name = "navPosition"; this.navPosition.Size = new System.Drawing.Size(40, 25); this.navPosition.Text = "1";
            this.navCount.Name = "navCount"; this.navCount.Text = "/ {0}"; this.navCount.ToolTipText = "Всего записей";
            this.navMoveNext.Name = "navMoveNext"; this.navMoveNext.Text = ">"; this.navMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMoveLast.Name = "navMoveLast"; this.navMoveLast.Text = ">|"; this.navMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navSep1.Name = "navSep1";
            this.navAddNew.Name = "navAddNew"; this.navAddNew.Text = "+"; this.navAddNew.ForeColor = System.Drawing.Color.Green; this.navAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navDelete.Name = "navDelete"; this.navDelete.Text = "X"; this.navDelete.ForeColor = System.Drawing.Color.DarkRed; this.navDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            // ===== Сетка =====
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colRegNomer,
                this.colNomerKuzova,
                this.colNomerDvigatelya,
                this.colGodVypuska,
                this.colProbeg,
                this.colCenaAvto,
                this.colCenaDnyaProkata,
                this.colDataTO,
                this.colOtmetki,
                this.colVozvrachen,
                this.colKodMarki,
                this.colKodMehanika});
            this.colRegNomer.DataPropertyName = "RegNomer"; this.colRegNomer.HeaderText = "Рег. номер"; this.colRegNomer.Name = "colRegNomer"; this.colRegNomer.MinimumWidth = 90;
            this.colNomerKuzova.DataPropertyName = "NomerKuzova"; this.colNomerKuzova.HeaderText = "Кузов"; this.colNomerKuzova.Name = "colNomerKuzova"; this.colNomerKuzova.MinimumWidth = 90;
            this.colNomerDvigatelya.DataPropertyName = "NomerDvigatelya"; this.colNomerDvigatelya.HeaderText = "Двигатель"; this.colNomerDvigatelya.Name = "colNomerDvigatelya"; this.colNomerDvigatelya.MinimumWidth = 90;
            this.colGodVypuska.DataPropertyName = "GodVypuska"; this.colGodVypuska.HeaderText = "Год"; this.colGodVypuska.Name = "colGodVypuska"; this.colGodVypuska.MinimumWidth = 90;
            this.colProbeg.DataPropertyName = "Probeg"; this.colProbeg.HeaderText = "Пробег"; this.colProbeg.Name = "colProbeg"; this.colProbeg.MinimumWidth = 90;
            this.colCenaAvto.DataPropertyName = "CenaAvto"; this.colCenaAvto.HeaderText = "Цена"; this.colCenaAvto.Name = "colCenaAvto"; this.colCenaAvto.MinimumWidth = 90;
            this.colCenaDnyaProkata.DataPropertyName = "CenaDnyaProkata"; this.colCenaDnyaProkata.HeaderText = "Цена/день"; this.colCenaDnyaProkata.Name = "colCenaDnyaProkata"; this.colCenaDnyaProkata.MinimumWidth = 90;
            this.colDataTO.DataPropertyName = "DataTO"; this.colDataTO.HeaderText = "Дата ТО"; this.colDataTO.Name = "colDataTO"; this.colDataTO.MinimumWidth = 90;
            this.colOtmetki.DataPropertyName = "Otmetki"; this.colOtmetki.HeaderText = "Отметки"; this.colOtmetki.Name = "colOtmetki"; this.colOtmetki.MinimumWidth = 90;
            this.colVozvrachen.DataPropertyName = "Vozvrachen"; this.colVozvrachen.HeaderText = "Возвращён"; this.colVozvrachen.Name = "colVozvrachen";
            this.colKodMarki.DataPropertyName = "KodMarki"; this.colKodMarki.HeaderText = "Марка"; this.colKodMarki.Name = "colKodMarki"; this.colKodMarki.DisplayMember = "Naimenovanie"; this.colKodMarki.ValueMember = "KodMarki"; this.colKodMarki.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodMarki.MinimumWidth = 110;
            this.colKodMarki.Items.AddRange(new object[] { "Toyota", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Hyundai", "Kia", "Lada" });
            this.colKodMehanika.DataPropertyName = "KodMehanika"; this.colKodMehanika.HeaderText = "Механик"; this.colKodMehanika.Name = "colKodMehanika"; this.colKodMehanika.DisplayMember = "FIO"; this.colKodMehanika.ValueMember = "KodSotrudnika"; this.colKodMehanika.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodMehanika.MinimumWidth = 110;
            this.colKodMehanika.Items.AddRange(new object[] { "Сидоров А. М.", "Кузнецов Д. О.", "Фёдоров А. И." });

            // ===== Образец строк (видимы только в конструкторе) =====
            this.grid.Rows.Add(new object[] { "А123БВ77", "KX12345", "DV12345", "2020", "50000", "1500000", "2500", "01.01.2024", "Хорошее", "True", "Toyota", "Сидоров А. М." });
            this.grid.Rows.Add(new object[] { "В234ГД77", "KX23456", "DV23456", "2021", "30000", "2500000", "3500", "15.02.2024", "Отличное", "True", "BMW", "Кузнецов Д. О." });
            this.grid.Rows.Add(new object[] { "Е345ЖЗ77", "KX34567", "DV34567", "2019", "75000", "2000000", "3000", "10.03.2024", "Среднее", "False", "Mercedes-Benz", "Фёдоров А. И." });
            this.grid.Rows.Add(new object[] { "К456ЛМ77", "KX45678", "DV45678", "2022", "20000", "2800000", "3800", "20.04.2024", "Отличное", "True", "Audi", "Сидоров А. М." });
            this.grid.Rows.Add(new object[] { "Н567ОП77", "KX56789", "DV56789", "2018", "90000", "1200000", "2200", "05.05.2024", "Среднее", "True", "Volkswagen", "Кузнецов Д. О." });
            this.grid.Rows.Add(new object[] { "Р678СТ77", "KX67890", "DV67890", "2021", "40000", "1400000", "2400", "12.06.2024", "Хорошее", "False", "Hyundai", "Фёдоров А. И." });
            this.grid.Rows.Add(new object[] { "У789ФХ77", "KX78901", "DV78901", "2020", "55000", "1300000", "2300", "18.07.2024", "Хорошее", "True", "Kia", "Сидоров А. М." });
            this.grid.Rows.Add(new object[] { "Ц890ЧШ77", "KX89012", "DV89012", "2023", "10000", "900000", "1800", "25.08.2024", "Отличное", "True", "Lada", "Кузнецов Д. О." });

            // ===== Нижняя панель кнопок =====
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnTable);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 50);

            this.btnAdd.Variant = CarRentalApp.Controls.BtnVariant.Add;     this.btnAdd.Text = "Добавить";   this.btnAdd.Location = new System.Drawing.Point(12, 9);   this.btnAdd.Name = "btnAdd";
            this.btnDel.Variant = CarRentalApp.Controls.BtnVariant.Delete;  this.btnDel.Text = "Удалить";    this.btnDel.Location = new System.Drawing.Point(128, 9);  this.btnDel.Name = "btnDel";
            this.btnSave.Variant = CarRentalApp.Controls.BtnVariant.Save;   this.btnSave.Text = "Сохранить"; this.btnSave.Location = new System.Drawing.Point(244, 9);  this.btnSave.Name = "btnSave";
            this.btnTable.Variant = CarRentalApp.Controls.BtnVariant.Default;  this.btnTable.Text = "Табличная"; this.btnTable.Location = new System.Drawing.Point(360, 9); this.btnTable.Name = "btnTable";
            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.Default; this.btnReport.Text = "Отчёт";    this.btnReport.Location = new System.Drawing.Point(476, 9); this.btnReport.Name = "btnReport";
            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Default;  this.btnClose.Text = "Закрыть";   this.btnClose.Location = new System.Drawing.Point(592, 9); this.btnClose.Name = "btnClose";

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(1200, 580);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "AvtomobiliForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автомобили";

            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.nav.ResumeLayout(false);
            this.nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
