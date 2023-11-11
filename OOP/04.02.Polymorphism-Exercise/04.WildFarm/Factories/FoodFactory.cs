using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
