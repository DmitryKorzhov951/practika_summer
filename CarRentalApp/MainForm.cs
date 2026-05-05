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
            Size          = new Size(900, 700);
            MinimumSize   = new Size(800, 600);

            // Заголовок
            Controls.Add(new Label
            {
                Text      = "База данных «Прокат автомобилей»",
                Dock      = DockStyle.Top, Height = 60,
                Font      = new Font("Segoe UI", 18, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Нижняя панель: Выход / О программе / Гистограмма
            var bottom = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.Gainsboro };
            bottom.Controls.Add(BotBtn("Выход",        10,  Color.IndianRed,      (s,e)=>Application.Exit()));
            bottom.Controls.Add(BotBtn("О программе",  170, Color.SteelBlue,      (s,e)=>new AboutForm().ShowDialog(this)));
            bottom.Controls.Add(BotBtn("Гистограмма",  330, Color.MediumSeaGreen, (s,e)=>new HistogramForm().ShowDialog(this)));
            Controls.Add(bottom);

            // Вкладки
            var tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11) };
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
                AutoScroll = true, WrapContents = false, Padding = new Padding(12)
            };

            list.Controls.Add(Header("Таблицы"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiForm().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiForm().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiForm().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiForm().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliForm().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyForm().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatForm().Show()));

            list.Controls.Add(Header("Запросы"));
            list.Controls.Add(Item("Отдел кадров",          () => new OtdelKadrovForm().Show()));
            list.Controls.Add(Item("Автопарк",              () => new AvtoparkForm().Show()));
            list.Controls.Add(Item("Автомобили в прокате",  () => new AvtoVProkateForm().Show()));

            list.Controls.Add(Header("Фильтры"));
            list.Controls.Add(Item("Сотрудники по должности",            () => new FilterByDolzhnost().Show()));
            list.Controls.Add(Item("Автомобили по марке",                () => new FilterByMarka().Show()));
            list.Controls.Add(Item("В прокате / свободные",              () => new FilterByVozvrachen().Show()));
            list.Controls.Add(Item("Прокат по дате",                     () => new FilterByDate().Show()));
            list.Controls.Add(Item("Оплачено / не оплачено",             () => new FilterByOplata().Show()));

            tab.Controls.Add(list);
            return tab;
        }

        private TabPage BuildReportsTab()
        {
            var tab = new TabPage("Отчёты");
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, Padding = new Padding(12)
            };

            list.Controls.Add(Header("Отчёты по таблицам"));
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiReport().Show()));
            list.Controls.Add(Item("Должности",             () => new DolzhnostiReport().Show()));
            list.Controls.Add(Item("Марки автомобилей",     () => new MarkiReport().Show()));
            list.Controls.Add(Item("Дополнительные услуги", () => new UslugiReport().Show()));
            list.Controls.Add(Item("Автомобили",            () => new AvtomobiliReport().Show()));
            list.Controls.Add(Item("Клиенты",               () => new KlientyReport().Show()));
            list.Controls.Add(Item("Прокат",                () => new ProkatReport().Show()));

            list.Controls.Add(Header("Отчёты по запросам"));
            list.Controls.Add(Item("Отдел кадров",          () => new OtdelKadrovReport().Show()));
            list.Controls.Add(Item("Автопарк",              () => new AvtoparkReport().Show()));
            list.Controls.Add(Item("Автомобили в прокате",  () => new AvtoVProkateReport().Show()));

            list.Controls.Add(Header("Отчёты по фильтрам"));
            list.Controls.Add(Item("Сотрудники по должности",            () => new ReportFormParam("Сотрудники по должности (все)", OtdelKadrovForm.Sql, null).Show()));
            list.Controls.Add(Item("Автомобили по марке",                () => new ReportFormParam("Автомобили по марке (все)",     AvtoparkForm.Sql,     null).Show()));
            list.Controls.Add(Item("В прокате / свободные",              () => new ReportFormParam("В прокате / свободные (все)",   AvtoparkForm.Sql,     null).Show()));
            list.Controls.Add(Item("Прокат по дате",                     () => new ReportFormParam("Прокат по дате (все)",          AvtoVProkateForm.Sql, null).Show()));
            list.Controls.Add(Item("Оплачено / не оплачено",             () => new ReportFormParam("Оплачено / не оплачено (все)",  AvtoVProkateForm.Sql, null).Show()));

            tab.Controls.Add(list);
            return tab;
        }

        private static Button BotBtn(string text, int x, Color color, EventHandler onClick)
        {
            var b = new Button
            {
                Text = text, Left = x, Top = 10, Width = 150, Height = 36,
                BackColor = color, ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            b.Click += onClick;
            return b;
        }

        private static Label Header(string text) => new()
        {
            Text = text, AutoSize = false, Width = 700, Height = 32,
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.SteelBlue, Margin = new Padding(0, 10, 0, 4)
        };

        private static Panel Item(string caption, Action onOpen)
        {
            var p = new Panel { Width = 700, Height = 38, Margin = new Padding(0, 2, 0, 2) };
            var b = new Button
            {
                Text = "Открыть", Left = 0, Top = 4, Width = 110, Height = 30,
                BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            b.Click += (s, e) => onOpen();
            var l = new Label
            {
                Text = caption, Left = 120, Top = 4, Width = 560, Height = 30,
                Font = new Font("Segoe UI", 11), TextAlign = ContentAlignment.MiddleLeft
            };
            p.Controls.Add(b); p.Controls.Add(l);
            return p;
        }
    }
}
