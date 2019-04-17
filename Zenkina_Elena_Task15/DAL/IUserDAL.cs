using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDAL
    {
        void Add(Entities.User user);
        IEnumerable<Entities.User> GetList();
    }
}
