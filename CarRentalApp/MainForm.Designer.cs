namespace CarRentalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTopAccent;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabForms;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHistogram;

        // --- Кнопки вкладки "Формы" ---
        private System.Windows.Forms.Label lblFormsTabl;
        private System.Windows.Forms.Button btnSotrudniki;
        private System.Windows.Forms.Button btnDolzhnosti;
        private System.Windows.Forms.Button btnMarki;
        private System.Windows.Forms.Button btnUslugi;
        private System.Windows.Forms.Button btnAvtomobili;
        private System.Windows.Forms.Button btnKlienty;
        private System.Windows.Forms.Button btnProkat;
        private System.Windows.Forms.Label lblFormsZap;
        private System.Windows.Forms.Button btnOtdelKadrov;
        private System.Windows.Forms.Button btnAvtopark;
        private System.Windows.Forms.Button btnAvtoVProkate;
        private System.Windows.Forms.Label lblFormsFilt;
        private System.Windows.Forms.Button btnFiltDolzh;
        private System.Windows.Forms.Button btnFiltMarka;
        private System.Windows.Forms.Button btnFiltVozvrat;
        private System.Windows.Forms.Button btnFiltDate;
        private System.Windows.Forms.Button btnFiltOplata;

        // --- Кнопки вкладки "Отчёты" ---
        private System.Windows.Forms.Label lblRepTabl;
        private System.Windows.Forms.Button btnRepSotrudniki;
        private System.Windows.Forms.Button btnRepDolzhnosti;
        private System.Windows.Forms.Button btnRepMarki;
        private System.Windows.Forms.Button btnRepUslugi;
        private System.Windows.Forms.Button btnRepAvtomobili;
        private System.Windows.Forms.Button btnRepKlienty;
        private System.Windows.Forms.Button btnRepProkat;
        private System.Windows.Forms.Label lblRepZap;
        private System.Windows.Forms.Button btnRepOtdelKadrov;
        private System.Windows.Forms.Button btnRepAvtopark;
        private System.Windows.Forms.Button btnRepAvtoVProkate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private static System.Windows.Forms.Button MkBtn(string text, int x, int y)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(280, 30),
                BackColor = System.Drawing.Color.FromArgb(30, 30, 34),
                ForeColor = System.Drawing.Color.FromArgb(240, 240, 244),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new System.Windows.Forms.Padding(10, 0, 0, 0),
                UseVisualStyleBackColor = false
            };
        }
        private static System.Windows.Forms.Label MkGroup(string text, int y)
        {
            return new System.Windows.Forms.Label
            {
                Text = text,
                Location = new System.Drawing.Point(14, y),
                Size = new System.Drawing.Size(280, 22),
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(229, 57, 53),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabForms = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();

            // Кнопки и подписи на вкладке "Формы"
            this.lblFormsTabl   = MkGroup("ТАБЛИЦЫ", 10);
            this.btnSotrudniki  = MkBtn("Сотрудники",            14, 36);
            this.btnDolzhnosti  = MkBtn("Должности",             14, 72);
            this.btnMarki       = MkBtn("Марки автомобилей",     14, 108);
            this.btnUslugi      = MkBtn("Дополнительные услуги", 14, 144);
            this.btnAvtomobili  = MkBtn("Автомобили",            14, 180);
            this.btnKlienty     = MkBtn("Клиенты",               14, 216);
            this.btnProkat      = MkBtn("Прокат",                14, 252);
            this.lblFormsZap    = MkGroup("ЗАПРОСЫ", 294);
            this.btnOtdelKadrov = MkBtn("Отдел кадров",          14, 320);
            this.btnAvtopark    = MkBtn("Автопарк",              14, 356);
            this.btnAvtoVProkate= MkBtn("Автомобили в прокате",  14, 392);
            this.lblFormsFilt   = MkGroup("ФИЛЬТРЫ", 434);
            this.btnFiltDolzh   = MkBtn("Сотрудники по должности", 14, 460);
            this.btnFiltMarka   = MkBtn("Автомобили по марке",     14, 496);
            this.btnFiltVozvrat = MkBtn("В прокате / свободные",   14, 532);
            this.btnFiltDate    = MkBtn("Прокат по дате",          14, 568);
            this.btnFiltOplata  = MkBtn("Оплачено / не оплачено",  14, 604);

            // Кнопки и подписи на вкладке "Отчёты"
            this.lblRepTabl       = MkGroup("ПО ТАБЛИЦАМ", 10);
            this.btnRepSotrudniki = MkBtn("Сотрудники",            14, 36);
            this.btnRepDolzhnosti = MkBtn("Должности",             14, 72);
            this.btnRepMarki      = MkBtn("Марки автомобилей",     14, 108);
            this.btnRepUslugi     = MkBtn("Дополнительные услуги", 14, 144);
            this.btnRepAvtomobili = MkBtn("Автомобили",            14, 180);
            this.btnRepKlienty    = MkBtn("Клиенты",               14, 216);
            this.btnRepProkat     = MkBtn("Прокат",                14, 252);
            this.lblRepZap        = MkGroup("ПО ЗАПРОСАМ", 294);
            this.btnRepOtdelKadrov= MkBtn("Отдел кадров",          14, 320);
            this.btnRepAvtopark   = MkBtn("Автопарк",              14, 356);
            this.btnRepAvtoVProkate= MkBtn("Автомобили в прокате", 14, 392);

            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();

            // ===== Верхняя панель (заголовок БД) =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(12, 12, 14);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.panelTopAccent);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(640, 68);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "БД «Прокат автомобилей»";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panelTopAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelTopAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTopAccent.Name = "panelTopAccent";
            this.panelTopAccent.Size = new System.Drawing.Size(640, 4);

            // ===== Вкладки =====
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Controls.Add(this.tabForms);
            this.tabs.Controls.Add(this.tabReports);

            this.tabForms.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.tabForms.Text = "Формы";
            this.tabForms.AutoScroll = true;
            this.tabForms.Padding = new System.Windows.Forms.Padding(8);
            this.tabForms.Controls.Add(this.lblFormsTabl);
            this.tabForms.Controls.Add(this.btnSotrudniki);
            this.tabForms.Controls.Add(this.btnDolzhnosti);
            this.tabForms.Controls.Add(this.btnMarki);
            this.tabForms.Controls.Add(this.btnUslugi);
            this.tabForms.Controls.Add(this.btnAvtomobili);
            this.tabForms.Controls.Add(this.btnKlienty);
            this.tabForms.Controls.Add(this.btnProkat);
            this.tabForms.Controls.Add(this.lblFormsZap);
            this.tabForms.Controls.Add(this.btnOtdelKadrov);
            this.tabForms.Controls.Add(this.btnAvtopark);
            this.tabForms.Controls.Add(this.btnAvtoVProkate);
            this.tabForms.Controls.Add(this.lblFormsFilt);
            this.tabForms.Controls.Add(this.btnFiltDolzh);
            this.tabForms.Controls.Add(this.btnFiltMarka);
            this.tabForms.Controls.Add(this.btnFiltVozvrat);
            this.tabForms.Controls.Add(this.btnFiltDate);
            this.tabForms.Controls.Add(this.btnFiltOplata);

            this.tabReports.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.tabReports.Text = "Отчёты";
            this.tabReports.AutoScroll = true;
            this.tabReports.Padding = new System.Windows.Forms.Padding(8);
            this.tabReports.Controls.Add(this.lblRepTabl);
            this.tabReports.Controls.Add(this.btnRepSotrudniki);
            this.tabReports.Controls.Add(this.btnRepDolzhnosti);
            this.tabReports.Controls.Add(this.btnRepMarki);
            this.tabReports.Controls.Add(this.btnRepUslugi);
            this.tabReports.Controls.Add(this.btnRepAvtomobili);
            this.tabReports.Controls.Add(this.btnRepKlienty);
            this.tabReports.Controls.Add(this.btnRepProkat);
            this.tabReports.Controls.Add(this.lblRepZap);
            this.tabReports.Controls.Add(this.btnRepOtdelKadrov);
            this.tabReports.Controls.Add(this.btnRepAvtopark);
            this.tabReports.Controls.Add(this.btnRepAvtoVProkate);

            // ===== Нижняя панель =====
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelBottom.Controls.Add(this.btnExit);
            this.panelBottom.Controls.Add(this.btnAbout);
            this.panelBottom.Controls.Add(this.btnHistogram);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(640, 50);

            this.btnExit.BackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 9);
            this.btnExit.Name = "btnExit"; this.btnExit.Size = new System.Drawing.Size(130, 32);
            this.btnExit.Text = "Выход"; this.btnExit.UseVisualStyleBackColor = false;

            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.btnAbout.Location = new System.Drawing.Point(148, 9);
            this.btnAbout.Name = "btnAbout"; this.btnAbout.Size = new System.Drawing.Size(140, 32);
            this.btnAbout.Text = "О программе"; this.btnAbout.UseVisualStyleBackColor = false;

            this.btnHistogram.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnHistogram.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistogram.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistogram.ForeColor = System.Drawing.Color.White;
            this.btnHistogram.Location = new System.Drawing.Point(294, 9);
            this.btnHistogram.Name = "btnHistogram"; this.btnHistogram.Size = new System.Drawing.Size(140, 32);
            this.btnHistogram.Text = "Гистограмма"; this.btnHistogram.UseVisualStyleBackColor = false;

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(640, 720);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "БД «Прокат автомобилей»";

            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabForms.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
