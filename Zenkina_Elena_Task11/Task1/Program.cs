using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подключение библиотеки с математическими функциями.");

            try
            {
                var number = 0;
                do
                {
                    number = MyLibrary.InputConsole.InputInt("Введите целое неотрицательное число для вычисления факториала: ");
                } while (number <= 0);

                Console.WriteLine($"{number}! = {MyLib.MyMath.Factorial(number)}");


                var doubleNumber = MyLibrary.InputConsole.InputDouble("Введите число (целое или дробное) для его возведения в квадрат: ");

                Console.WriteLine($"({doubleNumber}) * ({doubleNumber}) = {MyLib.MyMath.Square(doubleNumber)}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели слишком большое число.");
            }

            Console.ReadKey();
        }
    }
}
