using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
	public class HashCodeDemo
	{
		public static void Demo(/*string[] args*/)
		{
			TwoDPoint point1 = new TwoDPoint(1, 10);
			TwoDPoint point2 = new TwoDPoint(1, 10);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());

			TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 1);
			TwoDPointWithHash newPoint2 = new TwoDPointWithHash(10, 10);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());

            // уникальных точек будет 2, хотя координаты их одинаковы
            //Console.WriteLine("TwoDPointWithHash:");          // Здесь надо изменить заголовок для точек типа TwoDPoint
            Console.WriteLine("TwoDPoint:");

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

	class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{}

		public override int GetHashCode()
		{
			return 17 * X ^ 23 * Y; // ^ выполняет операцию логического исключающего XOR побитно

			// в чем тут проблема?
		}
	}
}
