using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Linq;
using System.Reflection;

namespace ChristmasPastryShop.Core
{
    internal class Controller : IController
    {
        private BoothRepository _booths;

        public Controller()
        {
            _booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(_booths.Models.Count + 1, capacity);
            _booths.AddModel(booth);

            return $"Added booth number {_booths.Models.Count} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var subclassTypes = Assembly.GetAssembly(typeof(Cocktail))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Cocktail)));

            bool isValedType = false;

            foreach (var type in subclassTypes)
            {
                if (type.Name == cocktailTypeName)
                {
                    isValedType = true;
                }
            }

            if (!isValedType)
            {
                throw new ArgumentException($"Cocktail type {cocktailTypeName} is not supported in our application!");
            }

            if (!(size == "Small" || size == "Middle" || size == "Large"))
            {
                throw new ArgumentException($"{size} is not recognized as valid cocktail size!");
            }

            IBooth currentBooth = _booths.Models.First(b => b.BoothId == boothId);

            if (!(currentBooth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size) == null))
            {
                throw new ArgumentException($"{size} {cocktailName} is already added in the pastry shop!");
            }

            ICocktail cocktail;

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
                currentBooth.CocktailMenu.AddModel(cocktail);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
                currentBooth.CocktailMenu.AddModel(cocktail);
            }

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var subclassTypes = Assembly.GetAssembly(typeof(Delicacy))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Delicacy)));

            bool isValedType = false;

            foreach (var type in subclassTypes)
            {
                if (type.Name == delicacyTypeName)
                {
                    isValedType = true;
                }
            }

            if (!isValedType)
            {
                throw new ArgumentException($"Delicacy type {delicacyTypeName} is not supported in our application!");
            }

            IBooth currentBooth = _booths.Models.First(b => b.BoothId == boothId);

            if (currentBooth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                throw new ArgumentException($"{delicacyName} is already added in the pastry shop!");
            }

            IDelicacy delicacy;

            foreach (var type in subclassTypes)
            {
                if (type.Name == "Gingerbread")
                {
                    delicacy = new Gingerbread(delicacyName);
                    currentBooth.DelicacyMenu.AddModel(delicacy);
                }
                else if (type.Name == "Stolen")
                {
                    delicacy = new Stolen(delicacyName);
                    currentBooth.DelicacyMenu.AddModel(delicacy);
                }
            }

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
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
            IBooth booth = _booths.Models
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault(b => !b.IsReserved && b.Capacity >= countOfPeople);

            if (booth == null)
            {
                throw new ArgumentException($"No available booth for {countOfPeople} people!");
            }

            booth.ChangeStatus();

            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}
