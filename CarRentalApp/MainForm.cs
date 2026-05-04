using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Главная форма с кнопками.</summary>
    public class MainForm : Form
    {
        public MainForm()
        {
            Text          = "Прокат автомобилей";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(420, 360);

            Controls.Add(new Label
            {
                Text      = "Прокат автомобилей",
                Dock      = DockStyle.Top, Height = 60,
                Font      = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, Padding = new Padding(20),
                FlowDirection = FlowDirection.TopDown, WrapContents = false
            };

            panel.Controls.Add(Btn("Клиенты",       () => new TableForm("Klienty",    "Клиенты").Show()));
            panel.Controls.Add(Btn("Автомобили",    () => new TableForm("Avtomobili", "Автомобили").Show()));
            panel.Controls.Add(Btn("Прокат",        () => new TableForm("Prokat",     "Прокат").Show()));
            panel.Controls.Add(Btn("Список прокатов (запрос)", () => new ProkatViewForm().Show()));
            panel.Controls.Add(Btn("О программе",   () => new AboutForm().ShowDialog(this)));
            panel.Controls.Add(Btn("Выход",         () => Application.Exit()));

            Controls.Add(panel);
        }

        private static Button Btn(string text, System.Action onClick)
        {
            var b = new Button
            {
                Text = text, Width = 340, Height = 36,
                Font = new Font("Segoe UI", 10), Margin = new Padding(0, 4, 0, 4)
            };
            b.Click += (s, e) => onClick();
            return b;
        }
    }
}
