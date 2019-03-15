using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Person
    {
        public delegate void EventHello(Person person, ComeTimeEventArgs comeTime);
        public delegate void EventGoodbye(Person person);

        public event EventHello OnHello;
        public event EventGoodbye OnGoodbye;

        public string Name;

        public Person(string name)
        {
            Name = name;
        }

        public void Hi(/*Person person, */DateTime comeTime)
        {
            // Факт прихода сотрудника
            OnHello?.Invoke(this, new ComeTimeEventArgs (comeTime));
        }

        public void Bye(/*Person person*/)
        {
            // Факт ухода сотрудника
            OnGoodbye?.Invoke(this);
        }
    }

    public class ComeTimeEventArgs : EventArgs
    {
        public readonly DateTime ComeTime;

        public ComeTimeEventArgs(DateTime comeTime)
        {
            ComeTime = comeTime;
        }
    }
}
