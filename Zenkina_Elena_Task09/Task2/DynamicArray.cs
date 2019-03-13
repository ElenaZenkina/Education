using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Этот класс и его реализация взята из задания №8
    /// </summary>
    partial class DynamicArray<T> where T : new()
    {
        private T[] dynArray;
        /// <summary>
        /// Длина заполненной части массива.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Ёмкость массива - количество всех элементов.
        /// </summary>
        public int Capacity => dynArray.Length;


        /// <summary>
        /// Конструктор без параметров создаёт массив емкостью 8 элементов.
        /// </summary>
        public DynamicArray() : this(8)
        {
        }

        /// <summary>
        /// Конструктор массива с заданной емкостью.
        /// </summary>
        public DynamicArray(int capacity)
        {
            IsCapacityCorrect(capacity);
            dynArray = new T[capacity];
            Length = 0;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает массив.
        /// </summary>
        public DynamicArray(DynamicArray<T> sourceArray)
        {
            dynArray = new T[sourceArray.Capacity];
            sourceArray.dynArray.CopyTo(dynArray, 0);
            Length = sourceArray.Length;
        }

        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером.
        /// </summary>
        public T this[int index]
        {
            get
            {
                IsIndexCorrect(index, Length - 1);
                return dynArray[index];
            }
            set
            {
                IsIndexCorrect(index, Length - 1);
                dynArray[index] = value;
                // При необходимости увеличиваем длину заполненной части массива
                Length = Length <= index ? ++index : Length;
            }
        }

        private void IsIndexCorrect(int index, int maxValue)
        {
            if (index < 0 || index > maxValue)
            {
                throw new ArgumentOutOfRangeException("Index", $"Индекс {index} не должен выходить за границу массива");
            }
        }

        private void IsCapacityCorrect(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity", $"Емкость массива {capacity} не может быть отрицательным числом");
            }
        }

        private void Resize(int capacity)
        {
            Array.Resize(ref dynArray, capacity);
        }

        /// <summary>
        /// Добавление одного элемента в конец массива.
        /// </summary>
        public void Add(T item)
        {
            Insert(Length, item);
        }

        /// <summary>
        /// Добавление в конец массива содержимого переданного массива.
        /// </summary>
        public void AddRange(DynamicArray<T> addArray)
        {
            var addArrayLen = addArray.Length;

            if (addArray == null || addArrayLen == 0)
            {
                return;
            }

            if (Length + addArrayLen > Capacity)
            {
                Resize(Length + addArrayLen);
            }

            for (int i = 0; i < addArrayLen; i++)
            {
                dynArray[Length + i] = addArray[i];
            }

            Length += addArrayLen;
        }

        /// <summary>
        /// Удаление указанного элемента.
        /// </summary>
        public bool Remove(T item)
        {
            if (dynArray == null || Length == 0)
            {
                return false;
            }

            int index = Array.IndexOf(dynArray, item);
            if (index == -1)
            {
                return false;
            }

            for (int i = index; i < Length - 1; i++)
            {
                dynArray[i] = dynArray[i + 1];
            }

            Length--;
            return true;
        }

        /// <summary>
        /// Добавление элемента в произвольную позицию массива.
        /// </summary>
        public bool Insert(int index, T item)
        {
            // Возможна вставка элемента на позицию Length, это равнозначно добавлению элемента в конец списка.
            IsIndexCorrect(index, Length);
            if (Length == Capacity)
            {
                Resize(Capacity == 0 ? 1 : Capacity * 2);
            }

            for (int i = Length; i > index; i--)
            {
                dynArray[i] = dynArray[i - 1];
            }
            dynArray[index] = item;

            Length++;
            return true;
        }

    }
}
