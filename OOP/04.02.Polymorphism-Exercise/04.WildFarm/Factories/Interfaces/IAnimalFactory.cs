namespace _04.WildFarm.Factories.Interfaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalTokens);
}
