using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuFFolderWatcher
{
    class WatchedFolderDataGridView
    {
        public string FolderID { get; set; }
        public bool FolderEnabled { get; set; }
        

        public WatchedFolderDataGridView(WatchedFolderSettings s)
        {
            FolderID = s.FolderID;
            FolderEnabled = s.FolderEnabled;
        }
    }
}
