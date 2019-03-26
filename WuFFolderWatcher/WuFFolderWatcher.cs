using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;
using Serilog;
using System.Reactive.Linq;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft;

namespace WuFFolderWatcher
{
    public partial class WuFFolderWatcher : ServiceBase
    {
        private List<FileSystemWatcher> listFileSystemWatcher;
        private List<BufferBlock<CommandInfo>> _listAsyncCommands;
        private List<WatchedFolderSettings> listFolders;
        private static int _counter = 0;
        private DateTime lastWrite = DateTime.MinValue;
        private string filters = "";

        private readonly ManualResetEvent _testMutex = new ManualResetEvent(false);
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
            this._listAsyncCommands = new List<BufferBlock<CommandInfo>>();

            int idx = 0;
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

                    watchedFolder.Index = idx;

                    this.filters = watchedFolder.FolderFilter;

                    // If sub directories should be considered
                    fileSWatch.IncludeSubdirectories = watchedFolder.FolderIncludeSub;
                    // Sets the folder location
                    fileSWatch.Path = watchedFolder.FolderPath;
                    // Sets the action to be executed
                    StringBuilder actionToExecute = new StringBuilder(
                      watchedFolder.ExecutableFile);
                    // List of arguments
                    StringBuilder actionArguments = new StringBuilder( watchedFolder.ExecutableArguments);
                    

                    // Subscribe to notify filters
                    Log.Information(String.Format("FILES ({0}) FOLDERS ({1})", watchedFolder.EntityFile.ToString(), watchedFolder.EntityFolder.ToString()));
                    if (watchedFolder.EntityFile)
                    {
                        // Sets the filter
                        fileSWatch.Filter = "*.*";

                        // Record a log entry into Windows Event Log
                        fileSWatch.NotifyFilter = NotifyFilters.LastAccess |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.FileName;
                    }
                    else
                    {
                        // Sets the filter
                        fileSWatch.Filter = "";
                        fileSWatch.NotifyFilter = NotifyFilters.DirectoryName;
                    }
                    
                   
                    
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
                                        .Where(e => {
                                            if (watchedFolder.EntityFile)
                                            {
                                                return File.Exists(e.EventArgs.FullPath);
                                            }
                                            else
                                            {
                                                return Directory.Exists(e.EventArgs.FullPath);
                                            }
                                        } )
                                       .Subscribe(
                                           (pattern) =>
                                                   fileSWatch_Created(pattern.Sender, pattern.EventArgs, watchedFolder)
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
                                               fileSWatch_Renamed(pattern.Sender, pattern.EventArgs, watchedFolder)
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
                                                fileSWatch_Deleted(pattern.Sender, pattern.EventArgs, watchedFolder)
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
                                            fileSWatch_Changed(pattern.Sender, pattern.EventArgs, watchedFolder)    
                                        );

                    }

                    Log.Information($"Index: {watchedFolder.Index}, Folder: {watchedFolder.FolderPath}, Filter: {fileSWatch.Filter}, NotifyFilter: [{fileSWatch.NotifyFilter}]");

                    // Begin watching
                    fileSWatch.EnableRaisingEvents = true;

                    // Add the systemWatcher to the list
                    listFileSystemWatcher.Add(fileSWatch);

                    // add async commands for this watched folder
                    _listAsyncCommands.Add(new BufferBlock<CommandInfo>());


