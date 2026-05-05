using System;
using System.Windows.Forms;

namespace CarRentalApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Гарантируем, что БД создана и доступна под текущей Windows-учёткой
            try
            {
                DbInit.EnsureDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось инициализировать БД:\n\n" + ex.Message +
                    "\n\nПроверьте, что установлен SQL Server LocalDB.",
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Стартовая - "Заставка"
            new SplashForm().ShowDialog();
            Application.Run(new MainForm());
        }
    }
}
