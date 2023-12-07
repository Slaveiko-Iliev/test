using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using System;
using System.Linq;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository _users;
        private VehicleRepository _vehicles;
        private RouteRepository _routes;

        public Controller()
        {
            _users = new UserRepository();
            _vehicles = new VehicleRepository();
            _routes = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (_routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length))
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }

            if (_routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length))
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }

            IRoute route = new Route(startPoint, endPoint, length, (_routes.GetAll().Count + 1));
            _routes.AddModel(route);

            if (_routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length))
            {
                _routes.GetAll().First(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length).LockRoute();
            }

            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (_users.GetAll().Any(u => u.DrivingLicenseNumber == drivingLicenseNumber))
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            _users.AddModel(user);

            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string RepairVehicles(int count)
        {
            if (_vehicles.GetAll().Count < count)
            {
                var vehiclesToRepair = _vehicles.GetAll().OrderBy(v => v.Brand).ThenBy(v => v.Model).Where(v => v.IsDamaged == true).Take(count);
            }
            else
            {
                var vehiclesToRepair = _vehicles.GetAll().OrderBy(v => v.Brand).ThenBy(v => v.Model).Where(v => v.IsDamaged == true);
            }

            foreach (var vehicle in vehiclesToRepair)
            {

            }
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (!(vehicleType == "CargoVan" || vehicleType == "PassengerCar"))
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            if (_vehicles.GetAll().Any(vehicle => vehicle.LicensePlateNumber == licensePlateNumber))
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            IVehicle vehicle = new CargoVan(brand, model, licensePlateNumber);

            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            _vehicles.AddModel(vehicle);

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string UsersReport()
        {
            throw new NotImplementedException();
        }
    }
}
