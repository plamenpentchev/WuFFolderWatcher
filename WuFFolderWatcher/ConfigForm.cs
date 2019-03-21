using System;
using System.Windows.Forms;
using Serilog;
using System.Configuration;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.ServiceProcess;
using System.Security.Principal;

namespace WuFFolderWatcher
{
    public partial class ConfigForm : Form
    {
        private List<WatchedFolderSettings> watchedFoldersSettings;
        private WatchedFolderSettings selectedSetting;
        private BindingList<WatchedFolderDataGridView> bindList;
        private SERVICE_STATES servState;
        private string logErrorsOnly;
        private int selectedIdx;
        private string fileNameXML;
        public ConfigForm()
        {
            InitializeComponent();
            
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
           
            this.PopulateListFileSystemWatchers();
            this.selectedSetting = watchedFoldersSettings.Count > 0 ? watchedFoldersSettings[0] : new WatchedFolderSettings();
            this.selectedIdx = 0;
            this.LoadCurrentSettingsToGUI(this.selectedSetting);
            this.servState = WuFFolderWatcher.GetServiceStatus();
            this.label6.Text = this.servState.GetDescription<SERVICE_STATES>();
            
            this.buttonStartService.Enabled = servState == SERVICE_STATES.STATE_STOPPED ? true: false;
            this.logErrorsOnly = ConfigurationManager.AppSettings["logErrorsOnly"];

            this.checkBoxLogErrorOnly.Checked = logErrorsOnly == "True" ? true : false;
            if (this.servState == SERVICE_STATES.STATE_NOT_INSTALLED)
            {
                MessageBox.Show("Please open an administrative console and run the 'Install.bat' file in the directory of the service's exe file.\nThis will install and start the service.", "Service not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (!this.IsAdministrator)
            {
                MessageBox.Show("Please run this application as administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void LoadCurrentSettingsToGUI(WatchedFolderSettings settings)
        {
            if (null != settings)
            {
                this.textBoxFolderPath.Text = settings.FolderPath;
                this.checkBoxDeleteFile.Checked = settings.EventDeletedFiles;
                this.radButFiles.Checked = settings.EntityFile;
                this.radButFolders.Checked = settings.EntityFolder;
                this.checkBoxNewFiles.Checked = settings.EventNewFiles;
                this.checkBoxModifyFiles.Checked = settings.EventModifiedFiles;
                this.checkBoxRenameFiles.Checked = settings.EventRenamedFiles;
                this.checkBoxIncludeSubFolders.Checked = settings.FolderIncludeSub;
                this.textBoxFileFilters.Text = settings.FolderFilter;
                this.textBoxExecutable.Text = settings.ExecutableFile;
                this.textBoxExecutableArguments.Text = settings.ExecutableArguments;
            }
            else
            {
                this.textBoxFolderPath.Text = string.Empty;
                this.checkBoxDeleteFile.Checked = false;
                this.radButFiles.Checked = false;
                this.radButFolders.Checked = false;
                this.checkBoxNewFiles.Checked = false;
                this.checkBoxModifyFiles.Checked = false;
                this.checkBoxRenameFiles.Checked = false;
                this.checkBoxIncludeSubFolders.Checked = false;
                this.textBoxFileFilters.Text = string.Empty;
                this.textBoxExecutable.Text = string.Empty;
                this.textBoxExecutableArguments.Text = string.Empty;
            }
            
        }

        private void LoadCurrentSettingsFromGUI(ref WatchedFolderSettings settings)
        {
            if (null != settings)
            {
                settings.FolderPath = this.textBoxFolderPath.Text;
                settings.EventDeletedFiles = this.checkBoxDeleteFile.Checked;
                settings.EntityFile = this.radButFiles.Checked;
                settings.EntityFolder = this.radButFolders.Checked;
                settings.EventNewFiles = this.checkBoxNewFiles.Checked;
                settings.EventModifiedFiles = this.checkBoxModifyFiles.Checked;
                settings.EventRenamedFiles = this.checkBoxRenameFiles.Checked;
                settings.FolderIncludeSub = this.checkBoxIncludeSubFolders.Checked;
                settings.FolderFilter = this.textBoxFileFilters.Text;
                settings.ExecutableFile = this.textBoxExecutable.Text;
                settings.ExecutableArguments = this.textBoxExecutableArguments.Text;
                if (this.selectedIdx >= 0 && this.selectedIdx < this.dataGridWatchedFolders.Rows.Count)
                {
                    settings.FolderID = this.dataGridWatchedFolders.Rows[this.selectedIdx].Cells[0].Value?.ToString();
                    settings.FolderEnabled = (bool)this.dataGridWatchedFolders.Rows[this.selectedIdx].Cells[1].Value;
                }
            }
            
        }

        /// <summary>Reads an XML file and populates a list of <CustomFolderSettings> </summary>
        private void PopulateListFileSystemWatchers()
        {
            // Get the XML file name from the App.config file
            this.fileNameXML = ConfigurationManager.AppSettings["WatchedFoldersSettings"];
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
                    var x = from w in watchedFoldersSettings
                            select new WatchedFolderDataGridView(w);

                    this.bindList = new BindingList<WatchedFolderDataGridView>(x.ToList());

                    this.dataGridWatchedFolders.DataSource = bindList;// x.ToList();
                    this.dataGridWatchedFolders.Update();
                    this.dataGridWatchedFolders.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }


        }

        private void DumpWatchedFoldesSettingsToFile()
        {
            // Create an instance of XMLSerializer
            XmlSerializer serializer =
              new XmlSerializer(typeof(List<WatchedFolderSettings>));
            using (FileStream fs = new FileStream(this.fileNameXML, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, this.watchedFoldersSettings);
            }
        }
        
        private Configuration OpenExeConfiguration(string assemblyName) =>
            ConfigurationManager.OpenExeConfiguration(assemblyName);

        private string[] ReadAppSettingValue(string key)
        {
            try
            {
                var configFile = this.OpenExeConfiguration(typeof(WuFFolderWatcher).Assembly.Location);
                return configFile.AppSettings.Settings[key].Value.Split('|');
            }
            catch (Exception ce)
            {
                Log.Fatal(ce, "Error writreading app settings");
                return new string[] { };
            }
        }
        

        private void AddUpdateAppSettingsValue(string key, string value, UPDATE_CONFIG_OPTIONS option)
        {
            try
            {
                var configFile = this.OpenExeConfiguration(typeof(WuFFolderWatcher).Assembly.Location);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    switch (option)
                    {
                        case UPDATE_CONFIG_OPTIONS.ADD_CONFIG_VALUE:
                            settings[key].Value += $"|{ value }";
                            break;
                        case UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE:
                            settings[key].Value = $"{ value }";
                            break;
                        default:
                            break;
                    }
                   
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ce)
            {
                Log.Fatal(ce, "Error writing app settings");
            }
        }

        private void butAddWatchFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var newFolder = new WatchedFolderSettings();
                    newFolder.FolderPath = fbd.SelectedPath;
                    watchedFoldersSettings.Add(newFolder);

                    var x = from w in watchedFoldersSettings
                            select new WatchedFolderDataGridView(w);

                    this.bindList = new BindingList<WatchedFolderDataGridView>(x.ToList());

                    this.dataGridWatchedFolders.DataSource = bindList; // x.ToList();
                    this.dataGridWatchedFolders.Update();
                    this.dataGridWatchedFolders.Refresh();
                    this.dataGridWatchedFolders.ClearSelection();
                    this.dataGridWatchedFolders.Rows[this.dataGridWatchedFolders.Rows.Count - 1].Selected = true;
                    DataGridViewCell cell = this.dataGridWatchedFolders.Rows[this.dataGridWatchedFolders.Rows.Count - 1].Cells[0];
                    this.dataGridWatchedFolders.CurrentCell = cell;
                    this.dataGridWatchedFolders.BeginEdit(true);
                    this.LoadCurrentSettingsToGUI(newFolder);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.LoadCurrentSettingsFromGUI(ref this.selectedSetting);
            this.DumpWatchedFoldesSettingsToFile();
            this.AddUpdateAppSettingsValue("logErrorsOnly", this.logErrorsOnly, UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.Close();
        }
        
        private void buttonOK_Click_Old(object sender, EventArgs e)
        {
            var watchFolders = "";
            //foreach (var item in this.listWatchFolders.Items)
            //{
            //    if (!string.IsNullOrEmpty(item.ToString()))
            //    {
            //        watchFolders += $"{ item.ToString() }|";
            //    }
            //}
            
            this.AddUpdateAppSettingsValue(
                        APP_SETTINGS_KEYS.WATCH_FODLERS.GetDescription<APP_SETTINGS_KEYS>(),
                        watchFolders.EndsWith("|") ? watchFolders.Substring(0, watchFolders.Length - 1)  : watchFolders,
                        UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                        APP_SETTINGS_KEYS.NEW_FILES.GetDescription<APP_SETTINGS_KEYS>(),
                        this.checkBoxNewFiles.Checked.ToString(),
                        UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                        APP_SETTINGS_KEYS.MODIFY_FILES.GetDescription<APP_SETTINGS_KEYS>(),
                        this.checkBoxModifyFiles.Checked.ToString(),
                        UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                       APP_SETTINGS_KEYS.DELETE_FILES.GetDescription<APP_SETTINGS_KEYS>(),
                       this.checkBoxDeleteFile.Checked.ToString(),
                       UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                       APP_SETTINGS_KEYS.RENAME_FILES.GetDescription<APP_SETTINGS_KEYS>(),
                       this.checkBoxRenameFiles.Checked.ToString(),
                       UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                       APP_SETTINGS_KEYS.INCLUDE_SUBFOLDERS.GetDescription<APP_SETTINGS_KEYS>(),
                       this.checkBoxIncludeSubFolders.Checked.ToString(),
                       UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.AddUpdateAppSettingsValue(
                        APP_SETTINGS_KEYS.FILE_FILTERS.GetDescription<APP_SETTINGS_KEYS>(),
                        this.textBoxFileFilters.Text,
                        UPDATE_CONFIG_OPTIONS.UPDATE_CONFIG_VALUE);
            this.Close();
        }

        private void checkBoxDeleteFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFileFilters_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridWatchedFolders_SelectionChanged(object sender, EventArgs e)
        {

            this.LoadCurrentSettingsFromGUI(ref this.selectedSetting);
            this.selectedIdx = ((DataGridView)sender).SelectedRows.Count > 0 ? ((DataGridView)sender).SelectedRows[0].Index: 0;
            if(this.watchedFoldersSettings.Count > 0)
            {
                this.selectedSetting = this.watchedFoldersSettings[this.selectedIdx];
                this.LoadCurrentSettingsToGUI(this.selectedSetting);
            }
            else
            {
                this.selectedSetting = null;
                this.LoadCurrentSettingsToGUI(this.selectedSetting);
            }
        }

        private void dataGridWatchedFolders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "FolderID":
                    this.watchedFoldersSettings[e.RowIndex].FolderID = dgv.CurrentCell.Value.ToString();
                    break;
                case "FolderEnabled":
                    this.watchedFoldersSettings[e.RowIndex].FolderEnabled = (bool)dgv.CurrentCell.Value ;
                    break;
                default:
                    break;
            }
            
        }

        private void buttonRemoveFromList_Click(object sender, EventArgs e)
        {
            if (this.selectedIdx < this.watchedFoldersSettings.Count)
                this.watchedFoldersSettings.RemoveAt(this.selectedIdx);
            if (this.selectedIdx < this.bindList.Count)
                this.bindList.RemoveAt(this.selectedIdx);

            this.selectedIdx--;
            if(this.selectedIdx < 0) this.selectedIdx = 0;
            if(this.watchedFoldersSettings.Count > 0)
            {
                this.selectedSetting = this.watchedFoldersSettings[this.selectedIdx];
                this.LoadCurrentSettingsToGUI(this.selectedSetting);
            }
            else
            {
                this.selectedSetting = null;
                this.LoadCurrentSettingsToGUI(this.selectedSetting);
            }
                
            //this.dataGridWatchedFolders.Rows.Remove(this.dataGridWatchedFolders.Rows[this.dataGridWatchedFolders.SelectedCells[0].RowIndex]);

        }

        private void buttonFindExecutable_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                openFileDialog.Filter = "exe files (*.exe)|*.exe|vbs files (*.vbs)|*.vbs|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;

                    this.textBoxExecutable.Text = filePath;
                }
            }

        }

        private void buttonStartService_Click(object sender, EventArgs e)
        {
            this.buttonStartService.Enabled = !WuFFolderWatcher.StartService();
            
        }

        private void checkBoxLogErrorOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.logErrorsOnly = ((CheckBox)sender).Checked ? "True" : "False";
        }

        private  bool IsAdministrator =>
           new WindowsPrincipal(WindowsIdentity.GetCurrent())
               .IsInRole(WindowsBuiltInRole.Administrator);
    }
}
