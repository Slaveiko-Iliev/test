using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<Cocktail>
    {
        private List<Cocktail> _cocktailMenu;

        public CocktailRepository()
        {
            _cocktailMenu = new List<Cocktail>();
        }

        public IReadOnlyCollection<Cocktail> Models => _cocktailMenu;

        public void AddModel(Cocktail model)
        {
            _cocktailMenu.Add(model);
        }
    }
}
