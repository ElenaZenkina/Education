using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class AdvanceDynamicArray<T> : DynamicArray<T>, IEnumerable<T> where T : new()
    {
        /// <summary>
        /// Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable.
        /// </summary>
        public AdvanceDynamicArray(IEnumerable<T> sourceArray)
        {
            dynArray = new T[sourceArray.Count()];
            var simpleArray = sourceArray.ToArray();
            simpleArray.CopyTo(dynArray, 0);

            Length = simpleArray.Length;
        }

        // Реализуем интерфейс IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < dynArray.Length; i++)
            {
                yield return dynArray[i];
            }

            // Или можно записать одной строкой:
            //return dynArray.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
