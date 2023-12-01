using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<Delicacy>
    {
        private List<Delicacy> _delicacyMenu;

        public DelicacyRepository()
        {
            _delicacyMenu = new List<Delicacy>();
        }

        public IReadOnlyCollection<Delicacy> Models => _delicacyMenu;

        public void AddModel(Delicacy model)
        {
            _delicacyMenu.Add(model);
        }
    }
}
