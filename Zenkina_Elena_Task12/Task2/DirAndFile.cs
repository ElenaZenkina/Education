using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class DirAndFile
    {

        public static readonly string LogFileName = Path.Combine(Environment.CurrentDirectory, "log.txt");
        public static readonly string BackupDirectoryName = Path.Combine(Environment.CurrentDirectory, "Temp");

        public static readonly string SourceDirectoryName = @"d:\1";
        public static readonly string FileExtension = "*.txt";

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
                    Console.WriteLine();
                    Directory.Delete(BackupDirectoryName, true);
                }

                if (File.Exists(LogFileName))
                {
                    Console.WriteLine($"Лог-файл {LogFileName} уже существует. Вы согласны его удалить?Y/N");
                    if (Console.ReadKey().Key != ConsoleKey.Y) { return false; }
                    Console.WriteLine();
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
        public static bool Delete(Log log)
        {
            try
            {
                File.Move(log.OldBackupFileName, log.NewBackupFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (delete) возникла ошибка {e.Message}");
                return false;
            }

            return WriteToLog(log.StringForWrite());
        }

        // Изменение файла: в backup этот файл переименовываем с учетом времени изменения, новый файл копируем в backup.
        public static bool Change(Log log)
        {
            try
            {
                File.Move(log.OldBackupFileName, log.NewBackupFileName);
                File.Copy(log.SourceFileName, log.OldBackupFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (change) возникла ошибка {e.Message}");
                return false;
            }
            return WriteToLog(log.StringForWrite());
        }

        // Создание файла: новый файл копируем в backup, в лог-файле делается запись о времени.
        public static bool Create(Log log)
        {
            try
            {
                File.Copy(log.SourceFileName, log.OldBackupFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (create) возникла ошибка {e.Message}");
                return false;
            }

            return WriteToLog(log.StringForWrite());
        }

        // Переименование файла: переименовываем файл в backup, в лог-файле делается запись о времени.
        public static bool Rename(Log log)
        {
            try
            {
                File.Move(log.OldBackupFileName, Path.Combine(BackupDirectoryName, Path.GetFileName(log.RenameFileName)));
            }
            catch (Exception e)
            {
                Console.WriteLine($"При создании копии (rename) возникла ошибка {e.Message}");
                return false;
            }
            return WriteToLog(log.StringForWrite());
        }

        private static bool WriteToLog(string contents)
        {
            try
            {
                using (StreamWriter sWriter = new StreamWriter(LogFileName, true))
                {
                    sWriter.Write(contents);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"При записи в лог-файл возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }


        // Для режима отката
        #region Функции для режима отката

        public static string[] ReadLogFile(DateTime dtRollback)
        {
            string[] contents;
            try
            {
                contents = File.ReadAllLines(LogFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При чтении лог-файла возникла ошибка {e.Message}");
                return null;
            }

            // Все записи в лог-файле расположены по возрастанию даты. Те, которые меньше указанной, запишем в лог-файл.

            DateTime dt;
            int i = 0;
            while (i < contents.Length && (!DateTime.TryParse(contents[i], out dt) || dtRollback > dt))
            {
                i++;
            }

            // В лог-файле остаются те записи, которые не надо откатывать.
            var remains = new string[i];
            Array.Copy(contents, remains, i);
            File.WriteAllLines(LogFileName, remains);

            // Массив с логами, которые надо откатить.
            var rollBackArray = new string[contents.Length - i];
            Array.Copy(contents, i, rollBackArray, 0, contents.Length - i);

            return rollBackArray;
        }

        public static bool RollBack(string[] rollBackArray)
        {
            List<Log> rollBack = Parser(rollBackArray);

            if (rollBack.Count > 0)
            {
                // Старт отката изменений
                RollBack(rollBack);
            }

            return true;
        }

        private static List<Log> Parser(string[] contents)
        {
            var rollBack = new List<Log>();
            for (int i = 0; i < contents.Length; i += 5)
            {
                var log = new Log();

                DateTime dt;
                if (DateTime.TryParse(contents[i], out dt)) { log.DateTimeBackup = dt; }

                switch (contents[i + 1].ToLower())
                {
                    case "changed":
                        log.ChangeType = WatcherChangeTypes.Changed;
                        break;
                    case "created":
                        log.ChangeType = WatcherChangeTypes.Created;
                        break;
                    case "deleted":
                        log.ChangeType = WatcherChangeTypes.Deleted;
                        break;
                    case "renamed":
                        log.ChangeType = WatcherChangeTypes.Renamed;
                        break;
                }

                log.SourceFileName = contents[i + 2];

                if (log.ChangeType == WatcherChangeTypes.Renamed)
                {
                    log.RenameFileName = contents[i + 3];
                }
                else
                {
                    //log.newBackupFileName = contents[i + 3];
                }

                rollBack.Add(log);

            }
            return rollBack;
        }

        private static bool RollBack(List<Log> listLog)
        {
            for (int i = listLog.Count - 1; i >= 0; i--)
            {
                var log = listLog[i];
                if (!Back(log)) { return false; }
            }
            return true;
        }

        private static bool Back(Log log)
        {
            try
            {
                if (log.ChangeType == WatcherChangeTypes.Created)
                {
                    File.Delete(log.SourceFileName);
                    File.Delete(log.OldBackupFileName);
                }
                else if (log.ChangeType == WatcherChangeTypes.Changed)
                {
                    File.Delete(log.SourceFileName);
                    File.Move(log.NewBackupFileName, log.SourceFileName);
                    File.Delete(log.OldBackupFileName);
                    File.Copy(log.SourceFileName, log.OldBackupFileName);
                }
                else if (log.ChangeType == WatcherChangeTypes.Deleted)
                {
                    File.Move(log.NewBackupFileName, log.SourceFileName);
                    File.Copy(log.SourceFileName, log.OldBackupFileName);
                }
                else if (log.ChangeType == WatcherChangeTypes.Renamed)
                {
                    File.Move(log.RenameFileName, log.SourceFileName);
                    File.Move(Path.Combine(BackupDirectoryName, Path.GetFileName(log.RenameFileName)), log.OldBackupFileName);
                }

                // Можно поменять атрибуты файла
                //File.SetLastWriteTime(log.SourceFileName, log.DateTimeBackup);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При операции {log.ChangeType.ToString()} возникла ошибка {e.Message}");
                return false;
            }
            return true;
        }

        #endregion
    }
}
