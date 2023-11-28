namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        public const double fuelAmount = 0;
        public const string make = "InitMake";
        public const string model = "InitModel";
        public const double fuelConsumption = 5;
        public const double fuelCapacity = 50;

        public Car car;

        [SetUp]
        public void Setup()
        {
            car = new(make, model, fuelConsumption, fuelCapacity);
        }


        [Test]
        public void CreatingCar_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(car);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase("", model, fuelConsumption, fuelCapacity)]
        public void UsingEmptyMake_ShouldThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(make, "", fuelConsumption, fuelCapacity)]
        public void UsingEmptyModel_ShouldThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(make, model, 0, fuelCapacity)]
        [TestCase(make, model, -5, fuelCapacity)]
        public void UsingZeroOrNegativeFuelConsumption_ShouldThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }
    }
}