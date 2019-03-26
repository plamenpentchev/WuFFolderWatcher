using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WuFFolderWatcher
{

    public enum ENTITY
    {
        [Description("NONE")]
        NONE,
        [Description("FILE")]
        FILE,
        [Description("FOLDER")]
        FOLDER
    }
    public enum UPDATE_CONFIG_OPTIONS
    {
        ADD_CONFIG_VALUE,
        UPDATE_CONFIG_VALUE
    }

    public enum FS_EVENT
    {
        [Description("CREATED")]
        CREATED,
        [Description("MODIFIED")]
        MODIFIED,
        [Description("DELETED")]
        DELETED,
        [Description("RENAMED")]
        RENAMED
    }

    public enum APP_SETTINGS_KEYS
    {
        [Description("newFiles")]
        NEW_FILES,
        [Description("modifyFiles")]
        MODIFY_FILES,
        [Description("deleteFiles")]
        DELETE_FILES,
        [Description("renameFiles")]
        RENAME_FILES,
        [Description("includeSubFolders")]
        INCLUDE_SUBFOLDERS,
        [Description("watchFolders")]
        WATCH_FODLERS,
        [Description("fileFilters")]
        FILE_FILTERS
    } 

    public enum SERVICE_STATES
    {
        [Description("Running")]
        STATE_RUNNING,
        [Description("Stopped")]
        STATE_STOPPED,
        [Description("Paused")]
        STATE_PAUSED,
        [Description("Stopping")]
        STATE_STOPPING,
        [Description("Starting")]
        STATE_STARTING,
        [Description("Status Changing")]
        STATE_CHANGING,
        [Description("Not Installed")]
        STATE_NOT_INSTALLED
    }

   
}
