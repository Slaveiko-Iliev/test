namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {
        private const string _Name = "TestName";
        RailwayStation rs;

        [SetUp]
        public void Setup()
        {
            rs = new RailwayStation(_Name);
        }

        [Test]
        public void TestCreatingRailwayStation()
        {
            Assert.IsNotNull(rs);
            Assert.IsNotNull(rs.ArrivalTrains);
            Assert.IsNotNull(rs.DepartureTrains);
            Assert.AreEqual(_Name, rs.Name);
        }

        [TestCase(null)]
        [TestCase("   ")]
        [TestCase("")]
        public void InvalidNameShouldReturnMessage(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase($"Train1{_Name}", $"Train2{_Name}")]
        public void TestNewArrivalOnBoard(string trainName1, string trainName2)
        {
            rs.NewArrivalOnBoard(trainName1);
            rs.NewArrivalOnBoard(trainName2);
            Assert.AreEqual(2, rs.ArrivalTrains.Count);
            Assert.AreEqual(trainName1, rs.ArrivalTrains.Peek());
        }

        [TestCase($"Train1{_Name}", $"Train2{_Name}")]
        public void TestTrainHasArrivedWithInvalidTrain(string trainName1, string trainName2)
        {
            rs.NewArrivalOnBoard(trainName1);
            rs.NewArrivalOnBoard(trainName2);
            Assert.AreEqual($"There are other trains to arrive before {trainName2}.", rs.TrainHasArrived(trainName2));
        }

        [TestCase($"Train1{_Name}", $"Train2{_Name}")]
        public void TestTrainHasArrivedWithValidTrain(string trainName1, string trainName2)
        {
            rs.NewArrivalOnBoard(trainName1);
            rs.NewArrivalOnBoard(trainName2);
            Assert.AreEqual($"{trainName1} is on the platform and will leave in 5 minutes.", rs.TrainHasArrived(trainName1));
            Assert.AreEqual(1, rs.ArrivalTrains.Count);
            Assert.AreEqual(1, rs.DepartureTrains.Count);
        }

        [TestCase($"Train1{_Name}", $"Train2{_Name}")]
        public void TestTrainHasLeftWithValidTrain(string trainName1, string trainName2)
        {
            rs.NewArrivalOnBoard(trainName1);
            rs.NewArrivalOnBoard(trainName2);
            rs.TrainHasArrived(trainName1);
            rs.TrainHasArrived(trainName2);
            Assert.AreEqual(true, rs.TrainHasLeft(trainName1));
            Assert.AreEqual(1, rs.DepartureTrains.Count);
            Assert.AreEqual(trainName2, rs.DepartureTrains.Peek());
        }

        [TestCase($"Train1{_Name}", $"Train2{_Name}")]
        public void TestTrainHasLeftWithInvalidTrain(string trainName1, string trainName2)
        {
            rs.NewArrivalOnBoard(trainName1);
            rs.NewArrivalOnBoard(trainName2);
            rs.TrainHasArrived(trainName1);
            rs.TrainHasArrived(trainName2);
            Assert.AreEqual(false, rs.TrainHasLeft(trainName2));
            Assert.AreEqual(2, rs.DepartureTrains.Count);
            Assert.AreEqual(trainName1, rs.DepartureTrains.Peek());

        }
    }
}