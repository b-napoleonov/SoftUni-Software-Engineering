namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameMustBeValid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, 5));
        }

        [Test]
        public void CapacityThrowsExceptionWhenInvalid()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Underworld", -5));
        }

        [Test]
        public void AddFishThrowsExceptionWhenAquariumIsFull()
        {
            aquarium = new Aquarium("Underworld", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Nemo")));
        }

        [Test]
        public void AddFishWorksRight()
        {
            aquarium = new Aquarium("Underworld", 1);

            aquarium.Add(new Fish("Nemo"));

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void RemoveFishThrowsExceptionWhenFishIsNotFOund()
        {
            aquarium = new Aquarium("Underworld", 1);

            Assert.Throws<InvalidOperationException>
                (() => aquarium.RemoveFish(null));
        }

        [Test]
        public void RemoveFishWorksRight()
        {
            aquarium = new Aquarium("Underworld", 1);
            aquarium.Add(new Fish("Nemo"));
            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void SellFishThrowsExceptionWhenRequestedFishIsNotFOund()
        {
            aquarium = new Aquarium("Underworld", 1);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void SellFishReturnsRightFish()
        {
            aquarium = new Aquarium("Underworld", 1);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);

            Assert.AreEqual(fish, aquarium.SellFish("Nemo"));
        }

        [Test]
        public void ReportReturnsRightData()
        {
            aquarium = new Aquarium("Underworld", 1);
            aquarium.Add(new Fish("Nemo"));

            string output = $"Fish available at {aquarium.Name}: {"Nemo"}";

            Assert.AreEqual(output, aquarium.Report());
        }
    }
}
