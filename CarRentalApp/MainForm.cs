using System;
using System.Drawing;
using System.Windows.Forms;
using CarRentalApp.Forms;

namespace CarRentalApp
{
    /// <summary>Главная кнопочная форма.</summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text          = "БД «Прокат автомобилей»";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(560, 540);
            MinimumSize   = new Size(420, 400);
            Font          = UI.Body;

            // Заголовок
            Controls.Add(new Label
            {
                Text      = "База данных «Прокат автомобилей»",
                Dock      = DockStyle.Top, Height = 32,
                Font      = new Font("Segoe UI", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = SystemColors.Control
            });

            // Нижняя панель: Выход / О программе / Гистограмма
            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Выход",        (s,e) => Application.Exit(),                       100));
            bottom.Controls.Add(UI.MakeBtn("О программе",  (s,e) => new AboutForm().ShowDialog(this),         110));
            bottom.Controls.Add(UI.MakeBtn("Гистограмма",  (s,e) => new HistogramForm().ShowDialog(this),     110));
            Controls.Add(bottom);

            // Вкладки
            var tabs = new TabControl { Dock = DockStyle.Fill };
            tabs.TabPages.Add(BuildFormsTab());
            tabs.TabPages.Add(BuildReportsTab());
            Controls.Add(tabs);
        }

        private TabPage BuildFormsTab()
        {
            var tab = new TabPage("Формы");
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, Padding = new Padding(8)
            };

            list.Controls.Add(Group("Таблицы"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiForm().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiForm().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiForm().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiForm().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliForm().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyForm().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatForm().Show()));

            list.Controls.Add(Group("Запросы"));
            list.Controls.Add(Item("Отдел кадров",         () => new OtdelKadrovForm().Show()));
            list.Controls.Add(Item("Автопарк",             () => new AvtoparkForm().Show()));
            list.Controls.Add(Item("Автомобили в прокате", () => new AvtoVProkateForm().Show()));

            list.Controls.Add(Group("Фильтры"));
            list.Controls.Add(Item("Сотрудники по должности",  () => new FilterByDolzhnost().Show()));
            list.Controls.Add(Item("Автомобили по марке",      () => new FilterByMarka().Show()));
            list.Controls.Add(Item("В прокате / свободные",    () => new FilterByVozvrachen().Show()));
            list.Controls.Add(Item("Прокат по дате",           () => new FilterByDate().Show()));
            list.Controls.Add(Item("Оплачено / не оплачено",   () => new FilterByOplata().Show()));

            tab.Controls.Add(list);
            return tab;
        }

        private TabPage BuildReportsTab()
        {
            var tab = new TabPage("Отчёты");
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, Padding = new Padding(8)
            };

            list.Controls.Add(Group("По таблицам"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiReport().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiReport().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiReport().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiReport().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliReport().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyReport().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatReport().Show()));

            list.Controls.Add(Group("По запросам"));
            list.Controls.Add(Item("Отдел кадров",         () => new OtdelKadrovReport().Show()));
            list.Controls.Add(Item("Автопарк",             () => new AvtoparkReport().Show()));
            list.Controls.Add(Item("Автомобили в прокате", () => new AvtoVProkateReport().Show()));

            list.Controls.Add(Group("По фильтрам"));
            list.Controls.Add(Item("Сотрудники по должности", () => new ReportFormParam("Сотрудники по должности (все)", OtdelKadrovForm.Sql, null).Show()));
            list.Controls.Add(Item("Автомобили по марке",     () => new ReportFormParam("Автомобили по марке (все)",     AvtoparkForm.Sql,     null).Show()));
            list.Controls.Add(Item("В прокате / свободные",   () => new ReportFormParam("В прокате / свободные (все)",   AvtoparkForm.Sql,     null).Show()));
            list.Controls.Add(Item("Прокат по дате",          () => new ReportFormParam("Прокат по дате (все)",          AvtoVProkateForm.Sql, null).Show()));
            list.Controls.Add(Item("Оплачено / не оплачено",  () => new ReportFormParam("Оплачено / не оплачено (все)",  AvtoVProkateForm.Sql, null).Show()));

            tab.Controls.Add(list);
            return tab;
        }

        // --- helpers ---
        private static Label Group(string text) => new()
        {
            Text     = text,
            AutoSize = false, Width = 460, Height = 24,
            Font     = new Font("Segoe UI", 9, FontStyle.Bold),
            ForeColor = SystemColors.ControlDarkDark,
            Margin   = new Padding(0, 8, 0, 2)
        };

        private static Panel Item(string caption, Action onOpen)
        {
            var p = new Panel { Width = 460, Height = 30, Margin = new Padding(0, 1, 0, 1) };
            var b = new Button
            {
                Text = "Открыть", Left = 0, Top = 2, Width = 90, Height = 26,
                UseVisualStyleBackColor = true, Font = UI.Body
            };
            b.Click += (s, e) => onOpen();
            var l = new Label
            {
                Text = caption, Left = 100, Top = 2, Width = 350, Height = 26,
                TextAlign = ContentAlignment.MiddleLeft, Font = UI.Body
            };
            p.Controls.Add(b); p.Controls.Add(l);
            return p;
        }
    }
}
