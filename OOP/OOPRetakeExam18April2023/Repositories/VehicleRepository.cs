using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> _vehicles;

        public VehicleRepository()
        {
            _vehicles = new List<IVehicle>();
        }

        public void AddModel(IVehicle model) => _vehicles.Add(model);

        public IVehicle FindById(string identifier) => _vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll() => _vehicles.AsReadOnly();

        public bool RemoveById(string identifier) => _vehicles.Remove(_vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier));
    }
}
