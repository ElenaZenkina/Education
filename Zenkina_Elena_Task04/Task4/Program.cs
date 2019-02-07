using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сравнительный анализ скорости работы классов String и StringBuilder.");

            var stopWatch = new System.Diagnostics.Stopwatch();

            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();
            Console.WriteLine($"Класса String: скорость работы для {N} операций сложения - {stopWatch.Elapsed}.");

            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch.Stop();
            Console.WriteLine($"Класса StringBuilder: скорость работы для {N} операций сложения - {stopWatch.Elapsed}.");

            Console.WriteLine();
            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }
    }
}
