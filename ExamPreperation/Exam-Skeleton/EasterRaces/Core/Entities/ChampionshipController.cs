using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var currDriver = drivers.GetByName(driverName);
            if (currDriver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            var currCar = cars.GetByName(carModel);
            if (currCar == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }
            currDriver.AddCar(currCar);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var currRace = this.races.GetByName(raceName);
            if (currRace == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            var currDriver = this.drivers.GetByName(driverName);
            if (currDriver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            currRace.AddDriver(currDriver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);           
            
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            var car1 = this.cars.GetByName(model);
            if (car1 != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }
            cars.Add(car);
            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            var driver = this.drivers.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }
            var driversToAdd = new Driver(driverName);
            this.drivers.Add(driversToAdd);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            var currRace = races.GetByName(name);
            if (currRace != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            this.races.Add(new Race(name, laps));
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var currRace = this.races.GetByName(raceName);
            if (currRace == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (currRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var carCollection = cars.GetAll().ToList();
            var bestDrivers = currRace.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(currRace.Laps)).ToArray();
            Driver first = (Driver)bestDrivers[0];
            Driver second = (Driver)bestDrivers[1];
            Driver tirth = (Driver)bestDrivers[2];
            first.WinRace();
            var sb = new StringBuilder();
            sb.AppendLine($"Driver {first.Name} wins {raceName} race.");
            sb.AppendLine($"Driver {second.Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {tirth.Name} is third in {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
