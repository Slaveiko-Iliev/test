using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> _models;

        public FishRepository()
        {
            _models = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => _models.AsReadOnly();

        public void AddModel(IFish model) => _models.Add(model);

        public IFish GetModel(string name) => _models.FirstOrDefault(m => m.Name == name);
    }
}
