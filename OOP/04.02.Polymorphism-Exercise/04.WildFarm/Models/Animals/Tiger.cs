using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Tiger : Mammal
    {
        private const double TigerWeightMultiplier = 1;


        public Tiger(string name, double weight) : base(name, weight)
        {
        }
        protected override double WeightMultiplier
            => TigerWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable) };

        public override string MadeSound()
            => "ROAR!!!";
    }
}

