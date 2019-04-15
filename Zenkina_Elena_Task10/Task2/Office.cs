using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Office
    {
        public delegate void Welcome(Person person, ComeTimeEventArgs comeTime);
        public delegate void Farewell(Person person);

        // Сссылки на методы приветствий
        private Welcome greetAll;

        // Ссылки на методы прощания
        private Farewell byeAll;

        private List<Person> persons;

        public Office()
        {
            persons = new List<Person>();
        }

        /// <summary>
        /// В офис пришел один сотрудник.
        /// </summary>
        public void ComeOneEmployee(Person person, DateTime time)
        {
            person.OnHello += OnCameHandler;
            person.OnGoodbye += OnLeaveHandler;
            person.Come(time);
            persons.Add(person);
        }

        /// <summary>
        /// Один сотрудник уходит домой.
        /// </summary>
        public bool ExitOneEmployee(Person p)
        {
            var person = persons.Find(pers => pers.Name == p.Name);
            if (person == null) { return false; }

            if (!persons.Remove(person)) { return false; }

            person.Exit();
            return true;
        }


        private void OnCameHandler(Person person, ComeTimeEventArgs comeTime)
        {
            Console.WriteLine();
            Console.WriteLine($"[На работу пришел {person.Name}.]");

            greetAll?.Invoke(person, comeTime);

            greetAll += person.SayHello;
            byeAll += person.SayGoodbye;
        }

        private void OnLeaveHandler(Person person)
        {
            Console.WriteLine();
            Console.WriteLine($"[{person.Name} ушел домой.]");

            greetAll -= person.SayHello;
            byeAll -= person.SayGoodbye;

            byeAll?.Invoke(person);
        }

    }
}
