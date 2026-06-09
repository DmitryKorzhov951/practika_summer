namespace CarRentalApp.Forms
{
    partial class UslugiForm
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
        private System.Windows.Forms.Label lblNaimenovanie;
        private System.Windows.Forms.TextBox txtNaimenovanie;
        private System.Windows.Forms.Label lblOpisanie;
        private System.Windows.Forms.TextBox txtOpisanie;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.TextBox txtCena;
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
            this.lblNaimenovanie = new System.Windows.Forms.Label();
            this.txtNaimenovanie = new System.Windows.Forms.TextBox();
            this.lblOpisanie = new System.Windows.Forms.Label();
            this.txtOpisanie = new System.Windows.Forms.TextBox();
            this.lblCena = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
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
            this.header.Title = "ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ";
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

            this.lblNaimenovanie.AutoSize = false;
            this.lblNaimenovanie.BackColor = System.Drawing.Color.Transparent;
            this.lblNaimenovanie.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblNaimenovanie.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblNaimenovanie.Location = new System.Drawing.Point(130, 370);
            this.lblNaimenovanie.Name = "lblNaimenovanie";
            this.lblNaimenovanie.Size = new System.Drawing.Size(160, 28);
            this.lblNaimenovanie.Text = "Наименование:";
            this.lblNaimenovanie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNaimenovanie.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtNaimenovanie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNaimenovanie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNaimenovanie.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtNaimenovanie.Location = new System.Drawing.Point(310, 370);
            this.txtNaimenovanie.Name = "txtNaimenovanie";
            this.txtNaimenovanie.Size = new System.Drawing.Size(440, 28);
            this.lblOpisanie.AutoSize = false;
            this.lblOpisanie.BackColor = System.Drawing.Color.Transparent;
            this.lblOpisanie.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblOpisanie.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblOpisanie.Location = new System.Drawing.Point(130, 410);
            this.lblOpisanie.Name = "lblOpisanie";
            this.lblOpisanie.Size = new System.Drawing.Size(160, 28);
            this.lblOpisanie.Text = "Описание:";
            this.lblOpisanie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOpisanie.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtOpisanie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpisanie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOpisanie.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtOpisanie.Location = new System.Drawing.Point(310, 410);
            this.txtOpisanie.Name = "txtOpisanie";
            this.txtOpisanie.Size = new System.Drawing.Size(440, 28);
            this.lblCena.AutoSize = false;
            this.lblCena.BackColor = System.Drawing.Color.Transparent;
            this.lblCena.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCena.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblCena.Location = new System.Drawing.Point(130, 450);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(160, 28);
            this.lblCena.Text = "Цена:";
            this.lblCena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCena.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtCena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCena.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtCena.Location = new System.Drawing.Point(310, 450);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(440, 28);

            // btnFirst
            this.btnFirst.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnFirst.Text = "Первая";
            this.btnFirst.Location = new System.Drawing.Point(60, 520);
            this.btnFirst.Size = new System.Drawing.Size(130, 36);
            this.btnFirst.Name = "btnFirst";
            // btnPrev
            this.btnPrev.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnPrev.Text = "Предыдущая";
            this.btnPrev.Location = new System.Drawing.Point(200, 520);
            this.btnPrev.Size = new System.Drawing.Size(130, 36);
            this.btnPrev.Name = "btnPrev";
            // btnAdd
            this.btnAdd.Variant = CarRentalApp.Controls.BtnVariant.Add;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(340, 520);
            this.btnAdd.Size = new System.Drawing.Size(130, 36);
            this.btnAdd.Name = "btnAdd";
            // btnSave
            this.btnSave.Variant = CarRentalApp.Controls.BtnVariant.Save;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(480, 520);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Name = "btnSave";
            // btnReport
            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnReport.Text = "Отчёт";
            this.btnReport.Location = new System.Drawing.Point(620, 520);
            this.btnReport.Size = new System.Drawing.Size(180, 36);
            this.btnReport.Name = "btnReport";

            // btnLast
            this.btnLast.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnLast.Text = "Последняя";
            this.btnLast.Location = new System.Drawing.Point(60, 565);
            this.btnLast.Size = new System.Drawing.Size(130, 36);
            this.btnLast.Name = "btnLast";
            // btnNext
            this.btnNext.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNext.Text = "Следующая";
            this.btnNext.Location = new System.Drawing.Point(200, 565);
            this.btnNext.Size = new System.Drawing.Size(130, 36);
            this.btnNext.Name = "btnNext";
            // btnDel
            this.btnDel.Variant = CarRentalApp.Controls.BtnVariant.Delete;
            this.btnDel.Text = "Удалить";
            this.btnDel.Location = new System.Drawing.Point(340, 565);
            this.btnDel.Size = new System.Drawing.Size(130, 36);
            this.btnDel.Name = "btnDel";
            // btnTable
            this.btnTable.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnTable.Text = "Табличная";
            this.btnTable.Location = new System.Drawing.Point(480, 565);
            this.btnTable.Size = new System.Drawing.Size(130, 36);
            this.btnTable.Name = "btnTable";
            // btnClose
            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(620, 565);
            this.btnClose.Size = new System.Drawing.Size(180, 36);
            this.btnClose.Name = "btnClose";

            // Форма
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblNaimenovanie);
            this.Controls.Add(this.txtNaimenovanie);
            this.Controls.Add(this.lblOpisanie);
            this.Controls.Add(this.txtOpisanie);
            this.Controls.Add(this.lblCena);
            this.Controls.Add(this.txtCena);
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
            this.Name = "UslugiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные Услуги";

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
