using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories;
using System;

namespace ChristmasPastryShop.Core
{
    internal class Controller : IController
    {
        private BoothRepository _booth;

        public Controller()
        {
            _booth = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(_booth.Models.Count + 1, capacity);
            _booth.AddModel(booth);

            return $"Added booth number {_booth.Models.Count + 1} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            throw new NotImplementedException();
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {

        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            throw new NotImplementedException();
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}
