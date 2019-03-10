using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dynArray = new DynamicArray<int>();
            Output("Конструктор без параметров создаёт массив емкостью 8 элементов:", dynArray);

            var myArray = new DynamicArray<int>(10);
            Output("Конструктор массива с заданной емкостью 10:", myArray);

            myArray.Add(0);
            myArray.Add(1);
            myArray.Add(1);
            myArray.Add(2);
            myArray.Add(3);
            myArray.Add(5);
            myArray.Add(8);
            myArray.Add(13);
            myArray.Add(21);
            myArray.Add(34);

            dynArray = new DynamicArray<int>(myArray);
            Output("Конструктор, который в качестве параметра принимает массив (с числами Фибоначчи):", dynArray);

            dynArray.Add(55);
            Output("Добавление одного элемента в конец массива:", dynArray);

            myArray = new DynamicArray<int>(3);
            myArray.Add(89);
            myArray.Add(144);
            myArray.Add(233);
            dynArray.AddRange(myArray);
            Output("Добавление в конец массива элементов другого массива:", dynArray);

            if (dynArray.Remove(34))
            {
                Output("Удаление элемента, содержащего значение 34:", dynArray);
            }

            dynArray.Insert(9, 34);
            Output("Добавление числа 34 на позицию с индексом 9:", dynArray);

            // Попытка вставить элемент с индексом 99
            try
            {
                dynArray.Insert(99, 34);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();

        }

        private static void Output(string message, DynamicArray<int> dynArray)
        {
            Console.WriteLine(message);
            if (dynArray.Length > 0)
            {
                for (int i = 0; i < dynArray.Length; i++)
                {
                    Console.Write("{0}\t", dynArray[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Длина заполненной части массива: {dynArray.Length}, емкость массива: {dynArray.Capacity}.");
            Console.WriteLine();
        }
    }
}
