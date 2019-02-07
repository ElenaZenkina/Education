using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class InputConsole
    {
        /// <summary>
        /// Ввод в консоль вещественного числа и его парсинг.
        /// </summary>
        /// <param name="message">Сообщение на консоли.</param>
        /// <returns>Вещественное число.</returns>
        public static double InputDouble(string message)
        {
            Console.Write(message);
            var number = 0.0;

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Это не вещественное число.");
                Console.Write("Еще раз " + message.ToLower());
            }

            return number;
        }

        /// <summary>
        /// Ввод в консоль целого числа и его парсинг.
        /// </summary>
        /// <param name="message">Сообщение на консоли.</param>
        /// <returns>Целое число.</returns>
        public static int InputInt(string message)
        {
            Console.Write(message);
            var number = 0;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Это не целое число.");
                Console.Write("Еще раз " + message.ToLower());
            }

            return number;
        }

        /// <summary>
        /// Ввод в консоль целого числа и его парсинг с возможностью повторного ввода, если число введено некорректно.
        /// </summary>
        /// <param name="message">Сообщение на консоли.</param>
        /// <param name="number">Возвращаемое целое число.</param>
        /// <returns>True - введено корректное число, false введено некорректное число.</returns>
        public static bool IsDataInput(string message, out int number)
        {
            do
            {
                Console.WriteLine();
                Console.Write(message);

                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Это не целое число.");
                    Console.Write("Хотите ввести число еще раз (Y - да)?");
                }
                else
                {
                    return true;
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);

            return false;
        }

        /// <summary>
        /// Ввод в консоль вещественного числа и его парсинг с возможностью повторного ввода, если число введено некорректно.
        /// </summary>
        /// <param name="message">Сообщение на консоли.</param>
        /// <param name="number">Возвращаемое вещественное число.</param>
        /// <returns>True - введено корректное число, false введено некорректное число.</returns>
        public static bool IsDataInput(string message, out double number)
        {
            do
            {
                Console.WriteLine();
                Console.Write(message);

                if (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Это не вещественное число.");
                    Console.Write("Хотите ввести число еще раз (Y - да)?");
                }
                else
                {
                    return true;
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);

            return false;
        }

    }
}
