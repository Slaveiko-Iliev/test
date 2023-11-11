using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;

        public Cat(string name, double weight) : base(name, weight)
        {
        }

        protected override double WeightMultiplier
            => CatWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable) };

        public override string MadeSound()
            => "Meow";
    }
}
