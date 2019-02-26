using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Serilog;
using System.Configuration;
using System.Windows.Forms;

namespace WuFFolderWatcher
{
    static class Program
    {
         //static System.Threading.Timer theTimer;
         static bool serviceWasRunning = false;
         static ConfigForm configForm;
         private static Mutex m_Mutex;

        //[STAThread]
        //static void Main()
        //{
        //    Main(new string[] { });
        //}

        /// (summary)
        /// The main entry point for the application.
        /// STAThread for the benefit of the GUI; service will ignore it.
        /// (/summary)
        [STAThread]
        static void Main(string[] args)
        {
            //... create logger
            if (ConfigurationManager.AppSettings["logErrorsOnly"] == "True")
            {
                Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(ConfigurationManager.AppSettings["logfile"],
                                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                                    retainedFileCountLimit: 10)
                .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(ConfigurationManager.AppSettings["logfile"],
                                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
                                    retainedFileCountLimit: 10)
                .CreateLogger();
            }
            



            
            if (Environment.UserInteractive)
            {
                bool createdNew;
                m_Mutex = new Mutex(true, "WuFFolderWatcher", out createdNew);
                if (createdNew)
                {
                    Program.DisableServiceIfRunning();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //... create configuration form
                    configForm = new ConfigForm();
                    Application.Run(configForm);
                    Program.EnableServiceIfWasRunning();
                }   
                else
                {
                    MessageBox.Show("The application is already running.", Application.ProductName,
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                
            }
            else
            {
                //... windows service mode
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new WuFFolderWatcher()
                };
                ServiceBase.Run(ServicesToRun);
            }
            
        }

        private static void DisableServiceIfRunning()
        {
            try
            {
                Log.Information($"Will try to stop { WuFFolderWatcher.SrvcName }. Interactive [{Environment.UserInteractive}]");
                ServiceController sc = new ServiceController(WuFFolderWatcher.SrvcName);
                if (null != sc && sc.Status == ServiceControllerStatus.Running)
                {
                     
                    sc.Stop();
                    serviceWasRunning = true;
                    Thread.Sleep(1000); // wait for service to stop
                }

            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"Exception in {nameof(DisableServiceIfRunning)}");
            }
        }

        private static void EnableServiceIfWasRunning()
        {
            if (serviceWasRunning)
            {
                serviceWasRunning = false;
                try
                {
                    ServiceController sc = new ServiceController(WuFFolderWatcher.SrvcName);
                    sc.Start();
                }
                catch (Exception ex)
                {

                    Log.Fatal(ex, $"Exception in {nameof(EnableServiceIfWasRunning)}");
                }
            }
        }

        

        /// (summary)
		/// This method receives control when either the service or the GUI starts.
		/// (/summary)
		/// (param name="args")(/param)
        static internal void OnStart(string[] args)
        {
            //theTimer = new System.Threading.Timer(tickHandler, null, 1000, 2000);
        }

        /// (summary)
		/// Shut down the timer.
		/// (/summary)
		static internal void OnStop()
        {
            //theTimer.Change(0, Timeout.Infinite);
            //theTimer.Dispose();
        }

        static private void tickHandler(object state)
        {
            //if (!Environment.UserInteractive)
            //{
                //Log.Information("Windows Service: tick handler invoked.");
                //Log.Information($"Log file :  { ConfigurationManager.AppSettings["logfile"] }");
                //Log.Information($"FoldersToWatch :  { ConfigurationManager.AppSettings["WatchedFoldersSettings"]}");

                //MethodInvoker action = () =>
                //{
                //    configForm.lblServiceStatus.Text = "Running";
                //    configForm.listBox1.Items.Add("Intearctive mode: tick handler invoked.");
                //    configForm.listBox1.TopIndex = configForm.listBox1.Items.Count - 1;
                //};
                //configForm.BeginInvoke(action);
                //Log.Information("Intearctive mode: tick handler invoked.");
            //}
        }
    }
}
