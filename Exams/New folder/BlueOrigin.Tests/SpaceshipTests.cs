namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfAstronautCtorWorksCorrectly()
        {
            this.astronaut = new Astronaut("Pesho", 21);

            string expectedName = "Pesho";
            double expectedOxygen = 21;

            Assert.AreEqual(expectedName, this.astronaut.Name);
            Assert.AreEqual(expectedOxygen, this.astronaut.OxygenInPercentage);
        }

        [Test]
        public void TestIfCtorWorksCorrectly()
        {
            string expectedShipName = "Enterprice";
            int expectedCapacity = 15;

            Spaceship spaceship = new Spaceship("Enterprice", 15);

            Assert.AreEqual(expectedShipName, spaceship.Name);
            Assert.AreEqual(expectedCapacity, spaceship.Capacity);
        }

        [Test]
        public void TestIfNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship("", 15);
            });
        }

        [Test]
        public void TestIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(null, 15);
            });
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 15);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestIfCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship spaceship = new Spaceship("Enterprice", -15);
            });
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 15);
            
            this.astronaut = new Astronaut("Pesho", 21);
            Astronaut astronaut1 = new Astronaut("Gosho", 22);

            int expectedCount = 2;

            spaceship.Add(this.astronaut);
            spaceship.Add(astronaut1);
            
            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestIfAddWhenCapacityIsFull()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 0);

            this.astronaut = new Astronaut("Pesho", 21);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(this.astronaut);
            });
        }

        [Test]
        public void TestIfAddWhenAstronautExist()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 3);

            this.astronaut = new Astronaut("Pesho", 21);

            spaceship.Add(this.astronaut);

            Astronaut astronaut1 = new Astronaut("Pesho", 29);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(astronaut1);
            });
        }

        [Test]
        public void TestIfRemoveWorksCorrectlyWithTrue()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 15);

            bool expectedResult = true;

            this.astronaut = new Astronaut("Pesho", 21);

            spaceship.Add(this.astronaut);

            Assert.AreEqual(expectedResult, spaceship.Remove("Pesho"));
        }

        [Test]
        public void TestIfRemoveMethodWorksCorrectlyWithFalse()
        {
            Spaceship spaceship = new Spaceship("Enterprice", 15);

            bool expectedResult = false;

            Assert.AreEqual(expectedResult, spaceship.Remove("Pesho"));
        }
    }
}