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

        public void Run()
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(filter)) { return; }

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
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Нажмите 'q', чтобы выйти из режима наблюдения.");
                while (Console.Read() != 'q') ;
            }
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
