using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate void Welcome(Person person, ComeTimeEventArgs comeTime);
    public delegate void Farewell(Person person);

    public class Office
    {
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
        public void ComeOneEmployee(Person person)
        {
            Console.WriteLine();
            Console.WriteLine($"[На работу пришел {person.Name}.]");

            foreach (var p in persons)
            {
                person.OnHello += p.SayHello;
            }

            //person.Come(DateTime.Now);
            // Приветствие от уже пришедших на работу
            greetAll?.Invoke(person, new ComeTimeEventArgs(DateTime.Now));

            // Ссылки на методы преветствия и прощания, которые будет говорить вновь пришёдший работник
            greetAll += person.SayHello;
            byeAll += person.SayGoodbye;

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

            Console.WriteLine();
            Console.WriteLine($"[{person.Name} ушел домой.]");

            foreach (var employee in persons)
            {
                person.OnGoodbye += employee.SayGoodbye;
            }

            person.Exit();
            return true;
        }

    }
}
