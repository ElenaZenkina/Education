using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate void EventHello(Person person, ComeTimeEventArgs comeTime);
    public delegate void EventGoodbye(Person person);

    public class Person
    {
        public event EventHello OnHello;
        public event EventGoodbye OnGoodbye;

        public string Name;

        public Person(string name)
        {
            Name = name;
        }

        // Факт прихода сотрудника.
        public void Come(/*Person person, */DateTime comeTime)
        {
            Console.WriteLine();
            Console.WriteLine("[На работу пришел " + Name + ".]");
            OnHello?.Invoke(this, new ComeTimeEventArgs(comeTime));
        }

        public void Hello(Person person, ComeTimeEventArgs comeTime)
        {
            var salute = String.Empty;
            if (comeTime.ComeTime.Hour < 12)
            {
                salute = "'Доброе утро, ";
            }
            else if (comeTime.ComeTime.Hour < 17)
            {
                salute = "'Добрый день, ";
            }
            else
            {
                salute = "'Добрый вечер, ";
            }

            Console.WriteLine(salute + person.Name + "!', - сказал " + Name + ".");
        }

        // Факт ухода сотрудника.
        public void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("[" + Name + " ушел домой.]");
            OnGoodbye?.Invoke(this);
        }

        public void Bye(Person person)
        {
            Console.WriteLine("'До свидания, " + person.Name + "!', - сказал " + Name + ".");
        }

        public void Unsubscribe()
        {
            this.OnHello = null;
            this.OnGoodbye = null;
        }
    }

}
