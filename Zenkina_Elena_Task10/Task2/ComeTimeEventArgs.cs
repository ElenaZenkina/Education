using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ComeTimeEventArgs
    {
        public readonly DateTime ComeTime;

        public ComeTimeEventArgs(DateTime comeTime)
        {
            ComeTime = comeTime;
        }
    }
}
