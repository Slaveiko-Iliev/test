using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string _name;
        private double _price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                _name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get => _price;
            private set
            {
                if (Size == "Large")
                {
                    _price = value;
                }
                else if (Size == "Middle")
                {
                    _price = 2.0 / 3 * value;
                }
                else if (Size == "Small")
                {
                    _price = 1.0 / 3 * value;
                }
            }
        }

        public override string ToString() => $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
    }
}
