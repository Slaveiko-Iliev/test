namespace Animals.Models
{
    public class Cat : Animal
    {
        private string name;
        private string favouriteFood;

        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf() =>
            $"{base.ExplainSelf()}" +
            $"{Environment.NewLine}" +
            $"MEEOW";
    }
}
