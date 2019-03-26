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
            try
            {
                var oneEmployee = new Employee("Иван", "Петрович", "Сидоров", new DateTime(1969, 9, 26), "инженер", 25);

                var twoEmployee = new Employee("Сидор", "Петрович", "Иванов", new DateTime(1969, 9, 26), "инженер", 25);

                var equal = oneEmployee.Equals(twoEmployee);

                Console.WriteLine($"Сравнение {oneEmployee.LastName} с {twoEmployee.LastName}: {equal}.");

                twoEmployee.Name = "Иван";
                twoEmployee.LastName = "Сидоров";

                equal = oneEmployee.Equals(twoEmployee);

                Console.WriteLine($"Сравнение {oneEmployee.LastName} с {twoEmployee.LastName}: {equal}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
