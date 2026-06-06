namespace CarRentalApp.Forms
{
    partial class ProkatForm
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVydachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrok;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVozvrata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCena;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOplachen;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodAvtomobilya;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodKlienta;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodUslugi1;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodUslugi2;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodUslugi3;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodSotrudnika;

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
            this.colDataVydachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSrok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVozvrata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOplachen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKodAvtomobilya = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodKlienta = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodUslugi1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodUslugi2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodUslugi3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKodSotrudnika = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка =====
            this.header.Title = "ПРОКАТ";
            this.header.Size = new System.Drawing.Size(1300, 56);

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
            this.nav.Size = new System.Drawing.Size(1300, 25);
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
                this.colDataVydachi,
                this.colSrok,
                this.colDataVozvrata,
                this.colCena,
                this.colOplachen,
                this.colKodAvtomobilya,
                this.colKodKlienta,
                this.colKodUslugi1,
                this.colKodUslugi2,
                this.colKodUslugi3,
                this.colKodSotrudnika});
            this.colDataVydachi.DataPropertyName = "DataVydachi"; this.colDataVydachi.HeaderText = "Дата выдачи"; this.colDataVydachi.Name = "colDataVydachi"; this.colDataVydachi.MinimumWidth = 90;
            this.colSrok.DataPropertyName = "Srok"; this.colSrok.HeaderText = "Срок"; this.colSrok.Name = "colSrok"; this.colSrok.MinimumWidth = 90;
            this.colDataVozvrata.DataPropertyName = "DataVozvrata"; this.colDataVozvrata.HeaderText = "Дата возврата"; this.colDataVozvrata.Name = "colDataVozvrata"; this.colDataVozvrata.MinimumWidth = 90;
            this.colCena.DataPropertyName = "Cena"; this.colCena.HeaderText = "Цена"; this.colCena.Name = "colCena"; this.colCena.MinimumWidth = 90;
            this.colOplachen.DataPropertyName = "Oplachen"; this.colOplachen.HeaderText = "Оплачен"; this.colOplachen.Name = "colOplachen";
            this.colKodAvtomobilya.DataPropertyName = "KodAvtomobilya"; this.colKodAvtomobilya.HeaderText = "Авто"; this.colKodAvtomobilya.Name = "colKodAvtomobilya"; this.colKodAvtomobilya.DisplayMember = "RegNomer"; this.colKodAvtomobilya.ValueMember = "KodAvtomobilya"; this.colKodAvtomobilya.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodAvtomobilya.MinimumWidth = 110;
            this.colKodAvtomobilya.Items.AddRange(new object[] { "А123БВ77", "В234ГД77", "Е345ЖЗ77", "К456ЛМ77", "Н567ОП77" });
            this.colKodKlienta.DataPropertyName = "KodKlienta"; this.colKodKlienta.HeaderText = "Клиент"; this.colKodKlienta.Name = "colKodKlienta"; this.colKodKlienta.DisplayMember = "FIO"; this.colKodKlienta.ValueMember = "KodKlienta"; this.colKodKlienta.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodKlienta.MinimumWidth = 110;
            this.colKodKlienta.Items.AddRange(new object[] { "Иванов С. П.", "Петрова О. И.", "Сидоров А. М.", "Кузнецов Д. О.", "Морозова А. В." });
            this.colKodUslugi1.DataPropertyName = "KodUslugi1"; this.colKodUslugi1.HeaderText = "Усл. 1"; this.colKodUslugi1.Name = "colKodUslugi1"; this.colKodUslugi1.DisplayMember = "Naimenovanie"; this.colKodUslugi1.ValueMember = "KodUslugi"; this.colKodUslugi1.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodUslugi1.MinimumWidth = 110;
            this.colKodUslugi1.Items.AddRange(new object[] { "Страховка КАСКО", "GPS-навигатор", "Детское кресло", "Доп. водитель", "Зимняя резина" });
            this.colKodUslugi2.DataPropertyName = "KodUslugi2"; this.colKodUslugi2.HeaderText = "Усл. 2"; this.colKodUslugi2.Name = "colKodUslugi2"; this.colKodUslugi2.DisplayMember = "Naimenovanie"; this.colKodUslugi2.ValueMember = "KodUslugi"; this.colKodUslugi2.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodUslugi2.MinimumWidth = 110;
            this.colKodUslugi2.Items.AddRange(new object[] { "Страховка КАСКО", "GPS-навигатор", "Детское кресло", "Доп. водитель", "Зимняя резина" });
            this.colKodUslugi3.DataPropertyName = "KodUslugi3"; this.colKodUslugi3.HeaderText = "Усл. 3"; this.colKodUslugi3.Name = "colKodUslugi3"; this.colKodUslugi3.DisplayMember = "Naimenovanie"; this.colKodUslugi3.ValueMember = "KodUslugi"; this.colKodUslugi3.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodUslugi3.MinimumWidth = 110;
            this.colKodUslugi3.Items.AddRange(new object[] { "Страховка КАСКО", "GPS-навигатор", "Детское кресло", "Доп. водитель", "Зимняя резина" });
            this.colKodSotrudnika.DataPropertyName = "KodSotrudnika"; this.colKodSotrudnika.HeaderText = "Сотрудник"; this.colKodSotrudnika.Name = "colKodSotrudnika"; this.colKodSotrudnika.DisplayMember = "FIO"; this.colKodSotrudnika.ValueMember = "KodSotrudnika"; this.colKodSotrudnika.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodSotrudnika.MinimumWidth = 110;
            this.colKodSotrudnika.Items.AddRange(new object[] { "Иванов С. П.", "Петрова О. И.", "Васильев И. Ю.", "Новикова Е. С." });

            // ===== Образец строк (видимы только в конструкторе) =====
            this.grid.Rows.Add(new object[] { "01.06.2025", "7", "08.06.2025", "17500", "True", "А123БВ77", "Иванов С. П.", "Страховка КАСКО", "GPS-навигатор", "", "Иванов С. П." });
            this.grid.Rows.Add(new object[] { "03.06.2025", "3", "06.06.2025", "10500", "True", "В234ГД77", "Петрова О. И.", "Страховка КАСКО", "", "", "Петрова О. И." });
            this.grid.Rows.Add(new object[] { "05.06.2025", "14", "19.06.2025", "42000", "False", "Е345ЖЗ77", "Сидоров А. М.", "Страховка КАСКО", "Детское кресло", "Зимняя резина", "Васильев И. Ю." });
            this.grid.Rows.Add(new object[] { "07.06.2025", "5", "12.06.2025", "19000", "True", "К456ЛМ77", "Кузнецов Д. О.", "Доп. водитель", "", "", "Новикова Е. С." });
            this.grid.Rows.Add(new object[] { "10.06.2025", "2", "12.06.2025", "4400", "True", "Н567ОП77", "Морозова А. В.", "GPS-навигатор", "", "", "Иванов С. П." });
            this.grid.Rows.Add(new object[] { "12.06.2025", "10", "22.06.2025", "23000", "False", "А123БВ77", "Петрова О. И.", "Страховка КАСКО", "Детское кресло", "", "Петрова О. И." });

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
            this.panelButtons.Size = new System.Drawing.Size(1300, 50);

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
            this.ClientSize = new System.Drawing.Size(1300, 580);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "ProkatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прокат";

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
