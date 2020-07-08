using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car testCar;

        [SetUp]
        public void Setup()
        {
            this.testCar = new Car("France", "Pegeaut", 7.0, 70.0);
        }

        [Test]
        public void TestCtorWorkingCorrectly()
        {
            string expectedMake = "Germany";
            string expectedModel = "Audi";
            double expectedFuelConsumption = 0.9;
            double expectedFuelCapacity = 80.0;
            double expectedFuelAmount = 0;

            Car car = new Car("Germany", "Audi", 0.9, 80.0);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestMakeIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "Audi", 0.9, 80.0);
            });
        }

        [Test]
        public void TestModelIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Germany", "", 0.9, 80.0);
            });
        }

        [Test]
        public void TestFuelConsumptionIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Germany", "Audi", 0, 80.0);
            });
        }

        [Test]
        public void TestFuelConsumptionIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car2 = new Car("Germany", "Audi", -5, 80.0);
            });
        }

        [Test]
        public void TestFuelCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Germany", "Audi", 0.9, -1);
            });
        }

        [Test]
        public void TestFuelCapacityIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car2 = new Car("Germany", "Audi", 0.9, 0);
            });
        }

        [Test]
        public void TestRefuelingCorrectly()
        {
            double expectedFuel = 25.5;

            this.testCar.Refuel(25.5);

            Assert.AreEqual(expectedFuel, this.testCar.FuelAmount);
        }

        [Test]
        public void TestRefuelingWithBiggerFuelAmountThenFuelCapacity()
        {
            double expetedRefuel = 70;

            this.testCar.Refuel(90);

            Assert.AreEqual(expetedRefuel, this.testCar.FuelAmount);
        }

        [Test]
        public void TestFuelToRefuelIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar.Refuel(0);
            });
        }

        [Test]
        public void TestFuelToRefuelIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar.Refuel(-1);
            });
        }

        [Test]
        public void TestDrivingCorrectly()
        {
            this.testCar.Refuel(60);

            this.testCar.Drive(300);

            double expectedFuelAmount = 39.0;

            Assert.AreEqual(expectedFuelAmount, testCar.FuelAmount);
        }

        [Test]
        public void TestDriveNotEnoughFuelForThisDistance()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testCar.Drive(1000);
            });
        }
    }
}