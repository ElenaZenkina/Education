using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Triangle
    {
        private int a;
        private int b;
        private int c;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0 && SideIsCorrect(value, b, c))
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
                if (value > 0 && SideIsCorrect(value, a, c))
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
                if (value > 0 && SideIsCorrect(value, a, b))
                {
                    c = value;
                }
            }
        }

        private bool SideIsCorrect(int x, int a, int b)
        {
            // Любая сторона треугольника меньше суммы двух других сторон и больше их разности.
            if (a == 0 || b == 0) return true;
            return (x < a + b) && (x > Math.Abs(a - b));
        }

        public Triangle()
        { }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
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
