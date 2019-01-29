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
            Console.WriteLine("Программа для определяния площади прямоугольника.");

            Console.WriteLine("Введите длину стороны прямоугольника: ");
            var a = EnterNumber();
            Console.WriteLine("Введите длину второй стороны прямоугольника: ");
            var b = EnterNumber();

            Console.WriteLine("Площадь прямоугольника равна " + a * b);

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }

        static int EnterNumber()
        {
            while (true)
            {
                var number = 0;
                var rectangle = Console.ReadLine();
                if (int.TryParse(rectangle, out number))
                {
                    if (number <= 0) Console.WriteLine($"{ number } является некорректным числом для стороны прямоугольника.\nВведите длину еще раз: ");
                    else return number;
                }
            }
        }
    }
}
