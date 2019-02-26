using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Serilog;
using System.Reactive.Linq;
using System.Reactive;
using System.Text.RegularExpressions;

namespace WuFFolderWatcher
{
    public partial class WuFFolderWatcher : ServiceBase
    {
        private List<FileSystemWatcher> listFileSystemWatcher;
        private List<WatchedFolderSettings> listFolders;
        private DateTime lastWrite = DateTime.MinValue;
        private string filters = "";
        public WuFFolderWatcher()
        {
            InitializeComponent();
        }
        public static string SrvcName { get { return typeof(WuFFolderWatcher).Assembly.GetName().Name; } }

        public static bool StartService()
        {
            try
            {
                ServiceController sc = new ServiceController(WuFFolderWatcher.SrvcName);
                sc.Start();
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Exception in {nameof(StartService)}");
                return false;
            }
        }

        public static SERVICE_STATES GetServiceStatus()
        {
            try
            {
                ServiceController sc = new ServiceController(WuFFolderWatcher.SrvcName);
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return SERVICE_STATES.STATE_RUNNING;
                    case ServiceControllerStatus.Stopped:
                        return SERVICE_STATES.STATE_STOPPED;
                    case ServiceControllerStatus.Paused:
                        return SERVICE_STATES.STATE_PAUSED;
                    case ServiceControllerStatus.StopPending:
                        return SERVICE_STATES.STATE_STOPPING;
                    case ServiceControllerStatus.StartPending:
                        return SERVICE_STATES.STATE_STARTING;
                    default:
                        return SERVICE_STATES.STATE_CHANGING;
                }
            }
            catch (Exception )
            {
                return SERVICE_STATES.STATE_NOT_INSTALLED;
            }

        }

        /// <summary>Event automatically fired when the service is started by Windows</summary>
        /// <param name="args">array of arguments</param>
        protected override void OnStart(string[] args)
        {
            Log.Information($"\nWatch services starts: Interactive [{Environment.UserInteractive}]");
            // Initialize the list of FileSystemWatchers based on the XML configuration file
            PopulateListFileSystemWatchers();
            Log.Information($"Wacth folders (enabled) count [{this.listFolders.FindAll( e => e.FolderEnabled).ToList().Count}]");
            // Start the file system watcher for each of the file specification
            // and folders found on the List<>
             StartFileSystemWatcher();
            Log.Information($"Folder watcher started: {this.listFileSystemWatcher.Count}");

        }
        /// <summary>Event automatically fired when the service is stopped by Windows</summary>
        protected override void OnStop()
        {
            Log.Information($"Watch service will stop.");
            if (listFileSystemWatcher != null)
            {
                foreach (FileSystemWatcher fsw in listFileSystemWatcher)
                {
                    // Stop listening
                    fsw.EnableRaisingEvents = false;
                    // Dispose the Object
                    fsw.Dispose();
                }
                // Clean the list
                listFileSystemWatcher.Clear();
            }
        }

      

        private void PopulateListFileSystemWatchers()
        {
            List<WatchedFolderSettings> watchedFoldersSettings;
            // Get the XML file name from the App.config file
            var fileNameXML = ConfigurationManager.AppSettings["WatchedFoldersSettings"];
            // Create an instance of XMLSerializer
            XmlSerializer deserializer =
              new XmlSerializer(typeof(List<WatchedFolderSettings>));
            using (TextReader reader = new StreamReader(fileNameXML))
            {
                try
                {
                    object obj = deserializer.Deserialize(reader);
                    // Close the TextReader object
                    reader.Close();
                    // Obtain a list of WatchedFolderSettings from XML Input data
                    watchedFoldersSettings = obj as List<WatchedFolderSettings>;
                    this.listFolders = watchedFoldersSettings;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Exception at populating lists with folders setting from config file.");
                }
               
            }


        }

