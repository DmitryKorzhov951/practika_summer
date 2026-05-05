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

            // Стартовая - "Заставка"
            new SplashForm().ShowDialog();
            Application.Run(new MainForm());
        }
    }
}
