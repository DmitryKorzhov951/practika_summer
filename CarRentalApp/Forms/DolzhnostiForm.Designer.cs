namespace CarRentalApp.Forms
{
    partial class DolzhnostiForm
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
        private System.Windows.Forms.Label lblNaim;
        private System.Windows.Forms.TextBox txtNaim;
        private System.Windows.Forms.Label lblOklad;
        private System.Windows.Forms.TextBox txtOklad;
        private System.Windows.Forms.Label lblObyaz;
        private System.Windows.Forms.TextBox txtObyaz;
        private System.Windows.Forms.Label lblTreb;
        private System.Windows.Forms.TextBox txtTreb;
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
            this.lblNaim = new System.Windows.Forms.Label();
            this.txtNaim = new System.Windows.Forms.TextBox();
            this.lblOklad = new System.Windows.Forms.Label();
            this.txtOklad = new System.Windows.Forms.TextBox();
            this.lblObyaz = new System.Windows.Forms.Label();
            this.txtObyaz = new System.Windows.Forms.TextBox();
            this.lblTreb = new System.Windows.Forms.Label();
            this.txtTreb = new System.Windows.Forms.TextBox();
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
            this.header.Title = "ДОЛЖНОСТИ";
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

            // lblNaim
            this.lblNaim.AutoSize = false;
            this.lblNaim.BackColor = System.Drawing.Color.Transparent;
            this.lblNaim.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblNaim.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblNaim.Location = new System.Drawing.Point(130, 370);
            this.lblNaim.Name = "lblNaim";
            this.lblNaim.Size = new System.Drawing.Size(170, 28);
            this.lblNaim.Text = "Наименование:";
            this.lblNaim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // txtNaim
            this.txtNaim.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtNaim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNaim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNaim.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtNaim.Location = new System.Drawing.Point(310, 370);
            this.txtNaim.Name = "txtNaim";
            this.txtNaim.Size = new System.Drawing.Size(440, 28);

            // lblOklad
            this.lblOklad.AutoSize = false;
            this.lblOklad.BackColor = System.Drawing.Color.Transparent;
            this.lblOklad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblOklad.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblOklad.Location = new System.Drawing.Point(130, 410);
            this.lblOklad.Name = "lblOklad";
            this.lblOklad.Size = new System.Drawing.Size(170, 28);
            this.lblOklad.Text = "Оклад:";
            this.lblOklad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // txtOklad
            this.txtOklad.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtOklad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOklad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOklad.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtOklad.Location = new System.Drawing.Point(310, 410);
            this.txtOklad.Name = "txtOklad";
            this.txtOklad.Size = new System.Drawing.Size(440, 28);

            // lblObyaz
            this.lblObyaz.AutoSize = false;
            this.lblObyaz.BackColor = System.Drawing.Color.Transparent;
            this.lblObyaz.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblObyaz.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblObyaz.Location = new System.Drawing.Point(130, 450);
            this.lblObyaz.Name = "lblObyaz";
            this.lblObyaz.Size = new System.Drawing.Size(170, 28);
            this.lblObyaz.Text = "Обязанности:";
            this.lblObyaz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // txtObyaz
            this.txtObyaz.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtObyaz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObyaz.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObyaz.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtObyaz.Location = new System.Drawing.Point(310, 450);
            this.txtObyaz.Name = "txtObyaz";
            this.txtObyaz.Size = new System.Drawing.Size(440, 28);

            // lblTreb
            this.lblTreb.AutoSize = false;
            this.lblTreb.BackColor = System.Drawing.Color.Transparent;
            this.lblTreb.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTreb.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblTreb.Location = new System.Drawing.Point(130, 490);
            this.lblTreb.Name = "lblTreb";
            this.lblTreb.Size = new System.Drawing.Size(170, 28);
            this.lblTreb.Text = "Требования:";
            this.lblTreb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // txtTreb
            this.txtTreb.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.txtTreb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTreb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTreb.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.txtTreb.Location = new System.Drawing.Point(310, 490);
            this.txtTreb.Name = "txtTreb";
            this.txtTreb.Size = new System.Drawing.Size(440, 28);

            // btnFirst
            this.btnFirst.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnFirst.Text = "Первая";
            this.btnFirst.Location = new System.Drawing.Point(60, 560);
            this.btnFirst.Size = new System.Drawing.Size(130, 36);
            this.btnFirst.Name = "btnFirst";
            // btnPrev
            this.btnPrev.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnPrev.Text = "Предыдущая";
            this.btnPrev.Location = new System.Drawing.Point(200, 560);
            this.btnPrev.Size = new System.Drawing.Size(130, 36);
            this.btnPrev.Name = "btnPrev";
            // btnAdd
            this.btnAdd.Variant = CarRentalApp.Controls.BtnVariant.Add;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(340, 560);
            this.btnAdd.Size = new System.Drawing.Size(130, 36);
            this.btnAdd.Name = "btnAdd";
            // btnSave
            this.btnSave.Variant = CarRentalApp.Controls.BtnVariant.Save;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(480, 560);
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.Name = "btnSave";
            // btnReport
            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnReport.Text = "Отчёт";
            this.btnReport.Location = new System.Drawing.Point(620, 560);
            this.btnReport.Size = new System.Drawing.Size(180, 36);
            this.btnReport.Name = "btnReport";

            // btnLast
            this.btnLast.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnLast.Text = "Последняя";
            this.btnLast.Location = new System.Drawing.Point(60, 605);
            this.btnLast.Size = new System.Drawing.Size(130, 36);
            this.btnLast.Name = "btnLast";
            // btnNext
            this.btnNext.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnNext.Text = "Следующая";
            this.btnNext.Location = new System.Drawing.Point(200, 605);
            this.btnNext.Size = new System.Drawing.Size(130, 36);
            this.btnNext.Name = "btnNext";
            // btnDel
            this.btnDel.Variant = CarRentalApp.Controls.BtnVariant.Delete;
            this.btnDel.Text = "Удалить";
            this.btnDel.Location = new System.Drawing.Point(340, 605);
            this.btnDel.Size = new System.Drawing.Size(130, 36);
            this.btnDel.Name = "btnDel";
            // btnTable
            this.btnTable.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnTable.Text = "Табличная";
            this.btnTable.Location = new System.Drawing.Point(480, 605);
            this.btnTable.Size = new System.Drawing.Size(130, 36);
            this.btnTable.Name = "btnTable";
            // btnClose
            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Default;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(620, 605);
            this.btnClose.Size = new System.Drawing.Size(180, 36);
            this.btnClose.Name = "btnClose";

            // Форма
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(900, 670);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblNaim);
            this.Controls.Add(this.txtNaim);
            this.Controls.Add(this.lblOklad);
            this.Controls.Add(this.txtOklad);
            this.Controls.Add(this.lblObyaz);
            this.Controls.Add(this.txtObyaz);
            this.Controls.Add(this.lblTreb);
            this.Controls.Add(this.txtTreb);
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
            this.Name = "DolzhnostiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Должности";

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
