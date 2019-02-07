using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Ring : Round
    {
        private double inRadius;

        /// <summary>
        /// Внутренний радиус кольца.
        /// </summary>
        public double InRadius
        {
            get { return inRadius; }
            set
            {
                if (value > 0 && value < Radius)
                {
                    inRadius = value;
                }
            }
        }

        /// <summary>
        /// Суммарная длина внешней и внутренней границ кольца.
        /// </summary>
        public double RingCircumference
        {
            get { return (2 * Math.PI * Radius) + (2 * Math.PI * inRadius); }
        }

        /// <summary>
        /// Площадь кольца.
        /// </summary>
        public double RingSquare
        {
            get { return (Math.PI * Radius * Radius) - (Math.PI * inRadius * inRadius); }
        }

    }
}
