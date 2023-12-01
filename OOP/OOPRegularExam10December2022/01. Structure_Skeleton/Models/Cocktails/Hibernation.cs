namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double PriceOfLarge = 10.50;

        protected Hibernation(string cocktailName, string size) : base(cocktailName, size, PriceOfLarge)
        {
        }
    }
}
