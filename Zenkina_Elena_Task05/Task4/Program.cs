using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая реализует собственный класс MyString.");

            var myString1 = new MyString("Александр ");
            var myString2 = new MyString("Сергеевич ");
            var myString3 = new MyString("Пушкин");

            var concate2String = myString1 + myString3;
            Console.WriteLine($"Конкатенация двух строк: {concate2String.ToString()}");

            var concate3String = myString1 + myString2 + myString3;
            Console.WriteLine($"Конкатенация трех строк: {concate3String.ToString()}");

            var removeSubString = concate2String - myString3;
            Console.WriteLine($"Удаление подстроки: {removeSubString.ToString()}");

            Console.WriteLine($"Сравнение строк {removeSubString.ToString()} и {myString1.ToString()}: {removeSubString == myString1}");

            Console.WriteLine($"Сравнение строк {myString3.ToString()} и {myString1.ToString()}: {myString3 == myString1}");

            Console.WriteLine("Нажмите Enter для выхода из программы.");
            Console.ReadLine();

        }
    }
}
