using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double fuealConsumption;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => fuealConsumption + 1.6;
        

        public override void Refuel(double liters)
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
                this.FuelQuantity += liters * 0.95;
            }
        }
        
    }
}
