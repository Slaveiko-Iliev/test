using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight) : base(name, weight)
        {
        }

        public string Breed { get; }
    }
}
