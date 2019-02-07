using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая удваивает в первой введенной строке все символы, принадлежащие второй введенной строке.");

            var firstString = InputString("Введите первую строку: ");
            var secondString = InputString("Введите вторую строку: ");

            Console.WriteLine("Результирующая строка: " + DoubleSymbol(firstString, secondString));

            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }


        private static string DoubleSymbol(string firstString, string secondString)
        {
            var result = String.Empty;

            for (int i = 0; i < firstString.Length; i++)
            {
                result += firstString[i];
                if (secondString.Contains(firstString[i]))
                {
                    result += firstString[i];
                }
                // Можно все это записать в одну строку:
                //result += secondString.Contains(firstString[i]) ? firstString[i] + firstString[i] : firstString[i];
            }
            return result;
        }

        private static string InputString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
