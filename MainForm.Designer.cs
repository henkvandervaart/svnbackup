namespace svnbackup
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textWorkingCopyFolder = new System.Windows.Forms.TextBox();
            this.groupBackupSettings = new System.Windows.Forms.GroupBox();
            this.labelArchiveExample = new System.Windows.Forms.Label();
            this.labelNumberOfFilesToKeep = new System.Windows.Forms.Label();
            this.numericUpDownFilesToKeep = new System.Windows.Forms.NumericUpDown();
            this.labelArchiveFileName = new System.Windows.Forms.Label();
            this.textArchiveFileName = new System.Windows.Forms.TextBox();
            this.labelExcept = new System.Windows.Forms.Label();
            this.textExcludeUnversionedExceptions = new System.Windows.Forms.TextBox();
            this.buttonBrowseBackupFolder = new System.Windows.Forms.Button();
            this.buttonBrowseWorkingFolder = new System.Windows.Forms.Button();
            this.labelTargetBackupFolder = new System.Windows.Forms.Label();
            this.textTargetBackupFolder = new System.Windows.Forms.TextBox();
            this.chkExcludeIgnoredFiles = new System.Windows.Forms.CheckBox();
            this.chkExcludeUnversionedFiles = new System.Windows.Forms.CheckBox();
            this.chkExcludeIgnoreOnCommit = new System.Windows.Forms.CheckBox();
            this.labelWorkingCopyFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.listViewModifications = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelCountSummary = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelRunningAction = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureProgress = new System.Windows.Forms.PictureBox();
            this.groupBackupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilesToKeep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // textWorkingCopyFolder
            // 
            this.textWorkingCopyFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textWorkingCopyFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textWorkingCopyFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.errorProvider.SetIconAlignment(this.textWorkingCopyFolder, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textWorkingCopyFolder.Location = new System.Drawing.Point(18, 38);
            this.textWorkingCopyFolder.Name = "textWorkingCopyFolder";
            this.textWorkingCopyFolder.Size = new System.Drawing.Size(457, 20);
            this.textWorkingCopyFolder.TabIndex = 0;
            this.textWorkingCopyFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textWorkingCopyFolder_KeyDown);
            this.textWorkingCopyFolder.Validating += new System.ComponentModel.CancelEventHandler(this.textWorkingCopyFolder_Validating);
            this.textWorkingCopyFolder.Validated += new System.EventHandler(this.textWorkingCopyFolder_Validated);
            // 
            // groupBackupSettings
            // 
            this.groupBackupSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBackupSettings.Controls.Add(this.labelArchiveExample);
            this.groupBackupSettings.Controls.Add(this.labelNumberOfFilesToKeep);
            this.groupBackupSettings.Controls.Add(this.numericUpDownFilesToKeep);
            this.groupBackupSettings.Controls.Add(this.labelArchiveFileName);
            this.groupBackupSettings.Controls.Add(this.textArchiveFileName);
            this.groupBackupSettings.Controls.Add(this.labelExcept);
            this.groupBackupSettings.Controls.Add(this.textExcludeUnversionedExceptions);
            this.groupBackupSettings.Controls.Add(this.buttonBrowseBackupFolder);
            this.groupBackupSettings.Controls.Add(this.buttonBrowseWorkingFolder);
            this.groupBackupSettings.Controls.Add(this.labelTargetBackupFolder);
            this.groupBackupSettings.Controls.Add(this.textTargetBackupFolder);
            this.groupBackupSettings.Controls.Add(this.chkExcludeIgnoredFiles);
            this.groupBackupSettings.Controls.Add(this.chkExcludeUnversionedFiles);
            this.groupBackupSettings.Controls.Add(this.chkExcludeIgnoreOnCommit);
            this.groupBackupSettings.Controls.Add(this.labelWorkingCopyFolder);
            this.groupBackupSettings.Controls.Add(this.textWorkingCopyFolder);
            this.groupBackupSettings.Location = new System.Drawing.Point(13, 7);
            this.groupBackupSettings.Name = "groupBackupSettings";
            this.groupBackupSettings.Size = new System.Drawing.Size(527, 195);
            this.groupBackupSettings.TabIndex = 1;
            this.groupBackupSettings.TabStop = false;
            this.groupBackupSettings.Text = "Backup Settings";
            // 
            // labelArchiveExample
            // 
            this.labelArchiveExample.AutoSize = true;
            this.labelArchiveExample.Location = new System.Drawing.Point(131, 167);
            this.labelArchiveExample.Name = "labelArchiveExample";
            this.labelArchiveExample.Size = new System.Drawing.Size(111, 13);
            this.labelArchiveExample.TabIndex = 15;
            this.labelArchiveExample.Text = "_yyMMddHHmmss.zip";
            // 
            // labelNumberOfFilesToKeep
            // 
            this.labelNumberOfFilesToKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberOfFilesToKeep.AutoSize = true;
            this.labelNumberOfFilesToKeep.Location = new System.Drawing.Point(324, 167);
            this.labelNumberOfFilesToKeep.Name = "labelNumberOfFilesToKeep";
            this.labelNumberOfFilesToKeep.Size = new System.Drawing.Size(116, 13);
            this.labelNumberOfFilesToKeep.TabIndex = 14;
            this.labelNumberOfFilesToKeep.Text = "Number of files to keep";
            // 
            // numericUpDownFilesToKeep
            // 
            this.numericUpDownFilesToKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFilesToKeep.Location = new System.Drawing.Point(446, 164);
            this.numericUpDownFilesToKeep.Name = "numericUpDownFilesToKeep";
            this.numericUpDownFilesToKeep.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownFilesToKeep.TabIndex = 13;
            this.numericUpDownFilesToKeep.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // labelArchiveFileName
            // 
            this.labelArchiveFileName.AutoSize = true;
            this.labelArchiveFileName.Location = new System.Drawing.Point(18, 149);
            this.labelArchiveFileName.Name = "labelArchiveFileName";
            this.labelArchiveFileName.Size = new System.Drawing.Size(85, 13);
            this.labelArchiveFileName.TabIndex = 12;
            this.labelArchiveFileName.Text = "Archive filename";
            // 
            // textArchiveFileName
            // 
            this.textArchiveFileName.Location = new System.Drawing.Point(21, 164);
            this.textArchiveFileName.Name = "textArchiveFileName";
            this.textArchiveFileName.Size = new System.Drawing.Size(110, 20);
            this.textArchiveFileName.TabIndex = 11;
            this.textArchiveFileName.Text = "svnbackup";
            // 
            // labelExcept
            // 
            this.labelExcept.AutoSize = true;
            this.labelExcept.Location = new System.Drawing.Point(162, 82);
            this.labelExcept.Name = "labelExcept";
            this.labelExcept.Size = new System.Drawing.Size(54, 13);
            this.labelExcept.TabIndex = 10;
            this.labelExcept.Text = "... except:";
            // 
            // textExcludeUnversionedExceptions
            // 
            this.textExcludeUnversionedExceptions.Location = new System.Drawing.Point(218, 79);
            this.textExcludeUnversionedExceptions.Name = "textExcludeUnversionedExceptions";
            this.textExcludeUnversionedExceptions.Size = new System.Drawing.Size(129, 20);
            this.textExcludeUnversionedExceptions.TabIndex = 9;
            this.textExcludeUnversionedExceptions.Text = "*.cs, *.vb";
            this.toolTip.SetToolTip(this.textExcludeUnversionedExceptions, "Comma separated list of file extensions not to be excluded from backup");
            this.textExcludeUnversionedExceptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textExcludeUnversionedExceptions_KeyDown);
            // 
            // buttonBrowseBackupFolder
            // 
            this.buttonBrowseBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseBackupFolder.CausesValidation = false;
            this.buttonBrowseBackupFolder.Location = new System.Drawing.Point(482, 122);
            this.buttonBrowseBackupFolder.Name = "buttonBrowseBackupFolder";
            this.buttonBrowseBackupFolder.Size = new System.Drawing.Size(28, 20);
            this.buttonBrowseBackupFolder.TabIndex = 8;
            this.buttonBrowseBackupFolder.Text = "...";
            this.buttonBrowseBackupFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseBackupFolder.Click += new System.EventHandler(this.buttonBrowseBackupFolder_Click);
            // 
            // buttonBrowseWorkingFolder
            // 
            this.buttonBrowseWorkingFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseWorkingFolder.CausesValidation = false;
            this.buttonBrowseWorkingFolder.Location = new System.Drawing.Point(482, 38);
            this.buttonBrowseWorkingFolder.Name = "buttonBrowseWorkingFolder";
            this.buttonBrowseWorkingFolder.Size = new System.Drawing.Size(28, 20);
            this.buttonBrowseWorkingFolder.TabIndex = 7;
            this.buttonBrowseWorkingFolder.Text = "...";
            this.buttonBrowseWorkingFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseWorkingFolder.Click += new System.EventHandler(this.buttonBrowseWorkingFolder_Click);
            // 
            // labelTargetBackupFolder
            // 
            this.labelTargetBackupFolder.AutoSize = true;
            this.labelTargetBackupFolder.Location = new System.Drawing.Point(18, 107);
            this.labelTargetBackupFolder.Name = "labelTargetBackupFolder";
            this.labelTargetBackupFolder.Size = new System.Drawing.Size(120, 13);
            this.labelTargetBackupFolder.TabIndex = 6;
            this.labelTargetBackupFolder.Text = "Target backup directory";
            // 
            // textTargetBackupFolder
            // 
            this.textTargetBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconAlignment(this.textTargetBackupFolder, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textTargetBackupFolder.Location = new System.Drawing.Point(21, 123);
            this.textTargetBackupFolder.Name = "textTargetBackupFolder";
            this.textTargetBackupFolder.Size = new System.Drawing.Size(457, 20);
            this.textTargetBackupFolder.TabIndex = 5;
            this.textTargetBackupFolder.TextChanged += new System.EventHandler(this.textTargetBackupFolder_TextChanged);
            this.textTargetBackupFolder.Validating += new System.ComponentModel.CancelEventHandler(this.textTargetBackupFolder_Validating);
            this.textTargetBackupFolder.Validated += new System.EventHandler(this.textTargetBackupFolder_Validated);
            // 
            // chkExcludeIgnoredFiles
            // 
            this.chkExcludeIgnoredFiles.AutoSize = true;
            this.chkExcludeIgnoredFiles.Checked = true;
            this.chkExcludeIgnoredFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeIgnoredFiles.Location = new System.Drawing.Point(218, 62);
            this.chkExcludeIgnoredFiles.Name = "chkExcludeIgnoredFiles";
            this.chkExcludeIgnoredFiles.Size = new System.Drawing.Size(129, 17);
            this.chkExcludeIgnoredFiles.TabIndex = 4;
            this.chkExcludeIgnoredFiles.Text = "Exclude ‘ignored’ files";
            this.chkExcludeIgnoredFiles.UseVisualStyleBackColor = true;
            this.chkExcludeIgnoredFiles.CheckedChanged += new System.EventHandler(this.chkExcludeIgnoredFiles_CheckedChanged);
            // 
            // chkExcludeUnversionedFiles
            // 
            this.chkExcludeUnversionedFiles.AutoSize = true;
            this.chkExcludeUnversionedFiles.Checked = true;
            this.chkExcludeUnversionedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeUnversionedFiles.Location = new System.Drawing.Point(18, 81);
            this.chkExcludeUnversionedFiles.Name = "chkExcludeUnversionedFiles";
            this.chkExcludeUnversionedFiles.Size = new System.Drawing.Size(150, 17);
            this.chkExcludeUnversionedFiles.TabIndex = 3;
            this.chkExcludeUnversionedFiles.Text = "Exclude \'unversioned\' files";
            this.chkExcludeUnversionedFiles.UseVisualStyleBackColor = true;
            this.chkExcludeUnversionedFiles.CheckedChanged += new System.EventHandler(this.chkExcludeUnversionedFiles_CheckedChanged);
            // 
            // chkExcludeIgnoreOnCommit
            // 
            this.chkExcludeIgnoreOnCommit.AutoSize = true;
            this.chkExcludeIgnoreOnCommit.Checked = true;
            this.chkExcludeIgnoreOnCommit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeIgnoreOnCommit.Location = new System.Drawing.Point(18, 62);
            this.chkExcludeIgnoreOnCommit.Name = "chkExcludeIgnoreOnCommit";
            this.chkExcludeIgnoreOnCommit.Size = new System.Drawing.Size(151, 17);
            this.chkExcludeIgnoreOnCommit.TabIndex = 2;
            this.chkExcludeIgnoreOnCommit.Text = "Exclude \'ignore-on-commit\'";
            this.chkExcludeIgnoreOnCommit.UseVisualStyleBackColor = true;
            this.chkExcludeIgnoreOnCommit.CheckedChanged += new System.EventHandler(this.chkExcludeIgnoreOnCommit_CheckedChanged);
            // 
            // labelWorkingCopyFolder
            // 
            this.labelWorkingCopyFolder.AutoSize = true;
            this.labelWorkingCopyFolder.Location = new System.Drawing.Point(15, 23);
            this.labelWorkingCopyFolder.Name = "labelWorkingCopyFolder";
            this.labelWorkingCopyFolder.Size = new System.Drawing.Size(116, 13);
            this.labelWorkingCopyFolder.TabIndex = 1;
            this.labelWorkingCopyFolder.Text = "Working copy directory";
            // 
            // buttonBackup
            // 
            this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackup.Location = new System.Drawing.Point(448, 213);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 2;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(366, 213);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // listViewModifications
            // 
            this.listViewModifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewModifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewModifications.Location = new System.Drawing.Point(13, 246);
            this.listViewModifications.Name = "listViewModifications";
            this.listViewModifications.Size = new System.Drawing.Size(527, 235);
            this.listViewModifications.TabIndex = 4;
            this.listViewModifications.UseCompatibleStateImageBehavior = false;
            this.listViewModifications.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 339;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Extension";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 107;
            // 
            // labelCountSummary
            // 
            this.labelCountSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCountSummary.Location = new System.Drawing.Point(13, 489);
            this.labelCountSummary.Name = "labelCountSummary";
            this.labelCountSummary.Size = new System.Drawing.Size(527, 18);
            this.labelCountSummary.TabIndex = 5;
            this.labelCountSummary.Text = "non-versioned=0, modified=0, added=0, ignored=0, ignore-on-commit=0, backup=0";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // labelRunningAction
            // 
            this.labelRunningAction.AutoSize = true;
            this.labelRunningAction.Location = new System.Drawing.Point(45, 218);
            this.labelRunningAction.Name = "labelRunningAction";
            this.labelRunningAction.Size = new System.Drawing.Size(110, 13);
            this.labelRunningAction.TabIndex = 7;
            this.labelRunningAction.Text = "Last backup archive: ";
            // 
            // pictureProgress
            // 
            this.pictureProgress.Image = global::svnbackup.Properties.Resources.InProgress_24;
            this.pictureProgress.Location = new System.Drawing.Point(17, 211);
            this.pictureProgress.Name = "pictureProgress";
            this.pictureProgress.Size = new System.Drawing.Size(24, 24);
            this.pictureProgress.TabIndex = 8;
            this.pictureProgress.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 515);
            this.Controls.Add(this.pictureProgress);
            this.Controls.Add(this.labelRunningAction);
            this.Controls.Add(this.labelCountSummary);
            this.Controls.Add(this.listViewModifications);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.groupBackupSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subversion Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBackupSettings.ResumeLayout(false);
            this.groupBackupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilesToKeep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textWorkingCopyFolder;
        private System.Windows.Forms.GroupBox groupBackupSettings;
        private System.Windows.Forms.Button buttonBrowseBackupFolder;
        private System.Windows.Forms.Button buttonBrowseWorkingFolder;
        private System.Windows.Forms.Label labelTargetBackupFolder;
        private System.Windows.Forms.TextBox textTargetBackupFolder;
        private System.Windows.Forms.CheckBox chkExcludeIgnoredFiles;
        private System.Windows.Forms.CheckBox chkExcludeUnversionedFiles;
        private System.Windows.Forms.CheckBox chkExcludeIgnoreOnCommit;
        private System.Windows.Forms.Label labelWorkingCopyFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ListView listViewModifications;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelCountSummary;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelRunningAction;
        private System.Windows.Forms.Label labelExcept;
        private System.Windows.Forms.TextBox textExcludeUnversionedExceptions;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelArchiveFileName;
        private System.Windows.Forms.TextBox textArchiveFileName;
        private System.Windows.Forms.Label labelNumberOfFilesToKeep;
        private System.Windows.Forms.NumericUpDown numericUpDownFilesToKeep;
        private System.Windows.Forms.Label labelArchiveExample;
        private System.Windows.Forms.PictureBox pictureProgress;
    }
}

