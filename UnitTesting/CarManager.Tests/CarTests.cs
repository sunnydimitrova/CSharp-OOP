using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]       
        public void Setup()
        {
            car = new Car("BMW", "X8", 6, 50);
        }

        [Test]
        public void ConstructorShouldInitializeCarAndSetFourParameters()
        {
            var make = "BMW";
            var model = "X7";
            var fuelConsumption = 6.2;
            var fuelCapacity = 50.0;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(null, "X8", 6, 50)]
        [TestCase("", "X8", 6, 50)]
        public void ThrowArgumenExeptionIfMakeIsNullOrEmty
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("BMW", null, 6, 50)]
        [TestCase("BMW", "", 6, 50)]
        public void ThrowArgumenExeptionIfModelIsNullOrEmty
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("BMW", "X8", 0, 50)]
        [TestCase("BMW", "X8", -6, 50)]
        public void ThrowArgumenExeptionIfFuelConsumptionIsZeroOrSmaller
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("BMW", "X8", 6, 0)]
        [TestCase("BMW", "X8", 6, -50)]
        public void ThrowArgumenExeptionIfFuelCapacityIsZeroOrSmaller
           (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void ThrowArgumenExeptionIfFuelToRefuelIsZeroOrSmaller(double fuelToRefuel)
        {
            var car = new Car("BMW", "X8", 6, 50);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void ChekIfFuelAmauntWasAbgrateWhitFuelToRefuel()
        {
            car.Refuel(10);

            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        
        public void ChekIfFuelAmountIsGraterThanFuelCapacityAfterRefuel()
        {
            car.Refuel(60);

            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        public void ThrowInvalidOperationExeptionIfFuelNeededIsGraterThanFuelAmount()
        {
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void ChekIfFuelAmountDecreasesWhitFuelNeededAfterDrive()
        {
            car.Refuel(10);
            car.Drive(100);

            Assert.AreEqual(4, car.FuelAmount);
        }
    }
}