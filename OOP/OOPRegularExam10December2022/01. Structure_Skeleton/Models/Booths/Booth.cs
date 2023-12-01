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
        private double _currentBill;
        private double _turnover;
        private DelicacyRepository _delicacyMenu;
        private CocktailRepository _cocktailMenu;
        private bool _isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            _currentBill = 0;
            _turnover = 0;
            _delicacyMenu = new DelicacyRepository();
            _cocktailMenu = new CocktailRepository();
            _isReserved = false;
        }

        public int BoothId { get; protected set; }

        public int Capacity
        {
            get => _capacity;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => (IRepository<IDelicacy>)_delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => (IRepository<ICocktail>)_cocktailMenu;

        public double CurrentBill => _currentBill;

        public double Turnover => _turnover;

        public bool IsReserved => _isReserved;

        public void ChangeStatus()
        {
            if (!_isReserved)
            {
                _isReserved = true;
            }
            else
            {
                _isReserved = false;
            }
        }

        public void Charge()
        {
            _turnover += CurrentBill;
            _currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            _currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");

            //foreach (var cocktail in CocktailMenu)
            //{
            //    sb.AppendLine( cocktail.ToString() );
            //}

            sb.AppendLine("-Delicacy menu:");

            //foreach (var delicacy in DelicacyMenu)
            //{
            //    sb.AppendLine( delicacy.ToString() );
            //}

            return sb.ToString().TrimEnd();
        }


    }
}
