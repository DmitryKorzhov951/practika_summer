namespace CarRentalApp.Forms
{
    partial class UslugiForm
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaimenovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpisanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCena;

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
            this.colNaimenovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpisanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка =====
            this.header.Title = "ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ";
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
                this.colNaimenovanie,
                this.colOpisanie,
                this.colCena});
            this.colNaimenovanie.DataPropertyName = "Naimenovanie"; this.colNaimenovanie.HeaderText = "Наименование"; this.colNaimenovanie.Name = "colNaimenovanie"; this.colNaimenovanie.MinimumWidth = 90;
            this.colOpisanie.DataPropertyName = "Opisanie"; this.colOpisanie.HeaderText = "Описание"; this.colOpisanie.Name = "colOpisanie"; this.colOpisanie.MinimumWidth = 90;
            this.colCena.DataPropertyName = "Cena"; this.colCena.HeaderText = "Цена"; this.colCena.Name = "colCena"; this.colCena.MinimumWidth = 90;

            // ===== Образец строк (видимы только в конструкторе) =====
            this.grid.Rows.Add(new object[] { "Страховка КАСКО", "Полная страховка автомобиля", "5000" });
            this.grid.Rows.Add(new object[] { "GPS-навигатор", "Современный GPS-навигатор", "1000" });
            this.grid.Rows.Add(new object[] { "Детское кресло", "Детское автокресло", "500" });
            this.grid.Rows.Add(new object[] { "Доп. водитель", "Дополнительный водитель в договоре", "800" });
            this.grid.Rows.Add(new object[] { "Зимняя резина", "Комплект зимних шин", "2000" });
            this.grid.Rows.Add(new object[] { "Багажник на крышу", "Аренда багажника", "700" });
            this.grid.Rows.Add(new object[] { "Wi-Fi-роутер", "Мобильный интернет в авто", "600" });

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
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "UslugiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные Услуги";

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
