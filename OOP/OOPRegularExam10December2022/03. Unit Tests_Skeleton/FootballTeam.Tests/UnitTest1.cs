using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private const string name = "testName";
        private const int playerNumber = 1;
        private const string position = "Goalkeeper";
        FootballPlayer testPlayer;

        [SetUp]
        public void Setup()
        {
            testPlayer = new FootballPlayer(name, playerNumber, position);
        }

        [Test]
        public void CreatingPlayer_shouldWorkCorrectly()
        {
            Assert.IsNotNull(testPlayer);
            Assert.AreEqual(name, testPlayer.Name);
            Assert.AreEqual(playerNumber, testPlayer.PlayerNumber);
            Assert.AreEqual(position, testPlayer.Position);
            Assert.AreEqual(0, testPlayer.ScoredGoals);
        }

        [TestCase("", playerNumber, position)]
        public void UsingNullOrEmptyPlayerName_ShouldThrowArgumentException(string name, int playerNumber, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => testPlayer = new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }
    }
}