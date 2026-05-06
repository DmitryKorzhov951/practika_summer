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
            Size            = new Size(440, 280);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            BackColor       = UI.Surface;
            Font            = UI.Body;

            Controls.Add(UI.MakeHeader("О программе"));

            var content = new Panel { Dock = DockStyle.Fill, BackColor = UI.Surface, Padding = new Padding(16) };
            content.Controls.Add(new Label
            {
                Text      = "Прокат автомобилей",
                Dock      = DockStyle.Top, Height = 36,
                Font      = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
                ForeColor = UI.Primary,
                TextAlign = ContentAlignment.MiddleLeft
            });
            content.Controls.Add(new Label
            {
                Text      = "Вариант №17  ·  C# / WinForms + SQL Server",
                Dock      = DockStyle.Top, Height = 24,
                Font      = new Font("Segoe UI", 9),
                ForeColor = UI.TextDim
            });
            content.Controls.Add(new Label
            {
                Text      = "\nУчебный курсовой проект.\nИнформационная система для учёта проката автомобилей.",
                Dock      = DockStyle.Top, Height = 80,
                Font      = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(45, 55, 72)
            });
            // children докаются в обратном порядке — переставим
            content.Controls.SetChildIndex(content.Controls[0], 2);
            Controls.Add(content);

            var bottom = UI.MakeButtonsPanel();
            var ok = UI.MakeBtn("OK", (s, e) => Close(), 90, UI.BtnStyle.Primary);
            bottom.Controls.Add(ok);
            Controls.Add(bottom);
            AcceptButton = ok;
        }
    }
}
