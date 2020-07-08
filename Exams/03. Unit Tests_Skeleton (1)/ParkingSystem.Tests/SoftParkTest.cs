namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfCarCtorWorksCorrectly()
        {
            string expectedMake = "Audi";

            string expectedRegNumber = "CB0660AP";

            Car car = new Car("Audi", "CB0660AP");

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedRegNumber, car.RegistrationNumber);
        }

        [Test]
        public void TestIfCtorWorksCorrectly()
        {
            int expectedParkingCount = 12;

            SoftPark softPark = new SoftPark();

            Assert.AreEqual(expectedParkingCount, softPark.Parking.Count);
        }

        [Test]
        public void TestIfParkCarWorksCorrectly()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            string expectedMessage = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(expectedMessage, softPark.ParkCar("A4", car));
        }

        [Test]
        public void TestIfParkingSpotDoesntExist()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar("A6", car);
            });
        }

        [Test]
        public void TestIfParkingSpotIsAlreadyTaken()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            softPark.ParkCar("A4", car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar("A4", car);
            });
        }

        [Test]
        public void TestIfCarIsAlreadyParked()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            softPark.ParkCar("A4", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                softPark.ParkCar("A1", car);
            });
        }

        [Test]
        public void TestIfRemoveCarWorksCorrectly()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            string expectedMessage = $"Remove car:{car.RegistrationNumber} successfully!";

            softPark.ParkCar("A4", car);

            Assert.AreEqual(expectedMessage, softPark.RemoveCar("A4", car));
        }

        [Test]
        public void TestIfParkingSpotDoesntExistWithRemoveCommand()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");

            softPark.ParkCar("A4", car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar("A5", car);
            });
        }

        [Test]
        public void TestIfCarForThatSpotDoesntExist()
        {
            SoftPark softPark = new SoftPark();

            Car car = new Car("Audi", "CB0660AP");
            Car car1 = new Car("WV", "C6818XK");

            softPark.ParkCar("A4", car);
            softPark.ParkCar("A3", car1);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar("A4", car1);
            });
        }
    }
}