using System;

namespace MyLibrary
{
    public class ArrayLib
    {

        /// <summary>
        /// Создает одномерный массив случайных целых чисел.
        /// </summary>
        /// <param name="N">Количество элементов в массиве</param>
        /// <param name="minArray">Минимально возможное значение элемента массива</param>
        /// <param name="maxArray">Максимально возможное значение элемента массива</param>
        /// <returns>Одномерный массив</returns>
        public static int[] GenerateArray(int N, int minArray, int maxArray)
        {
            var rnd = new Random();
            var myArray = new int[N];

            for (int i = 0; i < N; i++)
            {
                myArray[i] = rnd.Next(minArray, maxArray);
            }
            return myArray;
        }

        /// <summary>
        /// Вывод элементов одномерного массива на экран.
        /// </summary>
        /// <param name="message">Сообщение на экране для пояснения смысла массива</param>
        /// <param name="myArray">Массив</param>
        public static void OutputArray(string message, int[] myArray)
        {
            Console.WriteLine(message);
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + "\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод элементов двумерного массива на экран.
        /// </summary>
        /// <param name="message">Сообщение на экране для пояснения смысла массива</param>
        /// <param name="myArray">Массив</param>
        public static void OutputArray(string message, int[,] myArray)
        {
            Console.WriteLine(message);
            var N = myArray.GetUpperBound(0) + 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(myArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод на экран всех элементов трехмерного массива в одну строку.
        /// </summary>
        /// <param name="message">Сообщение на экране для пояснения смысла массива</param>
        /// <param name="myArray">Массив</param>
        public static void OutputArray(string message, int[,,] myArray)
        {
            Console.WriteLine(message);
            foreach (var item in myArray)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

    }
}
