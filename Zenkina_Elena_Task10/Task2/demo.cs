using System;
using System.Collections.Generic;
 
namespace ConsoleApplication1
{
    /*
        Делегаты для описания событий класса Person
     */
    public delegate void OnCame(Person p, DateTime time);
    public delegate void OnLeave(Person p);
 
    public class Person
    {
        public string Name { get; set; }
        public event OnCame OnCame;
        public event OnLeave OnLeave;
 
        public void GoToWork()
        {
            //logic
            OnCame?.Invoke(this, DateTime.Now);
        }
 
        public void GoHome()
        {
            // logic
            OnLeave?.Invoke(this);
        }
 
        public void SayHello(string otherPerson, DateTime time)
        {
            // say hello
        }
 
        public void SayGoodBye(string otherName)
        {
            // say bye
        }
    }
}
 
namespace ConsoleApplication1
{
    class Program
    {
        void Main1(string[] args)
        {
        }
    }
 
   /*
        Делегаты для описания multicast делегатов офиса
        которые он использует, чтобы хранить ссылки на методы преветствия и прощания
        вместо того, чтобы хранить явные ссылки на Person
    */ 
    public delegate void SayHello(string otherPerson, DateTime time);
    public delegate void SayBye(string otherName);
 
    class Office
    {
        // хранит ссылки на методы приветствий
        private SayHello greetAll;

        // хранит ссылки на методы прощания
        private SayBye byeAll;
 
        public Office(List<Person> persons)
        {
            foreach(var p in persons)
            {
                // подписываемся на события Person
                p.OnCame += OnCameHandler;
                p.OnLeave += OnLeaveHandler;
            }
        }
 
        private void OnCameHandler(Person p, DateTime time)
        {
 
            Console.WriteLine($"[Person {p.Name} came to work]");
            // вызываем все методы приветствия, какие есть
            // (если в офисе есть люди, то значит они уже положили свои методы в этот делегат. а значит они поприветствуют нового человека)
            greetAll?.Invoke(p.Name, time);
 
            // кладём в multicast делегаты ссылки на методы преветствия и прощаний пришёдшего работника
            greetAll += p.SayHello;
            byeAll += p.SayGoodBye;
        }
 
        private void OnLeaveHandler(Person p)
        {
            Console.WriteLine($"[Person {p.Name} leaved]");
            // удаляем из multicast делегатов ссыки на методы уходящего работника
            // чтобы он больше никого не приветствовал и ни с кем не прощался
            greetAll -= p.SayHello;
            byeAll -= p.SayGoodBye;
 
            // вызываем оставшиеся методы прощания
            byeAll?.Invoke(p.Name);
        }
    }
}
