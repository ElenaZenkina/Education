using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private delegate bool EqualLengthString(string string1, string string2);

        private static void Main(string[] args)
        {
            var stringArray = new[] { "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix",
                "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf", "vingt", "vingt et un", "vingt-deux"};

            Output("Исходный массив строк:", stringArray);

            SortByStringLength(stringArray, CompareTwoStrings);

            Output("Массив строк после сортировки:", stringArray);
            Console.ReadKey();
        }

        private static void SortByStringLength(string [] stringArray, EqualLengthString compare)
        {
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
            }
        }

        // Здесь для сравнения можно использовать различные методы с с учетом культурной среды, регистра символов и т.п.
        private static bool CompareTwoStrings(string string1, string string2) => 
            (string1.Length > string2.Length || (string1.Length == string2.Length && String.Compare(string1, string2) > 0));


        private static void Output(string message, string[] stringArray)
        {
            Console.WriteLine(message);
            foreach (var item in stringArray)
            {
                Console.WriteLine(item);
            }
        }

    }

}
