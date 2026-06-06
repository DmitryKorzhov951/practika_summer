namespace CarRentalApp.Forms
{
    partial class KlientyForm
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRozhdeniya;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPasport;

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
            this.colFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRozhdeniya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка =====
            this.header.Title = "КЛИЕНТЫ";
            this.header.Size = new System.Drawing.Size(1000, 56);

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
            this.nav.Size = new System.Drawing.Size(1000, 25);
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
                this.colFIO,
                this.colPol,
                this.colDataRozhdeniya,
                this.colAdres,
                this.colTelefon,
                this.colPasport});
            this.colFIO.DataPropertyName = "FIO"; this.colFIO.HeaderText = "ФИО"; this.colFIO.Name = "colFIO"; this.colFIO.MinimumWidth = 90;
            this.colPol.DataPropertyName = "Pol"; this.colPol.HeaderText = "Пол"; this.colPol.Name = "colPol"; this.colPol.MinimumWidth = 90;
            this.colDataRozhdeniya.DataPropertyName = "DataRozhdeniya"; this.colDataRozhdeniya.HeaderText = "Дата рождения"; this.colDataRozhdeniya.Name = "colDataRozhdeniya"; this.colDataRozhdeniya.MinimumWidth = 90;
            this.colAdres.DataPropertyName = "Adres"; this.colAdres.HeaderText = "Адрес"; this.colAdres.Name = "colAdres"; this.colAdres.MinimumWidth = 90;
            this.colTelefon.DataPropertyName = "Telefon"; this.colTelefon.HeaderText = "Телефон"; this.colTelefon.Name = "colTelefon"; this.colTelefon.MinimumWidth = 90;
            this.colPasport.DataPropertyName = "Pasport"; this.colPasport.HeaderText = "Паспорт"; this.colPasport.Name = "colPasport"; this.colPasport.MinimumWidth = 90;

            // ===== Образец строк (видимы только в конструкторе) =====
            this.grid.Rows.Add(new object[] { "Иванов Сергей Петрович", "М", "15.03.1985", "Москва, ул. Ленина, 12", "+7(495)123-45-67", "4510 123456" });
            this.grid.Rows.Add(new object[] { "Петрова Ольга Ивановна", "Ж", "22.07.1992", "Москва, ул. Тверская, 25", "+7(495)234-56-78", "4511 234567" });
            this.grid.Rows.Add(new object[] { "Сидоров Андрей Михайлович", "М", "10.11.1988", "Москва, пр. Мира, 45", "+7(495)345-67-89", "4512 345678" });
            this.grid.Rows.Add(new object[] { "Кузнецов Дмитрий Олегович", "М", "05.02.1990", "Москва, ул. Арбат, 7", "+7(495)456-78-90", "4513 456789" });
            this.grid.Rows.Add(new object[] { "Морозова Анна Викторовна", "Ж", "18.06.1995", "Москва, ул. Покровка, 33", "+7(495)567-89-01", "4514 567890" });
            this.grid.Rows.Add(new object[] { "Васильев Игорь Юрьевич", "М", "30.09.1983", "Москва, ул. Садовая, 15", "+7(495)678-90-12", "4515 678901" });
            this.grid.Rows.Add(new object[] { "Новикова Елена Сергеевна", "Ж", "12.04.1998", "Москва, ул. Полянка, 18", "+7(495)789-01-23", "4516 789012" });
            this.grid.Rows.Add(new object[] { "Фёдоров Алексей Иванович", "М", "25.07.1986", "Москва, ул. Якиманка, 5", "+7(495)890-12-34", "4517 890123" });
            this.grid.Rows.Add(new object[] { "Соколова Мария Александровна", "Ж", "08.12.1993", "Москва, ул. Остоженка, 22", "+7(495)901-23-45", "4518 901234" });
            this.grid.Rows.Add(new object[] { "Михайлов Олег Дмитриевич", "М", "14.05.1977", "Москва, ул. Пречистенка, 9", "+7(495)012-34-56", "4519 012345" });

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
            this.panelButtons.Size = new System.Drawing.Size(1000, 50);

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
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "KlientyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";

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
