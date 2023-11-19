using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _models;

        public TeamRepository()
        {
            _models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => _models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            _models.Add(model);
        }

        public bool ExistsModel(string name) => _models.Contains(_models.FirstOrDefault(p => p.Name == name));

        public ITeam GetModel(string name) => _models.FirstOrDefault(p => p.Name == name);

        public bool RemoveModel(string name) => _models.Remove(_models.FirstOrDefault(p => p.Name == name));
    }
}
