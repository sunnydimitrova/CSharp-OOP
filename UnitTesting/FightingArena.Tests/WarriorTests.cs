using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior attaker;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Ivan", 40, 100);
            attaker = new Warrior("Gosho", 30, 30);
        }

        [Test]
        public void ConstructorShouldInicilizeWarriorWhitThreeParameters()
        {
            var name = "Ivan";
            var damage = 30;
            var hp = 40;

            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 30, 50)]
        [TestCase("  ", 30, 50)]
        [TestCase(null, 30, 50)]
        public void ThrowArgumentExeptionIfNameIsNullOrWhitespace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 0, 50)]
        [TestCase("Ivan", -10, 50)]
        public void ThrowAgrumentExeptionIfDamageIsZiroOrSmaller(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 30, -10)]
        public void ThrowArgumentExeptionIfHPSmallerThanZero(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void ThrowInavlidOperationExeptionIfAttakerAtackedWhitThirtyOrSmallerHP()
        {
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(warrior));
        }

        [Test]
        public void ThrowInvalidOperationExeptionIfAttakerAtakedWarriorWhitThirtyOrSmallerHP()
        {
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attaker));
        }

        [Test]
        public void ThrowInvalidOperetionExeptionIfAttakerTryToAttakedWarriorWhitGreaterDamageThanAttekerHP()
        {
            var attaker = new Warrior("Ivan", 50, 40);
            var enemy = new Warrior("Gosho", 60, 100);

            Assert.Throws<InvalidOperationException>(() => attaker.Attack(enemy));
        }

        [Test]
        public void AttakerHpShouldDecreaseAfterAttackWhitEnemySDamage()
        {
            var attaker = new Warrior("Ivan", 50, 100);
            var enemy = new Warrior("Gosho", 30, 100);

            attaker.Attack(enemy);

            var expectedHp = 70;

            Assert.AreEqual(expectedHp, attaker.HP);
        }

        [Test]
        public void HPEnemyShouldBeZeroIfAttakerDamageIsGreater()
        {
            var attaker = new Warrior("Ivan", 50, 100);
            var enemy = new Warrior("Gosho", 30, 40);

            attaker.Attack(enemy);

            var expectedHp = 0;

            Assert.AreEqual(expectedHp, enemy.HP);
        }

        [Test]
        public void AftterAttackDeffenderHPShouldDecreaseWhitAttakerDamage()
        {
            var attaker = new Warrior("Ivan", 50, 100);
            var enemy = new Warrior("Gosho", 30, 100);

            attaker.Attack(enemy);

            var expectedHp = 50;

            Assert.AreEqual(expectedHp, enemy.HP);
        }
    }
}