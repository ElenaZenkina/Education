using System;
using System.Globalization;

namespace Task2
{
    class Program
    {
        // Задание сразу порождает несколько вопросов:
        // 1) переименовывание одной из папок внутри каталога для слежения - здесь надо реализовывать слишком сложную логику;
        // 2) при создании копии или откате в любой момент что-то может пойти не так, было бы хорошо реализовать все это в виде
        // транзакций (по типу транзакций в БД) - здесь надо реализовывать слишком сложную логику. Но даже в этом случае если
        // возникнет ошибка при откате транзакции, то непонятно, как из этого выкручиваться;
        // 3) 

        static void Main(string[] args)
        {
            string[] args1 = Environment.GetCommandLineArgs();

            ConsoleKey mode;
            do
            {
                Console.WriteLine("Выберите режим работы программы: 1 - режим наблюдения, 2 - режим отката ");
                mode = Console.ReadKey().Key;
            }
            while (mode != ConsoleKey.D1 && mode != ConsoleKey.D2);
            Console.WriteLine();

            // Выбран режим наблюдения
            if (mode == ConsoleKey.D1)
            {
                if (!Log.IsInitialize()) { return; }

                var watcher = new Watcher(Log.SourceDirectoryName, Log.FileExtension);
                watcher.StartWatcher();
            }

            if (mode == ConsoleKey.D2)
            {
                CultureInfo MyCultureInfo = new CultureInfo("ru-RU");
                //DateTime rollbackDateTime = DateTime.ParseExact(Console.ReadLine(), "D", MyCultureInfo);
                DateTime rollbackDateTime = new DateTime(2019, 1, 1, 12, 12, 12);
                
            }

        }
    }
}
