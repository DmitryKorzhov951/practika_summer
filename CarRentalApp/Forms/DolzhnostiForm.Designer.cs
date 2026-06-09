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

            // ===== Шапка =====
            this.header.Title = "ДОЛЖНОСТИ";
            this.header.Size = new System.Drawing.Size(900, 56);

            // ===== BindingNavigator =====
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
            this.navMoveFirst.Name = "navMoveFirst"; this.navMoveFirst.Text = "|<"; this.navMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMovePrev.Name = "navMovePrev"; this.navMovePrev.Text = "<"; this.navMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navPosition.Name = "navPosition"; this.navPosition.Size = new System.Drawing.Size(40, 25); this.navPosition.Text = "1";
            this.navCount.Name = "navCount"; this.navCount.Text = "/ {0}";
            this.navMoveNext.Name = "navMoveNext"; this.navMoveNext.Text = ">"; this.navMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.navMoveLast.Name = "navMoveLast"; this.navMoveLast.Text = ">|"; this.navMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            // ===== Постер =====
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureBox.Location = new System.Drawing.Point(40, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(820, 240);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabStop = false;

            // ===== Поля (тёмная тема: белый текст на тёмном фоне) =====
            System.Drawing.Color textCol = System.Drawing.Color.FromArgb(240, 240, 244);
            System.Drawing.Color labelCol = System.Drawing.Color.FromArgb(229, 57, 53);
            System.Drawing.Color fieldBg = System.Drawing.Color.FromArgb(30, 30, 34);
            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font textFont = new System.Drawing.Font("Segoe UI", 10F);

            void cfgLabel(System.Windows.Forms.Label l, string text, int x, int y)
            {
                l.AutoSize = false;
                l.BackColor = System.Drawing.Color.Transparent;
                l.Font = labelFont;
                l.ForeColor = labelCol;
                l.Location = new System.Drawing.Point(x, y);
                l.Size = new System.Drawing.Size(170, 28);
                l.Text = text;
                l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            }
            void cfgText(System.Windows.Forms.TextBox t, int x, int y)
            {
                t.BackColor = fieldBg;
                t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                t.Font = textFont;
                t.ForeColor = textCol;
                t.Location = new System.Drawing.Point(x, y);
                t.Size = new System.Drawing.Size(440, 28);
            }

            cfgLabel(this.lblNaim,  "Наименование:", 130, 370); this.lblNaim.Name  = "lblNaim";
            cfgText (this.txtNaim,  310, 370);                  this.txtNaim.Name  = "txtNaim";
            cfgLabel(this.lblOklad, "Оклад:",        130, 410); this.lblOklad.Name = "lblOklad";
            cfgText (this.txtOklad, 310, 410);                  this.txtOklad.Name = "txtOklad";
            cfgLabel(this.lblObyaz, "Обязанности:",  130, 450); this.lblObyaz.Name = "lblObyaz";
            cfgText (this.txtObyaz, 310, 450);                  this.txtObyaz.Name = "txtObyaz";
            cfgLabel(this.lblTreb,  "Требования:",   130, 490); this.lblTreb.Name  = "lblTreb";
            cfgText (this.txtTreb,  310, 490);                  this.txtTreb.Name  = "txtTreb";

            // ===== Кнопки =====
            int y1 = 560, y2 = 605, bw = 130, bh = 36, gap = 10, x0 = 60;

            void cfgBtn(CarRentalApp.Controls.ColoredButton b, string name, string text,
                        CarRentalApp.Controls.BtnVariant v, int x, int y, int w)
            {
                b.Name = name; b.Text = text; b.Variant = v;
                b.Location = new System.Drawing.Point(x, y);
                b.Size = new System.Drawing.Size(w, bh);
            }

            cfgBtn(this.btnFirst,  "btnFirst",  "Первая",     CarRentalApp.Controls.BtnVariant.Default, x0,             y1, bw);
            cfgBtn(this.btnPrev,   "btnPrev",   "Предыдущая", CarRentalApp.Controls.BtnVariant.Default, x0 + (bw+gap),  y1, bw);
            cfgBtn(this.btnAdd,    "btnAdd",    "Добавить",   CarRentalApp.Controls.BtnVariant.Add,     x0 + (bw+gap)*2,y1, bw);
            cfgBtn(this.btnSave,   "btnSave",   "Сохранить",  CarRentalApp.Controls.BtnVariant.Save,    x0 + (bw+gap)*3,y1, bw);
            cfgBtn(this.btnReport, "btnReport", "Отчёт",      CarRentalApp.Controls.BtnVariant.Default, x0 + (bw+gap)*4,y1, 170);

            cfgBtn(this.btnLast,  "btnLast",  "Последняя",   CarRentalApp.Controls.BtnVariant.Default, x0,             y2, bw);
            cfgBtn(this.btnNext,  "btnNext",  "Следующая",   CarRentalApp.Controls.BtnVariant.Default, x0 + (bw+gap),  y2, bw);
            cfgBtn(this.btnDel,   "btnDel",   "Удалить",     CarRentalApp.Controls.BtnVariant.Delete,  x0 + (bw+gap)*2,y2, bw);
            cfgBtn(this.btnTable, "btnTable", "Табличная",   CarRentalApp.Controls.BtnVariant.Default, x0 + (bw+gap)*3,y2, bw);
            cfgBtn(this.btnClose, "btnClose", "Закрыть",     CarRentalApp.Controls.BtnVariant.Default, x0 + (bw+gap)*4,y2, 170);

            // ===== Форма =====
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
