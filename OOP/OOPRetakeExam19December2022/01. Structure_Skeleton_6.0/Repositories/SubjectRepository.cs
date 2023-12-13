using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> _models;

        public SubjectRepository()
        {
            _models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => _models;

        public void AddModel(ISubject model) => _models.Add(model);

        public ISubject FindById(int id) => _models.FirstOrDefault(sub => sub.Id == id);

        public ISubject FindByName(string name) => _models.FirstOrDefault(sub => sub.Name == name);
    }
}
