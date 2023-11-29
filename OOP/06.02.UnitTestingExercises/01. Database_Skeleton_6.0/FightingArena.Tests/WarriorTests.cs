namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private const string name = "testName";
        private const int damage = 50;
        private const int hp = 100;

        [SetUp]
        public void SetUp()
        {
            Warrior warrior1 = new($"{name}1", damage, hp);
            Warrior warrior2 = new($"{name}2", damage - 20, hp);
            Warrior warrior3 = new($"{name}2", damage, hp - 80);
        }
    }
}