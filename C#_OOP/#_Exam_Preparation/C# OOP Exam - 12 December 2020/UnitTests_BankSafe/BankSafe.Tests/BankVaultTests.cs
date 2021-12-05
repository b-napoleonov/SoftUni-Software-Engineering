using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void AddItemThrowsExceptionWhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("nothing", new Item("Pesho", "44")));
        }

        [Test]
        public void AddItemThrowsExceptionWHenCellIsTaken()
        {
            bankVault.AddItem("A1", new Item("Pesho", "44"));

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("Pesho", "42")));
        }

        [Test]
        public void AddItemThrowsExceptionWHenItemIsAlreadyInCell()
        {
            bankVault.AddItem("A1", new Item("Pesho", "44"));

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", new Item("Gosho", "44")));
        }

        [Test]
        public void AddItemReturnsCorrectString()
        {
            Item item = new Item("Pesho", "44");

            Assert.AreEqual($"Item:{item.ItemId} saved successfully!", bankVault.AddItem("A1", item));
        }

        [Test]
        public void RemoveItemThrowsExceptionWhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A0", new Item("Pesho", "44")));
        }

        [Test]
        public void RemoveItemThrowsExceptionWhenItemInTheCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", new Item("Pesho", "44")));
        }

        [Test]
        public void RemoveItemCorrectlyRemovesTheItem()
        {
            Item item = new Item("Pesho", "44");

            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);

            Assert.IsNull(bankVault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItemReturnsCorrectString()
        {
            Item item = new Item("Pesho", "44");

            bankVault.AddItem("A1", item);

            Assert.AreEqual($"Remove item:{item.ItemId} successfully!", bankVault.RemoveItem("A1", item));
        }
    }
}