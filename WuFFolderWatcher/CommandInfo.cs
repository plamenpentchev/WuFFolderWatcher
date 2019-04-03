using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace WuFFolderWatcher
{
    public class CommandInfo
    {
        public CommandInfo(EventInfos eventInfo, WatchedFolderSettings wfSettings)
        {
            EventInfos = eventInfo;
            CommandArgs = !string.IsNullOrEmpty(wfSettings.ExecutableArguments) ?
                    string.Format(wfSettings.ExecutableArguments, 
                        EventInfos.FileFullPath, 
                        EventInfos.EventType.GetDescription<FS_EVENT>(), 
                        EventInfos.OldName, 
                        EventInfos.WatchedFolderRoot,
                        EventInfos.Counter) : 
                    "";
            CommandExe = wfSettings.ExecutableFile;
            BaseURL = wfSettings.BaseURL;
           
            POSTParameter = !string.IsNullOrEmpty(wfSettings.POSTParam) ?
                 "{" + string.Format(wfSettings.POSTParam,
                        EventInfos.FileFullPath,
                        EventInfos.EventType.GetDescription<FS_EVENT>(),
                        EventInfos.OldName,
                        EventInfos.WatchedFolderRoot,
                        EventInfos.Counter) +"}"
                : string.Empty ;
        }

        public EventInfos EventInfos { get; set; }
        public string CommandExe { get; set; }
        public string CommandArgs { get; set; }
        public string BaseURL { get; set; }
        public string POSTParameter { get; set; }

        public override string ToString() => $"{CommandExe} {CommandArgs}";
    }

    public class EventInfos
    {
        public string FileFullPath { get; set; }
        public FS_EVENT EventType { get; set; }
        public string OldName { get; set; }
        public string WatchedFolderRoot { get; set; }
        public long Counter { get; set; }
    }

    
}
