using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpSvn;
using System.IO;
using System.Collections.ObjectModel;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

namespace svnbackup
{
    public class SvnStatusCollection
    {
        List<SvnStatusEventArgs> statuses = new List<SvnStatusEventArgs>();

        public bool ExcludeIgnored { get; set; }
        public bool ExcludeNotVersioned { get; set; }
        public string ExcludeNotVersionedExceptions { get; set; }
        public bool ExcludeIgnoreOnCommit { get; set; }
        public string WorkingCopyFolder { get; set; }
        public int NotVersioned { get; private set; }
        public int Modified { get; private set; }
        public int Added { get; private set; }
        public int Ignored { get; private set; }
        public int IgnoreOnCommit { get; private set; }
        

        public SvnStatusCollection()
        {
        }

        public async Task GetStatusesAsync(string workingCopyFolder)
        {
            if (!String.IsNullOrEmpty(workingCopyFolder))
            {
                statuses.Clear();
                using (SvnClient client = new SvnClient())
                {
                    await Task.Run(() =>
                    {
                        statuses = GetStatuses(client, workingCopyFolder).ToList();
                        UpdateSummaryInfo();
                    });
                }
                WorkingCopyFolder = workingCopyFolder;
            }
        }

        private IEnumerable<SvnStatusEventArgs> GetStatuses(SvnClient client, string work)
        {
            Collection<SvnStatusEventArgs> statuses;
            SvnStatusArgs args = new SvnStatusArgs();
            args.RetrieveAllEntries = true;
            args.RetrieveIgnoredEntries = true;         // uses SvnClient.Configuration.GlobalIgnorePattern
            client.GetStatus(work, args, out statuses);
            return statuses;
        }

        public List<SvnStatusEventArgs> Filtered()
        {
            List<SvnStatusEventArgs> filtered = new List<SvnStatusEventArgs>();

            // NodeKind = File, Directory, Unknown or None
            // - File, Directory is versioned file or directory node kind
            // - Unknown is either ignored or unversioned node kind (can be file or folder)
            statuses.Where(x => x.NodeKind != SvnNodeKind.Directory).ToList().ForEach(x =>
            {
                bool filter = false;
                switch (x.LocalNodeStatus)
                {
                    case SvnStatus.Ignored:
                        filter = (!ExcludeIgnored&& !IsDirectory(x.Path));
                        break;
                    case SvnStatus.NotVersioned:
                        // filter = (!ExcludeNotVersioned && !IsDirectory(x.Path));
                        filter = (!IsDirectory(x.Path) && (!ExcludeNotVersioned || MatchesUnversionedException(Path.GetExtension(x.Path))));
                        break;
                    case SvnStatus.Modified:
                        bool ignore = (x.ChangeList == "ignore-on-commit");
                        filter =  ignore ? !ExcludeIgnoreOnCommit : true;
                        break;
                    case SvnStatus.Added:
                        filter = true;
                        break;
                    default:
                        break;
                }

                if (filter) { filtered.Add(x); };
            });

            return filtered;
        }

        private bool MatchesUnversionedException(string extension)
        {
            foreach(Match m in Regex.Matches(ExcludeNotVersionedExceptions, @"[.][a-zA-Z]*"))
            {
                if (m.Value.Equals(extension)) return true;
            }
            return false;
        }

        private void UpdateSummaryInfo()
        {
            NotVersioned = Modified = IgnoreOnCommit = Ignored = Added = 0;
            statuses.Where(x => x.NodeKind != SvnNodeKind.Directory).ToList().ForEach(x =>
            {
                switch (x.LocalNodeStatus)
                {
                    case SvnStatus.Ignored:
                        if (!IsDirectory(x.Path)) Ignored++;
                        break;
                    case SvnStatus.NotVersioned:
                        if (!IsDirectory(x.Path)) NotVersioned++;
                        break;
                    case SvnStatus.Modified:
                        bool ignore = (x.ChangeList == "ignore-on-commit");
                        Modified++;
                        if (ignore) IgnoreOnCommit++;
                        break;
                    case SvnStatus.Added:
                        Added++;
                        break;
                    default:
                        break;
                }
            });

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

        public void PurgeBackupFiles(string backupDirectory, string baseFileName, int numbersToKeep)
        {
            DirectoryInfo backupDir = new DirectoryInfo(backupDirectory);

            FileInfo[] backupFiles = backupDir.GetFiles(String.Format("{0}_*", baseFileName), SearchOption.TopDirectoryOnly);

            foreach (FileInfo f in backupFiles.OrderByDescending(file => file.CreationTime).Skip(numbersToKeep - 1))
            {
                // Console.WriteLine(f.FullName);
                File.Delete(f.FullName);
            }
        }

        public async Task SaveAsync(string backupFile, bool quiet = false)
        {
            await Task.Run(() =>
            {
                using (ZipFile zipFile = ZipFile.Create(backupFile))
                {
                    zipFile.BeginUpdate();
                    foreach (SvnStatusEventArgs status in this.Filtered())
                    {
                        string file = status.Path;
                        string relativePath = file.Substring(this.WorkingCopyFolder.Length);
                        if (!quiet) Console.WriteLine(file);
                        zipFile.Add(file, relativePath);
                    }
                    zipFile.CommitUpdate();
                }
            });
        }
    }
}
