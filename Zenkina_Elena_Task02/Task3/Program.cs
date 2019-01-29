using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5.");

            // Не надо n1 и n2 задавать равными 0.
            var n1 = 3;
            var n2 = 5;
            var max = 1000;
            var sum = 0;

            for (int i = 1; i < max; i++)
            {
                if ((i % n1 == 0) || (i % n2 == 0)) sum += i;
            }
            Console.WriteLine($"Сумма всех чисел меньше {max}, кратных {n1} или {n2} равна {sum}.");

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }
    }
}
