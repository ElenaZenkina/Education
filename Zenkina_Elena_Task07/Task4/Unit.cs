using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Координаты на игровом поле (карте).
    /// </summary>
    class Point
    {
        private int x, y;

        public int X
        {
            get { return x; }
            set
            {
                // Здесь проверка на допустимое значение координаты Х, для Y - аналогично.
                // if (0 < value && value < Width)
                x = value;
            }
        }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    /// <summary>
    /// Базовый класс для всех объектов (игрока, монстров, препятствий, бонусов) в игре.
    /// </summary>
    abstract class Item
    {
        // Расположение (координаты) объекта на карте. Положение объекта на карте можно задавать двумя координатами:
        // левого верхнего и правого нижнего углов прямоугольника, в который будет вписано изображение объекта.
        public Point point;

        // Изображение объекта на карте (здесь может храниться путь к файлу с картинкой).
        // Можно выбрать другой тип переменной из System.Drawing, в котором будет храниться картинка.
        protected string image;

        public Item(Point point, string image)
        {
            this.point = point;
            this.image = image;
        }

        // Отрисовка объекта на карте
        public void Draw()
        {}

        // Есть ли объект с такими же координатами.
        public bool IsEquals(Item item)
        {
            return point.X == item.point.X && point.Y == item.point.Y;
        }
    }


    /// <summary>
    /// Базовый класс для всех "юнитов" - двигающихся объектов (игрока и монстров).
    /// </summary>
    abstract class Unit : Item
    {
        public Unit(Point point, string image) : base(point, image)
        { }

        // Перемещение объекта по карте.
        public abstract void Move();

        // Объект встретился с бонусом.
        public abstract void Traverse(Bonus bonus);

        // Объект встретился с препятствием.
        public abstract void Traverse(Barrier barrier);
    }


    /// <summary>
    /// Игрок
    /// </summary>
    class Player : Unit
    {
        // Одна из характеристик игрока (их можно сделать много)
        private int Character { get; set; }

        public Player(Point point, string image) : base(point, image)
        { }

        // Перемещает игрока по карте.
        public override void Move()
        {
        }

        // Игрок встретился с бонусом - увеличил свою характеристику.
        // Здесь можно подробно расписать изменение разных характеристик от разных бонусов.
        public override void Traverse (Bonus bonus)
        {
            Character += bonus.IncreaseCharacter;
        }

        // Игрок встретился с препятствием
        public override void Traverse(Barrier barrier)
        {
            // Заблокировать возможность двигаться в том же направлении и возможно ухудшить какую-то характеристику
            barrier.Turn();
        }

    }


    /// <summary>
    /// Монстры всех типов.
    /// </summary>
    abstract class Monster : Unit
    {
        public Monster(Point point, string image) : base(point, image)
        { }

        // Задает алгоритм перемещения монстров по карте (для каждого монстра свой алгоритм).
        public abstract override void Move();

        // Монстр встретился с бонусом.
        public override void Traverse(Bonus bonus)
        {
            BarrierForMonster(bonus);
        }

        // Монстр встретился с препятствием.
        public override void Traverse(Barrier barrier)
        {
            BarrierForMonster(barrier);
        }

        // Для монстра бонусы, препятствия и другие монстры являются препятствиями.
        private void BarrierForMonster(Item item)
        {
        }
    }


    /// <summary>
    /// Монстр-волк. Для каждого типа монстра свой алгоритм перемещения.
    /// </summary>
    class Wolf : Monster
    {
        public Wolf(Point point, string image) : base(point, image)
        { }

        // Задает алгоритм перемещения волка по карте.
        public override void Move()
        { }
    }


    /// <summary>
    /// Монстр-медведь. Для каждого типа монстра свой алгоритм перемещения.
    /// </summary>
    class Bear : Monster
    {
        public Bear(Point point, string image) : base(point, image)
        { }

        // Задает алгоритм перемещения медведя по карте.
        public override void Move()
        { }
    }


    /// <summary>
    /// Базовый класс для всех препятствий.
    /// </summary>
    abstract class Barrier : Item
    {
        public Barrier(Point point, string image) : base(point, image)
        { }

        public abstract void Turn();
    }


    /// <summary>
    /// Препятствие - камень
    /// </summary>
    class Stone : Barrier
    {
        public Stone(Point point, string image) : base(point, image)
        { }

        // Надо развернуться от препятствия, при этом можно потерять какую-то характеристику
        public override void Turn()
        { }
    }


    /// <summary>
    /// Препятствие - дерево
    /// </summary>
    class Tree : Barrier
    {
        public Tree(Point point, string image) : base(point, image)
        { }

        // Надо развернуться от препятствия
        public override void Turn()
        { }
    }


    /// <summary>
    /// Бонусы всех типов.
    /// </summary>
    abstract class Bonus : Item
    {
        // Увеличение характеристики игрока
        public abstract int IncreaseCharacter { get; }

        public Bonus(Point point, string image) : base(point, image)
        { }
    }


    /// <summary>
    /// Бонус-яблоко.
    /// </summary>
    class Apple : Bonus
    {
        public override int IncreaseCharacter
        {
            get
            {
                // Алгоритм вычисления значения бонуса-яблока
                return 1;
            }
        }

        public Apple(Point point, string image) : base(point, image)
        { }
    }

    /// <summary>
    /// Бонус-вишня.
    /// </summary>
    class Cherry : Bonus
    {
        public override int IncreaseCharacter
        {
            get
            {
                // Алгоритм вычисления значения бонуса-вишни
                return 2;
            }
        }
        public Cherry(Point point, string image) : base(point, image)
        { }

    }
}
