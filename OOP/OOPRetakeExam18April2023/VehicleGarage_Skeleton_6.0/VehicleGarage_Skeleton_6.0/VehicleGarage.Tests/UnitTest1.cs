using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private const int _Capacity = 2;
        private const string _Brand = "TestBrand";
        private const string _Model = "TestModel";
        private const string _LicensePlateNumber = "TestLPN";
        private Garage garage;
        private Vehicle vehicle1;
        private Vehicle vehicle2;
        private Vehicle vehicle3;

        [SetUp]
        public void Setup()
        {
            garage = new Garage(_Capacity);
            vehicle1 = new Vehicle($"{_Brand}1", $"{_Model}1", $"{_LicensePlateNumber}1");
            vehicle2 = new Vehicle($"{_Brand}2", $"{_Model}2", $"{_LicensePlateNumber}2");
            vehicle3 = new Vehicle($"{_Brand}3", $"{_Model}3", $"{_LicensePlateNumber}3");
        }

        [Test]
        public void CreatingGarage_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(garage);
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(_Capacity, garage.Capacity);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void AddVehicle_ShouldIncreaseCount()
        {
            garage.AddVehicle(vehicle1);
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void AddVehicle_ShouldWorkCorrectly()
        {
            Assert.AreEqual(true, garage.AddVehicle(vehicle1));

            garage.AddVehicle(vehicle2);

            Assert.AreEqual(false, garage.AddVehicle(vehicle3));
        }

        //[Test]
        //public void AddVehicle_ShouldWorkCorrectly2()
        //{
        //    garage.AddVehicle(vehicle1);
        //    garage.AddVehicle(vehicle2);

        //    Assert.AreEqual(false, garage.AddVehicle(vehicle3));
        //}

        [Test]
        public void CantAddCarTwice()
        {
            garage.AddVehicle(vehicle1);
            Assert.AreEqual(false, garage.AddVehicle(vehicle1));
        }

        [Test]
        public void ChargeVehicles_ShouldWorkCorrectly()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.DriveVehicle(vehicle1.LicensePlateNumber, 20, false);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 60, false);
            Assert.AreEqual(1, garage.ChargeVehicles(50));
            Assert.AreEqual(80, vehicle1.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [TestCase($"{_LicensePlateNumber}1", 120, false)]
        [TestCase($"{_LicensePlateNumber}1", 90, false)]
        public void CantDriveVehicle_WithBatteryProblem(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            vehicle1.BatteryLevel = 80;
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);

            Assert.AreEqual(80, vehicle1.BatteryLevel);
        }

        [TestCase($"{_LicensePlateNumber}1", 190, false)]
        public void CantDriveVehicle_WithBatteryProblem2(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);

            Assert.AreEqual(100, vehicle1.BatteryLevel);
        }

        [TestCase($"{_LicensePlateNumber}1", 60, false)]
        public void CantDriveVehicle_WithBatteryProblem3(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);

            Assert.AreEqual(40, vehicle1.BatteryLevel);
        }

        [TestCase($"{_LicensePlateNumber}1", 50, true)]
        public void CantDriveVehicle_DamagedCar(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);

            Assert.AreEqual(50, vehicle1.BatteryLevel);

        }

        [TestCase($"{_LicensePlateNumber}1", 50, false)]
        public void DriveVehicle_ShouldDecreaseBatteryLevel(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.AreEqual(50, vehicle1.BatteryLevel);
        }

        [TestCase($"{_LicensePlateNumber}1", 50, true)]
        public void DriveWithAccident_ShouldDamageCar(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.AreEqual(true, vehicle1.IsDamaged);
        }

        [TestCase($"{_LicensePlateNumber}1", 20, true)]
        public void RepairVehicles_ShouldWorkCorrectly(string licensePlateNumber, int batteryDrainage, bool accidentOccured)
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, accidentOccured);
            Assert.AreEqual($"Vehicles repaired: 1", garage.RepairVehicles());
            Assert.AreEqual(false, garage.Vehicles.Any(v => v.IsDamaged == true));
            Assert.AreEqual(false, vehicle1.IsDamaged);
        }
    }
}