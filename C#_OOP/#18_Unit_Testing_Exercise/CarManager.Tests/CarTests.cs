using CarManager;
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
        }

        [Test]
        public void ValidateConstructors()
        {
            Car car = new Car("Mazda", "6", 6.7, 100);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase (null)]
        [TestCase ("")]
        public void MakeThrowsExceptionWhenStringIsNullOrEmpty(string input)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(input, "6", 6.7, 100), 
                "Make cannot be null or empty!");
        }

        [Test]
        [TestCase("Volvo")]
        [TestCase("VW")]
        [TestCase("BMW")]
        public void MakeReturnCorrectData(string make)
        {
            Car car = new Car(make, "6", 6.7, 100);

            Assert.AreEqual(make, car.Make);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelThrowsExceptionWhenStringIsNullOrEmpty(string input)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Mazda", input, 6.7, 100),
                "Model cannot be null or empty!");
        }

        [Test]
        [TestCase("Golf")]
        [TestCase("Polo")]
        [TestCase("Passat")]
        public void ModelReturnCorrectData(string model)
        {
            Car car = new Car("VW", model, 6.7, 100);

            Assert.AreEqual(model, car.Model);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void FuelConsumptionThrowsExceptionWhenDataIsZeroOrNegative(double data)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Mazda", "6", data, 100),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(6.7)]
        [TestCase(5.5)]
        [TestCase(7)]
        public void FuelConsumptionReturnCorrectData(double data)
        {
            Car car = new Car("VW", "Golf", data, 100);

            Assert.AreEqual(data, car.FuelConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        public void FuelCapacityThrowsExceptionWhenDataIsZeroOrNegative(double data)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Mazda", "6", 6.7, data),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase(100)]
        [TestCase(150)]
        [TestCase(60)]
        public void FuelCapacityReturnCorrectData(double data)
        {
            Car car = new Car("VW", "Golf", 6.7, data);

            Assert.AreEqual(data, car.FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void RefuelThrowsExceptionWhenGivenZeroOrNegativeValue(double amount)
        {
            Car car = new Car("VW", "Golf", 6.7, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(amount),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase(150)]
        [TestCase(100)]
        public void FuelAmountEqualsFuelCapacityWhenAmountExceedsCapacity(double amount)
        {
            Car car = new Car("VW", "Golf", 6.7, 100);

            car.Refuel(amount);

            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]
        [TestCase(50)]
        [TestCase(100)]
        public void DriveThrowsExceptionWhenFuelIsNotEnough(double distance)
        {
            Car car = new Car("VW", "Golf", 6.7, 100);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance),
                "You don't have enough fuel to drive!");
        }

        [Test]
        public void FuelAmountIsRightValueAfterDrive()
        {
            Car car = new Car("VW", "Golf", 6.7, 100);

            car.Refuel(50);
            car.Drive(100);

            Assert.AreEqual(43.3, car.FuelAmount);
        }
    }
}