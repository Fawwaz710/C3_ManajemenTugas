using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3_ManajemenTugas
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // UBAH BARIS INI: 
            // Dari DosenDashboardForm() menjadi LoginForm()
            Application.Run(new LoginForm());
        }
    }
}