using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Ring
    {
        private Round innerRing;
        private Round externalRing;
        public double innerRadius = 1;
        public double externalRadius = 2;

        public Coordinate center;
        public double InnerRadius
        {
            get { return innerRadius; }
            set
            {
                if (0 < value && value < externalRadius)
                {
                    innerRadius = value;
                }
            }
        }

        public double ExternalRadius
        {
            get { return externalRadius; }
            set
            {
                if (0 < value && value > innerRadius)
                {
                    externalRadius = value;
                }
            }
        }


        /// <summary>
        /// Суммарная длина внешней и внутренней границ кольца.
        /// </summary>
        public double RingCircumference
        {
            get { return (2 * Math.PI * innerRing.Radius) + (2 * Math.PI * externalRing.Radius); }
        }

        /// <summary>
        /// Площадь кольца.
        /// </summary>
        public double RingSquare
        {
            get { return (Math.PI * externalRing.Radius * externalRing.Radius) - (Math.PI * innerRing.Radius * innerRing.Radius); }
        }

        public Ring(Round innRing, Round exterRing)
        {
            if (innRing.Radius < exterRing.Radius)
            {
                innerRing = innRing;
                externalRing = exterRing;
            }
            else
            {
                innerRing = exterRing;
                externalRing = innRing;
            }

            if (innerRing.center.X != externalRing.center.X || innerRing.center.Y != externalRing.center.Y)
            {
                innerRing.center.X = externalRing.center.X;
                innerRing.center.Y = externalRing.center.Y;
            }
        }

    }
}
