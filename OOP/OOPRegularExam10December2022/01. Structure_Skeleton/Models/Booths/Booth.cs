using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int _capacity;
        private DelicacyRepository _delicacies;
        private CocktailRepository _cocktails;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            _delicacies = new DelicacyRepository();
            _cocktails = new CocktailRepository();
            IsReserved = false;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                _capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => _delicacies;

        public IRepository<ICocktail> CocktailMenu => _cocktails;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (!IsReserved)
            {
                IsReserved = true;
            }
            else
            {
                IsReserved = false;
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");

            foreach (var cocktail in _cocktails.Models)
            {
                sb.AppendLine(cocktail.ToString());
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in _delicacies.Models)
            {
                sb.AppendLine(delicacy.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
