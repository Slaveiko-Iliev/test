using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> _delicacies;

        public DelicacyRepository()
        {
            _delicacies = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => _delicacies.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            _delicacies.Add(model);
        }
    }
}
