using System;
using System.Collections.Generic;
using Vehicles;
using Vehicles.Models;

namespace Polymorphism
{
    public class Program
    {
        static void Main(string[] args)
        { 
            var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle  car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    var command = input[0];
                    var type = input[1];
                    if (command == "Drive")
                    {
                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(double.Parse(input[2])));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(input[2])));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(bus.DriveFullBus(double.Parse(input[2])));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.Drive(double.Parse(input[2])));
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
