using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _users;

        public UserRepository()
        {
            _users = new List<IUser>();
        }

        public void AddModel(IUser model) => _users.Add(model);

        public IUser FindById(string identifier) => _users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

        public IReadOnlyCollection<IUser> GetAll() => _users.AsReadOnly();

        public bool RemoveById(string identifier) => _users.Remove(_users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier));
    }
}
