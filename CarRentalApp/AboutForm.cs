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
            Size            = new Size(360, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false; MinimizeBox = false;

            Controls.Add(new Label
            {
                Text =
                    "Прокат автомобилей\n\n" +
                    "C# / WinForms + SQL Server\n" +
                    "Учебный проект",
                Dock      = DockStyle.Fill,
                Font      = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleCenter
            });

            var ok = new Button { Text = "OK", Dock = DockStyle.Bottom, Height = 32 };
            ok.Click += (s, e) => Close();
            Controls.Add(ok);
        }
    }
}
