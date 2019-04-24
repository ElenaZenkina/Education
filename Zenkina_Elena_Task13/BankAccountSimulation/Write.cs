using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSimulation
{
    interface IWrite
    {
        void Write(string message);
    }

    public class WriteToConsole: IWrite
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
