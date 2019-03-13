using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var menNumber = 10;

            // Использование коллекции типа LinkedList<T>

            var arrLinkedList = new LinkedList<int>(Enumerable.Range(1, menNumber));
            Console.WriteLine("Удаление каждого второго элемента в коллекции типа LinkedList.");
            Console.WriteLine("Исходная коллекция:" + string.Join(" ", arrLinkedList));

            // Реализация удаления каждого второго элемента без обращения к элементам напрямую по индексу
            var currentItem = arrLinkedList.First;
            while (arrLinkedList.Count != 1)
            {
                arrLinkedList.Remove(currentItem.Next ?? arrLinkedList.First);
                currentItem = currentItem.Next ?? arrLinkedList.First;
            }
            Console.WriteLine($"Результат для коллекции из {menNumber} элементов: {arrLinkedList.First.Value}");
            Console.WriteLine();


            // Аналогично для коллекции типа List<T>

            var arrList = new List<int>(Enumerable.Range(1, menNumber));
            Console.WriteLine("Удаление каждого второго элемента в коллекции типа List.");
            Console.WriteLine("Исходная коллекция: " + string.Join(" ", arrList));

            var i = 0;
            while (arrList.Count != 1)
            {
                arrList.RemoveAt(i + 1 < arrList.Count ? i + 1 : 0);
                i = i + 1 < arrList.Count ? i + 1 : 0;
            }
            Console.WriteLine($"Результат для коллекции из {menNumber} элементов: {arrList[0]}");
            Console.WriteLine();


            // Общий метод для List<T> и LinkedList<T>.
            Console.WriteLine("Удаление каждого второго элемента для List<T> и LinkedList<T> на примере французских королей.");
            var roiList = new List<FrenchPerson>();
            CreateRoiList<FrenchPerson>(roiList);
            Console.Write($"Результат для коллекции из {roiList.Count} королей: ");

            var flag = true;
            while (roiList.Count != 1)
            {
                flag = RemoveEachSecondItem(roiList, flag);
            }
            Console.WriteLine(roiList[0]);

            Console.ReadKey();
        }

        /// <summary>
        /// Удаление каждого второго элемента коллекции.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Коллекция, которая содержит N человек, стоящих по кругу</param>
        /// <param name="odd">True - первый элемент коллекции - нечетный, т.е. с него начинаем отсчет и удаляем каждый второй элемент;
        /// false - отсчет начинается с последнего элемента, т.к. список закольцован, то дальше удаляем первый элемент и т.д.</param>
        private static bool RemoveEachSecondItem<T>(ICollection<T> list, bool odd)
        {
            // Массив для хранения тех элементов коллекции (каждого второго), которые надо оставить.
            // Используется, т.к. в foreach нельзя изменять коллецию, по которой проходит цикл.
            T[] newList = new T [list.Count / 2 + 1];

            var j = 0;
            foreach (var item in list)
            {
                // Нечетные элементы коллекции не вычеркиваются, т.е. их надо сохранить.
                if (odd)
                {
                    newList[ j++ ] = item;
                }
                odd = !odd;
            }

            // Результат вычеркивания каждого второго записываем в исходную коллекцию.
            list.Clear();
            for (int i = 0; i < j; i++)
            {
                list.Add(newList[ i ]);
            }

            return odd;
        }

        private static void CreateRoiList<T>(ICollection<FrenchPerson> roiList)
        {
            roiList.Add(new FrenchPerson("Филипп VI Валуа", "Philippe VI de Valois", 1328, 1350));
            roiList.Add(new FrenchPerson("Иоанн II Добрый", "Jean II Le Bon", 1350, 1364));
            roiList.Add(new FrenchPerson("Карл V Мудрый", "Charles V Le Sage", 1364, 1380));
            roiList.Add(new FrenchPerson("Карл VI Безумный", "Charles VI Le Fol", 1380, 1422));
            roiList.Add(new FrenchPerson("Карл VII Победоносный", "Charles VII Le Victorieux", 1422, 1461));
            roiList.Add(new FrenchPerson("Людовик XI Благоразумный", "Louis XI Le Prudent", 1461, 1483));
            roiList.Add(new FrenchPerson("Карл VIII Любезный", "Charles VIII L’Affable", 1483, 1498));
            roiList.Add(new FrenchPerson("Людовик XII Отец народа", "Louis XII Le Père du peuple", 1498, 1515));
            roiList.Add(new FrenchPerson("Франциск I Король-рыцарь", "Le Roi Chevalier", 1515, 1547));
            roiList.Add(new FrenchPerson("Генрих II", "Henri II", 1547, 1559));
            roiList.Add(new FrenchPerson("Франциск II", "François II", 1559, 1560));
            roiList.Add(new FrenchPerson("Карл IX", "Charles IX", 1560, 1574));
            roiList.Add(new FrenchPerson("Генрих III", "Henri III de Valois", 1574, 1589));
            roiList.Add(new FrenchPerson("Генрих IV Великий", "Henri IV Le Grand", 1589, 1610));
            roiList.Add(new FrenchPerson("Людовик XIII Справедливый", "Louis XIII Le Juste", 1610, 1643));
            roiList.Add(new FrenchPerson("Людовик XIV Король Солнце", "Louis XIV Le Roi Soleil", 1643, 1715));
            roiList.Add(new FrenchPerson("Людовик XV Возлюбленный", "Louis XV Le Bien Aimé", 1715, 1774));
            roiList.Add(new FrenchPerson("Людовик XVI", "Louis XVI", 1774, 1792));

            // Вывод на экран
            foreach (var roi in roiList)
            {
                Console.WriteLine(roi.ToString());
            }
        }
    }


    // Класс для демонстрации работы с обощенными коллекциями не только для типов int, string etc
    public class FrenchPerson
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int BeginReign { get; set; }
        public int EndReign { get; set; }

        public FrenchPerson(string name, string fullName, int beginReign, int endReign)
        {
            Name = name;
            FullName = fullName;
            BeginReign = beginReign;
            EndReign = endReign;
        }

        public override string ToString()
        {
            return Name + " (фр. " + FullName + ") годы правления: " + BeginReign + " - " + EndReign + "";
        }
    }
}
