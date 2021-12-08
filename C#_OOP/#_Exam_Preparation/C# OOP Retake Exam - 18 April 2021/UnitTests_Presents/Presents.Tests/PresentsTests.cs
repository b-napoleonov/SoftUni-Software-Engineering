namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
            present = new Present("Present", 55);
        }

        [Test]
        public void CreateThrowsExceptionWhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateThrowsExceptionWhenPresentExists()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateReturnsCorrectString()
        {
            Assert.AreEqual("Successfully added present Present.", bag.Create(present));
        }

        [Test]
        public void RemoveWorksRight()
        {
            bag.Create(present);

            Assert.AreEqual(true, bag.Remove(present));
        }

        [Test]
        public void GetPresentWithLeastMagicReturnsRight()
        {
            Present bestPresent = new Present("Best Present", 100);
            bag.Create(present);
            bag.Create(bestPresent);

            Assert.AreSame(present, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentReturnsRightData()
        {
            Present bestPresent = new Present("Best Present", 100);
            bag.Create(present);
            bag.Create(bestPresent);

            Assert.AreSame(bestPresent, bag.GetPresent("Best Present"));
        }

        [Test]
        public void GetPresentsWorksRight()
        {
            bag.Create(present);

            Assert.AreEqual(1, bag.GetPresents().Count);
        }
    }
}
 