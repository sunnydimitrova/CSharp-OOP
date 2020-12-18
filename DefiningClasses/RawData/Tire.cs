using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private double tirePressure;
        private int tireAge;

        public Tire(double tirePressure, int tireAge)
        {
            TirePressure = tirePressure;
            TireAge = tireAge;
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }       

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

    }
}
