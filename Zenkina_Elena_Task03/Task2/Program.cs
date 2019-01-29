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
            Console.WriteLine("Программа, которая заменяет все положительные элементы в трехмерном массиве на нули.");

            var N = 4;
            var minArray = -100;
            var maxArray = 100;
            var myArray = Generate3DArray(N, minArray, maxArray);

            MyLibrary.ArrayLib.OutputArray("Вывод всех элементов трехмерного массива в одну строку:", myArray);

            ReplaceZero(myArray);
            MyLibrary.ArrayLib.OutputArray("Вывод всех элементов после замены на нули:", myArray);

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }

        static int[,,] Generate3DArray(int N, int minArray, int maxArray)
        {
            var rnd = new Random();
            var myArray = new int[N, N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        myArray[i, j, k] = rnd.Next(minArray, maxArray);
                    }
                }
            }
            return myArray;
        }

        static void ReplaceZero(int[,,] myArray)
        {
            var N = myArray.GetUpperBound(0) + 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        myArray[i, j, k] = 0 < myArray[i, j, k] ? 0 : myArray[i, j, k];
                    }
                }
            }
        }

    }
}
