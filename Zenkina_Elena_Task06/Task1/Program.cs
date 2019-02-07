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
            Console.WriteLine("Создание класса Employee:");

            var employees = new Employee[3];

            var employee = new Employee();
            employee.Name = "Чингиз";
            employee.MiddleName = "Торекулович";
            employee.LastName = "Айтматов";
            employee.Birthday = new DateTime(1928, 12, 12);
            employee.Position = "писатель";
            employee.Experience = 50;

            employees[0] = employee;
            employees[1] = new Employee("Юрий", "Алексеевич", "Гагарин", new DateTime(1934, 3, 9), "летчик-испытатель", 20);
            employees[2] = new Employee { Name = "Владимир", MiddleName = "Семенович", LastName = "Высоцкий", Birthday = new DateTime(1938, 1, 25), Position = "поэт", Experience = 25 };

            foreach (var emp in employees)
            {
                Output(emp);
            }

            Console.WriteLine("Нажмите Enter.");
            Console.ReadLine();

        }

        private static void Output(Employee user)
        {
            var age = String.Empty;
            if (user.Age % 10 == 1) { age = "год"; }
            else if (user.Age % 10 == 2 || user.Age % 10 == 3 || user.Age % 10 == 4) { age = "года"; }
            else { age = "лет"; }
            Console.WriteLine($"{user.Name} {user.MiddleName} {user.LastName} родился {user.Birthday:d}, знаменитый {user.Position}, " + 
                $"проработавший {user.Experience} {age}, сегодня ему было бы {user.Age} {age}.");
        }

    }
}
