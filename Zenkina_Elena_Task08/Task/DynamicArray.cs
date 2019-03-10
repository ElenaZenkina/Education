using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class DynamicArray<T> where T : new()
    {
        private T[] dynArray;
        /// <summary>
        /// Длина заполненной части массива.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Ёмкость массива - количество всех элементов.
        /// </summary>
        public int Capacity { get; set; }


        /// <summary>
        /// Конструктор без параметров создаёт массив емкостью 8 элементов.
        /// </summary>
        public DynamicArray()
        {
            dynArray = new T[8];
            Length = 0;
            Capacity = 8;
        }

        /// <summary>
        /// Конструктор массива с заданной емкостью.
        /// </summary>
        public DynamicArray(int capacity)
        {
            CorrectCapacity(capacity);
            dynArray = new T[capacity];
            Length = 0;
            Capacity = capacity;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает массив.
        /// </summary>
        public DynamicArray(DynamicArray<T> sourceArray)
        {
            dynArray = new T[sourceArray.Capacity];
            sourceArray.dynArray.CopyTo(dynArray, 0);
            Length = Capacity = sourceArray.Length;
        }

        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером.
        /// </summary>
        public T this[int index]
        {
            get
            {
                CorrectIndex(index);
                return dynArray[index];
            }
            set
            {
                CorrectIndex(index);
                dynArray[index] = value;
                // При необходимости увеличиваем длину заполненной части массива
                Length = Length <= index ? ++index : Length;
            }
        }

        private void CorrectIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("Index", $"Индекс {index} не должен выходить за границу массива");
            }
        }

        private void CorrectCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity", $"Емкость массива {capacity} не может быть отрицательным числом");
            }
        }

        private void Resize(int capacity)
        {
            Array.Resize(ref dynArray, capacity);
            Capacity = capacity;
        }

        /// <summary>
        /// Добавление одного элемента в конец массива.
        /// </summary>
        public void Add(T item)
        {
            if (Length == Capacity)
            {
                Resize(Capacity == 0 ? 1 : Capacity * 2);
            }

            dynArray[Length++] = item;
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
            CorrectIndex(index);
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
