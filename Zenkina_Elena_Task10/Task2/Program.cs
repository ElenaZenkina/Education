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
            string[] employees = {"Джон", "Билл", "Хьюго", "Кит"};

            var office = new Office();

            // Все сотрудники по очереди приходят в офис.
            foreach (var person in employees)
            {
                office.ComeOneEmployee(new Person(person), DateTime.Now);
            }

            // Домой уходит Билл.
            RemoveEmployee(office, new Person(employees[1]));

            // Билл опять приходит на работу.
            office.ComeOneEmployee(new Person(employees[1]), DateTime.Now);

            // А теперь все по очереди уходят домой.
            for (int i = 0; i < employees.Length; i++)
            {
                RemoveEmployee(office, new Person(employees[i]));
            }

            Console.ReadKey();
        }

        private static void RemoveEmployee(Office office, Person person)
        {
            if (!office.ExitOneEmployee(person))
            {
                Console.WriteLine($"Сотрудника по имени {person.Name} нет в офисе.");
            }
        }
    }

}
