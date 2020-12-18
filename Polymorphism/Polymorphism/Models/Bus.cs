using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public double DriveFullBus(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption + 1.4);
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= neededFuel;
            throw new Exception($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
