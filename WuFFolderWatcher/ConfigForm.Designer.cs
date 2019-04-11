namespace WuFFolderWatcher
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.groupBoxWatchFolders = new System.Windows.Forms.GroupBox();
            this.buttonRemoveFromList = new System.Windows.Forms.Button();
            this.dataGridWatchedFolders = new System.Windows.Forms.DataGridView();
            this.butAddWatchFolder = new System.Windows.Forms.Button();
            this.groupBoxEventsAndOptions = new System.Windows.Forms.GroupBox();
            this.radButFolders = new System.Windows.Forms.RadioButton();
            this.radButFiles = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxIncludeSubFolders = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxRenameFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteFile = new System.Windows.Forms.CheckBox();
            this.checkBoxModifyFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxNewFiles = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFileFilters = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupSynchronisation = new System.Windows.Forms.GroupBox();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.cbThreadCount = new System.Windows.Forms.ComboBox();
            this.tbGroupIntervalTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbRunAsync = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExecutableArguments = new System.Windows.Forms.TextBox();
            this.buttonFindExecutable = new System.Windows.Forms.Button();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxLogErrorOnly = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbPOSTParameter = new System.Windows.Forms.TextBox();
            this.tbBaseURL = new System.Windows.Forms.TextBox();
            this.cbWaitToReturn = new System.Windows.Forms.CheckBox();
            this.tabWebAPI = new System.Windows.Forms.TabPage();
            this.lblPOST = new System.Windows.Forms.Label();
            this.lblBaseURL = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExecutable = new System.Windows.Forms.TabPage();
            this.groupBoxWatchFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWatchedFolders)).BeginInit();
            this.groupBoxEventsAndOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupSynchronisation.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabWebAPI.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabExecutable.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWatchFolders
            // 
            this.groupBoxWatchFolders.Controls.Add(this.buttonRemoveFromList);
            this.groupBoxWatchFolders.Controls.Add(this.dataGridWatchedFolders);
            this.groupBoxWatchFolders.Controls.Add(this.butAddWatchFolder);
            this.groupBoxWatchFolders.Location = new System.Drawing.Point(8, 12);
            this.groupBoxWatchFolders.Name = "groupBoxWatchFolders";
            this.groupBoxWatchFolders.Size = new System.Drawing.Size(433, 612);
            this.groupBoxWatchFolders.TabIndex = 0;
            this.groupBoxWatchFolders.TabStop = false;
            this.groupBoxWatchFolders.Text = "Watched Folders";
            // 
            // buttonRemoveFromList
            // 
            this.buttonRemoveFromList.Location = new System.Drawing.Point(12, 570);
            this.buttonRemoveFromList.Name = "buttonRemoveFromList";
            this.buttonRemoveFromList.Size = new System.Drawing.Size(130, 36);
            this.buttonRemoveFromList.TabIndex = 3;
            this.buttonRemoveFromList.Text = "Remove from list";
            this.toolTip1.SetToolTip(this.buttonRemoveFromList, "Removes the selected folder profile from the collection.");
            this.buttonRemoveFromList.UseVisualStyleBackColor = true;
            this.buttonRemoveFromList.Click += new System.EventHandler(this.buttonRemoveFromList_Click);
            // 
            // dataGridWatchedFolders
            // 
            this.dataGridWatchedFolders.AllowUserToOrderColumns = true;
            this.dataGridWatchedFolders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridWatchedFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWatchedFolders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridWatchedFolders.EnableHeadersVisualStyles = false;
            this.dataGridWatchedFolders.Location = new System.Drawing.Point(12, 19);
            this.dataGridWatchedFolders.Name = "dataGridWatchedFolders";
            this.dataGridWatchedFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridWatchedFolders.ShowCellToolTips = false;
            this.dataGridWatchedFolders.Size = new System.Drawing.Size(405, 535);
            this.dataGridWatchedFolders.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dataGridWatchedFolders, resources.GetString("dataGridWatchedFolders.ToolTip"));
            this.dataGridWatchedFolders.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridWatchedFolders_CellValueChanged);
            this.dataGridWatchedFolders.SelectionChanged += new System.EventHandler(this.dataGridWatchedFolders_SelectionChanged);
            // 
            // butAddWatchFolder
            // 
            this.butAddWatchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddWatchFolder.Location = new System.Drawing.Point(269, 570);
            this.butAddWatchFolder.Name = "butAddWatchFolder";
            this.butAddWatchFolder.Size = new System.Drawing.Size(148, 36);
            this.butAddWatchFolder.TabIndex = 1;
            this.butAddWatchFolder.Text = "Add new watched folder";
            this.toolTip1.SetToolTip(this.butAddWatchFolder, "Adds a new folder profile from the file system.");
            this.butAddWatchFolder.UseVisualStyleBackColor = true;
            this.butAddWatchFolder.Click += new System.EventHandler(this.butAddWatchFolder_Click);
            // 
            // groupBoxEventsAndOptions
            // 
            this.groupBoxEventsAndOptions.Controls.Add(this.radButFolders);
            this.groupBoxEventsAndOptions.Controls.Add(this.radButFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.label7);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxIncludeSubFolders);
            this.groupBoxEventsAndOptions.Controls.Add(this.label2);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxRenameFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxDeleteFile);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxModifyFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxNewFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.label1);
            this.groupBoxEventsAndOptions.Location = new System.Drawing.Point(460, 71);
            this.groupBoxEventsAndOptions.Name = "groupBoxEventsAndOptions";
            this.groupBoxEventsAndOptions.Size = new System.Drawing.Size(317, 163);
            this.groupBoxEventsAndOptions.TabIndex = 1;
            this.groupBoxEventsAndOptions.TabStop = false;
            this.groupBoxEventsAndOptions.Text = "Events and Options";
            this.toolTip1.SetToolTip(this.groupBoxEventsAndOptions, "Config events and options for the watched folder.");
            // 
            // radButFolders
            // 
            this.radButFolders.AutoSize = true;
            this.radButFolders.Location = new System.Drawing.Point(191, 22);
            this.radButFolders.Name = "radButFolders";
            this.radButFolders.Size = new System.Drawing.Size(54, 17);
            this.radButFolders.TabIndex = 9;
            this.radButFolders.TabStop = true;
            this.radButFolders.Text = "Folder";
            this.toolTip1.SetToolTip(this.radButFolders, "sender as CheckBox");
            this.radButFolders.UseVisualStyleBackColor = true;
            this.radButFolders.CheckedChanged += new System.EventHandler(this.radButFolders_CheckedChanged);
            // 
            // radButFiles
            // 
            this.radButFiles.AutoSize = true;
            this.radButFiles.Location = new System.Drawing.Point(79, 22);
            this.radButFiles.Name = "radButFiles";
            this.radButFiles.Size = new System.Drawing.Size(46, 17);
            this.radButFiles.TabIndex = 8;
            this.radButFiles.TabStop = true;
            this.radButFiles.Text = "Files";
            this.toolTip1.SetToolTip(this.radButFiles, "Only events for files will be watched for");
            this.radButFiles.UseVisualStyleBackColor = true;
            this.radButFiles.CheckedChanged += new System.EventHandler(this.radButFiles_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Entitties:";
            // 
            // checkBoxIncludeSubFolders
            // 
            this.checkBoxIncludeSubFolders.AutoSize = true;
            this.checkBoxIncludeSubFolders.Location = new System.Drawing.Point(79, 135);
            this.checkBoxIncludeSubFolders.Name = "checkBoxIncludeSubFolders";
            this.checkBoxIncludeSubFolders.Size = new System.Drawing.Size(120, 17);
            this.checkBoxIncludeSubFolders.TabIndex = 6;
            this.checkBoxIncludeSubFolders.Text = "Include Sub-Folders";
            this.toolTip1.SetToolTip(this.checkBoxIncludeSubFolders, "Sub-folders will be observed as well.");
            this.checkBoxIncludeSubFolders.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Options: ";
            // 
            // checkBoxRenameFiles
            // 
            this.checkBoxRenameFiles.AutoSize = true;
            this.checkBoxRenameFiles.Location = new System.Drawing.Point(79, 102);
            this.checkBoxRenameFiles.Name = "checkBoxRenameFiles";
            this.checkBoxRenameFiles.Size = new System.Drawing.Size(72, 17);
            this.checkBoxRenameFiles.TabIndex = 4;
            this.checkBoxRenameFiles.Text = "Renamed";
            this.toolTip1.SetToolTip(this.checkBoxRenameFiles, "Watch for renamed files only.");
            this.checkBoxRenameFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteFile
            // 
            this.checkBoxDeleteFile.AutoSize = true;
            this.checkBoxDeleteFile.Location = new System.Drawing.Point(191, 102);
            this.checkBoxDeleteFile.Name = "checkBoxDeleteFile";
            this.checkBoxDeleteFile.Size = new System.Drawing.Size(63, 17);
            this.checkBoxDeleteFile.TabIndex = 3;
            this.checkBoxDeleteFile.Text = "Deleted";
            this.toolTip1.SetToolTip(this.checkBoxDeleteFile, "Watch if any files in this folders has been deleted.");
            this.checkBoxDeleteFile.UseVisualStyleBackColor = true;
            this.checkBoxDeleteFile.CheckedChanged += new System.EventHandler(this.checkBoxDeleteFile_CheckedChanged);
            // 
            // checkBoxModifyFiles
            // 
            this.checkBoxModifyFiles.AutoSize = true;
            this.checkBoxModifyFiles.Location = new System.Drawing.Point(190, 67);
            this.checkBoxModifyFiles.Name = "checkBoxModifyFiles";
            this.checkBoxModifyFiles.Size = new System.Drawing.Size(66, 17);
            this.checkBoxModifyFiles.TabIndex = 2;
            this.checkBoxModifyFiles.Text = "Modified";
            this.toolTip1.SetToolTip(this.checkBoxModifyFiles, "Watch for modifed files only. Modification implies name,extension and content mod" +
        "ification.");
            this.checkBoxModifyFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxNewFiles
            // 
            this.checkBoxNewFiles.AutoSize = true;
            this.checkBoxNewFiles.Location = new System.Drawing.Point(79, 67);
            this.checkBoxNewFiles.Name = "checkBoxNewFiles";
            this.checkBoxNewFiles.Size = new System.Drawing.Size(63, 17);
            this.checkBoxNewFiles.TabIndex = 1;
            this.checkBoxNewFiles.Text = "Created";
            this.toolTip1.SetToolTip(this.checkBoxNewFiles, "Watch for new files only.");
            this.checkBoxNewFiles.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Events: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFileFilters);
            this.groupBox1.Location = new System.Drawing.Point(461, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Filters";
            // 
            // textBoxFileFilters
            // 
            this.textBoxFileFilters.Location = new System.Drawing.Point(9, 19);
            this.textBoxFileFilters.Name = "textBoxFileFilters";
            this.textBoxFileFilters.Size = new System.Drawing.Size(293, 20);
            this.textBoxFileFilters.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxFileFilters, resources.GetString("textBoxFileFilters.ToolTip"));
            this.textBoxFileFilters.TextChanged += new System.EventHandler(this.textBoxFileFilters_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(603, 582);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(702, 583);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 36);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupSynchronisation
            // 
            this.groupSynchronisation.Controls.Add(this.lblThreadCount);
            this.groupSynchronisation.Controls.Add(this.cbThreadCount);
            this.groupSynchronisation.Controls.Add(this.tbGroupIntervalTime);
            this.groupSynchronisation.Controls.Add(this.label8);
            this.groupSynchronisation.Location = new System.Drawing.Point(460, 477);
            this.groupSynchronisation.Name = "groupSynchronisation";
            this.groupSynchronisation.Size = new System.Drawing.Size(314, 89);
            this.groupSynchronisation.TabIndex = 5;
            this.groupSynchronisation.TabStop = false;
            this.groupSynchronisation.Text = "Threads";
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Location = new System.Drawing.Point(90, 23);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(71, 13);
            this.lblThreadCount.TabIndex = 9;
            this.lblThreadCount.Text = "Thread count";
            // 
            // cbThreadCount
            // 
            this.cbThreadCount.FormattingEnabled = true;
            this.cbThreadCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThreadCount.Location = new System.Drawing.Point(7, 20);
            this.cbThreadCount.Name = "cbThreadCount";
            this.cbThreadCount.Size = new System.Drawing.Size(77, 21);
            this.cbThreadCount.TabIndex = 8;
            this.cbThreadCount.Text = "1";
            this.toolTip1.SetToolTip(this.cbThreadCount, "The number of threads that will be spawned  to fullfill the task");
            // 
            // tbGroupIntervalTime
            // 
            this.tbGroupIntervalTime.Location = new System.Drawing.Point(6, 57);
            this.tbGroupIntervalTime.Name = "tbGroupIntervalTime";
            this.tbGroupIntervalTime.Size = new System.Drawing.Size(78, 20);
            this.tbGroupIntervalTime.TabIndex = 7;
            this.tbGroupIntervalTime.Text = "500";
            this.toolTip1.SetToolTip(this.tbGroupIntervalTime, "the group of threads will be run in such intervalls(makes sense when many events," +
        " and few threads that will process the queue)");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Time intervall (ms.)";
            // 
            // cbRunAsync
            // 
            this.cbRunAsync.AutoSize = true;
            this.cbRunAsync.Location = new System.Drawing.Point(461, 452);
            this.cbRunAsync.Name = "cbRunAsync";
            this.cbRunAsync.Size = new System.Drawing.Size(90, 17);
            this.cbRunAsync.TabIndex = 5;
            this.cbRunAsync.Text = "Multithreaded";
            this.toolTip1.SetToolTip(this.cbRunAsync, "The process that will be invoked on these event will run asynchronously in a dedi" +
        "cated thread");
            this.cbRunAsync.UseVisualStyleBackColor = true;
            this.cbRunAsync.CheckedChanged += new System.EventHandler(this.cbRunAsync_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Arguments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Path";
            // 
            // textBoxExecutableArguments
            // 
            this.textBoxExecutableArguments.Location = new System.Drawing.Point(6, 59);
            this.textBoxExecutableArguments.Multiline = true;
            this.textBoxExecutableArguments.Name = "textBoxExecutableArguments";
            this.textBoxExecutableArguments.Size = new System.Drawing.Size(293, 45);
            this.textBoxExecutableArguments.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxExecutableArguments, "Arguments to the executble. You can pass over the file that caused the event by a" +
        "dding {0} to the arguments list.");
            // 
            // buttonFindExecutable
            // 
            this.buttonFindExecutable.Location = new System.Drawing.Point(275, 16);
            this.buttonFindExecutable.Name = "buttonFindExecutable";
            this.buttonFindExecutable.Size = new System.Drawing.Size(22, 23);
            this.buttonFindExecutable.TabIndex = 1;
            this.buttonFindExecutable.Text = "...";
            this.buttonFindExecutable.UseVisualStyleBackColor = true;
            this.buttonFindExecutable.Click += new System.EventHandler(this.buttonFindExecutable_Click);
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(6, 18);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(263, 20);
            this.textBoxExecutable.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxExecutable, "Path to the executable that will be called if one of the pre-configured events oc" +
        "urrs.\r\nThis exe will be run in synchronous mode, that is will wait for the proce" +
        "ss to return.");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFolderPath);
            this.groupBox3.Location = new System.Drawing.Point(461, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 57);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Folder Path";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(6, 19);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(293, 20);
            this.textBoxFolderPath.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxFolderPath, "Path to the folder that is  part of this profile. This folder will be watched for" +
        " the desired events.");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Service state:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 604);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // checkBoxLogErrorOnly
            // 
            this.checkBoxLogErrorOnly.AutoSize = true;
            this.checkBoxLogErrorOnly.Location = new System.Drawing.Point(461, 581);
            this.checkBoxLogErrorOnly.Name = "checkBoxLogErrorOnly";
            this.checkBoxLogErrorOnly.Size = new System.Drawing.Size(91, 17);
            this.checkBoxLogErrorOnly.TabIndex = 10;
            this.checkBoxLogErrorOnly.Text = "log errors only";
            this.toolTip1.SetToolTip(this.checkBoxLogErrorOnly, "Will log errors only, verbose mode otherwise.");
            this.checkBoxLogErrorOnly.UseVisualStyleBackColor = true;
            this.checkBoxLogErrorOnly.CheckedChanged += new System.EventHandler(this.checkBoxLogErrorOnly_CheckedChanged);
            // 
            // tbPOSTParameter
            // 
            this.tbPOSTParameter.Location = new System.Drawing.Point(3, 63);
            this.tbPOSTParameter.Multiline = true;
            this.tbPOSTParameter.Name = "tbPOSTParameter";
            this.tbPOSTParameter.Size = new System.Drawing.Size(296, 45);
            this.tbPOSTParameter.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbPOSTParameter, "JSON object that will be POSTed to the Web Endpoint");
            // 
            // tbBaseURL
            // 
            this.tbBaseURL.Location = new System.Drawing.Point(4, 22);
            this.tbBaseURL.Name = "tbBaseURL";
            this.tbBaseURL.Size = new System.Drawing.Size(295, 20);
            this.tbBaseURL.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbBaseURL, "This Web API endpoint will be informed(per POST only) about the events of the Fil" +
        "eSystemWatcher");
            // 
            // cbWaitToReturn
            // 
            this.cbWaitToReturn.AutoSize = true;
            this.cbWaitToReturn.Location = new System.Drawing.Point(682, 452);
            this.cbWaitToReturn.Name = "cbWaitToReturn";
            this.cbWaitToReturn.Size = new System.Drawing.Size(82, 17);
            this.cbWaitToReturn.TabIndex = 12;
            this.cbWaitToReturn.Text = "Wait for exit";
            this.toolTip1.SetToolTip(this.cbWaitToReturn, "if checked, the execution will wait for the started process to return");
            this.cbWaitToReturn.UseVisualStyleBackColor = true;
            // 
            // tabWebAPI
            // 
            this.tabWebAPI.Controls.Add(this.tbPOSTParameter);
            this.tabWebAPI.Controls.Add(this.lblPOST);
            this.tabWebAPI.Controls.Add(this.tbBaseURL);
            this.tabWebAPI.Controls.Add(this.lblBaseURL);
            this.tabWebAPI.Location = new System.Drawing.Point(4, 22);
            this.tabWebAPI.Name = "tabWebAPI";
            this.tabWebAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebAPI.Size = new System.Drawing.Size(310, 114);
            this.tabWebAPI.TabIndex = 1;
            this.tabWebAPI.Text = "Web API";
            this.tabWebAPI.UseVisualStyleBackColor = true;
            // 
            // lblPOST
            // 
            this.lblPOST.AutoSize = true;
            this.lblPOST.Location = new System.Drawing.Point(3, 45);
            this.lblPOST.Name = "lblPOST";
            this.lblPOST.Size = new System.Drawing.Size(87, 13);
            this.lblPOST.TabIndex = 2;
            this.lblPOST.Text = "POST Parameter";
            // 
            // lblBaseURL
            // 
            this.lblBaseURL.AutoSize = true;
            this.lblBaseURL.Location = new System.Drawing.Point(2, 3);
            this.lblBaseURL.Name = "lblBaseURL";
            this.lblBaseURL.Size = new System.Drawing.Size(56, 13);
            this.lblBaseURL.TabIndex = 0;
            this.lblBaseURL.Text = "Base URL";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExecutable);
            this.tabControl1.Controls.Add(this.tabWebAPI);
            this.tabControl1.Location = new System.Drawing.Point(460, 303);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 140);
            this.tabControl1.TabIndex = 11;
            // 
            // tabExecutable
            // 
            this.tabExecutable.Controls.Add(this.label3);
            this.tabExecutable.Controls.Add(this.textBoxExecutable);
            this.tabExecutable.Controls.Add(this.buttonFindExecutable);
            this.tabExecutable.Controls.Add(this.label4);
            this.tabExecutable.Controls.Add(this.textBoxExecutableArguments);
            this.tabExecutable.Location = new System.Drawing.Point(4, 22);
            this.tabExecutable.Name = "tabExecutable";
            this.tabExecutable.Padding = new System.Windows.Forms.Padding(3);
            this.tabExecutable.Size = new System.Drawing.Size(310, 114);
            this.tabExecutable.TabIndex = 0;
            this.tabExecutable.Text = "Executable";
            this.tabExecutable.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(793, 644);
            this.Controls.Add(this.cbWaitToReturn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBoxLogErrorOnly);
            this.Controls.Add(this.cbRunAsync);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupSynchronisation);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEventsAndOptions);
            this.Controls.Add(this.groupBoxWatchFolders);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(809, 683);
            this.MinimumSize = new System.Drawing.Size(809, 683);
            this.Name = "ConfigForm";
            this.Text = "Configuration form for WuFFolderWatcher";
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.groupBoxWatchFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWatchedFolders)).EndInit();
            this.groupBoxEventsAndOptions.ResumeLayout(false);
            this.groupBoxEventsAndOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupSynchronisation.ResumeLayout(false);
            this.groupSynchronisation.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabWebAPI.ResumeLayout(false);
            this.tabWebAPI.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabExecutable.ResumeLayout(false);
            this.tabExecutable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxWatchFolders;
        private System.Windows.Forms.Button butAddWatchFolder;
        private System.Windows.Forms.GroupBox groupBoxEventsAndOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxRenameFiles;
        private System.Windows.Forms.CheckBox checkBoxDeleteFile;
        private System.Windows.Forms.CheckBox checkBoxModifyFiles;
        private System.Windows.Forms.CheckBox checkBoxNewFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFileFilters;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupSynchronisation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExecutableArguments;
        private System.Windows.Forms.Button buttonFindExecutable;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.DataGridView dataGridWatchedFolders;
        private System.Windows.Forms.Button buttonRemoveFromList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxLogErrorOnly;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton radButFolders;
        private System.Windows.Forms.RadioButton radButFiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbRunAsync;
        private System.Windows.Forms.TextBox tbGroupIntervalTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabWebAPI;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExecutable;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.ComboBox cbThreadCount;
        private System.Windows.Forms.TextBox tbPOSTParameter;
        private System.Windows.Forms.Label lblPOST;
        private System.Windows.Forms.TextBox tbBaseURL;
        private System.Windows.Forms.Label lblBaseURL;
        private System.Windows.Forms.CheckBox cbWaitToReturn;
    }
}