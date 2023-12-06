using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private const string name = "testName";
        private const int playerNumber = 1;
        private const string position = "Goalkeeper";
        private const int capacity = 15;
        FootballPlayer testPlayer;
        FootballTeam testTeam;

        [SetUp]
        public void Setup()
        {
            testPlayer = new FootballPlayer(name, playerNumber, position);
            testTeam = new FootballTeam(name, capacity);
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

        [TestCase(name, 0, position)]
        [TestCase(name, 22, position)]
        [TestCase(name, 42, position)]
        [TestCase(name, -5, position)]
        public void UsingInvalidPlayerNumber_ShouldThrowArgumentException(string name, int playerNumber, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => testPlayer = new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Player number must be in range [1,21]", ex.Message);
        }

        [TestCase(name, playerNumber, "")]
        [TestCase(name, playerNumber, "invalid")]
        public void UsingInvalidPlayerPosition_ShouldThrowArgumentException(string name, int playerNumber, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => testPlayer = new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Invalid Position", ex.Message);
        }

        [Test]
        public void Score_ShouldIncreaseScoredGoalsCorrectly()
        {
            testPlayer.Score();

            Assert.AreEqual(1, testPlayer.ScoredGoals);
        }

        [Test]
        public void CreatingTeam_shouldWorkCorrectly()
        {
            Assert.IsNotNull(testTeam);
            Assert.AreEqual(name, testTeam.Name);
            Assert.AreEqual(15, testTeam.Capacity);
            Assert.IsNotNull(testTeam.Players);
        }

        [TestCase("", capacity)]
        public void UsingNullOrEmptyTeamName_ShouldThrowArgumentException(string name, int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => testTeam = new FootballTeam(name, capacity));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase(name, 14)]
        [TestCase(name, 5)]
        public void UsingOnvalidTeamCapacity_ShouldThrowArgumentException(string name, int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => testTeam = new FootballTeam(name, capacity));
            Assert.AreEqual("Capacity min value = 15", ex.Message);
        }

        [Test]
        public void AddingPlayer_WhenNoCapacity_ShouldReturnMessage()
        {
            for (int i = 0; i < 15; i++)
            {
                testTeam.AddNewPlayer(testPlayer);
            }

            Assert.AreEqual("No more positions available!", testTeam.AddNewPlayer(testPlayer));
        }

        [Test]
        public void SuccessfullAddingNewPlayer_ShouldReturnMessage()
        {
            Assert.AreEqual($"Added player {testPlayer.Name} in position {testPlayer.Position} with number {testPlayer.PlayerNumber}", testTeam.AddNewPlayer(testPlayer));
        }

        [Test]
        public void PickPlayerMethod_ShouldReturnPlayer_IfExist()
        {
            testTeam.AddNewPlayer(testPlayer);

            Assert.AreEqual(testPlayer, testTeam.PickPlayer(name));
        }

        [TestCase(name)]
        public void PickPlayerMethod_ShouldReturnNull_IfNotExist(string name)
        {
            testTeam.AddNewPlayer(testPlayer);

            Assert.AreEqual(null, testTeam.PickPlayer($"{name}1"));
        }

        [TestCase(playerNumber)]
        public void PlayerScoreMethod_ShouldReturnMessage_IfPlayerExist(int playerNumber)
        {
            testTeam.AddNewPlayer(testPlayer);
            Assert.AreEqual($"{testPlayer.Name} scored and now has 1 for this season!", testTeam.PlayerScore(playerNumber));
        }


    }
}