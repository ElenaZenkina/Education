using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для вывода отличий культур.");

            var cultures = new CultureInfo[3];
            cultures[0] = new CultureInfo("ru");
            cultures[1] = new CultureInfo("en");
            cultures[2] = CultureInfo.InvariantCulture;

            CompareCulture(cultures[0], cultures[1]);
            CompareCulture(cultures[0], cultures[2]);
            CompareCulture(cultures[1], cultures[2]);

            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }

        private static void CompareCulture(CultureInfo culture1, CultureInfo culture2)
        {
            Console.WriteLine("                                                                       " +
                $"\"{culture1.TwoLetterISOLanguageName}\" vs \"{culture2.TwoLetterISOLanguageName}\"");
            Console.WriteLine();

            Console.WriteLine($"| Дата и время в длинной форме      | " + 
                $"{culture1.DateTimeFormat.FullDateTimePattern,38} | {culture2.DateTimeFormat.FullDateTimePattern,38} |");

            Thread.CurrentThread.CurrentCulture = culture1;
            Console.Write($"| Пример даты и времени             | {DateTime.Now, 38:F} | ");

            Thread.CurrentThread.CurrentCulture = culture2;
            Console.WriteLine($"{DateTime.Now, 38:F} |");

            Console.WriteLine($"| Разделитель дробной и целой части | " +
                $"{culture1.NumberFormat.NumberDecimalSeparator,38} | {culture2.NumberFormat.NumberDecimalSeparator,38} |");

            Console.WriteLine($"| Разделитель групп разрядов        | " +
                $"{culture1.NumberFormat.NumberGroupSeparator,38} | {culture2.NumberFormat.NumberGroupSeparator,38} |");

            double number = 12345.67;
            Thread.CurrentThread.CurrentCulture = culture1;
            Console.Write($"| Пример числа                      | {number,38:N} | ");

            Thread.CurrentThread.CurrentCulture = culture2;
            Console.WriteLine($"{number,38:N} |");

            Console.WriteLine($"| Символ валюты                     | " +
                $"{culture1.NumberFormat.CurrencySymbol,38} | {culture2.NumberFormat.CurrencySymbol,38} |");

            Console.WriteLine();
        }

    }
}
