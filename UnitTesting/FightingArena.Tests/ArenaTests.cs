using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInicializeListOfWarriors()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrolldWarriorShouldNotBeEnrollAgain()
        {
            var warrior = new Warrior("Ivan", 40, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void CountShouldEncreaceAffterAddWarrior()
        {
            arena.Enroll(new Warrior("Ivan", 50, 100));
            arena.Enroll(new Warrior("Gosho", 60, 100));

            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void ThrowInvalidOperetionExeptionIfFighterIsNotEnrolledForFights()
        {
            arena.Enroll(new Warrior("Ivan", 50, 60));
            arena.Enroll(new Warrior("Pesho", 50, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", "Gosho"));
        }

        [Test]
        public void IfFightAttakerShouldAttackDiffender()
        {
            var attaker = new Warrior("Ivan", 50, 60);
            var diffender = new Warrior("Pesho", 50, 100);

            arena.Enroll(attaker);
            arena.Enroll(diffender);

            arena.Fight("Ivan", "Pesho");

            Assert.AreEqual(10, attaker.HP);
            Assert.AreEqual(50, diffender.HP);
        }
    }
}
