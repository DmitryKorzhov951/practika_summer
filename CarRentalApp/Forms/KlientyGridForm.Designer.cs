namespace CarRentalApp.Forms
{
    partial class KlientyGridForm
    {
        private System.ComponentModel.IContainer components = null;
        private CarRentalApp.Controls.BandedHeader header;
        private System.Windows.Forms.Panel panelParams;
        private System.Windows.Forms.Label lblPole;
        private System.Windows.Forms.ComboBox cmbPole;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private CarRentalApp.Controls.ColoredButton btnSortAsc;
        private CarRentalApp.Controls.ColoredButton btnSortDesc;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private CarRentalApp.Controls.StyledGrid grid;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.BindingNavigator nav;
        private System.Windows.Forms.ToolStripButton navMoveFirst;
        private System.Windows.Forms.ToolStripButton navMovePrev;
        private System.Windows.Forms.ToolStripTextBox navPosition;
        private System.Windows.Forms.ToolStripLabel navCount;
        private System.Windows.Forms.ToolStripButton navMoveNext;
        private System.Windows.Forms.ToolStripButton navMoveLast;
        private System.Windows.Forms.Panel panelButtons;
        private CarRentalApp.Controls.ColoredButton btnReport;
        private CarRentalApp.Controls.ColoredButton btnNavFirst;
        private CarRentalApp.Controls.ColoredButton btnNavPrev;
        private CarRentalApp.Controls.ColoredButton btnNavNext;
        private CarRentalApp.Controls.ColoredButton btnNavLast;
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
            this.panelParams = new System.Windows.Forms.Panel();
            this.lblPole = new System.Windows.Forms.Label();
            this.cmbPole = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSortAsc = new CarRentalApp.Controls.ColoredButton();
            this.btnSortDesc = new CarRentalApp.Controls.ColoredButton();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grid = new CarRentalApp.Controls.StyledGrid();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.nav = new System.Windows.Forms.BindingNavigator(this.components);
            this.navMoveFirst = new System.Windows.Forms.ToolStripButton();
            this.navMovePrev = new System.Windows.Forms.ToolStripButton();
            this.navPosition = new System.Windows.Forms.ToolStripTextBox();
            this.navCount = new System.Windows.Forms.ToolStripLabel();
            this.navMoveNext = new System.Windows.Forms.ToolStripButton();
            this.navMoveLast = new System.Windows.Forms.ToolStripButton();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnReport = new CarRentalApp.Controls.ColoredButton();
            this.btnNavFirst = new CarRentalApp.Controls.ColoredButton();
            this.btnNavPrev = new CarRentalApp.Controls.ColoredButton();
            this.btnNavNext = new CarRentalApp.Controls.ColoredButton();
            this.btnNavLast = new CarRentalApp.Controls.ColoredButton();
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
            this.panelParams.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка =====
            this.header.Title = "КЛИЕНТЫ — ТАБЛИЧНАЯ ФОРМА";
            this.header.Size = new System.Drawing.Size(1000, 56);

            // ===== Панель параметров: Поле / Фильтр / Сортировка / Поиск =====
            this.panelParams.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelParams.Controls.Add(this.lblPole);
            this.panelParams.Controls.Add(this.cmbPole);
            this.panelParams.Controls.Add(this.lblFilter);
            this.panelParams.Controls.Add(this.txtFilter);
            this.panelParams.Controls.Add(this.btnSortAsc);
            this.panelParams.Controls.Add(this.btnSortDesc);
            this.panelParams.Controls.Add(this.lblSearch);
            this.panelParams.Controls.Add(this.txtSearch);
            this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParams.Name = "panelParams";
            this.panelParams.Size = new System.Drawing.Size(1000, 44);

            this.lblPole.AutoSize = true;
            this.lblPole.BackColor = System.Drawing.Color.Transparent;
            this.lblPole.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblPole.ForeColor = System.Drawing.Color.FromArgb(160, 160, 168);
            this.lblPole.Location = new System.Drawing.Point(12, 14);
            this.lblPole.Name = "lblPole";
            this.lblPole.Text = "Поле:";

            this.cmbPole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPole.FormattingEnabled = true;
            this.cmbPole.Items.AddRange(new object[] { "ФИО", "Пол", "Дата рождения", "Адрес", "Телефон", "Паспорт" });
            this.cmbPole.Location = new System.Drawing.Point(56, 10);
            this.cmbPole.Name = "cmbPole";
            this.cmbPole.Size = new System.Drawing.Size(160, 23);
            this.cmbPole.SelectedIndex = 0;

            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(160, 160, 168);
            this.lblFilter.Location = new System.Drawing.Point(230, 14);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Text = "Фильтр:";

            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilter.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtFilter.Location = new System.Drawing.Point(284, 11);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(140, 22);

            this.btnSortAsc.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnSortAsc.Text = "▲";
            this.btnSortAsc.Size = new System.Drawing.Size(32, 26);
            this.btnSortAsc.Location = new System.Drawing.Point(432, 9);
            this.btnSortAsc.Name = "btnSortAsc";

            this.btnSortDesc.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnSortDesc.Text = "▼";
            this.btnSortDesc.Size = new System.Drawing.Size(32, 26);
            this.btnSortDesc.Location = new System.Drawing.Point(468, 9);
            this.btnSortDesc.Name = "btnSortDesc";

            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(160, 160, 168);
            this.lblSearch.Location = new System.Drawing.Point(514, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Поиск:";

            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtSearch.Location = new System.Drawing.Point(566, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);

            // ===== Сетка =====
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.AllowUserToAddRows = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFIO, this.colPol, this.colDataRozhdeniya, this.colAdres, this.colTelefon, this.colPasport });
            this.colFIO.DataPropertyName = "ФИО"; this.colFIO.HeaderText = "ФИО"; this.colFIO.Name = "colFIO"; this.colFIO.MinimumWidth = 110;
            this.colPol.DataPropertyName = "Пол"; this.colPol.HeaderText = "Пол"; this.colPol.Name = "colPol"; this.colPol.MinimumWidth = 50;
            this.colDataRozhdeniya.DataPropertyName = "Дата рождения"; this.colDataRozhdeniya.HeaderText = "Дата рождения"; this.colDataRozhdeniya.Name = "colDataRozhdeniya"; this.colDataRozhdeniya.MinimumWidth = 100;
            this.colAdres.DataPropertyName = "Адрес"; this.colAdres.HeaderText = "Адрес"; this.colAdres.Name = "colAdres"; this.colAdres.MinimumWidth = 200;
            this.colTelefon.DataPropertyName = "Телефон"; this.colTelefon.HeaderText = "Телефон"; this.colTelefon.Name = "colTelefon"; this.colTelefon.MinimumWidth = 130;
            this.colPasport.DataPropertyName = "Паспорт"; this.colPasport.HeaderText = "Паспорт"; this.colPasport.Name = "colPasport"; this.colPasport.MinimumWidth = 110;

            // Образец строк для конструктора (на запуске чистятся и заменяются реальными данными)
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

            // ===== BindingNavigator (без + и X — табличная форма только просмотр) =====
            this.nav.BindingSource = this.bs;
            this.nav.CountItem = this.navCount;
            this.nav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.navMoveFirst, this.navMovePrev, this.navPosition, this.navCount,
                this.navMoveNext, this.navMoveLast });
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

            // ===== Нижняя панель кнопок =====
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.btnNavFirst);
            this.panelButtons.Controls.Add(this.btnNavPrev);
            this.panelButtons.Controls.Add(this.btnNavNext);
            this.panelButtons.Controls.Add(this.btnNavLast);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1000, 50);

            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.Save;
            this.btnReport.Text = "Отчёт";
            this.btnReport.Location = new System.Drawing.Point(12, 9);
            this.btnReport.Size = new System.Drawing.Size(110, 32);
            this.btnReport.Name = "btnReport";

            this.btnNavFirst.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNavFirst.Text = "|<";
            this.btnNavFirst.Location = new System.Drawing.Point(140, 9);
            this.btnNavFirst.Size = new System.Drawing.Size(50, 32);
            this.btnNavFirst.Name = "btnNavFirst";

            this.btnNavPrev.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNavPrev.Text = "<";
            this.btnNavPrev.Location = new System.Drawing.Point(196, 9);
            this.btnNavPrev.Size = new System.Drawing.Size(50, 32);
            this.btnNavPrev.Name = "btnNavPrev";

            this.btnNavNext.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNavNext.Text = ">";
            this.btnNavNext.Location = new System.Drawing.Point(252, 9);
            this.btnNavNext.Size = new System.Drawing.Size(50, 32);
            this.btnNavNext.Name = "btnNavNext";

            this.btnNavLast.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNavLast.Text = ">|";
            this.btnNavLast.Location = new System.Drawing.Point(308, 9);
            this.btnNavLast.Size = new System.Drawing.Size(50, 32);
            this.btnNavLast.Name = "btnNavLast";

            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(376, 9);
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.Name = "btnClose";

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelParams);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "KlientyGridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты (табличная)";

            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.nav.ResumeLayout(false);
            this.nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelParams.ResumeLayout(false);
            this.panelParams.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
