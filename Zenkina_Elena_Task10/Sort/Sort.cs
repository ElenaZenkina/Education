using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sort
{
    public delegate bool EqualLengthString(string string1, string string2);

    public class SortArray
    {
        public static event EventHandler SortFinished;

        public static void SortByStringLength(string[] stringArray, EqualLengthString compare)
        {
            if (stringArray == null || compare == null)
            {
                throw new ArgumentNullException();
            }

            // Сортировка методом пузырька
            for (int i = 0; i < stringArray.Length; i++)
            {
                for (int j = i + 1; j < stringArray.Length; j++)
                {
                    if (compare(stringArray[i], stringArray[j]))
                    {
                        string tempString = stringArray[i];
                        stringArray[i] = stringArray[j];
                        stringArray[j] = tempString;
                    }
                }
                Console.WriteLine("Сортировка в отдельном потоке, итерация " + i);
            }

            SortFinished?.Invoke(stringArray, EventArgs.Empty);
        }


        public static void CreateThreadForSorting(string[] stringArray, EqualLengthString compare)
        {
            Thread thread = new Thread(() => SortByStringLength(stringArray, compare));
            thread.Start();
        }

    }

}
