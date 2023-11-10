using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
