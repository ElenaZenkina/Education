using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] args1 = Environment.GetCommandLineArgs();

            //Console.WriteLine("CurrentDirectory: \n\t{0}", Environment.CurrentDirectory);

            //Console.ReadKey();

            const string sourceFolder = @"d:\1";
            const string filter = "*.txt";

            var watcher = new Watcher(sourceFolder, filter);
            watcher.Run();
        }
    }
}
