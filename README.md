# svnbackup
svnbackup: This tool allows you to make a backup of all files that has changed (added, modified or deleted) in your Subversion working copy. Additional the tool also allow you to include unversioned or ignored files in the backup. The tool can be run from the commandline but also has a GUI version, just run the executable without any commandline parameters.



```
usage: svnbackup PATH [options]
```

Backup changed working copy PATH files into compressed backup archive that is
saved by default in current folder to svnbackup_*.zip with timestamp and which
will contain locally modified, added, ignored as well as unversioned files.

Valid commandline options are:
```
  -q [--quiet]               : print nothing, or only summary information
  -b [--backup-folder] ARG   : save the backup archive to backup folder ARG
  -f [--file-name] ARG       : filename ARG used to compose timestamped zip file
  -k [--keep-files] ARG      : number of backup archive files to keep
  --exclude-ignored          : exclude ignored files from the backup
  --exclude-unversioned      : exclude unversioned files from the backup
  -x [--exceptions] ARG      : list of unversioned file extensions not to be excluded
  --exclude-ignore-on-commit : exclude ignore-on-commit files from the backup
```
Examples:
```
svnbackup "C:\Working Copies\trunk" -q -b "D:\My Backups" -f trunk_800 --exclude-ignored --exclude-ignore-on-commit -x "*.cs *.vb"
```
This will backup all your changes made in the working copy folder "C:\Working Copies\trunk"
to backup folder "D:\My Backups" into a compressed archive 'trunk_800_*.zip'.
The backup will exclude ignored files as well as files part of 'ignore-on-commit' change list
and also exclusive unversioned files (with as exception *.cs and *.vb unversioned files).