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
            Size          = new Size(900, 640);
            MinimumSize   = new Size(800, 600);

            // ---- Заголовок (вверху) ----
            Controls.Add(new Label
            {
                Text      = "База данных «Прокат автомобилей»",
                Dock      = DockStyle.Top, Height = 60,
                Font      = new Font("Segoe UI", 18, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // ---- Нижняя панель: Выход / О программе / Гистограмма ----
            var bottom = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.Gainsboro };
            bottom.Controls.Add(BotBtn("Выход",        10,  Color.IndianRed,      (s,e)=>Application.Exit()));
            bottom.Controls.Add(BotBtn("О программе",  170, Color.SteelBlue,      (s,e)=>new AboutForm().ShowDialog(this)));
            bottom.Controls.Add(BotBtn("Гистограмма",  330, Color.MediumSeaGreen, (s,e)=>MessageBox.Show("Гистограмма — будет на след. шаге.")));
            Controls.Add(bottom);

            // ---- Вкладки "Формы" / "Отчёты" ----
            var tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11) };
            tabs.TabPages.Add(BuildFormsTab());
            tabs.TabPages.Add(BuildReportsTab());
            Controls.Add(tabs);
        }

        // ===================== Вкладка "Формы" =====================
        private TabPage BuildFormsTab()
        {
            var tab = new TabPage("Формы");
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false, Padding = new Padding(12)
            };

            list.Controls.Add(Header("Таблицы"));
            // Сделано:
            list.Controls.Add(Item("Сотрудники",            () => new SotrudnikiForm().Show()));
            // Заглушки на остальное (будут добавлены поэтапно):
            list.Controls.Add(Item("Должности",             null));
            list.Controls.Add(Item("Марки автомобилей",     null));
            list.Controls.Add(Item("Дополнительные услуги", null));
            list.Controls.Add(Item("Автомобили",            null));
            list.Controls.Add(Item("Клиенты",               null));
            list.Controls.Add(Item("Прокат",                null));

            list.Controls.Add(Header("Запросы"));
            list.Controls.Add(Item("Отдел кадров",          null));
            list.Controls.Add(Item("Автопарк",              null));
            list.Controls.Add(Item("Автомобили в прокате",  null));

            list.Controls.Add(Header("Фильтры"));
            list.Controls.Add(Item("Сотрудники по должности",            null));
            list.Controls.Add(Item("Автомобили по марке",                null));
            list.Controls.Add(Item("В прокате / свободные",              null));
            list.Controls.Add(Item("Прокат по дате",                     null));
            list.Controls.Add(Item("Оплачено / не оплачено",             null));

            tab.Controls.Add(list);
            return tab;
        }

        // ===================== Вкладка "Отчёты" =====================
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
            list.Controls.Add(Item("Должности",             null));
            list.Controls.Add(Item("Марки автомобилей",     null));
            list.Controls.Add(Item("Дополнительные услуги", null));
            list.Controls.Add(Item("Автомобили",            null));
            list.Controls.Add(Item("Клиенты",               null));
            list.Controls.Add(Item("Прокат",                null));

            list.Controls.Add(Header("Отчёты по запросам"));
            list.Controls.Add(Item("Отдел кадров",          null));
            list.Controls.Add(Item("Автопарк",              null));
            list.Controls.Add(Item("Автомобили в прокате",  null));

            list.Controls.Add(Header("Отчёты по фильтрам"));
            list.Controls.Add(Item("Сотрудники по должности",            null));
            list.Controls.Add(Item("Автомобили по марке",                null));
            list.Controls.Add(Item("В прокате / свободные",              null));
            list.Controls.Add(Item("Прокат по дате",                     null));
            list.Controls.Add(Item("Оплачено / не оплачено",             null));

            tab.Controls.Add(list);
            return tab;
        }

        // ===================== Helpers =====================
        private static Button BotBtn(string text, int x, Color color, EventHandler onClick)
        {
            var b = new Button
            {
                Text = text, Left = x, Top = 10, Width = 150, Height = 36,
                BackColor = color, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
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
                BackColor = onOpen != null ? Color.SteelBlue : Color.Silver,
                ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Enabled = onOpen != null
            };
            if (onOpen != null) b.Click += (s, e) => onOpen();
            var l = new Label
            {
                Text = caption, Left = 120, Top = 4, Width = 560, Height = 30,
                Font = new Font("Segoe UI", 11), TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = onOpen != null ? Color.Black : Color.Gray
            };
            p.Controls.Add(b); p.Controls.Add(l);
            return p;
        }
    }
}
