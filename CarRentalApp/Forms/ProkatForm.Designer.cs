namespace CarRentalApp.Forms
{
    partial class ProkatForm
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

        private void PaintHeader(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = this.panelHeader.ClientRectangle;
            using (var grad = new System.Drawing.Drawing2D.LinearGradientBrush(
                r,
                System.Drawing.Color.FromArgb(12, 12, 14),
                System.Drawing.Color.FromArgb(70, 18, 22),
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                g.FillRectangle(grad, r);
            using var red = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(229, 57, 53));
            g.FillRectangle(red, 0, 0, r.Width, 2);
            g.FillRectangle(red, 0, 0, 5, r.Height);
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
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ===== Шапка: тёмный градиент + красные полосы =====
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(12, 12, 14);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.panelHeaderAccent);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1300, 56);
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintHeader);

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.lblTitle.Text = "ПРОКАТ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.panelHeaderAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderAccent.Name = "panelHeaderAccent";
            this.panelHeaderAccent.Size = new System.Drawing.Size(1300, 4);

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

            // ===== Образец строк (видимы только в конструкторе; на запуске затираются DataSource) =====
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
            this.ClientSize = new System.Drawing.Size(1300, 580);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "ProkatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прокат";

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
