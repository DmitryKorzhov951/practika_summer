using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Просмотр прокатов с именами клиентов и марками авто (запрос vw_Prokat).</summary>
    public class ProkatViewForm : Form
    {
        public ProkatViewForm()
        {
            Text          = "Список прокатов";
            StartPosition = FormStartPosition.CenterScreen;
            Size          = new Size(800, 500);

            Controls.Add(new Label
            {
                Text      = "Список прокатов (с именами клиентов и марками)",
                Dock      = DockStyle.Top, Height = 36,
                Font      = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            });

            Controls.Add(new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = Db.Load("SELECT * FROM vw_Prokat ORDER BY DataVydachi DESC")
            });

            var btn = new Button { Text = "Закрыть", Dock = DockStyle.Bottom, Height = 36 };
            btn.Click += (s, e) => Close();
            Controls.Add(btn);
        }
    }
}
