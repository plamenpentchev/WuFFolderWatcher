using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using WuFFolderWatcher;
using System.Threading;
using System.Diagnostics;

namespace WuFFolderWatcherTrayApp
{
    public class WuFFolderWatcherTrayApplicationContext: ApplicationContext
    {
        static System.Threading.Timer theTimer;
        private NotifyIcon notifyIcon;
        private MenuItem exitMenuItem;
        private MenuItem startConfigMenuItem;
        private Container components;
        private SERVICE_STATES servState;

        public WuFFolderWatcherTrayApplicationContext()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            theTimer = new System.Threading.Timer(tickHandler, null, 1000, 2000);
        }

        /// (summary)
		/// Shut down the timer.
		/// (/summary)
		private void OnStop()
        {
            theTimer.Change(0, Timeout.Infinite);
            theTimer.Dispose();
        }

        private void tickHandler(object state)
        {
            this.servState = WuFFolderWatcher.WuFFolderWatcher.GetServiceStatus();
            this.SetStateIcon(this.servState);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            this.startConfigMenuItem = new MenuItem("Start Configurator", new EventHandler(StartConfigurator));
            this.notifyIcon = new NotifyIcon(this.components);
            this.servState = WuFFolderWatcher.WuFFolderWatcher.GetServiceStatus();
            this.SetStateIcon(this.servState);
            this.notifyIcon.Visible = true;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
            {
                exitMenuItem,
                startConfigMenuItem
            });
        }
        
        private void SetStateIcon(SERVICE_STATES state)
        {
            if (this.servState == SERVICE_STATES.STATE_RUNNING)
            {
                this.notifyIcon.Icon = Properties.Resources.folderwatcher_trayicon_green;
            }
            else
            {
                this.notifyIcon.Icon = Properties.Resources.folderwatcher_trayicon_orange;
            }
            this.notifyIcon.Text = $"WuFFolderWatcher service: {state.GetDescription<SERVICE_STATES>() }";
        }

        private void Exit(object sender, EventArgs e)
        {
            OnStop();
            Application.Exit();
        }

        private void StartConfigurator(object sender, EventArgs e)
        {
            ExecuteCommandLineProcess(".\\WuFFolderWatcher.exe", null);
        }

        private void ExecuteCommandLineProcess(string executableFile, string argumentList)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = executableFile;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = argumentList;
            try
            {
                // Start the process with the info specified
                // Call WaitForExit and then the using-statement will close
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
