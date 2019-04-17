using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reward
    {
        private string title;
        private string description;

        public int ID { get; set; }
        public string Title
        {
            get { return title; }
            set
            {
                if (IsStringValid(value, 50, true))
                {
                    title = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Title", value, $"Наименование должно содержать от 1 до 50 символов.");
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (IsStringValid(value, 250, false))
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Description", value, $"Описание должно содержать не более 250 символов.");
                }
            }
        }

        public Reward(int id, string title)
        {
            ID = id;
            Title = title;
        }

        public Reward(int id, string title, string description): this(id, title)
        {
            Description = description;
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
