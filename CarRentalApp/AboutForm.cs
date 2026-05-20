using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            Text            = "О программе";
            StartPosition   = FormStartPosition.CenterParent;
            Size            = new Size(460, 320);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            UI.ApplyTheme(this);

            Controls.Add(UI.MakeHeader("О программе"));

            var content = new Panel { Dock = DockStyle.Fill, BackColor = UI.Bg, Padding = new Padding(20) };

            var title = new Label
            {
                Text      = "ПРОКАТ АВТОМОБИЛЕЙ",
                Dock      = DockStyle.Top, Height = 36,
                Font      = new Font("Segoe UI Black", 14, FontStyle.Bold),
                ForeColor = UI.Primary,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var sub = new Label
            {
                Text      = "Вариант №17  ·  C# / WinForms + SQL Server",
                Dock      = DockStyle.Top, Height = 24,
                Font      = UI.Body, ForeColor = UI.TextDim
            };
            var body = new Label
            {
                Text      = "\nИнформационная система для учёта проката автомобилей.",
                Dock      = DockStyle.Top, Height = 50,
                Font      = new Font("Segoe UI", 10),
                ForeColor = UI.Text
            };
            var author = new Label
            {
                Text      = "Работу выполнил студент группы ВИС-22\nКоржов Дмитрий",
                Dock      = DockStyle.Top, Height = 56,
                Font      = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                ForeColor = UI.Accent
            };
            content.Controls.Add(author);
            content.Controls.Add(body);
            content.Controls.Add(sub);
            content.Controls.Add(title);
            Controls.Add(content);

            var bottom = UI.MakeButtonsPanel();
            var ok = UI.MakeBtn("OK", (s, e) => Close(), 90, UI.BtnStyle.Primary);
            bottom.Controls.Add(ok);
            Controls.Add(bottom);
            AcceptButton = ok;
        }
    }
}
