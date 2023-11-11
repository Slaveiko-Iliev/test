using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.Interfaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalTokens);
}
