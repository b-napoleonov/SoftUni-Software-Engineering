using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager compManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("Acer", "Predator", 2500);
            compManager = new ComputerManager();
        }

        [Test]
        public void ConstructorShouldInitializeTheListCorrectly()
        {
            ComputerManager compManager = new ComputerManager();

            Assert.IsNotNull(compManager.Computers);
        }
        [Test]
        public void CountReturnsCorrectData()
        {
            compManager.AddComputer(computer);

            Assert.AreEqual(1, compManager.Count);
        }

        [Test]
        public void AddComputerThrowsExceptionWhenComputerAlreadyExist()
        {
            compManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => compManager.AddComputer(computer));
        }

        [Test]
        public void AddComputerWorkFine()
        {
            compManager.AddComputer(computer);

            Assert.AreEqual(1, compManager.Computers.Count);
        }

        [Test]
        public void ValidateNullValueThrowsExceptionWhenVariableIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => compManager.AddComputer(null));
        }

        [Test]
        public void GetComputerThrowsExceptionWhenComputerIsNotFound()
        {
            Assert.Throws<ArgumentException>(() => compManager.GetComputer("Dell", "Inspiron"));
        }

        [TestCase(null)]
        public void GetComputerShouldThrowArgumentNullException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => compManager.GetComputer(value, "Di230"));
        }

        [Test]
        public void GetComputerShouldReturnCorrect()
        {
            compManager.AddComputer(computer);

            Assert.AreEqual(computer, compManager.GetComputer("Acer", "Predator"));
        }

        [Test]
        public void RemoveComputerWorksRight()
        {
            compManager.AddComputer(computer);
            compManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.IsEmpty(compManager.Computers);
        }

        [TestCase(null)]
        public void RemoveComputerThrowsNullException(string value)
        {
            compManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => compManager.RemoveComputer(value, "Predator"));
        }

        [Test]
        public void GetComputersByManufacturer()
        {
            Computer computer1 = new Computer("HP", "Device200", 700);
            Computer computer2 = new Computer("HP", "D320", 700);
            Computer computer3 = new Computer("Lenovo", "D320", 700);
            this.compManager.AddComputer(computer1);
            this.compManager.AddComputer(computer2);
            this.compManager.AddComputer(computer3);

            ICollection<Computer> expectedComputers =
                this.compManager.Computers.Where(x => x.Manufacturer == "HP").ToList();

            Assert.AreEqual(expectedComputers, compManager.GetComputersByManufacturer("HP"));
        }

        [Test]
        public void ComputerConstructorWorksCorrect()
        {
            Computer testComputer = new Computer("Dell", "Inspiron", 1600);

            Assert.IsNotNull(testComputer);
        }
    }
}