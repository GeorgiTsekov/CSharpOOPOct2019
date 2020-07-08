using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWarriorCtorWorkingCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 13;
            int expectedHp = 89;

            Warrior warrior = new Warrior("Pesho", 13, 89);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void TestWarriorNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("   ", 12, 100);
                Warrior warrior2 = new Warrior("", 12, 100);
            });
        }

        [Test]
        public void TestWarriorDamageIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 100);
                Warrior warrior2 = new Warrior("Pesho", -5, 100);
            });
        }

        [Test]
        public void TestWarriorHpIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -15);
            });
        }

        [Test]
        public void TestIfAttackWorkCorrectly()
        {
            Warrior attacker = new Warrior("Pesho", 12, 77);
            Warrior defender = new Warrior("Gosho", 14, 66);

            int expectedHpAttacker = 63;
            int expectedHpDeffender = 54;

            attacker.Attack(defender);

            Assert.AreEqual(expectedHpAttacker, attacker.HP);
            Assert.AreEqual(expectedHpDeffender, defender.HP);

            Warrior attacker1 = new Warrior("Tosho", 33, 55);
            Warrior defender1 = new Warrior("Sasho", 14, 32);

            attacker1.Attack(defender1);

            int expectedHpAttacker1 = 41;
            int expectedHpDeffender1 = 0;

            Assert.AreEqual(expectedHpAttacker1, attacker1.HP);
            Assert.AreEqual(expectedHpDeffender1, defender1.HP);
        }

        [Test]
        public void TestIfAttackerHaveLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 12, 30);
            Warrior defender = new Warrior("Gosho", 14, 66);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestIfDefenderHaveLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 12, 66);
            Warrior defender = new Warrior("Gosho", 14, 29);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestIfDefenderIsTooStrong()
        {
            Warrior attacker = new Warrior("Pesho", 12, 44);
            Warrior defender = new Warrior("Gosho", 45, 66);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }
    }
}