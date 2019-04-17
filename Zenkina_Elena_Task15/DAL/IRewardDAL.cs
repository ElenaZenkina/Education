using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRewardDAL
    {
        void Add(Entities.Reward user);
        IEnumerable<Entities.Reward> GetList();
    }
}
