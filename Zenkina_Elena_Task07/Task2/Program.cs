using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISeries progression = new GeometricalProgression(2, 2);
            Console.WriteLine("Geometrical Progression:");
            PrintSeries(progression);

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
    }

    public class GeometricalProgression : ISeries
    {
        double start, step;
        int currentIndex;

        public GeometricalProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.currentIndex = 1;
        }

        public double GetCurrent()
        {
            return start * Math.Pow(step, currentIndex);
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

    }

    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();
    }
}
