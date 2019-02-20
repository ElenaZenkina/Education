using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new List<Figure>();

            Point point1, point2;

            while (true)
            {
                Console.WriteLine("Выберите тип фигуры: L - линия, R - прямоугольник, O - окружность, I - кольцо (другая клавиша - выход из программы):");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.L:
                        Console.WriteLine();
                        Console.WriteLine("Координаты начала линии:");
                        point1 = InputPoint();
                        Console.WriteLine("Координаты конца линии:");
                        point2 = InputPoint();

                        DrawAndAdd(new Line(point1, point2), figures);
                        break;

                    case ConsoleKey.R:
                        Console.WriteLine();
                        Console.WriteLine("Координаты левого верхнего угла прямоугольника:");
                        point1 = InputPoint();

                        Console.WriteLine("Координаты нижнего правого угла прямоугольника:");
                        point2 = InputPoint();

                        DrawAndAdd(new Rectangle(point1, point2), figures);
                        break;

                    case ConsoleKey.O:
                        Console.WriteLine();
                        Console.WriteLine("Координаты центра окружности:");
                        point1 = InputPoint();

                        int radius = MyLibrary.InputConsole.InputInt("Радиус окружности:");

                        DrawAndAdd(new Circle(point1, radius), figures);
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine();
                        Console.WriteLine("Координаты центра кольца:");
                        point1 = InputPoint();

                        int inRadius = MyLibrary.InputConsole.InputInt("Внешний радиус окружности:");
                        int exRadius = MyLibrary.InputConsole.InputInt("Внутрений радиус окружности:");

                        DrawAndAdd(new Ring(point1, new Circle(point1, inRadius), new Circle(point1, exRadius)), figures);
                        break;
                    default:
                        return;
                }
            }
        }


        private static Point InputPoint()
        {
            var x = MyLibrary.InputConsole.InputInt("Введите значение координаты Х:");
            var y = MyLibrary.InputConsole.InputInt("Введите значение координаты Y:");

            return new Point(x, y);
        }


        private static void DrawAndAdd(Figure figure, List<Figure> figures)
        {
            figure.Draw();
            figures.Add(figure);
        }
    }
}
