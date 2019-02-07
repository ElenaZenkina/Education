using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание класса Ring:");

            var ring = new Ring();
            ring.center = new Coordinate(10, 20);

            ring.Radius = MyLibrary.InputConsole.InputDouble("Введите внешний радиус кольца (вещественное число): ");
            ring.InRadius = MyLibrary.InputConsole.InputDouble("Введите внутренний радиус кольца (вещественное число): ");

            if (ring.Radius == 0 || ring.InRadius == 0)
            {
                var radius = ring.Radius == 0 ? "Внешний" : "Внутренний";
                Console.WriteLine($"{radius} радиус введен некорректно.");
            }
            else
            {
                Console.WriteLine($"Длины окружностей кольца: {ring.RingCircumference}");
                Console.WriteLine($"Площадь кольца: {ring.RingSquare}");
            }

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }

    }
}
