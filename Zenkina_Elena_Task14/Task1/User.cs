using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class User
    {
        private DateTime birthdate;
        private string firstName;
        private string lastName;

        public int ID { get; set; }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (IsStringValid(value, 50, true))
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(FirstName), value, $"Имя должно содержать от 1 до 50 символов.");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (IsStringValid(value, 50, true))
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(LastName), value, $"Фамилия должна содержать от 1 до 50 символов.");
                }
            }
        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                if (DateTime.Now.AddYears(-150) < value && value < DateTime.Now)
                {
                    birthdate = value;
                    Age = (DateTime.MinValue + DateTime.Now.Subtract(birthdate)).Year - 1;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Birthdate), value, $"Дата рождения должна быть в диапазоне от {DateTime.Now.AddYears(-150)} до {DateTime.Now}.");
                }
            }
        }
        public int Age { get; private set; }

        public List<Reward> RewardsList { get; set; }

        public string ListRewardsToString
        {
            get
            {
                if (RewardsList == null || RewardsList.Count == 0) { return String.Empty; }
                string str = String.Empty;
                foreach (var rew in RewardsList)
                {
                    str += rew.Title + ", ";
                }
                return str.Remove(str.Length - 2);
            }
        }

        public User(int id, string firstName, string lastName, DateTime birthday)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthday;
            RewardsList = new List<Reward>();
        }

        public User(int id, string firstName, string lastName, DateTime birthday, List<Reward> listReward): this(id, firstName, lastName, birthday)
        {
            RewardsList = listReward;
        }

        /// <summary>
        /// Проверка корректности строки
        /// </summary>
        /// <param name="str">Проверяемая строка</param>
        /// <param name="maxLength">Максимально допустимая длина строки</param>
        /// <param name="required">Обязательное ли значение</param>
        /// <returns>Соответствие строки указанным требованиям</returns>
        private bool IsStringValid(string str, int maxLength, bool required)
        {
            if (str.Length > maxLength) { return false; }
            return !required || (required && str.Length > 0);
        }
    }
}
