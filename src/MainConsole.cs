using System;
using System.Threading.Tasks;
using System.IO;

namespace svnbackup
{
    /// <summary>
    /// </summary>
    class MainConsole
    {
        SvnStatusCollection statusCollection = null;

        public MainConsole()
        {
        }

        /// <summary>
        /// Run (executes) the application as a "console like" application (no GUI)
        /// </summary>
        /// <returns>exit code equals 0 when backup succeeded or -1 when it failed</returns>
        internal async Task<int> RunAsync()
        {
            int exitValue = -1;

            try
            {
                if (Program.CommandLine.Argument.Equals("help") ||
                    Program.CommandLine.Argument.Equals("?"))
                {
                    OutputHelp();
                }
                else
                {
                    string subversionFolder = Program.CommandLine.Argument;
                    string backupFolder = Program.CommandLine.TryGetOption("backup-folder", "b");
                    string zipFileBaseName = Program.CommandLine.TryGetOption("file-name", "f");
                    if (String.IsNullOrEmpty(zipFileBaseName))
                    {
                        zipFileBaseName = "svnbackup";
                    }

                    int numberOfFilesToKeep = 7;
                    string filesToKeep = Program.CommandLine.TryGetOption("keep-files", "k");
                    if (!String.IsNullOrEmpty(filesToKeep))
                    {
                        Int32.TryParse(filesToKeep, out numberOfFilesToKeep);
                    }

                    bool quiet = Program.CommandLine.IsParameterTrue("quiet") || 
                                 Program.CommandLine.IsParameterTrue("q");

                    if (Directory.Exists(subversionFolder) && Directory.Exists(backupFolder))
                    {
                        statusCollection = new SvnStatusCollection();
                        await statusCollection.GetStatusesAsync(subversionFolder);

                        // Set the exclude filters prior to save modified-added files
                        statusCollection.ExcludeIgnored = Program.CommandLine.IsParameterTrue("exclude-ignored");
                        statusCollection.ExcludeNotVersioned = Program.CommandLine.IsParameterTrue("exclude-unversioned");
                        statusCollection.ExcludeIgnoreOnCommit = Program.CommandLine.IsParameterTrue("exclude-ignore-on-commit");
                        statusCollection.ExcludeNotVersionedExceptions = Program.CommandLine.TryGetOption("exceptions", "e");

                        string backupFile = String.Format("{0}_{1}.zip",
                                                          zipFileBaseName,
                                                          DateTime.Now.ToString("yyMMddHHmmss"));

                        statusCollection.PurgeBackupFiles(backupFolder, zipFileBaseName, numberOfFilesToKeep);

                        await statusCollection.SaveAsync(Path.Combine(backupFolder, backupFile), quiet);

                        exitValue = 0;
                    }

                }
            }
            catch(Exception)
            {
            }

            return exitValue;
        }

        private void OutputHelp()
        {
            Console.WriteLine(@"
svnbackup: Make a backup of all files that has changed in your working copy

usage: svnbackup PATH...

Backup changed working copy PATH files into compressed backup archive that is 
saved by default in current folder to svnbackup_*.zip with timestamp and which 
will contain locally modified, added, ignored as well as unversioned files. 

Valid options:
  -q [--quiet]               : print nothing, or only summary information
  -b [--backup-folder] ARG   : save the backup archive to backup folder ARG
  -f [--file-name] ARG       : filename ARG used to compose timestamped zip file
  -k [--keep-files] ARG      : number of backup archive files to keep
  --exclude-ignored          : exclude ignored files from the backup
  --exclude-unversioned      : exclude unversioned files from the backup
  -x [--exceptions] ARG      : list of unversioned file extensions not to be excluded
  --exclude-ignore-on-commit : exclude ignore-on-commit files from the backup");
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");

        }

    }
}