        /// <summary>Start the file system watcher for each of the file
        /// specification and folders found on the List<>/// </summary>
        private void StartFileSystemWatcher()
        {
            // Creates a new instance of the list
            this.listFileSystemWatcher = new List<FileSystemWatcher>();
            // Loop the list to process each of the folder specifications found
            foreach (WatchedFolderSettings watchedFolder in listFolders)
            {
                DirectoryInfo dir = new DirectoryInfo(watchedFolder.FolderPath);
                // Checks whether the folder is enabled and
                // also the directory is a valid location
                if (watchedFolder.FolderEnabled && dir.Exists)
                {
                    // Creates a new instance of FileSystemWatcher
                    FileSystemWatcher fileSWatch = new FileSystemWatcher();
                    // Sets the filter
                    fileSWatch.Filter = "*.*";
                    this.filters = watchedFolder.FolderFilter;

                    // If sub directories should be considered
                    fileSWatch.IncludeSubdirectories = watchedFolder.FolderIncludeSub;
                    // Sets the folder location
                    fileSWatch.Path = watchedFolder.FolderPath;
                    // Sets the action to be executed
                    StringBuilder actionToExecute = new StringBuilder(
                      watchedFolder.ExecutableFile);
                    // List of arguments
                    StringBuilder actionArguments = new StringBuilder(
                      watchedFolder.ExecutableArguments);
                    // Subscribe to notify filters
                    fileSWatch.NotifyFilter =   NotifyFilters.LastAccess | 
                                                NotifyFilters.LastWrite | 
                                                NotifyFilters.FileName;

                    
                    //fileSWatch.NotifyFilter = NotifyFilters.DirectoryName;

                    // Associate the event that will be triggered when a new file
                    // is added to the monitored folder, using a lambda expression
                    if (watchedFolder.EventNewFiles)
                    {
                        //fileSWatch.NotifyFilter |= NotifyFilters.CreationTime;
                        //fileSWatch.Created += (senderObj, fileSysArgs) =>
                        //       fileSWatch_Created(senderObj, fileSysArgs,
                        //             actionToExecute.ToString(), actionArguments.ToString());

                        Observable.FromEventPattern<FileSystemEventArgs>(fileSWatch, "Created")
                                        .Select(e => e)
                                        .Where(e => File.Exists(e.EventArgs.FullPath))
                                       .Subscribe(
                                           (pattern) =>
                                                   fileSWatch_Created(pattern.Sender, pattern.EventArgs, actionToExecute.ToString(), actionArguments.ToString())
                                           );
                    }
                    

                    if (watchedFolder.EventRenamedFiles)
                    {
                        //fileSWatch.NotifyFilter |= NotifyFilters.FileName;
                        //fileSWatch.Renamed += (senderObj, fileSysArgs) =>
                        //  fileSWatch_Renamed(senderObj, fileSysArgs,
                        //   actionToExecute.ToString(), actionArguments.ToString());

                        Observable.FromEventPattern<RenamedEventArgs>(fileSWatch, "Renamed")
                                  .Subscribe(
                                       (pattern) =>
                                               fileSWatch_Renamed(pattern.Sender, pattern.EventArgs, actionToExecute.ToString(), actionArguments.ToString())
                                       );

                    }

                    if (watchedFolder.EventDeletedFiles)
                    {
                        //fileSWatch.NotifyFilter |= NotifyFilters.LastAccess;
                        //fileSWatch.Deleted += (senderObj, fileSysArgs) =>
                        //  fileSWatch_Deleted(senderObj, fileSysArgs,
                        //   actionToExecute.ToString(), actionArguments.ToString());

                        Observable.FromEventPattern<FileSystemEventArgs>(fileSWatch, "Deleted")
                                    .Subscribe(
                                        (pattern) =>
                                                fileSWatch_Deleted(pattern.Sender, pattern.EventArgs, actionToExecute.ToString(), actionArguments.ToString())
                                        );
                    }

                    if (watchedFolder.EventModifiedFiles)
                    {
                        //fileSWatch.NotifyFilter |= NotifyFilters.LastWrite;
                        //fileSWatch.Changed += (senderObj, fileSysArgs) =>
                        //  fileSWatch_Changed(senderObj, fileSysArgs,
                        //   actionToExecute.ToString(), actionArguments.ToString());
                        
                       
                        Observable.FromEventPattern<FileSystemEventArgs>(fileSWatch, "Changed")
                                    .Select(e => e)
                                    .Where(e => File.Exists(e.EventArgs.FullPath) && File.GetLastWriteTime(e.EventArgs.FullPath).Subtract(this.lastWrite).Ticks > 20)
                                    .Subscribe(
                                        pattern =>
                                            fileSWatch_Changed(pattern.Sender, pattern.EventArgs, actionToExecute.ToString(), actionArguments.ToString())    
                                        );

                    }

                    Log.Information($"Folder: {watchedFolder.FolderPath}, Filter: {watchedFolder.FolderFilter}, NotifyFilter: [{fileSWatch.NotifyFilter}]");

                    // Begin watching
                    fileSWatch.EnableRaisingEvents = true;
                    // Add the systemWatcher to the list
                    listFileSystemWatcher.Add(fileSWatch);
                    
                    // Record a log entry into Windows Event Log
                    Log.Information(String.Format(
                      "Starting to monitor files with extension ({0}) in the folder ({1})",
                      fileSWatch.Filter, fileSWatch.Path));
                }
            }
        }

