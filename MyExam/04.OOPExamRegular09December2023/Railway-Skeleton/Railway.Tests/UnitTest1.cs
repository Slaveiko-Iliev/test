namespace Railway.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private const string _Name = "TestName";
        RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation(_Name);
        }

        [Test]
        public void CreatingRailwayStation_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(railwayStation);
            Assert.IsNotNull(railwayStation.ArrivalTrains);
            Assert.IsNotNull(railwayStation.DepartureTrains);
            Assert.AreEqual(_Name, railwayStation.Name);
        }

        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void WhenUsingNullOrWhiteSpaceForName_ShouldThrowArgumentException(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => railwayStation = new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase("NumberOne")]
        public void NewArrivalOnBoard_ShouldIncreaseArrivalTrainsCount(string trainName)
        {
            railwayStation.NewArrivalOnBoard(trainName);
            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
        }

        //public void NewArrivalOnBoard_ShouldWorkCorrectly(string trainName)
        //{
        //    railwayStation.NewArrivalOnBoard(trainName);
        //    Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
        //}

        [TestCase("NumberOne")]
        public void WhenWrongTrainHasArrived_ShouldReturnMessage(string trainName)
        {
            railwayStation.NewArrivalOnBoard(trainName);
            Assert.AreEqual($"There are other trains to arrive before {_Name}.", railwayStation.TrainHasArrived(_Name));
        }

        [TestCase("NumberOne")]
        public void TrainHasArrived_ShouldWorkCorrectly(string trainName)
        {
            railwayStation.NewArrivalOnBoard(trainName);
            railwayStation.TrainHasArrived(trainName);
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
        }

        [TestCase("NumberOne")]
        public void TrainHasArrived_ShouldReturnCorrectMessage(string trainName)
        {
            railwayStation.NewArrivalOnBoard(trainName);
            Assert.AreEqual($"{trainName} is on the platform and will leave in 5 minutes.", railwayStation.TrainHasArrived(trainName));
        }

        [TestCase("NumberOne")]
        public void TrainHasLeft_ShouldWorkCorrectly(string trainName)
        {
            railwayStation.NewArrivalOnBoard(trainName);
            railwayStation.TrainHasArrived(trainName);
            Assert.AreEqual(false, railwayStation.TrainHasLeft(_Name));
            Assert.AreEqual(true, railwayStation.TrainHasLeft(trainName));

        }
    }
}