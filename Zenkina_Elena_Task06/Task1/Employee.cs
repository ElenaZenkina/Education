using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Employee : User
    {
        private string position = "инженер";
        private int experience = 0;

        /// <summary>
        /// Должность
        /// </summary>
        public string Position
        {
            get { return position; }
            set
            {
                if (PositionIsCorrect(value))
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

        private bool PositionIsCorrect(string position)
        {
            return NamesIsCorrect(position);
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
