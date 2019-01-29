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
            Console.WriteLine("Введите целое положительное число: ");

            var N = EnterNumber();
            var sym = '*';
            var space = ' ';
            Output(sym, space, N);

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }

        static void Output(char sym, char space, int N)
        {
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(new String(space, N - i) + new String(sym, 2 * i - 1));
            }
        }

        static int EnterNumber()
        {
            while (true)
            {
                var number = 0;
                var enter = Console.ReadLine();
                if (int.TryParse(enter, out number))
                {
                    if (number <= 0) Console.WriteLine($"{ number } не является положительным числом.\nВведите число еще раз: ");
                    else return number;
                }
                else Console.WriteLine($"{ enter } не является целым числом.\nВведите число еще раз: ");
            }
        }
    }
}
