using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая выводит формат вещественного числа.");

            Regex regex = new Regex(@"^[-+]?\d*([.,]\d*)?([eE][-+]?\d+)?$", RegexOptions.Compiled);

            do
            {
                Console.WriteLine();
                Console.Write("Введите число: ");
                var number = Console.ReadLine();
                if (regex.IsMatch(number))
                {
                    if (number.Contains("e"))
                    {
                        Console.WriteLine("Это число в научной нотации.");
                    }
                    else
                    {
                        Console.WriteLine("Это число в обычной нотации.");
                    }
                }
                else
                {
                    Console.WriteLine("Это не число.");
                }
                Console.Write("Хотите ввести еще одно число (Y - да)?");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);

        }
    }
}
