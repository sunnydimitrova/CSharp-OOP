using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var model = input[0];

                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);

                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];

                var tires = new Tire[4];
                var counter = 0;
                for (int tireIndex = 5; tireIndex < input.Length; tireIndex+=2)
                {
                    var currentTirePressure = double.Parse(input[tireIndex]);
                    var currntTireAge = int.Parse(input[tireIndex + 1]);

                    var currentTire = new Tire(currentTirePressure, currntTireAge);
                    tires[counter] = currentTire;
                    counter++;
                }
                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var currentCar = new Car(model, engine, cargo, tires);

                cars.Add(currentCar);
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            {
                cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(c => c.TirePressure < 1))
                    .ToList().ForEach(c => Console.WriteLine(c.Model));
            }
            else if (command == "flamable")
            {
                cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .ToList().ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
