using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.Interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}
