using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using System.Linq;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length))
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }

            if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length))
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }

            IRoute route = new Route(startPoint, endPoint, length, (routes.GetAll().Count + 1));
            routes.AddModel(route);

            if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length))
            {
                routes.GetAll().First(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length).LockRoute();
            }

            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IVehicle currentVehicle = vehicles.GetAll().First(v => v.LicensePlateNumber == licensePlateNumber);
            IUser currentUser = users.GetAll().First(u => u.DrivingLicenseNumber == drivingLicenseNumber);

            if (currentUser.IsBlocked)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }

            if (currentVehicle.IsDamaged)
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }

            if (routes.GetAll().First(r => r.RouteId == int.Parse(routeId)).IsLocked)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }

            currentVehicle.Drive(routes.GetAll().First(r => r.RouteId == (int.Parse(routeId))).Length);

            if (isAccidentHappened)
            {
                currentVehicle.ChangeStatus();
                currentUser.DecreaseRating();
            }
            else
            {
                currentUser.IncreaseRating();
            }

            return currentVehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.GetAll().Any(u => u.DrivingLicenseNumber == drivingLicenseNumber))
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string RepairVehicles(int count)
        {
            var vehiclesToRepair = vehicles.GetAll().OrderBy(v => v.Brand).ThenBy(v => v.Model).Where(v => v.IsDamaged == true);

            if (vehicles.GetAll().Count > count)
            {
                vehiclesToRepair = vehiclesToRepair.Take(count);
            }

            int countOfRepairedVehicles = 0;

            foreach (var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
                countOfRepairedVehicles++;
            }

            return $"{countOfRepairedVehicles} vehicles are successfully repaired!";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (!(vehicleType == "CargoVan" || vehicleType == "PassengerCar"))
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            if (vehicles.GetAll().Any(vehicle => vehicle.LicensePlateNumber == licensePlateNumber))
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            IVehicle vehicle = new CargoVan(brand, model, licensePlateNumber);

            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string UsersReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName))
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
