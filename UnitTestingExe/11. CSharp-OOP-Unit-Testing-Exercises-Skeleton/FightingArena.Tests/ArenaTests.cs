using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfCtorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 21, 55);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestIfEnrollWarriorWithExistedName()
        {
            Warrior warrior = new Warrior("Pesho", 21, 55);
            Warrior warrior2 = new Warrior("Pesho", 23, 54);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior2);
            });
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 21, 55);

            this.arena.Enroll(warrior);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            int expectedWarriorHP = 33;
            int expectedWarrior2HP = 33;

            Warrior warrior = new Warrior("Pesho", 21, 55);
            Warrior warrior2 = new Warrior("Gosho", 22, 54);

            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            this.arena.Fight(warrior.Name, warrior2.Name);

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            Assert.AreEqual(expectedWarrior2HP, warrior2.HP);
        }

        [Test]
        public void TestIfFightNameIsMissing()
        {
            Warrior warrior = new Warrior("Pesho", 21, 55);
            Warrior warrior2 = new Warrior("Gosho", 22, 54);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(warrior.Name, warrior2.Name);
            });
        }
    }
}
