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

            var center = new Coordinate(10, 20);
            double radius = MyLibrary.InputConsole.InputDouble("Введите радиус окружности (вещественное число): ");

            try
            {
                var round = new Round(center, radius);
                Console.WriteLine($"Длина окружности: {round.Circumference}");
                Console.WriteLine($"Площадь круга: {round.Square}");
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
