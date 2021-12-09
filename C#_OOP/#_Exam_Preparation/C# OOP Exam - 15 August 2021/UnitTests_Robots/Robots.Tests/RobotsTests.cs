namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            robotManager = new RobotManager(2);
            robot = new Robot("R2-D2", 80);
            robotManager.Add(robot);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(robot, "The constructor is broken!");
            Assert.IsNotNull(robotManager, "The constructor is broken!");
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(2, robotManager.Capacity, "Property isn't working right!");
        }

        [Test]
        public void CapacityPropertyThrowsExceptionIfValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-10));
        }

        [Test]
        public void VerifyCountMethod()
        {
            Assert.AreEqual(1, robotManager.Count, "Method isn't working right!");
        }

        [Test]
        public void VerifyAddMethod()
        {
            int expected = 2;
            Robot temp = new Robot("Temp", 2);
            robotManager.Add(temp);
            Assert.AreEqual(expected, robotManager.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenRobotWithTheSameNameIsFound()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("R2-D2", 5)));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenGoingOverTheCapacity()
        {
            Robot temp = new Robot("Temp", 2);
            robotManager.Add(temp);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("R2", 5)));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            Robot temp = new Robot("Temp", 2);
            robotManager.Add(temp);
            robotManager.Remove(temp.Name);
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(robot?.Name));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenNoSuchRobotIsFound()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Goshko"));
        }

        [Test]
        public void VerifyWorkMethod()
        {
            robotManager.Work(robot.Name, "Engineering", 20);
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot?.Name, "Cleaning", 20));
        }

        [Test]
        public void WorkMethodThrowsExceptionWhenHavingLessBatteryCapacityThanNeeded()
        {
            Robot temp = new Robot("Toshko", 20);
            robotManager.Add(temp);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(temp.Name, "Cleaning", 555));
        }

        [Test]
        public void VerifyChargeMethod()
        {
            robotManager.Work(robot.Name, "Drinking", 30);
            robotManager.Charge(robot.Name);
            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void ChargeMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robot?.Name));
        }
    }
}
