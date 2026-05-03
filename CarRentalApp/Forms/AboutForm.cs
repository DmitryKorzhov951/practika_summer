using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Forms
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            Text            = "О программе";
            StartPosition   = FormStartPosition.CenterParent;
            Size            = new Size(520, 360);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;

            var lblTitle = new Label
            {
                Text      = "Информационная система\n«Прокат автомобилей»",
                Font      = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize  = false,
                Dock      = DockStyle.Top,
                Height    = 80,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(30, 60, 120)
            };

            var lblInfo = new Label
            {
                Text =
                    "Вариант №17\n\n" +
                    "Учебный проект по дисциплине\n" +
                    "«Базы данных и информационные системы»\n\n" +
                    "Среда разработки: Microsoft Visual Studio (C#, WinForms)\n" +
                    "СУБД: Microsoft SQL Server\n\n" +
                    "Версия: 1.0",
                Font      = new Font("Segoe UI", 11),
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnOk = new Button
            {
                Text   = "OK",
                Dock   = DockStyle.Bottom,
                Height = 40,
                Font   = new Font("Segoe UI", 11)
            };
            btnOk.Click += (s, e) => Close();

            Controls.Add(lblInfo);
            Controls.Add(lblTitle);
            Controls.Add(btnOk);
            AcceptButton = btnOk;
        }
    }
}
