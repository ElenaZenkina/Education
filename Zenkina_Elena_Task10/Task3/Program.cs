using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task3
{
    class Program
    {
        private delegate bool EqualLengthString(string string1, string string2);

        static void Main(string[] args)
        {
            var stringArray = new[] { "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix",
                "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf", "vingt", "vingt et un", "vingt-deux"};

            var irregularVerbs = new[] { "be", "beat", "become", "begin", "bend", "bet", "bite", "blow", "break", "bring",
                "build", "buy", "catch", "choose", "come", "cost", "cut", "deal", "dig", "do", "draw", "drink", "drive",
                "eat", "fall", "feed", "feel", "fight", "find", "fly", "forget", "forgive", "freeze", "get", "give", "go", "grow",
                "hang", "have", "hear", "hide", "hit", "hold", "hurt", "keep", "know",
                "lay", "lead", "leave", "lend", "let", "lie", "light", "lose", "make", "mean", "meet",
                "pay", "put", "read", "ride", "ring", "rise", "run", "say", "see", "seek", "sell", "send", "set", "shake", "shine", "shoot", "show",
                "shut", "sing", "sink", "sit", "sleep", "speak", "spend", "stand", "steal", "stick", "strike", "swear", "sweep", "swim", "swing",
                "take", "teach", "tear", "tell", "think", "throw", "understand", "wake", "wear", "win", "write" };

            // Сообщение на событие об окончании сортировки
            Sort.SortArray.SortFinished += EndOfTheSorting;

            // Сортировка в отдельном потоке
            Sort.SortArray.CreateThreadForSorting(irregularVerbs, CompareTwoStrings);

            // Сортировка в главном потоке
            SortByStringLength(irregularVerbs, CompareTwoStrings);

            Console.ReadKey();
        }


        static void SortByStringLength(string[] stringArray, EqualLengthString compare)
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
                Console.WriteLine("Сортировка в основном потоке, итерация " + i);
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


        // Событие, сигнализирующее о завершении сортировки.
        private static void EndOfTheSorting(object stringArray, EventArgs e)
        {
            Console.WriteLine("Сортировка завершена.");
        }
    }
}
