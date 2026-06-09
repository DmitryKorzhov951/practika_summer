namespace CarRentalApp.Forms
{
    partial class KlientyForm
    {
        private System.ComponentModel.IContainer components = null;
        private CarRentalApp.Controls.BandedHeader header;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.BindingNavigator nav;
        private System.Windows.Forms.ToolStripButton navMoveFirst;
        private System.Windows.Forms.ToolStripButton navMovePrev;
        private System.Windows.Forms.ToolStripTextBox navPosition;
        private System.Windows.Forms.ToolStripLabel navCount;
        private System.Windows.Forms.ToolStripButton navMoveNext;
        private System.Windows.Forms.ToolStripButton navMoveLast;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.TextBox txtPol;
        private System.Windows.Forms.Label lblDataRozhdeniya;
        private System.Windows.Forms.TextBox txtDataRozhdeniya;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblPasport;
        private System.Windows.Forms.TextBox txtPasport;
        private CarRentalApp.Controls.ColoredButton btnFirst;
        private CarRentalApp.Controls.ColoredButton btnPrev;
        private CarRentalApp.Controls.ColoredButton btnNext;
        private CarRentalApp.Controls.ColoredButton btnLast;
        private CarRentalApp.Controls.ColoredButton btnAdd;
        private CarRentalApp.Controls.ColoredButton btnDel;
        private CarRentalApp.Controls.ColoredButton btnSave;
        private CarRentalApp.Controls.ColoredButton btnTable;
        private CarRentalApp.Controls.ColoredButton btnReport;
        private CarRentalApp.Controls.ColoredButton btnClose;

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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblFIO = new System.Windows.Forms.Label();
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.lblPol = new System.Windows.Forms.Label();
            this.txtPol = new System.Windows.Forms.TextBox();
            this.lblDataRozhdeniya = new System.Windows.Forms.Label();
            this.txtDataRozhdeniya = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblPasport = new System.Windows.Forms.Label();
            this.txtPasport = new System.Windows.Forms.TextBox();
            this.btnFirst = new CarRentalApp.Controls.ColoredButton();
            this.btnPrev = new CarRentalApp.Controls.ColoredButton();
            this.btnNext = new CarRentalApp.Controls.ColoredButton();
            this.btnLast = new CarRentalApp.Controls.ColoredButton();
            this.btnAdd = new CarRentalApp.Controls.ColoredButton();
            this.btnDel = new CarRentalApp.Controls.ColoredButton();
            this.btnSave = new CarRentalApp.Controls.ColoredButton();
            this.btnTable = new CarRentalApp.Controls.ColoredButton();
            this.btnReport = new CarRentalApp.Controls.ColoredButton();
            this.btnClose = new CarRentalApp.Controls.ColoredButton();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();

            // header
            this.header.Title = "КЛИЕНТЫ";
            this.header.Size = new System.Drawing.Size(900, 56);

            // nav
            this.nav.AddNewItem = null;
            this.nav.BindingSource = this.bs;
            this.nav.CountItem = this.navCount;
            this.nav.DeleteItem = null;
            this.nav.Dock = System.Windows.Forms.DockStyle.Top;
            this.nav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.navMoveFirst, this.navMovePrev, this.navPosition, this.navCount,
                this.navMoveNext, this.navMoveLast });
            this.nav.MoveFirstItem = this.navMoveFirst;
            this.nav.MoveLastItem = this.navMoveLast;
            this.nav.MoveNextItem = this.navMoveNext;
            this.nav.MovePreviousItem = this.navMovePrev;
            this.nav.Name = "nav";
            this.nav.PositionItem = this.navPosition;
            this.nav.Size = new System.Drawing.Size(900, 25);
            this.navMoveFirst.Name = "navMoveFirst";
            this.navMoveFirst.Text = "|<";
            this.navMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMovePrev.Name = "navMovePrev";
            this.navMovePrev.Text = "<";
            this.navMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navPosition.Name = "navPosition";
            this.navPosition.Size = new System.Drawing.Size(40, 25);
            this.navPosition.Text = "1";
            this.navCount.Name = "navCount";
            this.navCount.Text = "/ {0}";
            this.navMoveNext.Name = "navMoveNext";
            this.navMoveNext.Text = ">";
            this.navMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMoveLast.Name = "navMoveLast";
            this.navMoveLast.Text = ">|";
            this.navMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            // pictureBox
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureBox.Location = new System.Drawing.Point(40, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(820, 240);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabStop = false;

            this.lblFIO.AutoSize = false;
            this.lblFIO.BackColor = System.Drawing.Color.Transparent;
            this.lblFIO.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFIO.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblFIO.Location = new System.Drawing.Point(130, 370);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(160, 28);
            this.lblFIO.Text = "ФИО:";
            this.lblFIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtFIO.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFIO.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFIO.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtFIO.Location = new System.Drawing.Point(310, 370);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(440, 28);
            this.lblPol.AutoSize = false;
            this.lblPol.BackColor = System.Drawing.Color.Transparent;
            this.lblPol.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPol.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblPol.Location = new System.Drawing.Point(130, 410);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(160, 28);
            this.lblPol.Text = "Пол:";
            this.lblPol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPol.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtPol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPol.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtPol.Location = new System.Drawing.Point(310, 410);
            this.txtPol.Name = "txtPol";
            this.txtPol.Size = new System.Drawing.Size(440, 28);
            this.lblDataRozhdeniya.AutoSize = false;
            this.lblDataRozhdeniya.BackColor = System.Drawing.Color.Transparent;
            this.lblDataRozhdeniya.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDataRozhdeniya.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblDataRozhdeniya.Location = new System.Drawing.Point(130, 450);
            this.lblDataRozhdeniya.Name = "lblDataRozhdeniya";
            this.lblDataRozhdeniya.Size = new System.Drawing.Size(160, 28);
            this.lblDataRozhdeniya.Text = "Дата рождения:";
            this.lblDataRozhdeniya.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDataRozhdeniya.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtDataRozhdeniya.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataRozhdeniya.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDataRozhdeniya.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtDataRozhdeniya.Location = new System.Drawing.Point(310, 450);
            this.txtDataRozhdeniya.Name = "txtDataRozhdeniya";
            this.txtDataRozhdeniya.Size = new System.Drawing.Size(440, 28);
            this.lblAdres.AutoSize = false;
            this.lblAdres.BackColor = System.Drawing.Color.Transparent;
            this.lblAdres.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblAdres.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblAdres.Location = new System.Drawing.Point(130, 490);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(160, 28);
            this.lblAdres.Text = "Адрес:";
            this.lblAdres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAdres.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtAdres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdres.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdres.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtAdres.Location = new System.Drawing.Point(310, 490);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(440, 28);
            this.lblTelefon.AutoSize = false;
            this.lblTelefon.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefon.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefon.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblTelefon.Location = new System.Drawing.Point(130, 530);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(160, 28);
            this.lblTelefon.Text = "Телефон:";
            this.lblTelefon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTelefon.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefon.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtTelefon.Location = new System.Drawing.Point(310, 530);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(440, 28);
            this.lblPasport.AutoSize = false;
            this.lblPasport.BackColor = System.Drawing.Color.Transparent;
            this.lblPasport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPasport.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblPasport.Location = new System.Drawing.Point(130, 570);
            this.lblPasport.Name = "lblPasport";
            this.lblPasport.Size = new System.Drawing.Size(160, 28);
            this.lblPasport.Text = "Паспорт:";
            this.lblPasport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPasport.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtPasport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasport.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtPasport.Location = new System.Drawing.Point(310, 570);
            this.txtPasport.Name = "txtPasport";
            this.txtPasport.Size = new System.Drawing.Size(440, 28);

            // btnFirst
            this.btnFirst.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnFirst.Text = "Первая";
            this.btnFirst.Location = new System.Drawing.Point(60, 640);
            this.btnFirst.Size = new System.Drawing.Size(130, 36);
            this.btnFirst.Name = "btnFirst";
            // btnPrev
            this.btnPrev.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnPrev.Text = "Предыдущая";
            this.btnPrev.Location = new System.Drawing.Point(200, 640);
            this.btnPrev.Size = new System.Drawing.Size(130, 36);
            this.btnPrev.Name = "btnPrev";
            // btnAdd
            this.btnAdd.Variant = CarRentalApp.Controls.BtnVariant.Add;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(340, 640);
            this.btnAdd.Size = new System.Drawing.Size(130, 36);
            this.btnAdd.Name = "btnAdd";
            // btnSave
            this.btnSave.Variant = CarRentalApp.Controls.BtnVariant.Save;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(480, 640);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Name = "btnSave";
            // btnReport
            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnReport.Text = "Отчёт";
            this.btnReport.Location = new System.Drawing.Point(620, 640);
            this.btnReport.Size = new System.Drawing.Size(180, 36);
            this.btnReport.Name = "btnReport";

            // btnLast
            this.btnLast.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnLast.Text = "Последняя";
            this.btnLast.Location = new System.Drawing.Point(60, 685);
            this.btnLast.Size = new System.Drawing.Size(130, 36);
            this.btnLast.Name = "btnLast";
            // btnNext
            this.btnNext.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNext.Text = "Следующая";
            this.btnNext.Location = new System.Drawing.Point(200, 685);
            this.btnNext.Size = new System.Drawing.Size(130, 36);
            this.btnNext.Name = "btnNext";
            // btnDel
            this.btnDel.Variant = CarRentalApp.Controls.BtnVariant.Delete;
            this.btnDel.Text = "Удалить";
            this.btnDel.Location = new System.Drawing.Point(340, 685);
            this.btnDel.Size = new System.Drawing.Size(130, 36);
            this.btnDel.Name = "btnDel";
            // btnTable
            this.btnTable.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnTable.Text = "Табличная";
            this.btnTable.Location = new System.Drawing.Point(480, 685);
            this.btnTable.Size = new System.Drawing.Size(130, 36);
            this.btnTable.Name = "btnTable";
            // btnClose
            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(620, 685);
            this.btnClose.Size = new System.Drawing.Size(180, 36);
            this.btnClose.Name = "btnClose";

            // Форма
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(900, 740);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.txtFIO);
            this.Controls.Add(this.lblPol);
            this.Controls.Add(this.txtPol);
            this.Controls.Add(this.lblDataRozhdeniya);
            this.Controls.Add(this.txtDataRozhdeniya);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblPasport);
            this.Controls.Add(this.txtPasport);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "KlientyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";

            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.nav.ResumeLayout(false);
            this.nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
