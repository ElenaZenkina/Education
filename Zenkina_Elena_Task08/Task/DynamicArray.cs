using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class DynamicArray<T> where T : new()
    {
        T[] dynArray;
        int length;
        int capacity;

        /// <summary>
        /// Конструктор без параметров создаёт массив емкостью 8 элементов.
        /// </summary>
        public DynamicArray()
        {
            dynArray = new T[ 8 ];
            length = 0;
            capacity = 8;
        }

        /// <summary>
        /// Конструктор массива с заданной емкостью.
        /// </summary>
        public DynamicArray(uint capacity)
        {
            dynArray = new T[ capacity ];
            length = 0;
            this.capacity = (int)capacity;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает массив.
        /// </summary>
        public DynamicArray(DynamicArray<T> sourceArray)
        {
            dynArray = new T[sourceArray.Length];
            sourceArray.dynArray.CopyTo(dynArray, 0);
            length = sourceArray.Length;
            capacity = length;
        }

        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером.
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= capacity)
                {
                    throw new ArgumentOutOfRangeException("Index", $"Индекс {index} не должен выходить за границу массива");
                }
                return dynArray [ index ];
            }
            set
            {
                if (index < 0 || index >= capacity)
                {
                    throw new ArgumentOutOfRangeException("Index", $"Индекс {index} не должен выходить за границу массива");
                }
                dynArray [ index ] = value;
                // При необходимости увеличиваем длину заполненной части массива
                length = length <= index ? ++index : length;
            }
        }

        private void Resize(int capacity)
        {
            Array.Resize(ref dynArray, capacity);
            this.capacity = capacity;
        }

        public void Add(T item)
        {
            if (length == capacity)
            {
                Resize(capacity == 0 ? 1 : capacity * 2);
            }

            dynArray[length++] = item;
        }

        public void AddRange(DynamicArray<T> addArray)
        {
            var addArrayLen = addArray.Length;

            if (addArray == null || addArrayLen == 0)
            {
                return;
            }

            if (length + addArrayLen > capacity)
            {
                Resize(length + addArrayLen);
            }

            for (int i = 0; i < addArrayLen; i++)
            {
                dynArray[length + i] = addArray[i];
            }

            length += addArrayLen;
        }

        /// <summary>
        /// Удаление указанного элемента.
        /// </summary>
        public bool Remove(T item)
        {
            if (dynArray == null || length == 0)
            {
                return false;
            }

            int index = Array.IndexOf(dynArray, item);
            if (index == -1)
            {
                return false;
            }

            for (int i = index; i < length - 1; i++)
            {
                dynArray[i] = dynArray[i + 1];
            }

            dynArray[ --length ] = default(T);
            return true;
        }

        /// <summary>
        /// Добавление элемента в произвольную позицию массива.
        /// </summary>
        public bool Insert(int index, T item )
        {
            if (index < 0 || index >= capacity)
            {
                throw new ArgumentOutOfRangeException("Index", $"Индекс {index} не должен выходить за границу массива");
            }
            if (length == capacity)
            {
                Resize(capacity == 0 ? 1 : capacity * 2);
            }

            for (int i = length; i > index; i--)
            {
                dynArray[i] = dynArray[i - 1];
            }
            dynArray[index] = item;

            length++;
            return true;
        }

        /// <summary>
        /// Получение длины заполненной части массива.
        /// </summary>
        public int Length => length;

        /// <summary>
        /// Получение ёмкости массива - количества всех элементов.
        /// </summary>
        public int Capacity => capacity;

    }
}
