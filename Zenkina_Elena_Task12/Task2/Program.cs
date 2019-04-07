using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        // Задание сразу порождает несколько вопросов:
        // 1) переименовывание одной из папок внутри каталога для слежения - здесь надо реализовывать слишком сложную логику;
        // 2) при создании копии или откате в любой момент что-то может пойти не так, было бы хорошо реализовать все это в виде
        // транзакций (по типу транзакций в БД) - здесь надо реализовывать слишком сложную логику. Но даже в этом случае если
        // возникнет ошибка при откате транзакции, то непонятно, как из этого выкручиваться;
        // 

        static void Main(string[] args)
        {
            string[] args1 = Environment.GetCommandLineArgs();

            const string sourceFolder = @"d:\1";
            const string filter = "*.txt";

            var watcher = new Watcher(sourceFolder, filter);
            watcher.StartWatcher();
        }
    }
}
