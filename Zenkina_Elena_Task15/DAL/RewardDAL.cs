using System;
using System.Collections.Generic;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RewardDAL : IRewardDAL
    {
        private List<Reward> rewards = new List<Reward>();

        public void Add(Entities.Reward reward)
        {
            if (rewards == null)
            {
                throw new ArgumentException("Список наград пуст.", "List<Reward>");
            }
            rewards.Add(reward);
        }

        public IEnumerable<Reward> GetList()
        {
            return rewards;
        }
    }
}
