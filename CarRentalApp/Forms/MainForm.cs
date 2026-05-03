using System;
using System.Drawing;
using System.Windows.Forms;
using CarRentalApp.Configs;
using CarRentalApp.Forms.Tables;
using CarRentalApp.Forms.Queries;
using CarRentalApp.Forms.Filters;

namespace CarRentalApp.Forms
{
    /// <summary>Главная кнопочная форма приложения.</summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text            = "БД «Прокат автомобилей» - Главная форма";
            StartPosition   = FormStartPosition.CenterScreen;
            Size            = new Size(900, 640);
            MinimumSize     = new Size(800, 600);
            BackColor       = Color.WhiteSmoke;

            // ------------ Заголовок ------------
            var lblTitle = new Label
            {
                Text      = "База данных «Прокат автомобилей»",
                Font      = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 60, 120),
                AutoSize  = false,
                Dock      = DockStyle.Top,
                Height    = 70,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ------------ Нижняя панель кнопок ------------
            var bottomPanel = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.Gainsboro };

            var btnExit = MakeBigButton("Выход", Color.FromArgb(200, 80, 80));
            btnExit.Location = new Point(20, 10);
            btnExit.Click += (s, e) => Application.Exit();

            var btnAbout = MakeBigButton("О программе", Color.FromArgb(80, 130, 200));
            btnAbout.Location = new Point(180, 10);
            btnAbout.Click += (s, e) => { using var f = new AboutForm(); f.ShowDialog(this); };

            var btnHistogram = MakeBigButton("Гистограмма зарплат", Color.FromArgb(80, 170, 100));
            btnHistogram.Location = new Point(360, 10);
            btnHistogram.Click += (s, e) => { using var f = new HistogramForm(); f.ShowDialog(this); };

            bottomPanel.Controls.AddRange(new Control[] { btnExit, btnAbout, btnHistogram });

            // ------------ Вкладки в центре ------------
            var tabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Point(20, 8)
            };

            var tabForms   = new TabPage("Формы");
            var tabReports = new TabPage("Отчёты");
            tabs.TabPages.Add(tabForms);
            tabs.TabPages.Add(tabReports);

            BuildFormsTab(tabForms);
            BuildReportsTab(tabReports);

            Controls.Add(tabs);
            Controls.Add(bottomPanel);
            Controls.Add(lblTitle);
        }

        // ============================================================
        //                    Вкладка "Формы"
        // ============================================================
        private void BuildFormsTab(TabPage tab)
        {
            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10)
            };

            scroll.Controls.Add(MakeSection("Формы для таблиц"));
            scroll.Controls.Add(MakePair("Сотрудники",            "Ленточная форма",  () => new TableEditForm(TableConfigs.Sotrudniki()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Sotrudniki())));
            scroll.Controls.Add(MakePair("Должности",             "Ленточная форма",  () => new TableEditForm(TableConfigs.Dolzhnosti()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Dolzhnosti())));
            scroll.Controls.Add(MakePair("Марки автомобилей",     "Ленточная форма",  () => new TableEditForm(TableConfigs.Marki()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Marki())));
            scroll.Controls.Add(MakePair("Дополнительные услуги", "Ленточная форма",  () => new TableEditForm(TableConfigs.Uslugi()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Uslugi())));
            scroll.Controls.Add(MakePair("Автомобили",            "Ленточная форма",  () => new TableEditForm(TableConfigs.Avtomobili()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Avtomobili())));
            scroll.Controls.Add(MakePair("Клиенты",               "Ленточная форма",  () => new TableEditForm(TableConfigs.Klienty()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Klienty())));
            scroll.Controls.Add(MakePair("Прокат",                "Ленточная форма",  () => new TableEditForm(TableConfigs.Prokat()),
                                                                  "Табличная форма",  () => new TableGridForm(TableConfigs.Prokat())));

            scroll.Controls.Add(MakeSection("Формы запросов"));
            scroll.Controls.Add(MakeSingle("Отдел кадров",            () => new QueryGridForm(QueryConfigs.OtdelKadrov())));
            scroll.Controls.Add(MakeSingle("Автопарк",                () => new QueryGridForm(QueryConfigs.Avtopark())));
            scroll.Controls.Add(MakeSingle("Автомобили в прокате",    () => new QueryGridForm(QueryConfigs.AvtoVProkate())));

            scroll.Controls.Add(MakeSection("Формы фильтров"));
            scroll.Controls.Add(MakeSingle("Сотрудники по должности",            () => new FilterForm(FilterConfigs.SotrudnikiPoDolzh())));
            scroll.Controls.Add(MakeSingle("Автомобили по марке",                () => new FilterForm(FilterConfigs.AvtoPoMarke())));
            scroll.Controls.Add(MakeSingle("Автомобили в прокате / свободные",   () => new FilterForm(FilterConfigs.AvtoVProkate())));
            scroll.Controls.Add(MakeSingle("Прокат по дате",                     () => new FilterForm(FilterConfigs.ProkatPoDate())));
            scroll.Controls.Add(MakeSingle("Оплаченные / неоплаченные прокаты",  () => new FilterForm(FilterConfigs.OplataProkata())));

            tab.Controls.Add(scroll);
        }

        // ============================================================
        //                   Вкладка "Отчёты"
        // ============================================================
        private void BuildReportsTab(TabPage tab)
        {
            var scroll = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10)
            };

            scroll.Controls.Add(MakeSection("Отчёты по таблицам"));
            scroll.Controls.Add(MakeSingle("Сотрудники",            () => new ReportForm(TableConfigs.Sotrudniki())));
            scroll.Controls.Add(MakeSingle("Должности",             () => new ReportForm(TableConfigs.Dolzhnosti())));
            scroll.Controls.Add(MakeSingle("Марки автомобилей",     () => new ReportForm(TableConfigs.Marki())));
            scroll.Controls.Add(MakeSingle("Дополнительные услуги", () => new ReportForm(TableConfigs.Uslugi())));
            scroll.Controls.Add(MakeSingle("Автомобили",            () => new ReportForm(TableConfigs.Avtomobili())));
            scroll.Controls.Add(MakeSingle("Клиенты",               () => new ReportForm(TableConfigs.Klienty())));
            scroll.Controls.Add(MakeSingle("Прокат",                () => new ReportForm(TableConfigs.Prokat())));

            scroll.Controls.Add(MakeSection("Отчёты по запросам"));
            scroll.Controls.Add(MakeSingle("Отдел кадров",         () => new ReportForm(QueryConfigs.OtdelKadrov())));
            scroll.Controls.Add(MakeSingle("Автопарк",             () => new ReportForm(QueryConfigs.Avtopark())));
            scroll.Controls.Add(MakeSingle("Автомобили в прокате", () => new ReportForm(QueryConfigs.AvtoVProkate())));

            scroll.Controls.Add(MakeSection("Отчёты по фильтрам"));
            scroll.Controls.Add(MakeSingle("Сотрудники по должности",            () => new FilterReportForm(FilterConfigs.SotrudnikiPoDolzh())));
            scroll.Controls.Add(MakeSingle("Автомобили по марке",                () => new FilterReportForm(FilterConfigs.AvtoPoMarke())));
            scroll.Controls.Add(MakeSingle("Автомобили в прокате / свободные",   () => new FilterReportForm(FilterConfigs.AvtoVProkate())));
            scroll.Controls.Add(MakeSingle("Прокат по дате",                     () => new FilterReportForm(FilterConfigs.ProkatPoDate())));
            scroll.Controls.Add(MakeSingle("Оплаченные / неоплаченные прокаты",  () => new FilterReportForm(FilterConfigs.OplataProkata())));

            tab.Controls.Add(scroll);
        }

        // ============================================================
        //                     Вспомогательные методы
        // ============================================================
        private static Button MakeBigButton(string text, Color back)
        {
            return new Button
            {
                Text = text,
                Size = new Size(150, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private static Label MakeSection(string title)
        {
            return new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 120),
                AutoSize  = false,
                Width     = 800,
                Height    = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin    = new Padding(4, 12, 4, 4),
                BorderStyle = BorderStyle.None
            };
        }

        private static Panel MakeSingle(string caption, Func<Form> openFn)
        {
            var p = new Panel { Width = 800, Height = 42, Margin = new Padding(4) };

            var btn = new Button
            {
                Text   = "Открыть",
                Width  = 130,
                Height = 32,
                Left   = 4,
                Top    = 4,
                Font   = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(80, 130, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.Click += (s, e) => { var f = openFn(); f.Show(); };

            var lbl = new Label
            {
                Text     = caption,
                AutoSize = false,
                Width    = 640,
                Height   = 32,
                Left     = 144,
                Top      = 4,
                Font     = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleLeft
            };

            p.Controls.Add(btn);
            p.Controls.Add(lbl);
            return p;
        }

        private static Panel MakePair(string caption, string b1Text, Func<Form> b1Fn, string b2Text, Func<Form> b2Fn)
        {
            var p = new Panel { Width = 800, Height = 42, Margin = new Padding(4) };

            Button MakeBtn(string text, Func<Form> fn, int x, Color color)
            {
                var b = new Button
                {
                    Text   = text,
                    Width  = 150,
                    Height = 32,
                    Left   = x,
                    Top    = 4,
                    Font   = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = color,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                b.Click += (s, e) => { var f = fn(); f.Show(); };
                return b;
            }

            var b1 = MakeBtn(b1Text, b1Fn, 4,   Color.FromArgb(80, 170, 100));
            var b2 = MakeBtn(b2Text, b2Fn, 160, Color.FromArgb(80, 130, 200));

            var lbl = new Label
            {
                Text      = caption,
                AutoSize  = false,
                Width     = 480,
                Height    = 32,
                Left      = 320,
                Top       = 4,
                Font      = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleLeft
            };

            p.Controls.AddRange(new Control[] { b1, b2, lbl });
            return p;
        }
    }
}
