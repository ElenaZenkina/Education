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
        // 3) если при изменении файла его логирование пройдет правильно, а при записи этого действия в файл произойдет
        // ошибка, то возникнет несоответствие между копиями и записями о них.

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
                if (!DirAndFile.IsInitialize()) { return; }

                var watcher = new Watcher(DirAndFile.SourceDirectoryName, DirAndFile.FileExtension);
                watcher.StartWatcher();
            }


            // Выбран режим отката
            if (mode == ConsoleKey.D2)
            {
                Console.WriteLine("Введите дату и время в формате dd.mm.yyyy hh:mm:ss");
                var date = Console.ReadLine();

                DateTime rollbackDateTime;
                try
                {
                    string[] splitDateTime = date.Split(' ');
                    string[] splitDate = splitDateTime[0].Split('.');
                    string[] splitTime = splitDateTime[1].Split(':');

                    rollbackDateTime = new DateTime(Int32.Parse(splitDate[2]), Int32.Parse(splitDate[1]), Int32.Parse(splitDate[0]),
                        Int32.Parse(splitTime[0]), Int32.Parse(splitTime[1]), Int32.Parse(splitTime[2]));
                }
                catch
                {
                    Console.WriteLine("Дата введена некорректно.");
                    return;
                }

                var rollBackArray = DirAndFile.ReadLogFile(rollbackDateTime);
                if (rollBackArray != null && DirAndFile.RollBack(rollBackArray))
                {
                    Console.WriteLine($"Откат прошел успешно.");
                }
                else
                {
                    Console.WriteLine($"Откат не был произведен.");
                }
                Console.ReadKey();
            }

        }
    }
}
