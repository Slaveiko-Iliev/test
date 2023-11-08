namespace Animals.Models
{
    public class Dog :Animal
    {
        private string name;
        private string favouriteFood;

        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf() =>
            $"{base.ExplainSelf()}" +
            $"{Environment.NewLine}" +
            $"DJAAF";
    }
}
