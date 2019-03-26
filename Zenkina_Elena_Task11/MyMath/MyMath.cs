using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public static class MyMath
    {
        public static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return checked (x * Factorial(x - 1));
            }
        }

        public static int Square(int x)
        {
            return checked(x * x);
        }

        public static double Square(double x)
        {
            return checked(x * x);
        }
    }
}
