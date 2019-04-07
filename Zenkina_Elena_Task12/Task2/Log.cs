using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    // Для записи лог-файла можно использовать стандартные функции:
    // - серилизацию (для записи/чтения структур),
    // - запись/чтение в xml-файл.
    class Log
    {
        public static readonly string LogFileName = Path.Combine(Environment.CurrentDirectory, "log.txt");
        public static readonly string BackupDirectoryName = Path.Combine(Environment.CurrentDirectory, "Temp");

        private string backupFileName;
        private string sourceFileName;

        public DateTime DateTimeBackup { get; set; }
        public WatcherChangeTypes ChangeType { get; set; }
        public string SourceFileName
        {
            get { return sourceFileName; }
            set
            {
                string s = Path.GetFileNameWithoutExtension(SourceFileName);
                s = s + DateTimeBackup.Year + DateTimeBackup.Month + DateTimeBackup.Date +
                    DateTimeBackup.Hour + DateTimeBackup.Minute + DateTimeBackup.Second + Path.GetExtension(SourceFileName);
                backupFileName = Path.Combine(BackupDirectoryName, s);
            }
        }
        public string NewBackupFileName
        {
            get { return backupFileName; }
            set
            {
                string s = Path.GetFileNameWithoutExtension(SourceFileName);
                s = s + DateTimeBackup.Year + DateTimeBackup.Month + DateTimeBackup.Date + 
                    DateTimeBackup.Hour + DateTimeBackup.Minute + DateTimeBackup.Second + Path.GetExtension(SourceFileName);
                backupFileName = Path.Combine(BackupDirectoryName, s);
            }
        }
        private string OldBackupFileName { get; set; }

        public Log(DateTime dateTimeBackup, WatcherChangeTypes changeType, string sourceFileName, string backupFileName)
        {
            DateTimeBackup = dateTimeBackup;
            ChangeType = changeType;
            SourceFileName = sourceFileName;
            NewBackupFileName = backupFileName;
        }

        // Первый запуск программы слежения.
        public static bool IsInitialize()
        {
            /*
            // Если нет папки с копиями или лог-файла, то программа слежения запускается первый раз.
            if (!Directory.Exists(BackupDirectoryName) || (!File.Exists(LogFileName)))
            {
                if (!IsInitialize()) { return; }
            }
            try
            {
                if (Directory.Exists(copiesDirectoryName))
                {
                    Console.WriteLine("Папка для временных файлов уже существует. Вы согласны ее удалить?Y/N");
                    if (Console.ReadKey().Key != ConsoleKey.Y) { return false; }
                    Directory.Delete(copiesDirectoryName, true);
                }
                IsCopyDirectory(path, copiesDirectoryName);

                if (File.Exists(logFileName))
                {
                    Console.WriteLine($"Лог-файл {logFileName} уже существует. Вы согласны его удалить?Y/N");
                    if (Console.ReadKey().Key != ConsoleKey.Y) { return false; }
                    File.Delete(logFileName);
                }
                var logFile = File.Create(logFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При запуске программы слежения возникла ошибка: {e.Message}.");
                return false;
            }*/
            return true;
        }

        // Копирование исходного каталога.
        private static bool IsCopyDirectory(string SourceDir, string TargetDir)
        {
            try
            {
                Directory.CreateDirectory(TargetDir);
                foreach (string fileName in Directory.GetFiles(SourceDir, "*.txt"))
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
        public bool Delete(Log log)
        {
            try
            {
                File.Move(Path.GetFileName(SourceFileName), )
                WriteToLog();
            }
            catch
            { }
            return true;
        }

        private bool WriteToLog()
        {
            string transaction = DateTimeBackup.ToString() + Environment.NewLine +
                                     ChangeType.ToString() + Environment.NewLine +
                                            SourceFileName + Environment.NewLine +
                                            NewBackupFileName + Environment.NewLine;
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


        public bool ReadFromLog()
        {
            try
            {
                var transaction = String.Empty;

                using (StreamReader sReader = File.OpenText(LogFileName))
                {
                    transaction = sReader.ReadToEnd();
                }

                // разбор
            }
            catch (Exception e)
            {
                Console.WriteLine($"При чтении из лог-файла возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }



    }
}
