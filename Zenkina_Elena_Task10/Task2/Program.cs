using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] employees = {"Джон Леннон", "Билл Уаймен", "Хьюго Леви", "Кит Ричардс"};

            var office = new SmallOffice();

            foreach (var person in employees)
            {
                office.ComeEmployee(new Person(person));
            }

            office.ExitEmployee();

            Console.ReadKey();
        }
    }

    class SmallOffice
    {
        delegate void Welcomes(string welcome);
        private Welcomes welcomes;
        // Индекс сотрудника, который приветствует/прощается в групповом делегате
        private int personIndex = 0;

        private List<Person> persons;

        public SmallOffice()
        {
            persons = new List<Person>();
        }

        /// <summary>
        /// В офис пришел один сотрудник.
        /// </summary>
        public void ComeEmployee(Person person)
        {
            person.OnHello += Hello;
            person.Hi(DateTime.Now);
            persons.Add(person);
        }

        /// <summary>
        /// Все сотрудники, начиная с пришедшего первым, уходят домой.
        /// </summary>
        public void ExitEmployee()
        {
            while (persons.Count > 0)
            {
                var person = persons[0];
                persons.RemoveAt(0);

                person.OnGoodbye += GoodBye;
                person.Bye();
            }
        }

        private void Hello(Person person, ComeTimeEventArgs comeTime)
        {
            Console.WriteLine("[На работу пришел " + person.Name + ".]");

            string salute;
            if (comeTime.ComeTime.Hour < 12)
            {
                salute = "'Доброе утро, " + person.Name + "!', - сказал ";
            }
            else if (comeTime.ComeTime.Hour < 17)
            {
                salute = "'Добрый день, " + person.Name + "!', - сказал ";
            }
            else
            {
                salute = "'Добрый вечер, " + person.Name + "!', - сказал ";
            }
            personIndex = 0;
            welcomes?.Invoke(salute);
            welcomes += Welcome;
            Console.WriteLine();
        }

        private void GoodBye(Person person)
        {
            Console.WriteLine("[" + person.Name + " ушел домой.]");
            personIndex = 0;
            welcomes -= Welcome;
            welcomes?.Invoke("'До свидания, " + person.Name + "!', - сказал ");
            Console.WriteLine();
        }

        private void Welcome(string salute)
        {
            Console.WriteLine(salute + persons[personIndex].Name + ".");
            // При каждом вызове из группового делегата меняется сотрудник, который приветствует/прощается.
            personIndex++;
        }
    }
}
