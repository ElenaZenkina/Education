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
            // Программа, демонстрирующая класс DynamicArray, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable.
            var list = new List<int>(Enumerable.Range(1, 12));
            var myArray = new AdvanceDynamicArray<int>(list);

            // Благодаря реализации интерфейса IEnumerable, можно пройтись по нашему массиву foreach.
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
