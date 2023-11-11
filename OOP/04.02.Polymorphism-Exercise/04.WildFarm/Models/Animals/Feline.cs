using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight) : base(name, weight)
        {
        }

        public string Breed { get; }

        public override string ToString()
            => $"{base.ToString}{nameof(Type)}{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
