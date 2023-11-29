namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private const string name = "testName";
        private const int damage = 50;
        private const int hp = 100;
        public readonly Warrior warrior1 = new($"{name}1", damage, hp + 20);
        Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void CreatingArena_ShouldWorkCorrectly()
        {
            Arena arena = new();
            Assert.IsNotNull(arena);
            arena.Enroll(warrior1);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void ReAdditionOfWarrior_ShouldThrowInvalidOperationException()
        {
            arena.Enroll(warrior1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior1));
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void AddingWarrior_ShouldEncreaseCountCorrectly()
        {
            arena.Enroll(warrior1);
            Assert.AreEqual(1, arena.Count);
        }

        [TestCase("missingName")]
        public void FightWithMissingAttacker_ShouldThrowInvalidOperationException(string missingWarrior)
        {
            arena.Enroll(warrior1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(missingWarrior, warrior1.Name));
            Assert.AreEqual($"There is no fighter with name {missingWarrior} enrolled for the fights!", exception.Message);
        }

        [TestCase("missingName")]
        public void FightWithMissingDefender_ShouldThrowInvalidOperationException(string missingWarrior)
        {
            arena.Enroll(warrior1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior1.Name, missingWarrior));
            Assert.AreEqual($"There is no fighter with name {missingWarrior} enrolled for the fights!", exception.Message);
        }
    }
}
