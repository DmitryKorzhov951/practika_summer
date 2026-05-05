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
            Size            = new Size(420, 260);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false; MinimizeBox = false;

            Controls.Add(new Label
            {
                Text =
                    "Информационная система\n«Прокат автомобилей»\n\n" +
                    "Вариант №17\n\n" +
                    "C# / WinForms + Microsoft SQL Server",
                Dock      = DockStyle.Fill,
                Font      = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleCenter
            });

            var ok = new Button { Text = "OK", Dock = DockStyle.Bottom, Height = 36 };
            ok.Click += (s, e) => Close();
            Controls.Add(ok);
        }
    }
}
