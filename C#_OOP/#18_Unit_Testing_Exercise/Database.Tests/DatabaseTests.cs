using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database db;

        [SetUp]
        public void Setup()
        {
            db = new Database.Database();
        }

        [Test]
        public void ThrowExceptionWhenCapacityExceed()
        {
            for (int i = 0; i < 15; i++)
            {
                db.Add(i);
            }

            Assert.AreEqual(15, db.Count);
        }

        [Test]
        public void VerifyAddMethod()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }

            Assert.That(() => db.Add(1),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenDBIsEmpty()
        {
            Assert.That(() => db.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            db.Add(1);
            db.Add(1);
            db.Remove();

            Assert.That(db.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestConstructor()
        {
            db.Add(1);
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void VerifyFetchMethod()
        {
            int[] testArr = db.Fetch();
            Assert.That(db.Count, Is.EqualTo(testArr.Length));
        }
    }
}