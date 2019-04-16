using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2
{
    class Watcher
    {
        private readonly string path;
        private readonly string filter;
        
        public Watcher(string path, string filter)
        {
            this.path = path;
            this.filter = filter;
        }

        public void StartWatcher()
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(filter)) { return; }

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;
                watcher.Filter = filter;
                watcher.IncludeSubdirectories = true;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;
                watcher.Error += OnError;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Нажмите 'q', чтобы выйти из режима наблюдения.");
                while (Console.ReadKey().Key != ConsoleKey.Q) ;
            }
        }


        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            var log = new Log(DateTime.Now, e.ChangeType, e.FullPath);
            if (!DirAndFile.Delete(log))
            {
                Console.WriteLine($"Фатальная ошибка. Дальнейшее слежение бессмысленно.");
            }
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            var log = new Log(DateTime.Now, e.ChangeType, e.FullPath);
            if (!DirAndFile.Create(log))
            {
                Console.WriteLine($"Фатальная ошибка. Дальнейшее слежение бессмысленно.");
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Обход известной ошибки: при редактировании в Блокноте событие OnChanged срабатывает два раза.
            try
            {
                (source as FileSystemWatcher).EnableRaisingEvents = false;
                var log = new Log(DateTime.Now, e.ChangeType, e.FullPath);
                if (!DirAndFile.Change(log))
                {
                    Console.WriteLine($"Фатальная ошибка. Дальнейшее слежение бессмысленно.");
                }
            }
            finally
            {
                (source as FileSystemWatcher).EnableRaisingEvents = true;
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            var log = new Log(DateTime.Now, e.ChangeType, e.OldFullPath, e.FullPath);
            if (!DirAndFile.Rename(log))
            {
                Console.WriteLine($"Фатальная ошибка. Дальнейшее слежение бессмысленно.");
            }
        }

        private void OnError(object source, ErrorEventArgs e) =>
            Console.WriteLine("Переполнен внутренний буфер.");

    }
}
