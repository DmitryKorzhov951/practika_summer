namespace CarRentalApp.Forms
{
    partial class KlientyForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.DataGridViewTextBoxColumn colFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRozhd;
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.colFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRozhd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(20, 20, 24);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(960, 48);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(960, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "КЛИЕНТЫ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grid
            //
            this.grid.AllowUserToAddRows = true;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFIO, this.colPol, this.colDataRozhd, this.colAdres, this.colTelefon, this.colPasport});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 48);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(960, 384);
            this.grid.TabIndex = 1;
            //
            // colFIO
            //
            this.colFIO.DataPropertyName = "FIO";
            this.colFIO.HeaderText = "ФИО";
            this.colFIO.Name = "colFIO";
            //
            // colPol
            //
            this.colPol.DataPropertyName = "Pol";
            this.colPol.HeaderText = "Пол";
            this.colPol.Name = "colPol";
            //
            // colDataRozhd
            //
            this.colDataRozhd.DataPropertyName = "DataRozhdeniya";
            this.colDataRozhd.HeaderText = "Дата рождения";
            this.colDataRozhd.Name = "colDataRozhd";
            //
            // colAdres
            //
            this.colAdres.DataPropertyName = "Adres";
            this.colAdres.HeaderText = "Адрес";
            this.colAdres.Name = "colAdres";
            //
            // colTelefon
            //
            this.colTelefon.DataPropertyName = "Telefon";
            this.colTelefon.HeaderText = "Телефон";
            this.colTelefon.Name = "colTelefon";
            //
            // colPasport
            //
            this.colPasport.DataPropertyName = "Pasport";
            this.colPasport.HeaderText = "Паспорт";
            this.colPasport.Name = "colPasport";
            //
            // panelButtons
            //
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnTable);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 432);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(960, 48);
            this.panelButtons.TabIndex = 2;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            //
            // btnDel
            //
            this.btnDel.Location = new System.Drawing.Point(128, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(110, 32);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Удалить";
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(244, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            //
            // btnTable
            //
            this.btnTable.Location = new System.Drawing.Point(360, 8);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(110, 32);
            this.btnTable.TabIndex = 3;
            this.btnTable.Text = "Табличная";
            //
            // btnReport
            //
            this.btnReport.Location = new System.Drawing.Point(476, 8);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(110, 32);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отчёт";
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(592, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            //
            // KlientyForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 480);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.Name = "KlientyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
