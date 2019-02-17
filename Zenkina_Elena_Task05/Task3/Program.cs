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
            Console.WriteLine("Создание класса Triangle:");

            var sideA = 0;
            var sideB = 0;
            var sideC = 0;

            for (int i = 1; i <= 3; i++)
            {
                int side = MyLibrary.InputConsole.InputInt($"Введите длину {i} стороны треугольника (целое число): ");

                if (i == 1) { sideA = side; }
                if (i == 2) { sideB = side; }
                if (i == 3) { sideC = side; }
            }

            try
            {
                var triangle = new Triangle(sideA, sideB, sideC);
                Console.WriteLine($"Периметр теугольника: {triangle.Perimeter()}");
                Console.WriteLine($"Площадь треугольника: {triangle.Square()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }
    }
}
