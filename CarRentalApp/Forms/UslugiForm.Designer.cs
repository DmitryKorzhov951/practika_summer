namespace CarRentalApp.Forms
{
    partial class UslugiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelHeaderAccent;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(UslugiForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeaderAccent = new System.Windows.Forms.Panel();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.colNaimenovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpisanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(12, 12, 14);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.picPoster);
            this.panelHeader.Controls.Add(this.panelHeaderAccent);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(960, 72);
            this.picPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("poster")));
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPoster.Name = "picPoster"; this.picPoster.TabStop = false;
            this.panelHeaderAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderAccent.Size = new System.Drawing.Size(960, 3);
            this.panelHeaderAccent.Name = "panelHeaderAccent";
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(160, 12, 12, 14);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.lblTitle.Size = new System.Drawing.Size(360, 69);
            this.lblTitle.Text = "ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.grid.AllowUserToAddRows = true; this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.grid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.grid.ColumnHeadersHeight = 36;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNaimenovanie,
                this.colOpisanie,
                this.colCena});
            this.grid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.colNaimenovanie.DataPropertyName = "Naimenovanie"; this.colNaimenovanie.HeaderText = "Наименование"; this.colNaimenovanie.Name = "colNaimenovanie";
            this.colOpisanie.DataPropertyName = "Opisanie"; this.colOpisanie.HeaderText = "Описание"; this.colOpisanie.Name = "colOpisanie";
            this.colCena.DataPropertyName = "Cena"; this.colCena.HeaderText = "Цена"; this.colCena.Name = "colCena";
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnTable);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Size = new System.Drawing.Size(960, 50);
            this.panelButtons.Name = "panelButtons";

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

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "UslugiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные Услуги";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
