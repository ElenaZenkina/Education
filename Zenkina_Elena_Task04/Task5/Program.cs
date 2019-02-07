using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая заменяет все найденные в тексте HTML теги на знак _");

            Console.Write("Введите HTML текст: ");
            var textWithoutTag = DeleteHtmlTag(Console.ReadLine());
            Console.WriteLine($"Результат замены: {textWithoutTag}");

            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }

        private static string DeleteHtmlTag(string htmlText)
        {
            return Regex.Replace(htmlText, "<[^>]+>", "_");
        }
    }
}
