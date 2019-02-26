using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WuFFolderWatcherTrayApp
{
    static class Program
    {
        private static Mutex m_Mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            bool createdNew;
            m_Mutex = new Mutex(true, "WuFFolderWatcherTrayApp", out createdNew);
            if (createdNew)
                Application.Run(new WuFFolderWatcherTrayApplicationContext());
            else
                MessageBox.Show("The application is already running.", Application.ProductName,
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
        }
    }
}
