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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.buttonStartService = new System.Windows.Forms.Button();
            this.checkBoxLogErrorOnly = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxWatchFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWatchedFolders)).BeginInit();
            this.groupBoxEventsAndOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWatchFolders
            // 
            this.groupBoxWatchFolders.Controls.Add(this.buttonRemoveFromList);
            this.groupBoxWatchFolders.Controls.Add(this.dataGridWatchedFolders);
            this.groupBoxWatchFolders.Controls.Add(this.butAddWatchFolder);
            this.groupBoxWatchFolders.Location = new System.Drawing.Point(8, 12);
            this.groupBoxWatchFolders.Name = "groupBoxWatchFolders";
            this.groupBoxWatchFolders.Size = new System.Drawing.Size(433, 565);
            this.groupBoxWatchFolders.TabIndex = 0;
            this.groupBoxWatchFolders.TabStop = false;
            this.groupBoxWatchFolders.Text = "Watched Folders";
            // 
            // buttonRemoveFromList
            // 
            this.buttonRemoveFromList.Location = new System.Drawing.Point(12, 523);
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
            this.dataGridWatchedFolders.Size = new System.Drawing.Size(405, 498);
            this.dataGridWatchedFolders.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dataGridWatchedFolders, resources.GetString("dataGridWatchedFolders.ToolTip"));
            this.dataGridWatchedFolders.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridWatchedFolders_CellValueChanged);
            this.dataGridWatchedFolders.SelectionChanged += new System.EventHandler(this.dataGridWatchedFolders_SelectionChanged);
            // 
            // butAddWatchFolder
            // 
            this.butAddWatchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddWatchFolder.Location = new System.Drawing.Point(269, 523);
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
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxIncludeSubFolders);
            this.groupBoxEventsAndOptions.Controls.Add(this.label2);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxRenameFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxDeleteFile);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxModifyFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.checkBoxNewFiles);
            this.groupBoxEventsAndOptions.Controls.Add(this.label1);
            this.groupBoxEventsAndOptions.Location = new System.Drawing.Point(460, 71);
            this.groupBoxEventsAndOptions.Name = "groupBoxEventsAndOptions";
            this.groupBoxEventsAndOptions.Size = new System.Drawing.Size(317, 172);
            this.groupBoxEventsAndOptions.TabIndex = 1;
            this.groupBoxEventsAndOptions.TabStop = false;
            this.groupBoxEventsAndOptions.Text = "Events and Options";
            this.toolTip1.SetToolTip(this.groupBoxEventsAndOptions, "Config events and options for the watched folder.");
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
            this.checkBoxRenameFiles.Location = new System.Drawing.Point(79, 63);
            this.checkBoxRenameFiles.Name = "checkBoxRenameFiles";
            this.checkBoxRenameFiles.Size = new System.Drawing.Size(96, 17);
            this.checkBoxRenameFiles.TabIndex = 4;
            this.checkBoxRenameFiles.Text = "Renamed Files";
            this.toolTip1.SetToolTip(this.checkBoxRenameFiles, "Watch for renamed files only.");
            this.checkBoxRenameFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteFile
            // 
            this.checkBoxDeleteFile.AutoSize = true;
            this.checkBoxDeleteFile.Location = new System.Drawing.Point(191, 63);
            this.checkBoxDeleteFile.Name = "checkBoxDeleteFile";
            this.checkBoxDeleteFile.Size = new System.Drawing.Size(87, 17);
            this.checkBoxDeleteFile.TabIndex = 3;
            this.checkBoxDeleteFile.Text = "Deleted Files";
            this.toolTip1.SetToolTip(this.checkBoxDeleteFile, "Watch if any files in this folders has been deleted.");
            this.checkBoxDeleteFile.UseVisualStyleBackColor = true;
            this.checkBoxDeleteFile.CheckedChanged += new System.EventHandler(this.checkBoxDeleteFile_CheckedChanged);
            // 
            // checkBoxModifyFiles
            // 
            this.checkBoxModifyFiles.AutoSize = true;
            this.checkBoxModifyFiles.Location = new System.Drawing.Point(190, 28);
            this.checkBoxModifyFiles.Name = "checkBoxModifyFiles";
            this.checkBoxModifyFiles.Size = new System.Drawing.Size(90, 17);
            this.checkBoxModifyFiles.TabIndex = 2;
            this.checkBoxModifyFiles.Text = "Modified Files";
            this.toolTip1.SetToolTip(this.checkBoxModifyFiles, "Watch for modifed files only. Modification implies name,extension and content mod" +
        "ification.");
            this.checkBoxModifyFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxNewFiles
            // 
            this.checkBoxNewFiles.AutoSize = true;
            this.checkBoxNewFiles.Location = new System.Drawing.Point(79, 28);
            this.checkBoxNewFiles.Name = "checkBoxNewFiles";
            this.checkBoxNewFiles.Size = new System.Drawing.Size(72, 17);
            this.checkBoxNewFiles.TabIndex = 1;
            this.checkBoxNewFiles.Text = "New Files";
            this.toolTip1.SetToolTip(this.checkBoxNewFiles, "Watch for new files only.");
            this.checkBoxNewFiles.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Events: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFileFilters);
            this.groupBox1.Location = new System.Drawing.Point(460, 249);
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
            this.buttonCancel.Location = new System.Drawing.Point(607, 535);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(703, 535);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 36);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxExecutableArguments);
            this.groupBox2.Controls.Add(this.buttonFindExecutable);
            this.groupBox2.Controls.Add(this.textBoxExecutable);
            this.groupBox2.Location = new System.Drawing.Point(461, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 180);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Executable";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Arguments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Path";
            // 
            // textBoxExecutableArguments
            // 
            this.textBoxExecutableArguments.Location = new System.Drawing.Point(6, 100);
            this.textBoxExecutableArguments.Multiline = true;
            this.textBoxExecutableArguments.Name = "textBoxExecutableArguments";
            this.textBoxExecutableArguments.Size = new System.Drawing.Size(264, 72);
            this.textBoxExecutableArguments.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxExecutableArguments, "Arguments to the executble. You can pass over the file that caused the event by a" +
        "dding {0} to the arguments list.");
            // 
            // buttonFindExecutable
            // 
            this.buttonFindExecutable.Location = new System.Drawing.Point(276, 46);
            this.buttonFindExecutable.Name = "buttonFindExecutable";
            this.buttonFindExecutable.Size = new System.Drawing.Size(21, 23);
            this.buttonFindExecutable.TabIndex = 1;
            this.buttonFindExecutable.Text = "...";
            this.buttonFindExecutable.UseVisualStyleBackColor = true;
            this.buttonFindExecutable.Click += new System.EventHandler(this.buttonFindExecutable_Click);
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(5, 46);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(264, 20);
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
            this.label5.Location = new System.Drawing.Point(458, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Service state:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // buttonStartService
            // 
            this.buttonStartService.Enabled = false;
            this.buttonStartService.Location = new System.Drawing.Point(503, 535);
            this.buttonStartService.Name = "buttonStartService";
            this.buttonStartService.Size = new System.Drawing.Size(75, 36);
            this.buttonStartService.TabIndex = 9;
            this.buttonStartService.Text = "Start service";
            this.buttonStartService.UseVisualStyleBackColor = true;
            this.buttonStartService.Visible = false;
            this.buttonStartService.Click += new System.EventHandler(this.buttonStartService_Click);
            // 
            // checkBoxLogErrorOnly
            // 
            this.checkBoxLogErrorOnly.AutoSize = true;
            this.checkBoxLogErrorOnly.Location = new System.Drawing.Point(686, 495);
            this.checkBoxLogErrorOnly.Name = "checkBoxLogErrorOnly";
            this.checkBoxLogErrorOnly.Size = new System.Drawing.Size(91, 17);
            this.checkBoxLogErrorOnly.TabIndex = 10;
            this.checkBoxLogErrorOnly.Text = "log errors only";
            this.toolTip1.SetToolTip(this.checkBoxLogErrorOnly, "Will log errors only, verbose mode otherwise.");
            this.checkBoxLogErrorOnly.UseVisualStyleBackColor = true;
            this.checkBoxLogErrorOnly.CheckedChanged += new System.EventHandler(this.checkBoxLogErrorOnly_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(790, 594);
            this.Controls.Add(this.checkBoxLogErrorOnly);
            this.Controls.Add(this.buttonStartService);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEventsAndOptions);
            this.Controls.Add(this.groupBoxWatchFolders);
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Configuration form for WuFFolderWatcher";
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.groupBoxWatchFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWatchedFolders)).EndInit();
            this.groupBoxEventsAndOptions.ResumeLayout(false);
            this.groupBoxEventsAndOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Button buttonStartService;
        private System.Windows.Forms.CheckBox checkBoxLogErrorOnly;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}