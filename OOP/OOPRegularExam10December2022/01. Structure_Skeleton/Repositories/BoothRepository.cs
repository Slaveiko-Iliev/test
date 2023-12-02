using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> _booths;

        public BoothRepository()
        {
            _booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => (IReadOnlyCollection<IBooth>)_booths.AsReadOnly();

        public void AddModel(IBooth model)
        {
            _booths.Add(model);
        }
    }
}
