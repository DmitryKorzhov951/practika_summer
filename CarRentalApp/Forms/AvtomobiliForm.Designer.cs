namespace CarRentalApp.Forms
{
    partial class AvtomobiliForm
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(AvtomobiliForm));
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
            this.panelHeader.Size = new System.Drawing.Size(1100, 72);
            this.picPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("poster")));
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPoster.Name = "picPoster"; this.picPoster.TabStop = false;
            this.panelHeaderAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelHeaderAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderAccent.Size = new System.Drawing.Size(1100, 3);
            this.panelHeaderAccent.Name = "panelHeaderAccent";
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(160, 12, 12, 14);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.lblTitle.Size = new System.Drawing.Size(360, 69);
            this.lblTitle.Text = "АВТОМОБИЛИ";
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
            this.colRegNomer.DataPropertyName = "RegNomer"; this.colRegNomer.HeaderText = "Рег. номер"; this.colRegNomer.Name = "colRegNomer";
            this.colNomerKuzova.DataPropertyName = "NomerKuzova"; this.colNomerKuzova.HeaderText = "Кузов"; this.colNomerKuzova.Name = "colNomerKuzova";
            this.colNomerDvigatelya.DataPropertyName = "NomerDvigatelya"; this.colNomerDvigatelya.HeaderText = "Двигатель"; this.colNomerDvigatelya.Name = "colNomerDvigatelya";
            this.colGodVypuska.DataPropertyName = "GodVypuska"; this.colGodVypuska.HeaderText = "Год"; this.colGodVypuska.Name = "colGodVypuska";
            this.colProbeg.DataPropertyName = "Probeg"; this.colProbeg.HeaderText = "Пробег"; this.colProbeg.Name = "colProbeg";
            this.colCenaAvto.DataPropertyName = "CenaAvto"; this.colCenaAvto.HeaderText = "Цена"; this.colCenaAvto.Name = "colCenaAvto";
            this.colCenaDnyaProkata.DataPropertyName = "CenaDnyaProkata"; this.colCenaDnyaProkata.HeaderText = "Цена/день"; this.colCenaDnyaProkata.Name = "colCenaDnyaProkata";
            this.colDataTO.DataPropertyName = "DataTO"; this.colDataTO.HeaderText = "Дата ТО"; this.colDataTO.Name = "colDataTO";
            this.colOtmetki.DataPropertyName = "Otmetki"; this.colOtmetki.HeaderText = "Отметки"; this.colOtmetki.Name = "colOtmetki";
            this.colVozvrachen.DataPropertyName = "Vozvrachen"; this.colVozvrachen.HeaderText = "Возвращён"; this.colVozvrachen.Name = "colVozvrachen";
            this.colKodMarki.DataPropertyName = "KodMarki"; this.colKodMarki.HeaderText = "Марка"; this.colKodMarki.Name = "colKodMarki"; this.colKodMarki.DisplayMember = "Naimenovanie"; this.colKodMarki.ValueMember = "KodMarki"; this.colKodMarki.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.colKodMehanika.DataPropertyName = "KodMehanika"; this.colKodMehanika.HeaderText = "Механик"; this.colKodMehanika.Name = "colKodMehanika"; this.colKodMehanika.DisplayMember = "FIO"; this.colKodMehanika.ValueMember = "KodSotrudnika"; this.colKodMehanika.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnTable);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Size = new System.Drawing.Size(1100, 50);
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
            this.ClientSize = new System.Drawing.Size(1100, 520);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "AvtomobiliForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автомобили";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
