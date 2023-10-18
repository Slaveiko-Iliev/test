using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; private set; }
        public List<Drink> Drinks { get; private set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return Drinks.Remove(Drinks.FirstOrDefault(d => d.Name == name));
        }

        public Drink GetLongest()
        {
            return Drinks.MaxBy(d => d.Volume);
        }

        public Drink GetCheapest()
        {
            return Drinks.MinBy(d => d.Price);
        }

        public string BuyDrink(string name)
        {
            return Drinks.FirstOrDefault(d => d.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
