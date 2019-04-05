using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1
{
    class Program
    {
        delegate int ToSquare(int x);

        static void Main(string[] args)
        {
            const string fileName = @"d:\disposable_task_file.txt";

            string contents = ReadFile(fileName);
            if (String.IsNullOrEmpty(contents))
            {
                Console.WriteLine($"Файл {fileName} не существует или он пуст.");
                Console.ReadKey();
                return;
            }

            int[] intArray = StringToIntArray(contents);

            SquareEachToIntArray(intArray, Square);

            contents = IntArrayToString(intArray);

            WriteFile(fileName, contents);

            Console.WriteLine("Замена чисел на их квадраты прошла успешно.");
            Console.ReadKey();

        }

        private static int Square(int x) => checked(x * x);

        /// <summary>
        /// Возведение в квадрат каждого элемента массива.
        /// </summary>
        private static void SquareEachToIntArray(int[] intArray, ToSquare square)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                try
                {
                    intArray[i] = square(intArray[i]);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"Переполнение при возведениие в квадрат числа {intArray[i]} в строке {i + 1} ({e.Message}).");
                }
            }
        }

        /// <summary>
        /// Строку в массив отдельных строк с конвертацией в число
        /// </summary>
        private static int[] StringToIntArray(string contents)
        {
            var stringArray = contents.Split(new Char[] {'\r', '\n', '\t'} , StringSplitOptions.RemoveEmptyEntries);

            int[] intArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!Int32.TryParse(stringArray[i], out intArray[i]))
                {
                }
            }
            return intArray;
        }

        /// <summary>
        /// Массив чисел в одну строку
        /// </summary>
        private static string IntArrayToString(int[] intArray)
        {
            string content = String.Empty;
            foreach (var intArr in intArray)
            {
                content += intArr.ToString() + "\r\n";
            }
            return content;
        }

        /// <summary>
        /// Чтение всего файла в одну строку.
        /// </summary>
        private static string ReadFile(string fileName)
        {
            var content = String.Empty;

            if (!File.Exists(fileName)) { return content; }

            using (StreamReader sReader = File.OpenText(fileName))
            {
                content = sReader.ReadToEnd();
            }
            return content;
        }
        
        /// <summary>
        /// Запись строки в файл (файл перезаписывается).
        /// </summary>
        private static void WriteFile(string fileName, string contents)
        {
            using (StreamWriter sWriter = new StreamWriter(fileName, false))
            {
                sWriter.Write(contents);
            }
        }
    }
}
