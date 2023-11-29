namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        public Car car;

        [SetUp]
        public void SetUp()
        {
            car = new("Make1", "Model1", 5, 50);
        }

        [Test]
        public void DefaultMethodCar_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(car);
            Assert.AreEqual(0, car.FuelAmount);
        }
    }
}