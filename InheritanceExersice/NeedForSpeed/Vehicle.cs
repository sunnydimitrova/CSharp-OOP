using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(double fuel, int horsePower)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public void Drive(double kilometers)
        {
            bool canDrive = Fuel - kilometers * FuelConsumption >= 0;
            if (canDrive)
            {
                Fuel -= kilometers * FuelConsumption;
            }
            
        }
    }
}
