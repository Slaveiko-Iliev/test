using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> _models;

        public UniversityRepository()
        {
            _models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => _models;

        public void AddModel(IUniversity model) => _models.Add(model);

        public IUniversity FindById(int id) => _models.FirstOrDefault(x => x.Id == id);

        public IUniversity FindByName(string name) => _models.FirstOrDefault(x => x.Name == name);
    }
}
