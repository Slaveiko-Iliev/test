namespace _04.WildFarm.Factories.Interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}
