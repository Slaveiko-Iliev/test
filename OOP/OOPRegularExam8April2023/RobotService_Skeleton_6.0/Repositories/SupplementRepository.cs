using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> _models;

        public SupplementRepository()
        {
            _models = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() => _models;

        public void AddNew(ISupplement model)
        {
            _models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard) => _models.FirstOrDefault(m => m.InterfaceStandard == interfaceStandard);

        public bool RemoveByName(string typeName)
        {
            if (_models.Remove(_models.FirstOrDefault(m => m.GetType().Name == typeName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
