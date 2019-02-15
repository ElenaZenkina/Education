using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round
    {
        private double radius = 1.0;

        /// <summary>
        /// Координаты центра окружности.
        /// </summary>
        public Coordinate center;

        /// <summary>
        /// Радиус окружности.
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
            }
        }

        /// <summary>
        /// Длина окружности.
        /// </summary>
        public double Circumference
        {
            get { return 2 * Math.PI * radius; }
        }

        /// <summary>
        /// Площадь круга.
        /// </summary>
        public double Square
        {
            get { return Math.PI * radius * radius; }
        }

        public Round()
        {
        }

        public Round(Coordinate center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }
    }

    public class Coordinate
    {
        // На координатной плоскости значения X и Y могут быть как положительными, так и отрицательными,
        // хотя здесь тоже можно придумать какие-то ограничения.
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate()
        {
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
