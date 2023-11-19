using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> _models;

        public PlayerRepository()
        {
            _models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => _models.AsReadOnly();

        public void AddModel(IPlayer model) => _models.Add(model);

        public bool ExistsModel(string name) => _models.Any(p => p.Name == name);

        public IPlayer GetModel(string name) => _models.FirstOrDefault(p => p.Name == name);

        public bool RemoveModel(string name) => _models.Remove(_models.FirstOrDefault(p => p.Name == name));
    }
}
