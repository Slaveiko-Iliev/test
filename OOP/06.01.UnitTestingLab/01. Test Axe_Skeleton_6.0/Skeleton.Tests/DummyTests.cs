using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new(10, 10);
        }

        [Test]
        [TestCase(5)]
        public void WhenTheDummyIsAttacked_ShouldLoseHealth(int attackPoints)
        {
            dummy.TakeAttack(attackPoints);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        [TestCase(12)]
        public void IfAttackedDeadDummyShouldThrowsAnException(int attackPoints)
        {
            dummy.TakeAttack(attackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }

        //[Test]
        //public int DeadDummy_ShouldCanGiveXP()
        //{
        //    dummy.GiveExperience();

        //    Assert.AreEqual(10, dummy.);
        //}

        [Test]
        public void AliveDummy_ShouldntCanGiveXP()
        {
            InvalidOperationException exeption = Assert.Throws<InvalidOperationException>(() => dummy.IsDead());
            Assert.AreEqual("Target is not dead.", exeption.Message);
        }
    }
}