using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        enum SORT_DIRECT { Increase, Decrease }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая генерирует элементы массива.");

            var N = 10;
            var minArray = -100;
            var maxArray = 100;
            var myArray = MyLibrary.ArrayLib.GenerateArray(N, minArray, maxArray);

            MyLibrary.ArrayLib.OutputArray("Исходный массив:", myArray);

            Console.WriteLine("Минимальное значение: " + GetMinValue( myArray ));
            Console.WriteLine("Максимальное значение: " + GetMaxValue( myArray ));

            Sort(myArray, SORT_DIRECT.Increase);
            MyLibrary.ArrayLib.OutputArray("Массив, отсортированыый по возрастанию:", myArray);

            Sort(myArray, SORT_DIRECT.Decrease);
            MyLibrary.ArrayLib.OutputArray("Массив, отсортированыый по убыванию:", myArray);

            Console.WriteLine("Для завершения работы программы нажмите Enter.");
            Console.ReadLine();
        }


        static int GetMinValue(int[] myArray)
        {
            var minValue = myArray[0];
            for (int i = 0; i < myArray.Length; i++)
            {
                minValue = myArray[i] < minValue ? myArray[i] : minValue;
            }
            return minValue;
        }


        static int GetMaxValue(int[] myArray)
        {
            var maxValue = myArray[0];
            for (int i = 0; i < myArray.Length; i++)
            {
                maxValue = maxValue < myArray[i] ? myArray[i] : maxValue;
            }
            return maxValue;
        }


        static void Sort(int[] myArray, SORT_DIRECT dirSort)
        {
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if ( (dirSort == SORT_DIRECT.Increase && myArray[i] > myArray[j]) ||
                         (dirSort == SORT_DIRECT.Decrease && myArray[i] < myArray[j]))
                    {
                        var temp = myArray[i];
                        myArray[i] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }
        }

    }
}