        private bool FileExtensionInFilter(string filePath, string filters)
        {
            if (filters.Trim().Length == 0) return true;
            if (filters.Trim().Contains("*.*")) return true;
            return filters.Contains(Path.GetExtension(filePath));
        }
           

        private bool FileExtensionInFilter_OLD(string filePath, string filters) =>
            Regex.IsMatch(filePath, filters, RegexOptions.IgnoreCase);


        /// <summary>This event is triggered when a file with the specified
        /// extension is created on the monitored folder</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        //void fileSWatch_General(object sender, FileSystemEventArgs e, string action_Exec, string action_Args)
        //{
        //    Log.Information();
        //}

        /// <summary>This event is triggered when a file with the specified
        /// extension is created on the monitored folder</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Created(object sender, FileSystemEventArgs e,
          string action_Exec, string action_Args)
        {
            if(!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }

            Log.Information(String.Format("New file ({0}) in folder ({1})", e.FullPath, Directory.GetParent(e.FullPath).FullName));
            string fileName = e.FullPath;
            
            // Adds the file name to the arguments. The filename will be placed in lieu of {0}
            string newStr = string.Format(action_Args, fileName);
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(action_Exec))
            {
                ExecuteCommandLineProcess(action_Exec, newStr);
            }
        }

        /// <summary>This event is triggered when a file has been renamed.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Renamed(object sender, RenamedEventArgs e,
          string action_Exec, string action_Args)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }

            this.lastWrite = File.GetLastWriteTime(e.FullPath);
            Log.Information(String.Format("Renamed file ({0}) in folder ({1}). ({2})", e.FullPath, Directory.GetParent(e.FullPath).FullName, sender.GetType().Name));
            string fileName = e.FullPath;
            // Adds the file name to the arguments. The filename will be placed in lieu of {0}
            string newStr = string.Format(action_Args, fileName);
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(action_Exec))
            {
                ExecuteCommandLineProcess(action_Exec, newStr);
            }
        }

        /// <summary>This event is triggered when a file has been deleted.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Deleted(object sender, FileSystemEventArgs e,
          string action_Exec, string action_Args)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }

            Log.Information(String.Format("Deleted file ({0}) in folder ({1})", e.FullPath, Directory.GetParent(e.FullPath).FullName));
            string fileName = e.FullPath;
            // Adds the file name to the arguments. The filename will be placed in lieu of {0}
            string newStr = string.Format(action_Args, fileName);
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(action_Exec))
            {
                ExecuteCommandLineProcess(action_Exec, newStr);
            }
        }

        /// <summary>This event is triggered when a file has been modified.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Changed(object sender, FileSystemEventArgs e,
          string action_Exec, string action_Args)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }
            this.lastWrite = File.GetLastWriteTime(e.FullPath);
           
            Log.Information(String.Format("Modified file ({0}) in folder ({1}), ISFile: ({2})",  e.FullPath, Directory.GetParent(e.FullPath).FullName, File.Exists(e.FullPath)));
            //Log.Information($"Last write time (new): {  this.lastWrite }");

            string fileName = e.FullPath;
            // Adds the file name to the arguments. The filename will be placed in lieu of {0}
            string newStr = string.Format(action_Args, fileName);
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(action_Exec))
            {
                ExecuteCommandLineProcess(action_Exec, newStr);
            }
        }

        /// <summary>Executes a set of instructions through the command window</summary>
        /// <param name="executableFile">Name of the executable file or program</param>
        /// <param name="argumentList">List of arguments</param>
        private void ExecuteCommandLineProcess(string executableFile, string argumentList)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = executableFile;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = argumentList;
            try
            {
                // Start the process with the info specified
                // Call WaitForExit and then the using-statement will close
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();

                    // Register a log of the successful operation
                    Log.Information(string.Format(
                      "Succesful operation --> Executable: {0} --> Arguments: {1}",
                      executableFile, argumentList));
                    Log.Information($"Exit code: { exeProcess.ExitCode }");
                }
            }
            catch (Exception exc)
            {
                // Register a Log of the Exception
                Log.Error(exc, "Exception in ExecuteCommandLineProcess");
            }
        }
    }
}
