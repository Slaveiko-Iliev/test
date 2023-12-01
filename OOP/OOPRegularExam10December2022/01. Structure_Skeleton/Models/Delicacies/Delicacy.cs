using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string _name;

        protected Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }

        public string Name
        {
            get => _name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                _name = value;
            }
        }

        public double Price { get; protected set; }

        public override string ToString() => $"{this.Name} - {this.Price:f2} lv";
    }
}
