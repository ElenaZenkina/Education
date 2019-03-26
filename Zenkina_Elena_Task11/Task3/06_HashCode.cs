using System;
using System.Collections.Generic;
using System.Linq;

namespace NetBasicsDemo
{
	public class HashCodeDemo
	{
		public static void Demo(/*string[] args*/)
		{
			TwoDPoint point1 = new TwoDPoint(1, 10);
			TwoDPoint point2 = new TwoDPoint(1, 10);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());

			TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 1);
			TwoDPointWithHash newPoint2 = new TwoDPointWithHash(2, 2);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());

			// уникальных точек будет 2, хотя координаты их одинаковы
			Console.WriteLine("TwoDPointWithHash:");

			var twoDPointList = new List<TwoDPoint> { point1, point2 };
			var distinctTwoDPointList = twoDPointList.Distinct();
			foreach (var point in distinctTwoDPointList)
			{
				Console.WriteLine("Distinct point: {0}", point);
			}

			// одна уникальная точка
			Console.WriteLine("TwoDPointWithHash:");

			var twoDPointWithHashList = new List<TwoDPointWithHash> { newPoint1, newPoint2 };
			var distinctTwoDPointWithHashList = twoDPointWithHashList.Distinct();
			foreach (var point in distinctTwoDPointWithHashList)
			{
				Console.WriteLine("Distinct point: {0}", point);
			}
		}
	}

    class TwoDPoint : IEquatable<TwoDPoint>
    {
        // Readonly auto-implemented properties.
        public int X { get; private set; }
        public int Y { get; private set; }

        // Set the properties in the constructor.
        public TwoDPoint(int x, int y)
        {
            if ((x < 1) || (x > 2000) || (y < 1) || (y > 2000))
            {
                throw new System.ArgumentException("Point must be in range 1 - 2000");
            }
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as TwoDPoint);
        }

        public bool Equals(TwoDPoint p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return X * 0x00010000 + Y;
            //return 17 * X.GetHashCode() + 23 * Y.GetHashCode();
        }

        public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs)
        {
            return !(lhs == rhs);
        }
    }

    class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{}

		public override int GetHashCode()
		{
            return X ^ Y; // ^ выполняет операцию логического исключающего XOR побитно

            // в чем тут проблема?

            //return 17 * X.GetHashCode() + Y.GetHashCode();
        }
	}
}
