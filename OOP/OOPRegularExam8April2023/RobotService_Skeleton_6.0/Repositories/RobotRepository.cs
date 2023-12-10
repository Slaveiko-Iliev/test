using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> _models;

        public RobotRepository()
        {
            _models = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => _models;

        public IRobot FindByStandard(int interfaceStandard) => _models.FirstOrDefault(m => m.InterfaceStandards.Any(i => i.Equals(interfaceStandard)));

        public void AddNew(IRobot model)
        {
            _models.Add(model);
        }

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
