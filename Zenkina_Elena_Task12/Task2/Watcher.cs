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

        private void CreateBegin()
        {
            // Папка для копий файлов
            string folder = Environment.CurrentDirectory;
            // Привязаться к текущему рабочему каталогу
            DirectoryInfo dir1 = new DirectoryInfo(".");

            // Привязаться к несуществующему каталогу, затем создать его
            DirectoryInfo dir3 = new DirectoryInfo(@"D:\Epam\Net\Testing");
            dir3.Create();
            // предпочтительно использовать методы Path для создания адресов
            string filePath = Path.Combine(dir1.FullName, "test.txt");


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
