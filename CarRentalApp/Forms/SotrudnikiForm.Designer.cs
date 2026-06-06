namespace CarRentalApp.Forms
{
    partial class SotrudnikiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelHeaderAccent;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVozrast;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPasport;
        private System.Windows.Forms.DataGridViewComboBoxColumn colKodDolzhnosti;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeaderAccent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.colFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVozrast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKodDolzhnosti = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка: чёрная плашка с заголовком слева =====
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(12, 12, 14);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.panelHeaderAccent);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 56);

            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.lblTitle.Text = "СОТРУДНИКИ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.panelHeaderAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderAccent.Name = "panelHeaderAccent";
            this.panelHeaderAccent.Size = new System.Drawing.Size(1000, 4);

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
            this.nav.TabStop = true;

            this.navMoveFirst.Name = "navMoveFirst"; this.navMoveFirst.Text = "|<"; this.navMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMovePrev.Name = "navMovePrev"; this.navMovePrev.Text = "<"; this.navMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navPosition.Name = "navPosition"; this.navPosition.Size = new System.Drawing.Size(40, 25); this.navPosition.AccessibleName = "Position"; this.navPosition.Text = "1";
            this.navCount.Name = "navCount"; this.navCount.Text = "/ {0}"; this.navCount.ToolTipText = "Всего записей";
            this.navMoveNext.Name = "navMoveNext"; this.navMoveNext.Text = ">"; this.navMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMoveLast.Name = "navMoveLast"; this.navMoveLast.Text = ">|"; this.navMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navSep1.Name = "navSep1";
            this.navAddNew.Name = "navAddNew"; this.navAddNew.Text = "+"; this.navAddNew.ForeColor = System.Drawing.Color.Green; this.navAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navDelete.Name = "navDelete"; this.navDelete.Text = "X"; this.navDelete.ForeColor = System.Drawing.Color.DarkRed; this.navDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            // ===== Сетка данных =====
            this.grid.AllowUserToAddRows = true;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.grid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.grid.ColumnHeadersHeight = 36;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFIO,
                this.colVozrast,
                this.colPol,
                this.colAdres,
                this.colTelefon,
                this.colPasport,
                this.colKodDolzhnosti});
            this.grid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.grid.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(38, 38, 44);
            this.grid.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 30;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.colFIO.DataPropertyName = "FIO"; this.colFIO.HeaderText = "ФИО"; this.colFIO.Name = "colFIO"; this.colFIO.MinimumWidth = 90;
            this.colVozrast.DataPropertyName = "Vozrast"; this.colVozrast.HeaderText = "Возраст"; this.colVozrast.Name = "colVozrast"; this.colVozrast.MinimumWidth = 90;
            this.colPol.DataPropertyName = "Pol"; this.colPol.HeaderText = "Пол"; this.colPol.Name = "colPol"; this.colPol.MinimumWidth = 90;
            this.colAdres.DataPropertyName = "Adres"; this.colAdres.HeaderText = "Адрес"; this.colAdres.Name = "colAdres"; this.colAdres.MinimumWidth = 90;
            this.colTelefon.DataPropertyName = "Telefon"; this.colTelefon.HeaderText = "Телефон"; this.colTelefon.Name = "colTelefon"; this.colTelefon.MinimumWidth = 90;
            this.colPasport.DataPropertyName = "Pasport"; this.colPasport.HeaderText = "Паспорт"; this.colPasport.Name = "colPasport"; this.colPasport.MinimumWidth = 90;
            this.colKodDolzhnosti.DataPropertyName = "KodDolzhnosti"; this.colKodDolzhnosti.HeaderText = "Должность"; this.colKodDolzhnosti.Name = "colKodDolzhnosti"; this.colKodDolzhnosti.DisplayMember = "Naimenovanie"; this.colKodDolzhnosti.ValueMember = "KodDolzhnosti"; this.colKodDolzhnosti.FlatStyle = System.Windows.Forms.FlatStyle.Standard; this.colKodDolzhnosti.MinimumWidth = 110;
            this.colKodDolzhnosti.Items.AddRange(new object[] { "Директор", "Менеджер", "Механик", "Бухгалтер", "Администратор" });

            // ===== Образец строк (видимы только в конструкторе; на запуске затираются DataSource) =====
            this.grid.Rows.Add(new object[] { "Иванов Сергей Петрович", "45", "М", "Москва, ул. Ленина, 12", "+7(495)123-45-67", "4510 123456", "Директор" });
            this.grid.Rows.Add(new object[] { "Петрова Ольга Ивановна", "32", "Ж", "Москва, ул. Тверская, 25", "+7(495)234-56-78", "4511 234567", "Менеджер" });
            this.grid.Rows.Add(new object[] { "Сидоров Андрей Михайлович", "28", "М", "Москва, пр. Мира, 45", "+7(495)345-67-89", "4512 345678", "Механик" });
            this.grid.Rows.Add(new object[] { "Кузнецов Дмитрий Олегович", "35", "М", "Москва, ул. Арбат, 7", "+7(495)456-78-90", "4513 456789", "Механик" });
            this.grid.Rows.Add(new object[] { "Морозова Анна Викторовна", "29", "Ж", "Москва, ул. Покровка, 33", "+7(495)567-89-01", "4514 567890", "Бухгалтер" });
            this.grid.Rows.Add(new object[] { "Васильев Игорь Юрьевич", "41", "М", "Москва, ул. Садовая, 15", "+7(495)678-90-12", "4515 678901", "Менеджер" });
            this.grid.Rows.Add(new object[] { "Новикова Елена Сергеевна", "26", "Ж", "Москва, ул. Полянка, 18", "+7(495)789-01-23", "4516 789012", "Администратор" });
            this.grid.Rows.Add(new object[] { "Фёдоров Алексей Иванович", "38", "М", "Москва, ул. Якиманка, 5", "+7(495)890-12-34", "4517 890123", "Механик" });
            this.grid.Rows.Add(new object[] { "Соколова Мария Александровна", "31", "Ж", "Москва, ул. Остоженка, 22", "+7(495)901-23-45", "4518 901234", "Администратор" });
            this.grid.Rows.Add(new object[] { "Михайлов Олег Дмитриевич", "47", "М", "Москва, ул. Пречистенка, 9", "+7(495)012-34-56", "4519 012345", "Менеджер" });

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

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(40, 28, 0);
            this.btnAdd.Location = new System.Drawing.Point(12, 9);
            this.btnAdd.Name = "btnAdd"; this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.Text = "Добавить"; this.btnAdd.UseVisualStyleBackColor = false;

            this.btnDel.BackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(128, 9);
            this.btnDel.Name = "btnDel"; this.btnDel.Size = new System.Drawing.Size(110, 32);
            this.btnDel.Text = "Удалить"; this.btnDel.UseVisualStyleBackColor = false;

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(244, 9);
            this.btnSave.Name = "btnSave"; this.btnSave.Size = new System.Drawing.Size(110, 32);
            this.btnSave.Text = "Сохранить"; this.btnSave.UseVisualStyleBackColor = false;

            this.btnTable.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.btnTable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnTable.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.btnTable.Location = new System.Drawing.Point(360, 9);
            this.btnTable.Name = "btnTable"; this.btnTable.Size = new System.Drawing.Size(110, 32);
            this.btnTable.Text = "Табличная"; this.btnTable.UseVisualStyleBackColor = false;

            this.btnReport.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.btnReport.Location = new System.Drawing.Point(476, 9);
            this.btnReport.Name = "btnReport"; this.btnReport.Size = new System.Drawing.Size(110, 32);
            this.btnReport.Text = "Отчёт"; this.btnReport.UseVisualStyleBackColor = false;

            this.btnClose.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.btnClose.Location = new System.Drawing.Point(592, 9);
            this.btnClose.Name = "btnClose"; this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.Text = "Закрыть"; this.btnClose.UseVisualStyleBackColor = false;

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "SotrudnikiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудники";

            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.nav.ResumeLayout(false);
            this.nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
