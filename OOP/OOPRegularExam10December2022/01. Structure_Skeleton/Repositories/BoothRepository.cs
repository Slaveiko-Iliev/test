using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    internal class BoothRepository : IRepository<Booth>
    {
        private List<Booth> _booths;

        public BoothRepository()
        {
            _booths = new List<Booth>();
        }

        public IReadOnlyCollection<Booth> Models => (IReadOnlyCollection<Booth>)_booths;

        public void AddModel(Booth model)
        {
            _booths.Add(model);
        }
    }
}
