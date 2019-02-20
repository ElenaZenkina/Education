using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    abstract class Figure
    {
        protected abstract string FigureType { get; }
        public abstract void Draw();
    }


    class Line : Figure
    {
        public Point BeginPoint { get; set; }
        public Point EndPoint { get; set; }

        protected override string FigureType
        {
            get { return "Линия"; }
        }

        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {FigureType} ({GetType()}).");
            Console.WriteLine($"Ее параметры: координаты начальной точки {BeginPoint.ToString()}, конечной точки {EndPoint.ToString()}.");
        }

        public Line(Point beginPoint, Point endPoint)
        {
            BeginPoint = beginPoint;
            EndPoint = endPoint;
        }
    }


    class Rectangle : Figure
    {
        // Прямоугольник рисуется по двум точкам: левого верхнего и нижнего правого углов.
        public Point LeftUpPoint { get; set; }
        public Point RightDownPoint { get; set; }

        protected override string FigureType
        {
            get { return "Прямоугольник"; }
        }

        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {FigureType} ({GetType()}).");
            Console.WriteLine($"Ее параметры: координаты левого верхнего угла {LeftUpPoint.ToString()}, правого нижнего угла {RightDownPoint.ToString()}.");
        }

        public Rectangle(Point leftUpPoint, Point rightDownPoint)
        {
            LeftUpPoint = leftUpPoint;
            RightDownPoint = rightDownPoint;
        }
    }


    class Circle : Figure
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        protected override string FigureType
        {
            get { return "Окружность"; }
        }

        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {FigureType} ({GetType()}).");
            Console.WriteLine($"Ее параметры: центр окружности {Center.ToString()}, радиус {Radius}.");
        }

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }
    }


    class Ring : Figure
    {
        public Point Center { get; set; }
        public Circle InnerCircle { get; set; }
        public Circle ExternalCircle { get; set; }

        protected override string FigureType
        {
            get { return "Кольцо"; }
        }

        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {FigureType} ({GetType()}).");
            Console.WriteLine($"Ее параметры: центр окружности {Center.ToString()}, " + 
                $"внутренний радиус {InnerCircle.Radius}, внешний радиус {ExternalCircle.Radius}.");
        }

        public Ring(Point center, Circle inCircle, Circle extCircle)
        {
            Center = center;
            InnerCircle = inCircle;
            ExternalCircle = extCircle;
        }
    }


    /// <summary>
    /// Координаты точки (X, Y).
    /// </summary>
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + ", " + Y.ToString() + ")";
        }
    }
}
