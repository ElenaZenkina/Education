﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task1
{
    public class User
    {
        private string name;
        private string middleName;
        private string lastName;
        private DateTime birthday;
        private int age;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (NamesIsCorrect(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name", $"Имя {value} задано некорректно.");
                }
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (NamesIsCorrect(value))
                {
                    middleName = value;
                }
                else
                {
                    throw new ArgumentException("MiddleName", $"Имя {value} задано некорректно.");
                }
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (NamesIsCorrect(value))
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("LastName", $"Имя {value} задано некорректно.");
                }
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (DateTime.Now.AddYears(-100) < value && value < DateTime.Now)
                {
                    birthday = value;
                    age = (DateTime.MinValue + DateTime.Now.Subtract(birthday)).Year - 1;
                }
                else
                {
                    throw new ArgumentException("Birthday", $"Дата {value} задана некорректно.");
                }
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get { return age; }
        }

        protected bool NamesIsCorrect(string name)
        {
            // ФИО может содержать только буквы и иногда тире.
            // Здесь можно также поставить условие, что имена в ФИО не короче 3 символов
            // (хотя у корейцев есть имя/фамилия Ю), и они пишутся с заглавной буквы.
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я-]*$", RegexOptions.Compiled);

            return (regex.IsMatch(name)) && (name.Trim().Length > 0);
        }

        public User(string name, string middleName, string lastName, DateTime birthday)
        {
            Name = name;
            MiddleName = middleName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
