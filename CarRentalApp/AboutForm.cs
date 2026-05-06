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
            Size            = new Size(380, 220);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;

            Controls.Add(new Label
            {
                Text      = "Прокат автомобилей\n\n" +
                            "Вариант №17\n\n" +
                            "C# / WinForms + SQL Server",
                Dock      = DockStyle.Fill,
                Font      = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleCenter
            });

            var ok = UI.MakeBtn("OK", (s, e) => Close(), 90);
            ok.Dock = DockStyle.Bottom;
            ok.Height = 30;
            Controls.Add(ok);
            AcceptButton = ok;
        }
    }
}
