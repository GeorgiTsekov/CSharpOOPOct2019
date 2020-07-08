using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfUnitMotorcycleCtorWorksCorrectly()
        {
            string expectedModel = "Honda";
            int expectedHorsePower = 110;
            double expectedCubicCentimeters = 1000;

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            Assert.AreEqual(expectedModel, unitMotorcycle.Model);
            Assert.AreEqual(expectedHorsePower, unitMotorcycle.HorsePower);
            Assert.AreEqual(expectedCubicCentimeters, unitMotorcycle.CubicCentimeters);
        }

        [Test]
        public void TestIfUnitRiderCtorWorksCorrectly()
        {
            string expectedName = "Gosho";

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            UnitRider unitRider = new UnitRider("Gosho", unitMotorcycle);

            Assert.AreEqual(expectedName, unitRider.Name);
            Assert.AreEqual(unitMotorcycle, unitRider.Motorcycle);
        }

        [Test]
        public void TestIfUnitRiderNameIsNull()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitRider unitRider = new UnitRider(null, unitMotorcycle);
            });
        }

        [Test]
        public void TestIfRaceEntryCounterWorksCorrectly()
        {
            int expectedCount = 0;

            RaceEntry raceEntry = new RaceEntry();

            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }

        [Test]
        public void TestIfAddRIderWorksCorrectly()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            UnitRider unitRider = new UnitRider("Gosho", unitMotorcycle);

            RaceEntry raceEntry = new RaceEntry();

            string expectedName = $"Rider {unitRider.Name} added in race.";

            Assert.AreEqual(expectedName, raceEntry.AddRider(unitRider));
        }

        [Test]
        public void TestIfInAddRiderRiderIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(null);
            });
        }

        [Test]
        public void TestIfInAddRiderRiderExist()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Harly", 100, 900);

            UnitRider unitRider = new UnitRider("Gosho", unitMotorcycle);

            UnitRider unitRider1 = new UnitRider("Gosho", unitMotorcycle1);

            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(unitRider1);
            });
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerWorksCorrectly()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 110, 1000);

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Harly", 100, 900);

            UnitRider unitRider = new UnitRider("Pesho", unitMotorcycle);

            UnitRider unitRider1 = new UnitRider("Gosho", unitMotorcycle1);

            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider);

            raceEntry.AddRider(unitRider1);

            int expectedAverageHorsePower = 105;

            Assert.AreEqual(expectedAverageHorsePower, raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestIfInCalculateAverageHorsePowerCountIsZero()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}