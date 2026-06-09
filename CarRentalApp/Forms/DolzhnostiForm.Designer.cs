namespace CarRentalApp.Forms
{
    partial class DolzhnostiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.BindingNavigator nav;
        private System.Windows.Forms.ToolStripButton navMoveFirst;
        private System.Windows.Forms.ToolStripButton navMovePrev;
        private System.Windows.Forms.ToolStripTextBox navPosition;
        private System.Windows.Forms.ToolStripLabel navCount;
        private System.Windows.Forms.ToolStripButton navMoveNext;
        private System.Windows.Forms.ToolStripButton navMoveLast;
        private System.Windows.Forms.ToolStripSeparator navSep1;
        private System.Windows.Forms.ToolStripButton navAddNew;
        private System.Windows.Forms.ToolStripButton navDelete;
        private System.Windows.Forms.ToolStripButton navSave;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNaim;
        private System.Windows.Forms.TextBox txtNaim;
        private System.Windows.Forms.Label lblOklad;
        private System.Windows.Forms.TextBox txtOklad;
        private System.Windows.Forms.Label lblObyaz;
        private System.Windows.Forms.TextBox txtObyaz;
        private System.Windows.Forms.Label lblTreb;
        private System.Windows.Forms.TextBox txtTreb;
        private CarRentalApp.Controls.ColoredButton btnFirst;
        private CarRentalApp.Controls.ColoredButton btnLast;
        private CarRentalApp.Controls.ColoredButton btnPrev;
        private CarRentalApp.Controls.ColoredButton btnNext;
        private CarRentalApp.Controls.ColoredButton btnAdd;
        private CarRentalApp.Controls.ColoredButton btnDel;
        private CarRentalApp.Controls.ColoredButton btnReport;
        private CarRentalApp.Controls.ColoredButton btnTable;
        private CarRentalApp.Controls.ColoredButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.navSave = new System.Windows.Forms.ToolStripButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNaim = new System.Windows.Forms.Label();
            this.txtNaim = new System.Windows.Forms.TextBox();
            this.lblOklad = new System.Windows.Forms.Label();
            this.txtOklad = new System.Windows.Forms.TextBox();
            this.lblObyaz = new System.Windows.Forms.Label();
            this.txtObyaz = new System.Windows.Forms.TextBox();
            this.lblTreb = new System.Windows.Forms.Label();
            this.txtTreb = new System.Windows.Forms.TextBox();
            this.btnFirst = new CarRentalApp.Controls.ColoredButton();
            this.btnLast = new CarRentalApp.Controls.ColoredButton();
            this.btnPrev = new CarRentalApp.Controls.ColoredButton();
            this.btnNext = new CarRentalApp.Controls.ColoredButton();
            this.btnAdd = new CarRentalApp.Controls.ColoredButton();
            this.btnDel = new CarRentalApp.Controls.ColoredButton();
            this.btnReport = new CarRentalApp.Controls.ColoredButton();
            this.btnTable = new CarRentalApp.Controls.ColoredButton();
            this.btnClose = new CarRentalApp.Controls.ColoredButton();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();

            // ===== BindingNavigator =====
            this.nav.AddNewItem = this.navAddNew;
            this.nav.BindingSource = this.bs;
            this.nav.CountItem = this.navCount;
            this.nav.DeleteItem = this.navDelete;
            this.nav.Dock = System.Windows.Forms.DockStyle.Top;
            this.nav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.navMoveFirst, this.navMovePrev, this.navPosition, this.navCount,
                this.navMoveNext, this.navMoveLast, this.navSep1,
                this.navAddNew, this.navDelete, this.navSave });
            this.nav.MoveFirstItem = this.navMoveFirst;
            this.nav.MoveLastItem = this.navMoveLast;
            this.nav.MoveNextItem = this.navMoveNext;
            this.nav.MovePreviousItem = this.navMovePrev;
            this.nav.Name = "nav";
            this.nav.PositionItem = this.navPosition;
            this.nav.Size = new System.Drawing.Size(900, 28);
            this.navMoveFirst.Name = "navMoveFirst"; this.navMoveFirst.Text = "|◀"; this.navMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMovePrev.Name = "navMovePrev"; this.navMovePrev.Text = "◀"; this.navMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navPosition.Name = "navPosition"; this.navPosition.Size = new System.Drawing.Size(40, 28); this.navPosition.Text = "1";
            this.navCount.Name = "navCount"; this.navCount.Text = "для {0}";
            this.navMoveNext.Name = "navMoveNext"; this.navMoveNext.Text = "▶"; this.navMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMoveLast.Name = "navMoveLast"; this.navMoveLast.Text = "▶|"; this.navMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navSep1.Name = "navSep1";
            this.navAddNew.Name = "navAddNew"; this.navAddNew.Text = "✚"; this.navAddNew.ForeColor = System.Drawing.Color.FromArgb(255, 165, 0); this.navAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navDelete.Name = "navDelete"; this.navDelete.Text = "✕"; this.navDelete.ForeColor = System.Drawing.Color.DarkRed; this.navDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navSave.Name = "navSave"; this.navSave.Text = "💾"; this.navSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            // ===== Постер =====
            this.pictureBox.Location = new System.Drawing.Point(60, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(780, 280);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabStop = false;

            // ===== Заголовок (тёмно-красная плашка) =====
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(123, 24, 24);
            this.titleBar.Controls.Add(this.lblTitle);
            this.titleBar.Location = new System.Drawing.Point(220, 330);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(460, 44);

            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Таблица \"Должности\"";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===== Поля =====
            System.Drawing.Color labelColor = System.Drawing.Color.FromArgb(123, 24, 24);
            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font textFont = new System.Drawing.Font("Segoe UI", 10F);

            this.lblNaim.AutoSize = false;
            this.lblNaim.BackColor = System.Drawing.Color.Transparent;
            this.lblNaim.Font = labelFont;
            this.lblNaim.ForeColor = labelColor;
            this.lblNaim.Location = new System.Drawing.Point(130, 400);
            this.lblNaim.Name = "lblNaim"; this.lblNaim.Size = new System.Drawing.Size(150, 28);
            this.lblNaim.Text = "Наименование:";
            this.lblNaim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNaim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNaim.Font = textFont;
            this.txtNaim.Location = new System.Drawing.Point(290, 400);
            this.txtNaim.Name = "txtNaim"; this.txtNaim.Size = new System.Drawing.Size(420, 28);

            this.lblOklad.AutoSize = false;
            this.lblOklad.BackColor = System.Drawing.Color.Transparent;
            this.lblOklad.Font = labelFont;
            this.lblOklad.ForeColor = labelColor;
            this.lblOklad.Location = new System.Drawing.Point(130, 444);
            this.lblOklad.Name = "lblOklad"; this.lblOklad.Size = new System.Drawing.Size(150, 28);
            this.lblOklad.Text = "Оклад:";
            this.lblOklad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOklad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOklad.Font = textFont;
            this.txtOklad.Location = new System.Drawing.Point(290, 444);
            this.txtOklad.Name = "txtOklad"; this.txtOklad.Size = new System.Drawing.Size(420, 28);

            this.lblObyaz.AutoSize = false;
            this.lblObyaz.BackColor = System.Drawing.Color.Transparent;
            this.lblObyaz.Font = labelFont;
            this.lblObyaz.ForeColor = labelColor;
            this.lblObyaz.Location = new System.Drawing.Point(130, 488);
            this.lblObyaz.Name = "lblObyaz"; this.lblObyaz.Size = new System.Drawing.Size(150, 28);
            this.lblObyaz.Text = "Обязанности:";
            this.lblObyaz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtObyaz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObyaz.Font = textFont;
            this.txtObyaz.Location = new System.Drawing.Point(290, 488);
            this.txtObyaz.Name = "txtObyaz"; this.txtObyaz.Size = new System.Drawing.Size(420, 28);

            this.lblTreb.AutoSize = false;
            this.lblTreb.BackColor = System.Drawing.Color.Transparent;
            this.lblTreb.Font = labelFont;
            this.lblTreb.ForeColor = labelColor;
            this.lblTreb.Location = new System.Drawing.Point(130, 532);
            this.lblTreb.Name = "lblTreb"; this.lblTreb.Size = new System.Drawing.Size(150, 28);
            this.lblTreb.Text = "Требования:";
            this.lblTreb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTreb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTreb.Font = textFont;
            this.txtTreb.Location = new System.Drawing.Point(290, 532);
            this.txtTreb.Name = "txtTreb"; this.txtTreb.Size = new System.Drawing.Size(420, 28);

            // ===== Кнопки внизу =====
            this.btnFirst.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnFirst.Text = "Первая";
            this.btnFirst.Location = new System.Drawing.Point(110, 620);
            this.btnFirst.Size = new System.Drawing.Size(150, 38);
            this.btnFirst.Name = "btnFirst";

            this.btnPrev.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnPrev.Text = "Предыдущая";
            this.btnPrev.Location = new System.Drawing.Point(272, 620);
            this.btnPrev.Size = new System.Drawing.Size(150, 38);
            this.btnPrev.Name = "btnPrev";

            this.btnAdd.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(434, 620);
            this.btnAdd.Size = new System.Drawing.Size(150, 38);
            this.btnAdd.Name = "btnAdd";

            this.btnReport.Variant = CarRentalApp.Controls.BtnVariant.LightRose;
            this.btnReport.Text = "Отчёт \"Должности\"";
            this.btnReport.Location = new System.Drawing.Point(640, 620);
            this.btnReport.Size = new System.Drawing.Size(190, 38);
            this.btnReport.Name = "btnReport";

            this.btnLast.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnLast.Text = "Последняя";
            this.btnLast.Location = new System.Drawing.Point(110, 670);
            this.btnLast.Size = new System.Drawing.Size(150, 38);
            this.btnLast.Name = "btnLast";

            this.btnNext.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnNext.Text = "Следующая";
            this.btnNext.Location = new System.Drawing.Point(272, 670);
            this.btnNext.Size = new System.Drawing.Size(150, 38);
            this.btnNext.Name = "btnNext";

            this.btnDel.Variant = CarRentalApp.Controls.BtnVariant.DarkRed;
            this.btnDel.Text = "Удалить";
            this.btnDel.Location = new System.Drawing.Point(434, 670);
            this.btnDel.Size = new System.Drawing.Size(150, 38);
            this.btnDel.Name = "btnDel";

            this.btnTable.Variant = CarRentalApp.Controls.BtnVariant.LightRose;
            this.btnTable.Text = "Табличная форма \"Должности\"";
            this.btnTable.Location = new System.Drawing.Point(640, 670);
            this.btnTable.Size = new System.Drawing.Size(220, 38);
            this.btnTable.Name = "btnTable";

            this.btnClose.Variant = CarRentalApp.Controls.BtnVariant.Navy;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(700, 720);
            this.btnClose.Size = new System.Drawing.Size(160, 38);
            this.btnClose.Name = "btnClose";

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 220);
            this.ClientSize = new System.Drawing.Size(900, 780);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.titleBar);
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
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.nav);
            this.Name = "DolzhnostiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица \"Должности\"";

            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.nav.ResumeLayout(false);
            this.nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.titleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
