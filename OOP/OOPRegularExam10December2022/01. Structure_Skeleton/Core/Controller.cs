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
using System.Text;

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

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
                currentBooth.DelicacyMenu.AddModel(delicacy);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
                currentBooth.DelicacyMenu.AddModel(delicacy);
            }

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            IBooth currentBooth = _booths.Models.First(b => b.BoothId == boothId);
            return currentBooth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth currentBooth = _booths.Models.Where(b => b.BoothId == boothId) as IBooth;

            double currentBill = currentBooth.CurrentBill;
            currentBooth.Charge();
            currentBooth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
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
            var subclassTypes = Assembly.GetAssembly(typeof(Cocktail))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Cocktail)) && t.IsSubclassOf(typeof(Delicacy)));
            string[] orderInfo = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            string itemCount = orderInfo[2];
            string cocktailSize;

            IBooth booth = _booths.Models.First(b => b.BoothId == boothId);

            if (!subclassTypes.Any(t => t.Name == itemTypeName))
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (!(booth.CocktailMenu.Models.Any(t => t.Name == itemName) || booth.DelicacyMenu.Models.Any(t => t.Name == itemName)))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                cocktailSize = orderInfo[3];

                if (!booth.CocktailMenu.Models.Any(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == cocktailSize))
                {
                    return $"There is no {cocktailSize} {itemName} available!";
                }
                ICocktail currentCocktail = booth.CocktailMenu.Models.First(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == cocktailSize);
                booth.UpdateCurrentBill(currentCocktail.Price * double.Parse(itemCount));
            }

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (!booth.DelicacyMenu.Models.Any(c => c.GetType().Name == itemTypeName && c.Name == itemName))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }
                IDelicacy currentDelicacy = booth.DelicacyMenu.Models.First(c => c.GetType().Name == itemTypeName && c.Name == itemName);
                booth.UpdateCurrentBill(currentDelicacy.Price * double.Parse(itemCount));
            }

            return $"Booth {boothId} ordered {itemCount} {itemName}!";
        }
    }
}
