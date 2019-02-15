using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Triangle
    {
        private int a = 1;
        private int b = 1;
        private int c = 1;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0)
                {
                    a = value;
                }
            }
        }

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0)
                {
                    b = value;
                }
            }
        }

        public int C
        {
            get { return c; }
            set
            {
                if (value > 0)
                {
                    c = value;
                }
            }
        }

        private bool IsSideCorrect(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0) { return false; }
            // Любая сторона треугольника меньше суммы двух других сторон и больше их разности.
            return (c < a + b) && (c > Math.Abs(a - b)) &&
                   (a < c + b) && (a > Math.Abs(c - b)) &&
                   (b < a + c) && (b > Math.Abs(a - c));
        }

        public bool IsSideCorrect()
        {
            return IsSideCorrect(this.a, this.b, this.c);
        }

        public Triangle()
        { }

        public Triangle(int a, int b, int c)
        {
            if (IsSideCorrect(a, b, c))
            {
                A = a;
                B = b;
                C = c;
            }
        }

        public int Perimeter()
        {
            return a + b + c;
        }

        public double Square()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
