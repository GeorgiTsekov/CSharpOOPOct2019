using System;
using System.Collections.Generic;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        public Person personOne = new Person(8009296921, "Gosho");
        public Person personTwo = new Person(8009123344, "Pesho");
        public Person personThree = new Person(8111123344, "Tosho");

        private List<Person> people;
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(personOne, personTwo, personThree);
            this.people = new List<Person>();
        }

        [Test]
        public void TestConstructorPersonWorkCorrectly()
        {
            string expectedPersonName = "Gosho";
            long expectedPersonId = 8009296921;

            Person person = new Person(8009296921, "Gosho");

            Assert.AreEqual(expectedPersonName, person.UserName);
            Assert.AreEqual(expectedPersonId, person.Id);
        }

        [Test]
        public void TestCtorExtendedDatabaseWorkingCorrectly()
        {
            int expectedCount = 2;

            ExtendedDatabase.ExtendedDatabase extendedDatabase1 = new ExtendedDatabase.ExtendedDatabase(personOne, personTwo);

            Assert.AreEqual(expectedCount, extendedDatabase1.Count);
        }

        [Test]
        public void TestIfCtorDataIsBiggerThen16()
        {
            for (int i = 0; i < 20; i++)
            {
                Person person = new Person(i, "i");
                this.people.Add(person);
            }
        
            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase.ExtendedDatabase extendedDatabase2 = new ExtendedDatabase.ExtendedDatabase(this.people.ToArray());
            });
        }

        [Test]
        public void TestFindByUsernameWorkingCorrectly()
        {
            string expectedUsername = "Gosho";

            Assert.AreEqual(expectedUsername, this.extendedDatabase.FindByUsername("Gosho").UserName);
        }

        [Test]
        public void TestFindByIdIdWorkingCorrectly()
        {
            long expectedId = 8009296921;

            Assert.AreEqual(expectedId, this.extendedDatabase.FindById(8009296921).Id);
        }

        [Test]
        public void TestFindByUsernameWhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedDatabase.FindByUsername("");
            });
        }

        [Test]
        public void TestFindByIdWhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.extendedDatabase.FindById(-1);
            });
        }

        [Test]
        public void TestFindByUsernameWhenNamesAreEquals()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindByUsername("Petko");
            });
        }

        [Test]
        public void TestFindByIdWhenIdsAreEquals()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindById(90375489757);
            });
        }

        [Test]
        public void TestCountWorkingCorrectly()
        {
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, this.extendedDatabase.Count);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            int expectedCount = 4;

            Person person = new Person(8129296921, "Ivo");
            this.extendedDatabase.Add(person);
            Assert.AreEqual(expectedCount, this.extendedDatabase.Count);
        }

        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 4; i <= 16; i++)
            {
                Person person = new Person(i, i.ToString());
                this.extendedDatabase.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new Person(17, 17.ToString());
                this.extendedDatabase.Add(person);
            });
        }

        [Test]
        public void TestAddingWhenAlreadyHaveUserWithThisName()
        {
            Person person = new Person(8138296921, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person);
            });
        }

        [Test]
        public void TestAddingWhenAlreadyHaveUserWithThisId()
        {
            Person person = new Person(8009296921, "Kolio");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person);
            });
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedResult = 2;

            this.extendedDatabase.Remove();

            Assert.AreEqual(expectedResult, extendedDatabase.Count);
        }

        [Test]
        public void TestRemovingWhenNull()
        {
            for (int i = 0; i < 3; i++)
            {
                this.extendedDatabase.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Remove();
            });
        }
    }
}