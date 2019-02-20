using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IIndexableSeries progression = new ArithmeticalProgression(2, 2);
            Console.WriteLine("Progression:");
            PrintSeries(progression);

            try
            {
                AccessByIndex(progression, 5);
                AccessByIndex(progression, -3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            IIndexableSeries list = new List(new double[] { 5, 8, 6, 3, 1 });
            Console.WriteLine("List:");
            PrintSeries(list);

            try
            {
                AccessByIndex(list, 2);
                AccessByIndex(list, 8);
                AccessByIndex(list, 21);
                AccessByIndex(list, -3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static void PrintSeries(ISeries series)
        {
            series.Reset();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

        // Метод, демонстрирующий работу с объектами «IIndexable», то есть с индексом.
        static void AccessByIndex(IIndexableSeries series, int index)
        {
            // В арифметической прогрессии индексация начинается с 1, в других последовательностях с 0.
            int beginIndex = series is ArithmeticalProgression ? 1 : 0;
            Console.WriteLine($"Элемент с индексом {index} имеет значение {series[index]} (индексация начинается с {beginIndex}).");
        }
    }


    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();
    }

    public interface IIndexable
    {
        double this[int index] { get; }
    }

    interface IIndexableSeries : ISeries, IIndexable
    {
    }


    public class ArithmeticalProgression : IIndexableSeries
    {
        double start, step;
        int currentIndex;

        public ArithmeticalProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.currentIndex = 1;
        }

        public double GetCurrent()
        {
            //return start + step * currentIndex;
            return CalculateElement(currentIndex);
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = 1;
        }

        // Вместо типа int для индекса можно использовать тип uint, тогда не придется проверять на отрицательное значение.
        public double this[int index]
        {
            get
            {
                if (index <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Индекс {index} не может быть отрицательным числом.");
                }
                return CalculateElement(index);
            }
        }

        private double CalculateElement(int index)
        {
            return start + step * index;
        }

    }


    public class List : IIndexableSeries
    {
        private double[] series;
        private int currentIndex;

        public List(double[] series)
        {
            this.series = series;
            currentIndex = 0;
        }

        public double GetCurrent()
        {
            return series[currentIndex];
        }

        public bool MoveNext()
        {
            currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
            return true;
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Индекс {index} не может быть отрицательным числом.");
                }
                return series[index % series.Length];
            }
        }

    }
}
