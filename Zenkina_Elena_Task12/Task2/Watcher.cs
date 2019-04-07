using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2
{
    //https://docs.microsoft.com/ru-ru/previous-versions/visualstudio/visual-studio-2008/ch2s8yd7(v=vs.90)
    //http://www.cyberforum.ru/windows-forms/thread1631380.html
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

            if (!Log.IsInitialize()) { return; }

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;
                watcher.Filter = filter;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Нажмите 'q', чтобы выйти из режима наблюдения.");
                while (Console.ReadKey().Key != ConsoleKey.Q) ;
            }
        }

        


        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            var loging = new Log(DateTime.Now, e.ChangeType, e.FullPath, e.Name);
            loging.Delete(loging);
            //Console.WriteLine($"При создании копий файлов возникла ошибка:");
        }


        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e) =>
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}
