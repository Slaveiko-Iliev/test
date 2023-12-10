namespace Railway.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    public class Tests
    {
        private const string _Name = "TestName";
        private Queue<string> arrivalTrains;
        private Queue<string> departureTrains;
        RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation(_Name);
            railwayStation.ArrivalTrains.Enqueue($"{_Name}in");
            railwayStation.DepartureTrains.Enqueue($"{_Name}out");
        }

        [Test]
        public void CreatingRailwayStation_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(railwayStation);
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenRailwayStationNameIsNullOrWhiteSpace_ShouldThrowArgumentException(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => railwayStation = new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase("treinInfo")]
        public void WhenNewArrivalOnBoard_arrivalTrainsCountShouldIncrease(string trainInfo)
        {
            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.AreEqual(2, railwayStation.ArrivalTrains.Count);
        }

        [TestCase("treinInfo")]
        public void WhenTrainWantArrived_ButNnotAtStart_ShouldThrowMessage(string trainInfo)
        {

            Assert.AreEqual($"There are other trains to arrive before {$"{_Name}in"}.", $"There are other trains to arrive before {railwayStation.ArrivalTrains.Peek()}.");
        }

        [TestCase("TestNamein")]
        public void TrainHasArrived_ShouldWorkCorrctly(string trainInfo)
        {

            Assert.AreEqual(trainInfo, railwayStation.ArrivalTrains.Dequeue());
        }

        [Test]
        public void TrainHasArrived_ShouldDecreaseCount()
        {
            railwayStation.TrainHasArrived(railwayStation.ArrivalTrains.Peek());
            Assert.AreEqual(2, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasArrived_ShouldWorkCorrectly()
        {
            Assert.AreEqual($"TestNamein is on the platform and will leave in 5 minutes.", railwayStation.TrainHasArrived(railwayStation.ArrivalTrains.Peek()));
        }


        [Test]
        public void TrainHasLeft_ShouldWorkCorrectly()
        {
            railwayStation.TrainHasLeft("TestNameout");
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }
    }
}