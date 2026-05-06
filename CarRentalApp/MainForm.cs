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
            Size          = new Size(620, 600);
            MinimumSize   = new Size(500, 460);
            Font          = UI.Body;
            BackColor     = UI.Surface;

            // Заголовок
            Controls.Add(UI.MakeHeader("База данных «Прокат автомобилей»"));

            // Нижняя панель: Выход / О программе / Гистограмма
            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Выход",        (s,e) => Application.Exit(),                   100, UI.BtnStyle.Danger));
            bottom.Controls.Add(UI.MakeBtn("О программе",  (s,e) => new AboutForm().ShowDialog(this),     120));
            bottom.Controls.Add(UI.MakeBtn("Гистограмма",  (s,e) => new HistogramForm().ShowDialog(this), 130, UI.BtnStyle.Accent));
            Controls.Add(bottom);

            // Вкладки
            var tabs = new TabControl
            {
                Dock      = DockStyle.Fill,
                Font      = UI.BodyBold,
                Padding   = new Point(14, 6)
            };
            tabs.TabPages.Add(BuildFormsTab());
            tabs.TabPages.Add(BuildReportsTab());
            Controls.Add(tabs);
        }

        private TabPage BuildFormsTab()
        {
            var tab = new TabPage("  Формы  ") { BackColor = UI.Surface };
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                Padding = new Padding(12), BackColor = UI.Surface
            };

            list.Controls.Add(Group("ТАБЛИЦЫ"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiForm().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiForm().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiForm().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiForm().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliForm().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyForm().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatForm().Show()));

            list.Controls.Add(Group("ЗАПРОСЫ"));
            list.Controls.Add(Item("Отдел кадров",         () => new OtdelKadrovForm().Show()));
            list.Controls.Add(Item("Автопарк",             () => new AvtoparkForm().Show()));
            list.Controls.Add(Item("Автомобили в прокате", () => new AvtoVProkateForm().Show()));

            list.Controls.Add(Group("ФИЛЬТРЫ"));
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
            var tab = new TabPage("  Отчёты  ") { BackColor = UI.Surface };
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                Padding = new Padding(12), BackColor = UI.Surface
            };

            list.Controls.Add(Group("ПО ТАБЛИЦАМ"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiReport().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiReport().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiReport().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiReport().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliReport().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyReport().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatReport().Show()));

            list.Controls.Add(Group("ПО ЗАПРОСАМ"));
            list.Controls.Add(Item("Отдел кадров",         () => new OtdelKadrovReport().Show()));
            list.Controls.Add(Item("Автопарк",             () => new AvtoparkReport().Show()));
            list.Controls.Add(Item("Автомобили в прокате", () => new AvtoVProkateReport().Show()));

            list.Controls.Add(Group("ПО ФИЛЬТРАМ"));
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
            AutoSize = false, Width = 540, Height = 24,
            Font     = new Font("Segoe UI Semibold", 9, FontStyle.Bold),
            ForeColor = UI.PrimaryLt,
            Margin   = new Padding(2, 10, 0, 4)
        };

        private static Panel Item(string caption, Action onOpen)
        {
            var p = new Panel
            {
                Width = 540, Height = 38,
                Margin = new Padding(0, 1, 0, 1),
                BackColor = Color.White
            };
            // тонкая нижняя разделительная линия
            p.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            };

            var b = UI.MakeBtn("Открыть", (s, e) => onOpen(), 100, UI.BtnStyle.Primary);
            b.Left = 8; b.Top = 4;
            var l = new Label
            {
                Text = caption, Left = 116, Top = 0, Width = 410, Height = 38,
                TextAlign = ContentAlignment.MiddleLeft, Font = UI.Body,
                ForeColor = Color.FromArgb(45, 55, 72)
            };
            p.Controls.Add(b); p.Controls.Add(l);
            return p;
        }
    }
}