                    if (watchedFolder.RunAsync)
                    {
                        
                        for (int i = 0; i < Convert.ToInt32(watchedFolder.ThreadCount); i++)
                        {
                            //... consume commands
                            this.Consumer(watchedFolder,  idx);
                        }
                    }
                    idx++;

                }
            }
        }

        private async void Producer(CommandInfo itemToProduce, int asyncCommIndex) =>
            await this._listAsyncCommands[asyncCommIndex].SendAsync<CommandInfo>(itemToProduce);

        private async void Consumer(WatchedFolderSettings watchedFolder, int asyncCommIndex)
        {
            CommandInfo ci;
            while (true)
            {
                try
                {
                    ci = await this._listAsyncCommands[asyncCommIndex].ReceiveAsync<CommandInfo>();
                    if (ci.CommandExe.Length > 0)
                    {
                        ExecuteCommandLineProcess(ci.CommandExe, ci.CommandArgs);
                        await Task.Delay(Convert.ToInt32(watchedFolder.ThreadGroupInterval));
                    }
                    if (!string.IsNullOrEmpty(ci.BaseURL))
                    {
                        ExecuteWebAPI_POST(ci.BaseURL, ci.POSTParameter);
                        await Task.Delay(Convert.ToInt32(watchedFolder.ThreadGroupInterval));
                    }
                }
                catch (InvalidOperationException)
                {
                    break;
                }
               //Log.Information($"Consumming: {ci.ToString()}");
            }
        }

        private void FinishedEventHandler(object sender, BlockingCollectionEventArgs e)
        {
            _testMutex.Set();
        }

        private bool FileExtensionInFilter(string filePath, string filters)
        {
            if (filters.Trim().Length == 0) return true;
            if (filters.Trim().Contains("*.*")) return true;
            return filters.Contains(Path.GetExtension(filePath));
        }         

        private bool FileExtensionInFilter_OLD(string filePath, string filters) =>
            Regex.IsMatch(filePath, filters, RegexOptions.IgnoreCase);

        private string GetFormatString(bool cond, string ifTrue, string ifElse) => cond ? ifTrue : ifElse;

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
          WatchedFolderSettings watchedFolder)
        {
            if(!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }
            //string actionToExecute = watchedFolder.ExecutableFile;        // action to execute

            Interlocked.Increment(ref _counter);

            string entity = GetFormatString(watchedFolder.EntityFile == true , "file" , "folder");
            string isAsync = GetFormatString(watchedFolder.RunAsync == true, "YES", "NO");
            Log.Information($"[async: {isAsync}] - New { entity } ({e.FullPath}) in folder ({Directory.GetParent(e.FullPath).FullName})");
            //string fileName = e.FullPath;
            
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(watchedFolder.ExecutableFile))
            {
                CommandInfo ci = new CommandInfo(
                                    new EventInfos
                                    {
                                        FileFullPath = e.FullPath,
                                        EventType = FS_EVENT.CREATED,
                                        OldName = "",
                                        WatchedFolderRoot = watchedFolder.FolderPath,
                                        Counter = _counter
                                    },
                                    watchedFolder);

                if (watchedFolder.RunAsync)
                {
                    this.Producer(ci, watchedFolder.Index);
                }
                else
                {
                    ExecuteCommandLineProcess(ci.CommandExe, ci.CommandArgs);
                    if (!string.IsNullOrEmpty(ci.BaseURL))
                    {
                        ExecuteWebAPI_POST(ci.BaseURL, ci.POSTParameter);
                    }
                }

            }
        }

        /// <summary>This event is triggered when a file has been renamed.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Renamed(object sender, RenamedEventArgs e,
           WatchedFolderSettings watchedFolder)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }

            this.lastWrite = File.GetLastWriteTime(e.FullPath);
            string actionToExecute = watchedFolder.ExecutableFile;        // action to execute

            Log.Information(String.Format("Renamed {3} ({0}) in folder ({1}). Old name({2})", e.FullPath, Directory.GetParent(e.FullPath).FullName, e.OldName, watchedFolder.EntityFile ? "file" : "folder"));
            string fileName = e.FullPath;
            
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(actionToExecute))
            {
                // Adds the file name to the arguments. The filename will be placed in lieu of {0}
                string argStr = "";
                if (!string.IsNullOrEmpty(watchedFolder.ExecutableArguments))
                {
                    argStr = string.Format(watchedFolder.ExecutableArguments, fileName, "RENAMED", e.OldName, watchedFolder.FolderPath);
                }
                if (watchedFolder.RunAsync)
                {

                }
                else
                {
                    ExecuteCommandLineProcess(actionToExecute, argStr);
                }
            }
        }

        /// <summary>This event is triggered when a file has been deleted.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Deleted(object sender, FileSystemEventArgs e,
            WatchedFolderSettings watchedFolder)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }
            string actionToExecute = watchedFolder.ExecutableFile;        // action to execute

            Log.Information(String.Format("Deleted {2} ({0}) in folder ({1})", e.FullPath, Directory.GetParent(e.FullPath).FullName, watchedFolder.EntityFile ? "file" : "folder"));
            string fileName = e.FullPath;
            
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(actionToExecute))
            {
                // Adds the file name to the arguments. The filename will be placed in lieu of {0}
                string argStr = "";
                if (!string.IsNullOrEmpty(watchedFolder.ExecutableArguments))
                {
                    argStr = string.Format(watchedFolder.ExecutableArguments, fileName, "DELETED", "", watchedFolder.FolderPath);
                }
                if (watchedFolder.RunAsync)
                {

                }
                else
                {
                    ExecuteCommandLineProcess(actionToExecute, argStr);
                }
            }
        }

        /// <summary>This event is triggered when a file has been modified.</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Changed(object sender, FileSystemEventArgs e,
          WatchedFolderSettings watchedFolder)
        {
            if (!this.FileExtensionInFilter(e.FullPath, this.filters))
            {
                return;
            }
            this.lastWrite = File.GetLastWriteTime(e.FullPath);
            string actionToExecute = watchedFolder.ExecutableFile;        // action to execute

            Log.Information(String.Format("Modified {2} ({0}) in folder ({1})",  e.FullPath, Directory.GetParent(e.FullPath).FullName, watchedFolder.EntityFile ? "file" : "folder"));
           
            string fileName = e.FullPath;
            
            // Executes the command from the DOS window
            if (!string.IsNullOrEmpty(actionToExecute))
            {
                // Adds the file name to the arguments. The filename will be placed in lieu of {0}
                string argStr = "";
                if (!string.IsNullOrEmpty(watchedFolder.ExecutableArguments))
                {
                    argStr = string.Format(watchedFolder.ExecutableArguments, fileName, "MODIFIED", "", watchedFolder.FolderPath);
                }

                if (watchedFolder.RunAsync)
                {

                }
                else
                {
                    ExecuteCommandLineProcess(actionToExecute, argStr);
                }
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
                      "Succesful operation (Background thread:{2}, Poolthread: {3}) --> Executable: {0} --> Arguments: {1}",
                      executableFile, argumentList, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread));
                    Log.Information($"Exit code: { exeProcess.ExitCode }");
                }
            }
            catch (Exception exc)
            {
                // Register a Log of the Exception
                Log.Error(exc, "Exception in ExecuteCommandLineProcess");
            }
        }

        private void ExecuteWebAPI_POST(string baseURL, object POSTParam)
        {
            Log.Information($"Executing POST to {baseURL}");
            Log.Information($"TypeNAme of PARAM {POSTParam.GetType().Name}");
            Log.Information($"PARAM {POSTParam.ToString().Replace(@"\", @"\\")}");
        }
    }
}
