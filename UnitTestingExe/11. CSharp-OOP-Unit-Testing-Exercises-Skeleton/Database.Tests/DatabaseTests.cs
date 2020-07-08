using NUnit.Framework;
using System;
using Database;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] data = new int[] { 1, 2 };
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(data);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            int expectedCount = 3;

            this.database.Add(3);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddingWhenFull()
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
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenZero()
        {
            for (int i = 2; i > 0; i--)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestFetchingCorrectlyArray()
        {
            int[] result = this.database.Fetch();

            CollectionAssert.AreEqual(this.data, result);
        }
    }
}