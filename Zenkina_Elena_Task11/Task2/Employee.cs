using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee : User, IEquatable<Employee>
    {
        private string position;
        private int experience;

        public override bool Equals(object obj)
        {
            return Equals(obj as Employee);
        }

        public bool Equals(Employee employee)
        {
            if (ReferenceEquals(employee, null))
            {
                return false;
            }

            if (ReferenceEquals(this, employee))
            {
                return true;
            }

            if (this.GetType() != employee.GetType())
            {
                return false;
            }

            return Name.Equals(employee.Name) && MiddleName.Equals(employee.MiddleName) && 
                LastName.Equals(employee.LastName) && Birthday.Equals(employee.Birthday) && 
                Position.Equals(employee.Position) && Experience.Equals(employee.Experience);
        }

        // При переопределении Equals рекомендуется переопределить GetHashCode таким образом, чтобы два объекта с равными значениями создавали одинаковый хэш-код.
        // Для этого рекомендуется использовать простые числа (я выбрала 17 и 23, хотя читала про рекомендации о больших числах типа 2166136261).
        // При переопределении рекомендуется завязываться на неизменяемые поля (хотя в данном случае ФИО и ДР могут изменяться для одного экземпляра Employee
        // в случае неправильного ввода).
        // В книге Рихтера говориться о том, что:
        //      должно использоваться минимум одно экземплярное поле,
        //      лучше не использовать вызов метода GetHashCode для базового типа.
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (23 * hash) ^ Name.Length;
                hash = (23 * hash) ^ Birthday.Year;
                return hash;
            }
        }

        // При переопределении Equals рекомендуется перегрузить операторы == и !=.
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            if (ReferenceEquals(employee1, null))
            {
                if (ReferenceEquals(employee2, null))
                {
                    return true;
                }

                return false;
            }
            return employee1.Equals(employee2);
        }

        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return !(employee1 == employee2);
        }


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
                else
                {
                    throw new ArgumentException($"Введенная должность '{value}' некорректна.");
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
                if (value >= 0 && value < Age)
                {
                    experience = value;
                }
                else
                {
                    throw new ArgumentException($"Стаж '{value}' не может быть меньше 0 и больше возраста {Age}.");
                }
            }
        }

        private bool PositionIsCorrect(string position)
        {
            return NamesIsCorrect(position);
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
