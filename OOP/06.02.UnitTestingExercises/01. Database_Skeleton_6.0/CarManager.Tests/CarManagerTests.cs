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


        [TestCase(make, model, fuelConsumption, 0)]
        [TestCase(make, model, fuelConsumption, -50)]
        public void UsingZeroOrNegativeFuelCapacity_ShouldThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-50)]
        public void RefuelWithZeroOrNegativeAmount_ShouldThrowArgumentException(double fuelAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [TestCase(50)]
        public void Refuel_ShouldWorkCorrectly(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [TestCase(55)]
        public void RefuelWithMoreThanCapacity_ShouldWorkCorrectly(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(500)]
        public void WhenDriveWhitNotEnoughFuel_shouldThrowInvalidOperationException(double distance)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

        [TestCase(5, 50)]
        public void WhenDrive_FuelShouldDecreasedCorrectly(double distance, double fuelAmount)
        {
            car.Refuel(fuelAmount);
            double currentAmount = car.FuelAmount;
            car.Drive(distance);
            Assert.AreEqual(currentAmount - (distance / 100 * fuelConsumption), car.FuelAmount);
        }
    }
}