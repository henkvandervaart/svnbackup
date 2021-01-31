using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SharpSvn;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using System.Reflection;

namespace svnbackup
{
    public partial class MainForm : Form
    {
        SvnStatusCollection statusCollection = new SvnStatusCollection(); 

        bool validSvnWorkingFolder = false;
        bool svnStatusesRetrieved = false;
        string currentSvnWorkingFolder = String.Empty;

        public MainForm()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                Version applicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                this.Text = String.Format("Subversion Backup - Version {0}.{1:D3}", applicationVersion.Major, applicationVersion.Minor);

                labelCountSummary.Text = String.Empty;
                labelRunningAction.Visible = false;     // No running background action yet
                pictureProgress.Image = null;

                // Disable 'Refresh' and 'Backup' buttons since no SVN statuses get yet
                buttonRefresh.Enabled = false;
                buttonBackup.Enabled = false;

                // Read persisted settings and populate it into related controls
                ReadSettings();

                // If we already have a valid SVN workfolder then retrieve its statuses
                if (IsSvnWorkingFolder(textWorkingCopyFolder.Text))
                {
                    validSvnWorkingFolder = true;
                    currentSvnWorkingFolder = textWorkingCopyFolder.Text;

                    RetrieveSubversionStatuses();
                }
                this.ValidateChildren(ValidationConstraints.Enabled);
            }
            catch(Exception)
            {
            }
        }

        /// <summary>
        /// Load 'last run'persisted application settings 
        /// </summary>
        private void ReadSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            textExcludeUnversionedExceptions.Text = config.AppSettings.Settings["ExcludeUnversionedExceptions"].Value;
            textWorkingCopyFolder.Text = config.AppSettings.Settings["SvnWorkingFolder"].Value;
            string backupFolder = config.AppSettings.Settings["TargetBackupFolder"].Value;
            textTargetBackupFolder.Text = IsDirectory(backupFolder) ? backupFolder : Environment.CurrentDirectory;
            textArchiveFileName.Text = config.AppSettings.Settings["TargetBaseFileName"].Value;

            int numberValue = 0;
            Int32.TryParse(config.AppSettings.Settings["NumberOfFilesToKeep"].Value, out numberValue);
            numericUpDownFilesToKeep.Value = numberValue;

            bool value;
            Boolean.TryParse(config.AppSettings.Settings["ExcludeIgnoreOnCommit"].Value, out value);
            chkExcludeIgnoreOnCommit.Checked = value;
            Boolean.TryParse(config.AppSettings.Settings["ExcludeIgnoredFiles"].Value, out value);
            chkExcludeIgnoredFiles.Checked = value;
            Boolean.TryParse(config.AppSettings.Settings["ExcludeUnversionedFiles"].Value, out value);
            chkExcludeUnversionedFiles.Checked = value;
        }

        private async void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (WaitCursor wc = new WaitCursor(this))
                {
                    groupBackupSettings.Enabled = false;
                    buttonBackup.Enabled = false;
                    buttonRefresh.Enabled = false;

                    string backupFile = String.Format("{0}_{1}.zip", 
                                                      textArchiveFileName.Text,
                                                      DateTime.Now.ToString("yyMMddHHmmss"));

                    labelRunningAction.Text = String.Format("Backup to {0} is in progress ...", backupFile);
                    labelRunningAction.Visible = true;
                    pictureProgress.Image = Properties.Resources.InProgress_24;

                    statusCollection.PurgeBackupFiles(textTargetBackupFolder.Text, textArchiveFileName.Text, (Int32)numericUpDownFilesToKeep.Value);

                    await statusCollection.SaveAsync(Path.Combine(textTargetBackupFolder.Text, backupFile));

                    labelRunningAction.Visible = false;
                    pictureProgress.Image = null;
                    groupBackupSettings.Enabled = true;
                    buttonBackup.Enabled = true;
                    buttonRefresh.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AddModifiedItem(string path, string extension, string status)
        {
            ListViewItem item = new ListViewItem(path);
            item.SubItems.Add(extension);
            item.SubItems.Add(status);

            listViewModifications.Items.Add(item);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RetrieveSubversionStatuses();
        }

        private async void RetrieveSubversionStatuses()
        {
            try
            {
                using (WaitCursor wc = new WaitCursor(this))
                {
                    labelRunningAction.Text = "Checking for local modifications...";
                    labelRunningAction.Visible = true;
                    pictureProgress.Image = Properties.Resources.InProgress_24;
                    groupBackupSettings.Enabled = false;
                    buttonRefresh.Enabled = false;
                    buttonBackup.Enabled = false;

                    await statusCollection.GetStatusesAsync(textWorkingCopyFolder.Text);
                    svnStatusesRetrieved = true;

                    // Populate list view with retrieved statuses and update control emable/disable statuses
                    UpdateListView();
                    buttonRefresh.Enabled = true;
                    buttonBackup.Enabled = true;

                    labelRunningAction.Visible = false;
                    pictureProgress.Image = null;
                    groupBackupSettings.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void UpdateListView()
        {
            listViewModifications.Items.Clear();

            statusCollection.ExcludeIgnored = chkExcludeIgnoredFiles.Checked;
            statusCollection.ExcludeIgnoreOnCommit = chkExcludeIgnoreOnCommit.Checked;
            statusCollection.ExcludeNotVersioned = chkExcludeUnversionedFiles.Checked;
            statusCollection.ExcludeNotVersionedExceptions = textExcludeUnversionedExceptions.Text;

            foreach (SvnStatusEventArgs status in statusCollection.Filtered())
            {
                string modifiedItemPath = status.Path.Substring(textWorkingCopyFolder.TextLength + 1);
                AddModifiedItem(modifiedItemPath,
                                Path.GetExtension(modifiedItemPath),
                                SvnStatusToDisplay(status.LocalNodeStatus));
            }

            labelCountSummary.Text = String.Format("non-versioned={0}, modified={1}, added={2}, ignored={3}, ignore-on-commit={4}, backup={5}",
                                                   statusCollection.NotVersioned,
                                                   statusCollection.Modified,
                                                   statusCollection.Added,
                                                   statusCollection.Ignored,
                                                   statusCollection.IgnoreOnCommit,
                                                   statusCollection.Filtered().Count);
        }

        private string SvnStatusToDisplay(SvnStatus value)
        {
            string display = String.Empty;
            switch (value)
            {
                case SvnStatus.Added:
                    display = "added";
                    break;
                case SvnStatus.Modified:
                    display = "modified";
                    break;
                case SvnStatus.Ignored:
                    display = "ignored";
                    break;
                case SvnStatus.NotVersioned:
                    display = "non-versioned";
                    break;
                default:
                    display = value.ToString();
                    break;
            }
            return display;
        }

        private bool IsDirectory(string path)
        {
            if (String.IsNullOrEmpty(path) || !Directory.Exists(path)) return false;
            bool result = false;
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                result = (attr & FileAttributes.Directory) == FileAttributes.Directory;
            }
            catch (Exception)
            {
            }
            return result;
        }

        private bool IsSvnWorkingFolder(string folder)
        {
            if (String.IsNullOrEmpty(folder)) return false;

            try
            {
                using (var client = new SvnClient())
                {
                    var uri = client.GetUriFromWorkingCopy(folder);

                    return uri != null;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        private void textWorkingCopyFolder_Validating(object sender, CancelEventArgs e)
        {
            if (!IsSvnWorkingFolder(textWorkingCopyFolder.Text))
            {
                e.Cancel = true;
                this.errorProvider.SetError(textWorkingCopyFolder, "Should be a SVN local working copy (sub)folder");

                listViewModifications.Items.Clear();
                buttonRefresh.Enabled = false;
            }
        }

        private void textWorkingCopyFolder_Validated(object sender, EventArgs e)
        {
            try
            {
                // If all conditions have been met, clear the ErrorProvider of errors.
                errorProvider.SetError(textWorkingCopyFolder, "");

                validSvnWorkingFolder = true;
                if (!currentSvnWorkingFolder.Equals(textWorkingCopyFolder.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    RetrieveSubversionStatuses();
                }
            }
            catch(Exception)
            {
            }
        }

        private void chkExcludeUnversionedFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (validSvnWorkingFolder && svnStatusesRetrieved)
            {
                UpdateListView();
            }
        }

        private void chkExcludeIgnoreOnCommit_CheckedChanged(object sender, EventArgs e)
        {
            if (validSvnWorkingFolder && svnStatusesRetrieved)
            {
                UpdateListView();
            }
        }

        private void chkExcludeIgnoredFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (validSvnWorkingFolder && svnStatusesRetrieved)
            {
                UpdateListView();
            }
        }

        private void buttonBrowseBackupFolder_Click(object sender, EventArgs e)
        {
            string defaultSelectedPath = Environment.CurrentDirectory;
            if (IsDirectory(textTargetBackupFolder.Text))
            {
                defaultSelectedPath = textTargetBackupFolder.Text;
            }
            else
            {
                if (!String.IsNullOrEmpty(textWorkingCopyFolder.Text))
                {
                    defaultSelectedPath = Directory.GetParent(textWorkingCopyFolder.Text).FullName;
                }
            }
            folderBrowserDialog.SelectedPath = defaultSelectedPath;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textTargetBackupFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonBrowseWorkingFolder_Click(object sender, EventArgs e)
        {
            string defaultSelectedPath = Environment.CurrentDirectory;
            if (IsDirectory(textWorkingCopyFolder.Text))
            {
                defaultSelectedPath = textWorkingCopyFolder.Text;
            }
            folderBrowserDialog.SelectedPath = defaultSelectedPath;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textWorkingCopyFolder.Text = folderBrowserDialog.SelectedPath;
                // Change focus to enforce via textWorkingCopyFolder_TextChanged validation 
                // for valid SVN folder and when this is the case retrieve the local changes
                textTargetBackupFolder.Focus();     
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["SvnWorkingFolder"].Value = textWorkingCopyFolder.Text;
            config.AppSettings.Settings["TargetBackupFolder"].Value = textTargetBackupFolder.Text;
            config.AppSettings.Settings["TargetBaseFileName"].Value = textArchiveFileName.Text;
            config.AppSettings.Settings["NumberOfFilesToKeep"].Value = numericUpDownFilesToKeep.Value.ToString();

            config.AppSettings.Settings["ExcludeIgnoreOnCommit"].Value = chkExcludeIgnoreOnCommit.Checked.ToString();
            config.AppSettings.Settings["ExcludeIgnoredFiles"].Value = chkExcludeIgnoredFiles.Checked.ToString();
            config.AppSettings.Settings["ExcludeUnversionedFiles"].Value = chkExcludeUnversionedFiles.Checked.ToString();
            config.AppSettings.Settings["ExcludeUnversionedExceptions"].Value = textExcludeUnversionedExceptions.Text;
            config.Save(ConfigurationSaveMode.Minimal);

            e.Cancel = false;
        }

        private void textTargetBackupFolder_TextChanged(object sender, EventArgs e)
        {
            if (!IsDirectory(textTargetBackupFolder.Text))
            {
                this.errorProvider.SetError(textTargetBackupFolder, "The backup folder location does not exist or is invalid");
            }
            else
            {
                this.errorProvider.SetError(textTargetBackupFolder, "");
            }
        }

        private void textTargetBackupFolder_Validating(object sender, CancelEventArgs e)
        {
            if (!IsDirectory(textTargetBackupFolder.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                this.errorProvider.SetError(textTargetBackupFolder, "The backup folder location does not exist or is invalid");
            }
        }

        private void textTargetBackupFolder_Validated(object sender, EventArgs e)
        {
            // Only enable backup button when validated backup folder and valid SVN folder
            buttonBackup.Enabled = IsSvnWorkingFolder(textWorkingCopyFolder.Text);
        }

        private void textWorkingCopyFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RetrieveSubversionStatuses();
            }
        }

        private void textExcludeUnversionedExceptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (validSvnWorkingFolder && svnStatusesRetrieved)
            {
                UpdateListView();
            }
        }


    }
}
