using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая определяет среднюю длину слова.");

            Console.WriteLine("Введите ваш текст: ");
            int count = CountAverageLength(Console.ReadLine());
            Console.WriteLine($"Средняя длина слова { count } букв(а).");
            // Это можно записать в одну строку:
            //Console.WriteLine($"Средняя длина слова { AverageWordLength(Console.ReadLine()) } букв(ы).");

            Console.WriteLine("Работа программы завершена, нажмите Enter.");
            Console.ReadLine();
        }

        /// <summary>
        /// Вычисление средней длины слова.
        /// </summary>
        /// <returns>Целое число, но можно переделать в тип double для большей точности</returns>
        private static int CountAverageLength(string inputString)
        {
            // В этот список можно добавить знаки /\|*-+@#$%^&={}[], а также \t,
            // которые НЕ являются символами пунктуации, но и не являются словами.
            string[] words = inputString.Split(new char[] { ' ', '.', ',', ';', ':', '?', '!', '-', '(', ')', '\'', '"' }, StringSplitOptions.RemoveEmptyEntries);

            var i = 0;
            var sum = 0;

            foreach (var word in words)
            {
                i++;
                sum += word.Length;
            }
            // Здесь отбрасывается остаток от деления, но можно переделать на округление.
            return i == 0 ? 0 : sum / i;
        }
    }
}
