using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle 
    { 
        private double tankCapacity;
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {           
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }
        

        public string Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= neededFuel;
            return$"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            else if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }            
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
