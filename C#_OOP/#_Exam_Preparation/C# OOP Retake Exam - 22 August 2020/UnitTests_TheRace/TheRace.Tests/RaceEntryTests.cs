using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void CounterHasRightValue()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddDriverThrowsExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverThrowsExceptionWhenDriverNameAlreadyExists()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Golf", 300, 400)));

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Mazda", 300, 400))));
        }

        [Test]
        public void AddDriverReturnsRightData()
        {
            Assert.AreEqual("Driver Pesho added in race.", raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Golf", 300, 400))));
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsExceptionWhenDriverCOuntIsLessThanMinimum()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerReturnsRightData()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Golf", 300, 400)));
            raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Subaru", 300, 400)));

            Assert.AreEqual(300, raceEntry.CalculateAverageHorsePower());
        }
    }
}