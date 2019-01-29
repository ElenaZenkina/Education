using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая определяет сумму элементов двумерного массива, стоящих на чётных позициях.");

            var N = 7;
            var minArray = -100;
            var maxArray = 100;
            var myArray = Generate2DArray(N, minArray, maxArray);

            MyLibrary.ArrayLib.OutputArray("Исходный массив:", myArray);

            Console.WriteLine("Сумма элементов двумерного массива, стоящих на чётных позициях, равна: " + SumEvenNumbers(myArray));

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }

        static int SumEvenNumbers(int[,] myArray)
        {
            var sum = 0;
            var N = myArray.GetUpperBound(0) + 1;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sum += ((i + j) % 2 == 0) ? myArray[i, j] : 0;
                }
            }
            return sum;
        }

        static int[,] Generate2DArray(int N, int minArray, int maxArray)
        {
            var rnd = new Random();
            var myArray = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    myArray[i, j] = rnd.Next(minArray, maxArray);
                }
            }
            return myArray;
        }

    }
}
