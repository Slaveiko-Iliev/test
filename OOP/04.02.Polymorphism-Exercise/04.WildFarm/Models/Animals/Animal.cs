using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; init; }
    }
}
