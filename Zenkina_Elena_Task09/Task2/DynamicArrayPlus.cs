using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Сюда добавлены пункты из задания №9
    /// </summary>
    partial class DynamicArray<T> : IEnumerable<T> where T : new()
    {
        /// <summary>
        /// Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable.
        /// </summary>
        public DynamicArray(IEnumerable<T> sourceArray)
        {
            dynArray = new T[sourceArray.Count()];
            var simpleArray = sourceArray.ToArray();
            simpleArray.CopyTo(dynArray, 0);

            Length = simpleArray.Length;
        }

        // Реализуем интерфейс IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return dynArray.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
