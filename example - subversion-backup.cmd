@echo off
echo Subversion Backup of local modifications is in progress ...
set SVNBACKUP_EXE="E:\Tool Programs\Subversion Backup\svnbackup.exe"
set SVNBACKUP_FOLDER="E:\Backup Folder\Subversion Local Modifications"
set EXCLUDE_OPTIONS=--exclude-ignored --exclude-unversioned --exclude-ignore-on-commit --exceptions "*.cs *.vb"

rem backup local modified or added files of SVN working folders
echo ... for 'Applications' trunk
%SVNBACKUP_EXE% "W:\Working Folder\Subversion\nlmssvn10\Applications\trunk" -q -b %SVNBACKUP_FOLDER% -f Applications_trunk %EXCLUDE_OPTIONS% --keep-files 7
echo ... for 'Applications' BCT_7.11.x
%SVNBACKUP_EXE% "W:\Working Folder\Subversion\nlmssvn10\Applications\branches\maintenance\BCT_7.11.x" -q -b %SVNBACKUP_FOLDER% -f Applications_BCT_7.11 %EXCLUDE_OPTIONS% --keep-files 7
echo ... for 'Applications' BCT_7.10.x
%SVNBACKUP_EXE% "W:\Working Folder\Subversion\nlmssvn10\Applications\branches\maintenance\BCT_7.10.x" -q -b %SVNBACKUP_FOLDER% -f Applications_BCT_7.10 %EXCLUDE_OPTIONS% --keep-files 7
echo ... for 'Applications' BCT_7.00.x
%SVNBACKUP_EXE% "W:\Working Folder\Subversion\nlmssvn10\Applications\branches\maintenance\BCT_7.00.x" -q -b %SVNBACKUP_FOLDER% -f Applications_BCT_7.00 %EXCLUDE_OPTIONS% --keep-files 7
echo ... for 'Mobility' trunk
%SVNBACKUP_EXE% "W:\Working Folder\Subversion\nlmssvn10\Mobility\dect-applications\trunk" -q -b %SVNBACKUP_FOLDER% -f Mobility_trunk %EXCLUDE_OPTIONS% --keep-files 7
