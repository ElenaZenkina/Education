using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    // Для записи лог-файла также можно использовать стандартные функции:
    // - серилизацию (для записи/чтения структур),
    // - запись/чтение в xml-файл.
    class Log
    {
        private string sourceFileName;
        private string oldBackupFileName;
        private string newBackupFileName;

        public DateTime DateTimeBackup { get; set; }
        public WatcherChangeTypes ChangeType { get; set; }
        public string SourceFileName
        {
            get { return sourceFileName; }
            set
            {
                sourceFileName = value;
                oldBackupFileName = Path.Combine(DirAndFile.BackupDirectoryName, Path.GetFileName(sourceFileName));

                string newFileName = Path.GetFileNameWithoutExtension(sourceFileName) + "-" +
                                      DateTimeBackup.Year +
                                      IntTwoDigit(DateTimeBackup.Month) + IntTwoDigit(DateTimeBackup.Day) +
                                      IntTwoDigit(DateTimeBackup.Hour) + IntTwoDigit(DateTimeBackup.Minute) +
                                      IntTwoDigit(DateTimeBackup.Second) +
                                    Path.GetExtension(sourceFileName);

                newBackupFileName = Path.Combine(DirAndFile.BackupDirectoryName, newFileName);
            }
        }
        public string OldBackupFileName
        {
            get { return oldBackupFileName; }
        }
        public string NewBackupFileName
        {
            get { return newBackupFileName; }
        }
        // Используется только при переименовании файла
        public string RenameFileName { get; set; }

        // Добавление "0" для формирование двузначного числа.
        private string IntTwoDigit(int number)
        {
            return (number < 10 ? "0" : "") + number;
        }

        public Log()
        { }

        public Log(DateTime dateTimeBackup, WatcherChangeTypes changeType, string sourceFileName)
        {
            DateTimeBackup = dateTimeBackup;
            ChangeType = changeType;
            SourceFileName = sourceFileName;
        }

        public Log(DateTime dateTimeBackup, WatcherChangeTypes changeType, string sourceFileName, string renameFileName): 
            this (dateTimeBackup, changeType, sourceFileName)
        {
            RenameFileName = renameFileName;
        }


        public string StringForWrite()
        {
            return DateTimeBackup.ToString() + Environment.NewLine +
                       ChangeType.ToString() + Environment.NewLine +
                              SourceFileName + Environment.NewLine +
                         (ChangeType == WatcherChangeTypes.Renamed ? RenameFileName : newBackupFileName) +
                         Environment.NewLine + Environment.NewLine;
        }

    }
}
