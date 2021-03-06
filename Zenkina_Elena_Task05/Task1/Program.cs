﻿using System;
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
            Console.WriteLine("Создание класса User:");

            var users = new User[3];

            try
            {
                users[0] = new User("Чингиз", "Торекулович", "Айтматов", new DateTime(1928, 12, 12));
                users[1] = new User("Юрий", "Алексеевич", "Гагарин", new DateTime(1934, 3, 9));
                users[2] = new User("Владимир", "Семенович", "Высоцкий", new DateTime(1938, 1, 25));

                // Здесь неправильна задана фамилия
                users[0] = new User("Чингиз", "Торекулович", "Айтматов!", new DateTime(1928, 12, 12));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (var _user in users)
            {
                Output(_user);
            }

            Console.WriteLine("Нажмите Enter.");
            Console.ReadLine();
        }

        private static void Output(User user)
        {
            var age = String.Empty;
            if (user.Age % 10 == 1) { age = "год"; }
            else if (user.Age % 10 == 2 || user.Age % 10 == 3 || user.Age % 10 == 4) { age = "года"; }
            else { age = "лет"; }
            Console.WriteLine($"{user.Name} {user.MiddleName} {user.LastName} родился {user.Birthday:d}, сегодня ему было бы {user.Age} {age}.");
        }
    }
}
