using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Office
    {
        private List<Person> persons;

        public Office()
        {
            persons = new List<Person>();
        }

        /// <summary>
        /// В офис пришел один сотрудник.
        /// </summary>
        public void ComeEmployee(Person person)
        {
            foreach (var employee in persons)
            {
                person.OnHello += employee.Hello;
            }

            person.Come(/*person, */DateTime.Now);
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

            foreach (var employee in persons)
            {
                person.OnGoodbye += employee.Bye;
            }

            person.Exit();
            // Удалить все подписки
            person.Unsubscribe();
            return true;
        }

    }
}
