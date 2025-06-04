using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NoSleepAudio
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool createdNew;

            using (var mutex = new System.Threading.Mutex(true, AppInfo.AppName, out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new NoSleepPlayerForm());
                }
                else
                {
                    MessageBox.Show("Another instance of the application is already running.", "Error - " + AppInfo.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}