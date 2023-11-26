using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new(10, 1);
            dummy = new(10, 10);
        }

        [Test]
        public void WhenAxeAttack_ShouldLosesDurability()
        {
            axe.Attack(dummy);

            //Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Dueability doesn't change after attack.");

            Assert.AreEqual(axe.DurabilityPoints, 0);
        }

        [Test]
        public void BrokenAxe_ShouldntAttack()
        {
            //axe.Attack(dummy);
            axe.Attack(dummy);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");

            Assert.AreEqual("Axe is broken.", exception.Message);
        }
    }
}