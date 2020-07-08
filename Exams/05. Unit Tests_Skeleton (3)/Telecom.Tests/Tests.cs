namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfCtorWorksCorrectly()
        {
            string expectedMake = "Sony";
            string expectedModel = "Xperia";
            int expectedCount = 0;

            Phone phone = new Phone("Sony", "Xperia");

            Assert.AreEqual(expectedMake, phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestIfMakeIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("", "Xperia");
            });
        }

        [Test]
        public void TestIfModelIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("Sony", "");
            });
        }

        [Test]
        public void TestIfAddContactWorksCorrectly()
        {
            Phone phone = new Phone("Sony", "Xperia");

            int expectedCount = 1;

            phone.AddContact("Gosho", "0884352137");

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestIfPersonNameAlreadyExists()
        {
            Phone phone = new Phone("Sony", "Xperia");

            phone.AddContact("Gosho", "0884352137");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Gosho", "9083459832");
            });
        }

        [Test]
        public void TestIfCallWorksCorrectly()
        {
            Phone phone = new Phone("Sony", "Xperia");

            phone.AddContact("Gosho", "0884352137");
            
            string expectedCall = $"Calling {"Gosho"} - {"0884352137"}...";

            Assert.AreEqual(expectedCall, phone.Call("Gosho"));
        }

        [Test]
        public void TestIfPersonNameDoesntExists()
        {
            Phone phone = new Phone("Sony", "Xperia");

            phone.AddContact("Gosho", "0884352137");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Pesho");
            });
        }
    }
}