using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая определяет сумму неотрицательных элементов в одномерном массиве.");

            var N = 10;
            var minArray = -100;
            var maxArray = 100;
            var myArray = MyLibrary.ArrayLib.GenerateArray(N, minArray, maxArray);

            MyLibrary.ArrayLib.OutputArray("Исходный массив:", myArray);

            Console.WriteLine("Сумма неотрицательных элементов равна: " + SumPositive(myArray));

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }


        static int SumPositive(int[] myArray)
        {
            var sum = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                sum += 0 <= myArray[i] ? myArray[i] : 0;
            }
            return sum;
        }

    }
}
