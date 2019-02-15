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
            Console.WriteLine("Создание класса Round:");

            var round = new Round();
            round.center = new Coordinate(10, 20);
            round.Radius = MyLibrary.InputConsole.InputDouble("Введите радиус окружности (вещественное число): ");

            if (round.Radius <= 0)
            {
                Console.WriteLine($"Длина окружности: {round.Circumference}");
                Console.WriteLine($"Площадь круга: {round.Square}");
            }
            else
            {
                Console.WriteLine("Радиус введен некорректно.");
            }

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();
        }
    }
}
