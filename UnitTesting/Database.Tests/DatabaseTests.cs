using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int[] data = new int[] { 1, 2, 3 };
            this.database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorMustThrowExeptionIfTheColectionIsBigger()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);
            });
        }

        [Test]
        public void TestIfAddCorectlyElements()
        {
            this.database.Add(3);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ThrowExeptionIfCountIsBiggerThenAddElement()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            this.database.Remove();

            int expected = 1;
            int actual = this.database.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThrowExeprionIfRemovedFromEmptyDatabase()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void FetchShouldReturnCopyDatabase(int[] data)
        {
            this.database = new Database(data);
            int[] actual = this.database.Fetch();

            CollectionAssert.AreEqual(data, actual);
        }
    }
}