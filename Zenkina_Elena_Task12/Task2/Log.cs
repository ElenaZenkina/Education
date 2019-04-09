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
        public static readonly string LogFileName = Path.Combine(Environment.CurrentDirectory, "log.txt");
        public static readonly string BackupDirectoryName = Path.Combine(Environment.CurrentDirectory, "Temp");

        public static readonly string SourceDirectoryName = @"d:\1";
        public static readonly string FileExtension = "*.txt";

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
                oldBackupFileName = Path.Combine(BackupDirectoryName, Path.GetFileName(sourceFileName));

                string newFileName = Path.GetFileNameWithoutExtension(sourceFileName) + "-" +
                                      DateTimeBackup.Year +
                                      IntTwoDigit(DateTimeBackup.Month) + IntTwoDigit(DateTimeBackup.Day) +
                                      IntTwoDigit(DateTimeBackup.Hour) + IntTwoDigit(DateTimeBackup.Minute) +
                                      IntTwoDigit(DateTimeBackup.Second) +
                                    Path.GetExtension(sourceFileName);

                newBackupFileName = Path.Combine(BackupDirectoryName, newFileName);
            }
        }
        // Используется только при переименовании файла
        public string RenameFileName { get; set; }

        // Добавление "0" для формирование двузначного числа.
        private string IntTwoDigit(int number)
        {
            return (number < 10 ? "0" : "") + number;
        }

        public Log(DateTime dateTimeBackup, WatcherChangeTypes changeType, string sourceFileName)
        {
            DateTimeBackup = dateTimeBackup;
            ChangeType = changeType;
            SourceFileName = sourceFileName;
        }

        public Log(DateTime dateTimeBackup, WatcherChangeTypes changeType, string sourceFileName, string renameFileName)
        {
            DateTimeBackup = dateTimeBackup;
            ChangeType = changeType;
            SourceFileName = sourceFileName;
            RenameFileName = renameFileName;
        }

        // Первый запуск программы слежения.
        public static bool IsInitialize()
        {
            if (Directory.Exists(BackupDirectoryName) && (File.Exists(LogFileName))) { return true; }

            // Если нет папки с копиями или лог-файла, то программа слежения запускается первый раз.
            try
            {
                if (Directory.Exists(BackupDirectoryName))
                {
                    Console.WriteLine("Папка для временных файлов уже существует. Вы согласны ее удалить?Y/N");
                    if (Console.ReadKey().Key != ConsoleKey.Y) { return false; }
                    Directory.Delete(BackupDirectoryName, true);
                }

                if (File.Exists(LogFileName))
                {
                    Console.WriteLine($"Лог-файл {LogFileName} уже существует. Вы согласны его удалить?Y/N");
                    if (Console.ReadKey().Key != ConsoleKey.Y) { return false; }
                    File.Delete(LogFileName);
                }

                IsCopyDirectory(SourceDirectoryName, BackupDirectoryName);
                using (var logFile = File.Create(LogFileName)) { }
            }
            catch (Exception e)
            {
                Console.WriteLine($"При запуске программы слежения возникла ошибка: {e.Message}.");
                return false;
            }
            return true;
        }

        // Копирование исходного каталога.
        private static bool IsCopyDirectory(string SourceDir, string TargetDir)
        {
            try
            {
                Directory.CreateDirectory(TargetDir);
                foreach (string fileName in Directory.GetFiles(SourceDir, FileExtension))
                {
                    File.Copy(fileName, Path.Combine(TargetDir, Path.GetFileName(fileName)));
                }
                foreach (string dirName in Directory.GetDirectories(SourceDir))
                {
                    IsCopyDirectory(dirName, Path.Combine(TargetDir, Path.GetFileName(dirName)));
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копий файлов возникла ошибка: {e.Message}.");
                return false;
            }
        }


        // Удаление файла: в backup этот файл переименовываем с учетом времени удаления.
        public bool Delete()
        {
            try
            {
                File.Move(oldBackupFileName, newBackupFileName);
                WriteToLog();
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (delete) возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }

        // Изменение файла: в backup этот файл переименовываем с учетом времени изменения, новый файл копируем в backup.
        public bool Change()
        {
            try
            {
                File.Move(oldBackupFileName, newBackupFileName);
                File.Copy(SourceFileName, oldBackupFileName);
                WriteToLog();
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (change) возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }

        // Создание файла: новый файл копируем в backup, в лог-файле делается запись о времени.
        public bool Create()
        {
            try
            {
                File.Copy(SourceFileName, oldBackupFileName);
                WriteToLog();
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (create) возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }

        // Переименование файла: переименовываем файл в backup, в лог-файле делается запись о времени.
        public bool Rename()
        {
            try
            {
                File.Move(oldBackupFileName, Path.Combine(BackupDirectoryName, Path.GetFileName(RenameFileName)));
                WriteToLog();
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (rename) возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }

        private bool WriteToLog()
        {
            string transaction = DateTimeBackup.ToString() + Environment.NewLine +
                                     ChangeType.ToString() + Environment.NewLine +
                                            SourceFileName + Environment.NewLine +
                                    (ChangeType == WatcherChangeTypes.Renamed ? RenameFileName : newBackupFileName) +
                                            Environment.NewLine + Environment.NewLine;
            try
            {
                using (StreamWriter sWriter = new StreamWriter(LogFileName, true))
                {
                    sWriter.Write(transaction);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"При записи в лог-файл возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }


        private static string ReadFromLog()
        {
            var contents = String.Empty;
            try
            {
                using (StreamReader sReader = File.OpenText(LogFileName))
                {
                    contents = sReader.ReadToEnd();
                }

                // разбор
            }
            catch (Exception e)
            {
                Console.WriteLine($"При чтении из лог-файла возникла ошибка {e.Message}");
                return contents;
            }
            return contents;
        }

        public void ReadLog(DateTime dtRollback)
        {
            string[] contents = File.ReadAllLines(LogFileName);
            var toLog = new List<string>();
            var toParse = new List<string>();

            string[] contents1;
            for (int i = 0; i < contents.Length; i++)
            {
                DateTime dt;
                if (!DateTime.TryParse(contents[i], out dt) && dt < dtRollback)
                {
                    toLog.Add(contents[i]);
                }
            }
        }



    }
}
