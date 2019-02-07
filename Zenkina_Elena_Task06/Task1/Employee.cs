using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Employee : User
    {
        private string position;
        private int experience;

        /// <summary>
        /// Должность
        /// </summary>
        public string Position
        {
            get { return position; }
            set
            {
                if (NamesIsCorrect(value))
                {
                    position = value;
                }
            }
        }

        /// <summary>
        /// Стаж
        /// </summary>
        public int Experience
        {
            get { return experience; }
            set
            {
                if (value >= 0)
                {
                    experience = value;
                }
            }
        }

        public Employee()
        {
        }

        public Employee(string name, string middleName, string lastName, DateTime birthday, string position, int experience)
            : base (name, middleName, lastName, birthday)
        {
            Position = position;
            Experience = experience;
        }

        // Можно добавить уровень владения специальностью и поля, связанные с зарплатой:
        public enum Levels {Junior, Middle, Senior};
        public Levels Level { get; set; }

        private double salary;
        private double bonus;

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
            }
        }

        public double Bonus
        {
            get { return bonus; }
            set
            {
                if (value >= 0)
                {
                    bonus = value;
                }
            }
        }

    }
}
