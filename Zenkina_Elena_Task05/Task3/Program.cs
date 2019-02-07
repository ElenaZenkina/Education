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

            var triangle = new Triangle();

            for (int i = 1; i <= 3; i++)
            {
                int side = MyLibrary.InputConsole.InputInt($"Введите длину {i} стороны треугольника (целое число): ");

                if (i == 1) { triangle.A = side; }
                if (i == 2) { triangle.B = side; }
                if (i == 3) { triangle.C = side; }
            }
            
            if (triangle.A == 0 || triangle.B == 0 || triangle.C == 0)
            {
                Console.WriteLine("Одна из сторон треугольника введена некорректно. Расчет невозможен.");
            }
            else
            {
                Console.WriteLine($"Периметр теугольника: {triangle.Perimeter()}");
                Console.WriteLine($"Площадь треугольника: {triangle.Square()}");
            }

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }
    }
}
