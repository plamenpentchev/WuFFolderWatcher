using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuFFolderWatcher
{
    public class WatchedFolderSettings
    {
        public int Index { get; set; }
        /// <summary>Unique identifier of the combination File type/folder.
        /// Arbitrary number (for instance 001, 002, and so on)</summary>
        [XmlAttribute]
        public string FolderID { get; set; }
        /// <summary>If TRUE: the file type and folder will be monitored</summary>
        [XmlElement]
        public bool FolderEnabled { get; set; }
        /// <summary>Description of the type of files and folder location –
        /// Just for documentation purpose</summary>
        [XmlElement]
        public string FolderDescription { get; set; }
        /// <summary>Filter to select the type of files to be monitored.
        /// (Examples: *.shp, *.*, Project00*.zip)</summary>
        [XmlElement]
        public string FolderFilter { get; set; }
        /// <summary>Full path to be monitored
        /// (i.e.: D:\files\projects\shapes\ )</summary>
        [XmlElement]
        public string FolderPath { get; set; }
        /// <summary>If TRUE: the folder and its subfolders will be monitored</summary>
        [XmlElement]
        public bool FolderIncludeSub { get; set; }
        /// <summary>If TRUE: the file events will be watched for </summary>
        [XmlElement]
        public bool EntityFile { get; set; }
        /// <summary>If TRUE: the folder events will be watched for </summary>
        [XmlElement]
        public bool EntityFolder { get; set; }
        /// <summary>Specifies the command or action to be executed
        /// after an event has raised</summary>
        [XmlElement]
        public string ExecutableFile { get; set; }
        /// <summary>List of arguments to be passed to the executable file</summary>
        [XmlElement]
        public string ExecutableArguments { get; set; }
        /// <summary>Specifies if newly created files should be considered</summary>
        [XmlElement]
        public bool EventNewFiles { get; set; }
        // <summary>Specifies if newly modified files should be considered</summary>
        [XmlElement]
        public bool EventModifiedFiles { get; set; }
        // <summary>Specifies if newly deleted files should be considered</summary>
        [XmlElement]
        public bool EventDeletedFiles { get; set; }
        // <summary>Specifies if newly renamed files should be considered</summary>
        [XmlElement]
        public bool EventRenamedFiles { get; set; }
        /// <summary>If TRUE: the proces will be started asynchronously </summary>
        [XmlElement]
        public bool RunAsync { get; set; }
        /// <summary>If set the thread groups will be run in thi interval
        [XmlElement]
        public string ThreadGroupInterval { get; set; }
        /// <summary>If set the asynchronously started process will be waited for so much milliseconds to exit</summary>
        [XmlElement]
        public string ThreadCount { get; set; }
        /// <summary>If set a Web API will be informed about the event.</summary>
        [XmlElement]
        public string BaseURL { get; set; }
        /// <summary>JSON object that will be posted to the Web endpoint.</summary>
        [XmlElement]
        public string POSTParam { get; set; }
        /// <summary>Default constructor of the class</summary>       
        public WatchedFolderSettings()
        {
        }
    }
}
