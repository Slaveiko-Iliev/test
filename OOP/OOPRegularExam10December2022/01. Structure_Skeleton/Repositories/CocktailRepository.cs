using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> _cocktails;

        public CocktailRepository()
        {
            _cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => _cocktails.AsReadOnly();

        public void AddModel(ICocktail model)
        {
            _cocktails.Add(model);
        }
    }
}
