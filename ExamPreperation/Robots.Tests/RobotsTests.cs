namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private RobotManager robotM;
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            robotM = new RobotManager(50);
            robot = new Robot("Sasho", 100);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.AreEqual(50, robotM.Capacity);
        }

        [Test]
        [TestCase(-40)]
        [TestCase(-1)]
        public void CapacityShoudThrowArumentExceptionIfCapacityIsLessThenZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void CountShoudReturnCountOfAddedRobots()
        {
            robotM.Add(robot);
            Assert.AreEqual(1, robotM.Count);
        }

        [Test]
        public void ThrowInvalidOperationExceptionIfTryToAddExistingRobot()
        {
            robotM.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotM.Add(new Robot("Sasho", 100)));
        }

        [Test]
        public void ThrowInvalidOperationExceptionIfTryToAddRobotWhenCapacityIsFull()
        {
            var roborMg = new RobotManager(1);
            roborMg.Add(robot);
            Assert.Throws<InvalidOperationException>(() => roborMg.Add(new Robot("Gosho", 40)));
        }

        [Test]
        public void ThrowInvalidOperationExceptionIfTryToRemoveUnexisitingRobot()
        {
            robotM.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotM.Remove("Pesho"));
        }

        [Test]
        public void IfRemoveRobotCountMustDecrease()
        {
            robotM.Add(robot);
            robotM.Remove("Sasho");
            Assert.AreEqual(0, robotM.Count);
        }

        [Test]
        public void ThrowInvaliderationExceptionIfUnexisitingRobotTryToWork()
        {
            robotM.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotM.Work("Test", "Test", 30));
        }

        [Test]
        [TestCase(101)]
        [TestCase(200)]
        public void ThrowInvalidOperationExeptionIfRobotDoesNotHaveEnoughtBattery(int bateryUsage)
        {
            robotM.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotM.Work("Sasho", "Test", bateryUsage));
        }

        [Test]
        public void BateryShouldDecreaseAfterWork()
        {
            robotM.Add(robot);
            robotM.Work("Sasho", "Test", 40);
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void ThrowInvalidOperationExeptionIfTryToChargeUnexistingRobot()
        {
            robotM.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotM.Charge("Test"));
        }

        [Test]
        public void RobotShoudHaveMaximumBateryAfterCharging()
        {
            robotM.Add(robot);
            robotM.Work("Sasho", "Test", 40);
            robotM.Charge("Sasho");
            Assert.AreEqual(100, robot.Battery);
        }
    }
}
