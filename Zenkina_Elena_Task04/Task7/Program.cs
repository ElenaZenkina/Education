using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая определяет, сколько раз в тексте встречается время.");

            Console.Write("Введите текст: ");
            int N = CountTime(Console.ReadLine());
            Console.WriteLine($"Время в тексте присутствует {N} раз(а).");

            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }

        private static int CountTime(string text)
        {
            Regex regex = new Regex(@"([0-1]?[0-9]|[2][0-3]):([0-5][0-9])", RegexOptions.Compiled);
            return regex.Matches(text).Count;
        }
    }
}
