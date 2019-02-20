using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.CreateMap();
            game.SettingGame();

            while (true)
            {
                var rendezvous = game.Traverse();

                // Игрок встретился с бонусом - удалить бонус с карты
                if (rendezvous is Bonus)
                {
                    game.player.Traverse((Bonus)rendezvous);
                    game.map.Remove(rendezvous);
                    if (game.map.BonusNumber == 0)
                    {
                        // Все бонусы съедены - игра пройдена
                        break;
                    }
                }
                // Игрок встретился с препятствием
                else if (rendezvous is Barrier)
                {
                    game.player.Traverse((Barrier)rendezvous);
                }
                // Игрок встретился с монстром - конец игры
                else if (rendezvous is Monster)
                {
                    break;
                }
                // Перемещение игрока
                else
                {
                    game.player.Move();
                }

            }
        }
    }


    /// <summary>
    /// Игра - события/действия, которые происходят в игре.
    /// </summary>
    class Game
    {
        public Map map;
        public Player player;

        public void CreateMap()
        {
            map = new Map();
            player = new Player(new Point(0, 0), "player");
        }

        // Начальные установки игры
        public void SettingGame()
        {
            // Начальное расположение объектов на карте.
            CreateBarriers();
            CreateMonsters();
            CreateBonuses();
        }

        // Встретился ли игрок с каким-либо объектом на карте.
        public Item Traverse()
        {
            foreach (var item in map.Items)
            {
                if (player.IsEquals(item))
                {
                    return item;
                }
            }
            return null;
        }

        // Координаты каждого объекта на карте задаются случайным образом.
        // Каждый объект добавляется на карту с помощью Map.Add(item), если он вернул false, то надо задать другие координаты для объекта.
        private void CreateBarriers() { }
        private void CreateMonsters() { }
        private void CreateBonuses() { }
    }


    /// <summary>
    /// Карта со всеми объектами на ней
    /// </summary>
    class Map
    {
        // Список всех объектов карты
        public List<Item> Items;
        // Количество бонусов на карте (как только BonusNumber == 0, то игра закончена)
        public int BonusNumber { get; private set; }

        public Map()
        {
            Items = new List<Item>();
        }

        // Существует ли на карте объект с такими координатами.
        private bool IsExist(Item item)
        {
            return true;
        }

        // Добавление объекта на карту (в игру). Возвращает true, если добавление прошло успешно.
        public bool Add(Item item)
        {
            if (IsExist(item)) { return false; }
            return true;
        }

        // Удаление объекта с карты (из игры).
        public void Remove(Item item)
        {}
    }

}
