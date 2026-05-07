using System;
using System.Drawing;
using System.Windows.Forms;
using CarRentalApp.Forms;

namespace CarRentalApp
{
    /// <summary>Главная кнопочная форма (тёмная гоночная тема).</summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text          = "БД «Прокат автомобилей»";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(680, 640);
            MinimumSize   = new Size(540, 480);
            UI.ApplyTheme(this);

            // Заголовок
            Controls.Add(UI.MakeHeader("База данных «Прокат автомобилей»"));

            // Нижняя панель
            var bottom = UI.MakeButtonsPanel();
            bottom.Controls.Add(UI.MakeBtn("Выход",        (s,e) => Application.Exit(),                   100, UI.BtnStyle.Danger));
            bottom.Controls.Add(UI.MakeBtn("О программе",  (s,e) => new AboutForm().ShowDialog(this),     130));
            bottom.Controls.Add(UI.MakeBtn("Гистограмма",  (s,e) => new HistogramForm().ShowDialog(this), 140, UI.BtnStyle.Primary));
            Controls.Add(bottom);

            // Кастомные тёмные вкладки
            var tabs = new TabControl
            {
                Dock          = DockStyle.Fill,
                Font          = UI.BodyBold,
                Appearance    = TabAppearance.Normal,
                SizeMode      = TabSizeMode.Fixed,
                ItemSize      = new Size(160, 32),
                DrawMode      = TabDrawMode.OwnerDrawFixed,
                Padding       = new Point(0, 0)
            };
            tabs.DrawItem += (s, e) =>
            {
                var tc = (TabControl)s;
                var page = tc.TabPages[e.Index];
                bool sel = e.State == DrawItemState.Selected || tc.SelectedIndex == e.Index;

                Color bg = sel ? UI.Surface : Color.FromArgb(22, 22, 26);
                Color fg = sel ? UI.Primary : UI.TextDim;
                using var bgBr = new SolidBrush(bg);
                e.Graphics.FillRectangle(bgBr, e.Bounds);

                if (sel)
                {
                    using var red = new SolidBrush(UI.Primary);
                    e.Graphics.FillRectangle(red, e.Bounds.Left, e.Bounds.Bottom - 3, e.Bounds.Width, 3);
                }

                TextRenderer.DrawText(e.Graphics, page.Text, UI.BodyBold,
                    e.Bounds, fg,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            tabs.TabPages.Add(BuildTab("ФОРМЫ",   BuildFormsContent));
            tabs.TabPages.Add(BuildTab("ОТЧЁТЫ",  BuildReportsContent));
            Controls.Add(tabs);
        }

        private TabPage BuildTab(string title, Action<FlowLayoutPanel> fill)
        {
            var tab = new TabPage(title) { BackColor = UI.Surface };
            var list = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
                AutoScroll = true, WrapContents = false,
                Padding = new Padding(16), BackColor = UI.Surface
            };
            fill(list);
            tab.Controls.Add(list);
            return tab;
        }

        private void BuildFormsContent(FlowLayoutPanel list)
        {
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
        }

        private void BuildReportsContent(FlowLayoutPanel list)
        {
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
        }

        // --- helpers ---
        private static Label Group(string text)
        {
            var l = new Label
            {
                Text     = "▌ " + text,
                AutoSize = false, Width = 580, Height = 28,
                Font     = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                ForeColor = UI.Primary,
                Margin   = new Padding(0, 12, 0, 6),
                TextAlign = ContentAlignment.MiddleLeft
            };
            return l;
        }

        private static Panel Item(string caption, Action onOpen)
        {
            var p = new Panel
            {
                Width = 580, Height = 42,
                Margin = new Padding(0, 2, 0, 2),
                BackColor = UI.SurfaceAlt
            };
            p.Paint += (s, e) =>
            {
                using var border = new Pen(UI.Border);
                e.Graphics.DrawRectangle(border, 0, 0, p.Width - 1, p.Height - 1);
                using var red = new SolidBrush(UI.Primary);
                e.Graphics.FillRectangle(red, 0, 0, 4, p.Height);
            };
            p.MouseEnter += (s, e) => p.BackColor = UI.SurfaceHi;
            p.MouseLeave += (s, e) => p.BackColor = UI.SurfaceAlt;

            var b = UI.MakeBtn("Открыть", (s, e) => onOpen(), 100, UI.BtnStyle.Primary);
            b.Left = 12; b.Top = 5;
            var l = new Label
            {
                Text = caption, Left = 124, Top = 0, Width = 444, Height = 42,
                TextAlign = ContentAlignment.MiddleLeft, Font = UI.BodyBold,
                ForeColor = UI.Text, BackColor = Color.Transparent
            };
            l.MouseEnter += (s, e) => p.BackColor = UI.SurfaceHi;
            p.Controls.Add(b); p.Controls.Add(l);
            return p;
        }
    }
}
