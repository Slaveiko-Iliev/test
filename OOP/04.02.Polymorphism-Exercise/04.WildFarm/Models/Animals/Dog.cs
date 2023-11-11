using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.4;


        public Dog(string name, double weight) : base(name, weight)
        {
        }

        protected override double WeightMultiplier
            => DogWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
            => new HashSet<Type>() { typeof(Meat) };

        public override string MadeSound()
            => "Woof!";

        public override string ToString()
            => $"{base.ToString}{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
