using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CarRentalApp.Forms;

namespace CarRentalApp
{
    /// <summary>Главная форма в стиле Netflix: hero-баннер + ряды каруселей карточек.</summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text          = "БД «Прокат автомобилей»";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(1060, 720);
            MinimumSize   = new Size(820, 560);
            UI.ApplyTheme(this);

            // ---- Нижняя панель ----
            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Выход",       (s,e) => Application.Exit(),                   100, UI.BtnStyle.Danger));
            bottom.Controls.Add(UI.MakeBtn("О программе", (s,e) => new AboutForm().ShowDialog(this),     130));
            bottom.Controls.Add(UI.MakeBtn("Гистограмма", (s,e) => new HistogramForm().ShowDialog(this), 140, UI.BtnStyle.Primary));
            Controls.Add(bottom);

            // ---- Прокручиваемая лента контента ----
            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = UI.Bg
            };
            var content = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                BackColor = UI.Bg,
                Padding = new Padding(0, 0, 0, 20)
            };
            scroll.Controls.Add(content);
            Controls.Add(scroll);

            // ---- Hero-баннер ----
            content.Controls.Add(BuildHero());

            // ---- Ряды каруселей ----
            content.Controls.Add(BuildRow("ТАБЛИЦЫ", new (string, string, Action)[]
            {
                ("Сотрудники",            "sotrudniki", () => new SotrudnikiForm().Show()),
                ("Должности",             "dolzhnosti", () => new DolzhnostiForm().Show()),
                ("Марки автомобилей",     "marki",      () => new MarkiForm().Show()),
                ("Дополнительные услуги", "uslugi",     () => new UslugiForm().Show()),
                ("Автомобили",            "avtomobili", () => new AvtomobiliForm().Show()),
                ("Клиенты",               "klienty",    () => new KlientyForm().Show()),
                ("Прокат",                "prokat",     () => new ProkatForm().Show()),
            }));

            content.Controls.Add(BuildRow("ЗАПРОСЫ", new (string, string, Action)[]
            {
                ("Отдел кадров",         "q_kadrov",   () => new OtdelKadrovForm().Show()),
                ("Автопарк",             "q_avtopark", () => new AvtoparkForm().Show()),
                ("Автомобили в прокате", "q_vprokate", () => new AvtoVProkateForm().Show()),
            }));

            content.Controls.Add(BuildRow("ФИЛЬТРЫ", new (string, string, Action)[]
            {
                ("Сотрудники по должности", "f_dolzh",   () => new FilterByDolzhnost().Show()),
                ("Автомобили по марке",     "f_marka",   () => new FilterByMarka().Show()),
                ("В прокате / свободные",   "f_vozvrat", () => new FilterByVozvrachen().Show()),
                ("Прокат по дате",          "f_data",    () => new FilterByDate().Show()),
                ("Оплачено / не оплачено",  "f_oplata",  () => new FilterByOplata().Show()),
            }));

            // ---- Ряд отчётов ----
            content.Controls.Add(BuildRow("ОТЧЁТЫ", new (string, string, Action)[]
            {
                ("Сотрудники",            "sotrudniki", () => new SotrudnikiReport().Show()),
                ("Должности",             "dolzhnosti", () => new DolzhnostiReport().Show()),
                ("Марки автомобилей",     "marki",      () => new MarkiReport().Show()),
                ("Дополнительные услуги", "uslugi",     () => new UslugiReport().Show()),
                ("Автомобили",            "avtomobili", () => new AvtomobiliReport().Show()),
                ("Клиенты",               "klienty",    () => new KlientyReport().Show()),
                ("Прокат",                "prokat",     () => new ProkatReport().Show()),
                ("Отдел кадров",          "q_kadrov",   () => new OtdelKadrovReport().Show()),
                ("Автопарк",              "q_avtopark", () => new AvtoparkReport().Show()),
                ("Автомобили в прокате",  "q_vprokate", () => new AvtoVProkateReport().Show()),
            }));

            // содержимое и ряды подгоняем по ширине окна
            void Resize()
            {
                int w = scroll.ClientSize.Width;
                content.Width = w;
                foreach (Control row in content.Controls)
                    row.Width = w;
            }
            scroll.Resize += (s, e) => Resize();
            Resize();
        }

        // ============ Hero-баннер ============
        private Panel BuildHero()
        {
            var hero = new Panel { Height = 180, Width = 1000 };
            hero.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var bg = new LinearGradientBrush(hero.ClientRectangle,
                        Color.FromArgb(80, 16, 22), Color.FromArgb(14, 14, 17),
                        LinearGradientMode.Horizontal))
                    g.FillRectangle(bg, hero.ClientRectangle);
                // диагональные скоростные линии
                using var line = new Pen(Color.FromArgb(22, 255, 255, 255), 8);
                for (int x = -200; x < hero.Width; x += 70)
                    g.DrawLine(line, x, 0, x + hero.Height, hero.Height);
                // нижняя красная полоса
                using var red = new SolidBrush(UI.Primary);
                g.FillRectangle(red, 0, hero.Height - 4, hero.Width, 4);
            };

            var sub = new Label
            {
                Text = "ИНФОРМАЦИОННАЯ СИСТЕМА  ·  ВАРИАНТ №17",
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                ForeColor = UI.Primary, BackColor = Color.Transparent,
                AutoSize = true, Location = new Point(40, 44)
            };
            var title = new Label
            {
                Text = "ПРОКАТ АВТОМОБИЛЕЙ",
                Font = new Font("Segoe UI Black", 30, FontStyle.Bold),
                ForeColor = Color.White, BackColor = Color.Transparent,
                AutoSize = true, Location = new Point(38, 70)
            };
            var hint = new Label
            {
                Text = "Выберите раздел — таблицы, запросы, фильтры или отчёты",
                Font = new Font("Segoe UI", 10),
                ForeColor = UI.TextDim, BackColor = Color.Transparent,
                AutoSize = true, Location = new Point(40, 130)
            };
            hero.Controls.Add(sub);
            hero.Controls.Add(title);
            hero.Controls.Add(hint);
            return hero;
        }

        // ============ Ряд-карусель ============
        private Panel BuildRow(string title, (string caption, string poster, Action open)[] items)
        {
            var row = new Panel { Height = 200, Width = 1000, BackColor = UI.Bg };

            var lbl = new Label
            {
                Text = "▌ " + title,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = UI.Primary,
                AutoSize = false, Height = 30,
                Dock = DockStyle.Top,
                Padding = new Padding(36, 4, 0, 0),
                BackColor = UI.Bg
            };

            var strip = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(36, 6, 36, 6),
                BackColor = UI.Bg
            };

            foreach (var (caption, poster, open) in items)
            {
                var card = new PosterCard(poster, open);
                var tip = new ToolTip();
                tip.SetToolTip(card, caption);
                strip.Controls.Add(card);
            }

            row.Controls.Add(strip);
            row.Controls.Add(lbl);
            return row;
        }
    }
}
