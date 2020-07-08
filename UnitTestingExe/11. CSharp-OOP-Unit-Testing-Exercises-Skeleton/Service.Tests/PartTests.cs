using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfCtorPartsWorksCorrectly()
        {
            string expectedLaptopName = "Laptop";
            string expectedPhoneName = "Phone";
            string expectedPcName = "Pc";
            decimal expectedLaptopCost = 1952.2M * 1.5m;
            decimal expectedPhoneCost = 551.2M * 1.3m;
            decimal expectedPcCost = 55.2M * 1.2m;

            Part laptopPart = new LaptopPart("Laptop", 1952.2M, true);
            Part phonePart = new PhonePart("Phone", 551.2M, true);
            Part pcPart = new PCPart("Pc", 55.2M, false);

            Assert.AreEqual(expectedLaptopName, laptopPart.Name);
            Assert.AreEqual(expectedPhoneName, phonePart.Name);
            Assert.AreEqual(expectedPcName, pcPart.Name);
            Assert.AreEqual(expectedLaptopCost, laptopPart.Cost);
            Assert.AreEqual(expectedPhoneCost, phonePart.Cost);
            Assert.AreEqual(expectedPcCost, pcPart.Cost);
        }

        [Test]
        public void TestIfNamesIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Part laptopPart = new LaptopPart("", 1952.2M, true);
               Part phonePart = new PhonePart("", 551.2M, true);
               Part pcPart = new PCPart("", 55.2M, false);
           });
        }

        [Test]
        public void TestIfCostIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Part laptopPart = new LaptopPart("Laptop", 0, true);
                Part phonePart = new PhonePart("Phone", -10, true);
                Part pcPart = new PCPart("Pc", -22, false);
            });
        }

        [Test]
        public void TestIfRepairMethodWorksCorrectly()
        {
            Part laptopPart = new LaptopPart("Laptop", 1952.2M, true);
            Part phonePart = new PhonePart("Phone", 551.2M, true);
            Part pcPart = new PCPart("Pc", 55.2M, false);

            bool expectedLaptopIsBroken = false;
            bool expectedPhoneIsBroken = false;
            bool expectedPcIsBroken = false;

            laptopPart.Repair();
            phonePart.Repair();
            pcPart.Repair();

            Assert.AreEqual(expectedLaptopIsBroken, laptopPart.IsBroken);
            Assert.AreEqual(expectedPhoneIsBroken, phonePart.IsBroken);
            Assert.AreEqual(expectedPcIsBroken, pcPart.IsBroken);
        }

        public void TestIfReportMethodWorksCorrectly()
        {
            Part laptopPart = new LaptopPart("Laptop", 1952.2M, true);
            Part phonePart = new PhonePart("Phone", 551.2M, true);
            Part pcPart = new PCPart("Pc", 55.2M, false);

            string expectedLaptopReport = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {laptopPart.IsBroken}";
            string expectedPhoneReport = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                 $"Broken: {laptopPart.IsBroken}";
            string expectedPcReport = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {laptopPart.IsBroken}";

            Assert.AreEqual(expectedLaptopReport, laptopPart.Report());
            Assert.AreEqual(expectedPhoneReport, phonePart.Report());
            Assert.AreEqual(expectedPcReport, pcPart.Report());
        }
    }
}