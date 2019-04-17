using System;
using System.Collections.Generic;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        private List<User> users = new List<User>();

        public void Add(User user)
        {
            if (users == null)
            {
                throw new ArgumentException("Список пользователей пуст.", "List<User>");
            }
            users.Add(user);
        }

        public IEnumerable<User> GetList()
        {
            return users;
        }
    }
}
