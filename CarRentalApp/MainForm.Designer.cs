namespace CarRentalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Верх — hero-баннер
        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.Panel panelHeroAccent;
        private System.Windows.Forms.Label  lblHeroTitle;
        private System.Windows.Forms.Label  lblHeroSub;

        // Центр — скроллируемый контейнер
        private System.Windows.Forms.Panel panelContent;

        // Группы и ряды
        private System.Windows.Forms.Label lblGroupTables;
        private System.Windows.Forms.FlowLayoutPanel rowTables;
        private System.Windows.Forms.Label lblGroupQueries;
        private System.Windows.Forms.FlowLayoutPanel rowQueries;
        private System.Windows.Forms.Label lblGroupFilters;
        private System.Windows.Forms.FlowLayoutPanel rowFilters;
        private System.Windows.Forms.Label lblGroupReports;
        private System.Windows.Forms.FlowLayoutPanel rowReports;

        // Карточки — Формы
        private System.Windows.Forms.Button cardSotrudniki;
        private System.Windows.Forms.Button cardDolzhnosti;
        private System.Windows.Forms.Button cardMarki;
        private System.Windows.Forms.Button cardUslugi;
        private System.Windows.Forms.Button cardAvtomobili;
        private System.Windows.Forms.Button cardKlienty;
        private System.Windows.Forms.Button cardProkat;
        private System.Windows.Forms.Button cardOtdelKadrov;
        private System.Windows.Forms.Button cardAvtopark;
        private System.Windows.Forms.Button cardAvtoVProkate;
        private System.Windows.Forms.Button cardFiltDolzh;
        private System.Windows.Forms.Button cardFiltMarka;
        private System.Windows.Forms.Button cardFiltVozvrat;
        private System.Windows.Forms.Button cardFiltDate;
        private System.Windows.Forms.Button cardFiltOplata;

        // Карточки — Отчёты (повторяют те же постеры)
        private System.Windows.Forms.Button cardRepSotrudniki;
        private System.Windows.Forms.Button cardRepDolzhnosti;
        private System.Windows.Forms.Button cardRepMarki;
        private System.Windows.Forms.Button cardRepUslugi;
        private System.Windows.Forms.Button cardRepAvtomobili;
        private System.Windows.Forms.Button cardRepKlienty;
        private System.Windows.Forms.Button cardRepProkat;
        private System.Windows.Forms.Button cardRepOtdelKadrov;
        private System.Windows.Forms.Button cardRepAvtopark;
        private System.Windows.Forms.Button cardRepAvtoVProkate;

        // Низ — панель кнопок
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHistogram;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private static System.Windows.Forms.Button MkCard(
            System.ComponentModel.ComponentResourceManager res, string posterKey)
        {
            var b = new System.Windows.Forms.Button
            {
                Size = new System.Drawing.Size(230, 130),
                BackColor = System.Drawing.Color.FromArgb(30, 30, 34),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Margin = new System.Windows.Forms.Padding(0, 0, 12, 0),
                Cursor = System.Windows.Forms.Cursors.Hand,
                BackgroundImage = ((System.Drawing.Image)(res.GetObject("poster_" + posterKey))),
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                Text = "",
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 66);
            return b;
        }

        private static System.Windows.Forms.Label MkGroup(string text)
        {
            return new System.Windows.Forms.Label
            {
                Text = "▌ " + text,
                AutoSize = false,
                Size = new System.Drawing.Size(1080, 26),
                Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(229, 57, 53),
                Margin = new System.Windows.Forms.Padding(0, 14, 0, 4),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new System.Windows.Forms.Padding(36, 0, 0, 0)
            };
        }

        private static System.Windows.Forms.FlowLayoutPanel MkRow()
        {
            return new System.Windows.Forms.FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink,
                FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new System.Windows.Forms.Padding(36, 4, 36, 4),
                BackColor = System.Drawing.Color.FromArgb(18, 18, 20)
            };
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

            this.panelHero = new System.Windows.Forms.Panel();
            this.panelHeroAccent = new System.Windows.Forms.Panel();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.lblHeroSub = new System.Windows.Forms.Label();

            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();

            // ---- Карточки и группы ----
            this.lblGroupTables  = MkGroup("ТАБЛИЦЫ");
            this.lblGroupQueries = MkGroup("ЗАПРОСЫ");
            this.lblGroupFilters = MkGroup("ФИЛЬТРЫ");
            this.lblGroupReports = MkGroup("ОТЧЁТЫ");

            this.rowTables = MkRow();
            this.rowQueries = MkRow();
            this.rowFilters = MkRow();
            this.rowReports = MkRow();

            this.cardSotrudniki   = MkCard(resources, "sotrudniki");
            this.cardDolzhnosti   = MkCard(resources, "dolzhnosti");
            this.cardMarki        = MkCard(resources, "marki");
            this.cardUslugi       = MkCard(resources, "uslugi");
            this.cardAvtomobili   = MkCard(resources, "avtomobili");
            this.cardKlienty      = MkCard(resources, "klienty");
            this.cardProkat       = MkCard(resources, "prokat");

            this.cardOtdelKadrov  = MkCard(resources, "q_kadrov");
            this.cardAvtopark     = MkCard(resources, "q_avtopark");
            this.cardAvtoVProkate = MkCard(resources, "q_vprokate");

            this.cardFiltDolzh    = MkCard(resources, "f_dolzh");
            this.cardFiltMarka    = MkCard(resources, "f_marka");
            this.cardFiltVozvrat  = MkCard(resources, "f_vozvrat");
            this.cardFiltDate     = MkCard(resources, "f_data");
            this.cardFiltOplata   = MkCard(resources, "f_oplata");

            this.cardRepSotrudniki   = MkCard(resources, "sotrudniki");
            this.cardRepDolzhnosti   = MkCard(resources, "dolzhnosti");
            this.cardRepMarki        = MkCard(resources, "marki");
            this.cardRepUslugi       = MkCard(resources, "uslugi");
            this.cardRepAvtomobili   = MkCard(resources, "avtomobili");
            this.cardRepKlienty      = MkCard(resources, "klienty");
            this.cardRepProkat       = MkCard(resources, "prokat");
            this.cardRepOtdelKadrov  = MkCard(resources, "q_kadrov");
            this.cardRepAvtopark     = MkCard(resources, "q_avtopark");
            this.cardRepAvtoVProkate = MkCard(resources, "q_vprokate");

            this.panelHero.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ===== Hero-баннер сверху =====
            this.panelHero.BackColor = System.Drawing.Color.FromArgb(40, 12, 16);
            this.panelHero.Controls.Add(this.lblHeroSub);
            this.panelHero.Controls.Add(this.lblHeroTitle);
            this.panelHero.Controls.Add(this.panelHeroAccent);
            this.panelHero.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(1140, 170);

            this.lblHeroTitle.AutoSize = true;
            this.lblHeroTitle.Font = new System.Drawing.Font("Segoe UI Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitle.Location = new System.Drawing.Point(38, 56);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Text = "ПРОКАТ АВТОМОБИЛЕЙ";

            this.lblHeroSub.AutoSize = true;
            this.lblHeroSub.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeroSub.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblHeroSub.Location = new System.Drawing.Point(40, 30);
            this.lblHeroSub.Name = "lblHeroSub";
            this.lblHeroSub.Text = "ИНФОРМАЦИОННАЯ СИСТЕМА  ·  ВАРИАНТ №17";

            this.panelHeroAccent.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.panelHeroAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeroAccent.Name = "panelHeroAccent";
            this.panelHeroAccent.Size = new System.Drawing.Size(1140, 4);

            // ===== Центральная скроллируемая область =====
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);

            // Ряды наполняем карточками
            this.rowTables.Controls.Add(this.cardSotrudniki);
            this.rowTables.Controls.Add(this.cardDolzhnosti);
            this.rowTables.Controls.Add(this.cardMarki);
            this.rowTables.Controls.Add(this.cardUslugi);
            this.rowTables.Controls.Add(this.cardAvtomobili);
            this.rowTables.Controls.Add(this.cardKlienty);
            this.rowTables.Controls.Add(this.cardProkat);

            this.rowQueries.Controls.Add(this.cardOtdelKadrov);
            this.rowQueries.Controls.Add(this.cardAvtopark);
            this.rowQueries.Controls.Add(this.cardAvtoVProkate);

            this.rowFilters.Controls.Add(this.cardFiltDolzh);
            this.rowFilters.Controls.Add(this.cardFiltMarka);
            this.rowFilters.Controls.Add(this.cardFiltVozvrat);
            this.rowFilters.Controls.Add(this.cardFiltDate);
            this.rowFilters.Controls.Add(this.cardFiltOplata);

            this.rowReports.Controls.Add(this.cardRepSotrudniki);
            this.rowReports.Controls.Add(this.cardRepDolzhnosti);
            this.rowReports.Controls.Add(this.cardRepMarki);
            this.rowReports.Controls.Add(this.cardRepUslugi);
            this.rowReports.Controls.Add(this.cardRepAvtomobili);
            this.rowReports.Controls.Add(this.cardRepKlienty);
            this.rowReports.Controls.Add(this.cardRepProkat);
            this.rowReports.Controls.Add(this.cardRepOtdelKadrov);
            this.rowReports.Controls.Add(this.cardRepAvtopark);
            this.rowReports.Controls.Add(this.cardRepAvtoVProkate);

            // Размещаем группы и ряды в контенте сверху-вниз (Y координаты)
            this.lblGroupTables.Location  = new System.Drawing.Point(0,   10);
            this.rowTables.Location       = new System.Drawing.Point(0,   42);
            this.lblGroupQueries.Location = new System.Drawing.Point(0,  192);
            this.rowQueries.Location      = new System.Drawing.Point(0,  224);
            this.lblGroupFilters.Location = new System.Drawing.Point(0,  374);
            this.rowFilters.Location      = new System.Drawing.Point(0,  406);
            this.lblGroupReports.Location = new System.Drawing.Point(0,  556);
            this.rowReports.Location      = new System.Drawing.Point(0,  588);

            this.panelContent.Controls.Add(this.lblGroupTables);
            this.panelContent.Controls.Add(this.rowTables);
            this.panelContent.Controls.Add(this.lblGroupQueries);
            this.panelContent.Controls.Add(this.rowQueries);
            this.panelContent.Controls.Add(this.lblGroupFilters);
            this.panelContent.Controls.Add(this.rowFilters);
            this.panelContent.Controls.Add(this.lblGroupReports);
            this.panelContent.Controls.Add(this.rowReports);

            // ===== Нижняя панель =====
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(22, 22, 26);
            this.panelBottom.Controls.Add(this.btnExit);
            this.panelBottom.Controls.Add(this.btnAbout);
            this.panelBottom.Controls.Add(this.btnHistogram);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1140, 52);

            this.btnExit.BackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(14, 10);
            this.btnExit.Name = "btnExit"; this.btnExit.Size = new System.Drawing.Size(120, 32);
            this.btnExit.Text = "Выход"; this.btnExit.UseVisualStyleBackColor = false;

            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(30, 30, 34);
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 66);
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.btnAbout.Location = new System.Drawing.Point(140, 10);
            this.btnAbout.Name = "btnAbout"; this.btnAbout.Size = new System.Drawing.Size(140, 32);
            this.btnAbout.Text = "О программе"; this.btnAbout.UseVisualStyleBackColor = false;

            this.btnHistogram.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnHistogram.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistogram.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistogram.ForeColor = System.Drawing.Color.White;
            this.btnHistogram.Location = new System.Drawing.Point(286, 10);
            this.btnHistogram.Name = "btnHistogram"; this.btnHistogram.Size = new System.Drawing.Size(150, 32);
            this.btnHistogram.Text = "Гистограмма"; this.btnHistogram.UseVisualStyleBackColor = false;

            // ===== Форма =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 20);
            this.ClientSize = new System.Drawing.Size(1140, 760);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHero);
            this.ForeColor = System.Drawing.Color.FromArgb(240, 240, 244);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "БД «Прокат автомобилей»";

            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
