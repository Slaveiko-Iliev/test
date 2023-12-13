using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> _models;

        public StudentRepository()
        {
            _models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => _models;

        public void AddModel(IStudent model) => _models.Add(model);

        public IStudent FindById(int id) => _models.FirstOrDefault(x => x.Id == id);

        public IStudent FindByName(string name) => _models.FirstOrDefault(x => $"{x.FirstName} {x.LastName}" == name);
    }
}
