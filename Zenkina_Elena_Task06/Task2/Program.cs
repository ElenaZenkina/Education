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

            var externalRadius = MyLibrary.InputConsole.InputDouble("Введите внешний радиус кольца (вещественное число): ");
            var innerRadius = MyLibrary.InputConsole.InputDouble("Введите внутренний радиус кольца (вещественное число): ");

            var center = new Coordinate(10, 20);
            var innerRound = new Round(center, innerRadius);
            var externalRound = new Round(center, externalRadius);
            var ring = new Ring(externalRound, innerRound);

            Console.WriteLine($"Длины окружностей кольца: {ring.RingCircumference}");
            Console.WriteLine($"Площадь кольца: {ring.RingSquare}");

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }

    }
}
