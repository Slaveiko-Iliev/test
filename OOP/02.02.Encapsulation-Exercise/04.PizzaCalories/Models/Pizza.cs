namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
		private string pizzaName;
		private List<Topping> toppings;
		private Dough pizzaDough;

        public Pizza(string pizzaName)
		{
			PizzaName = pizzaName;
			toppings = new ();
		}

		public string PizzaName
		{
			get => pizzaName;
			init
			{
				if (value.Length < 1 || value.Length > 15)
				{
					throw new ArgumentException(ExceptionMessages.PizzaNameLength);
				}
				pizzaName = value;
			}
		}
		public int NumberOfToppings { get => toppings.Count; }
		public Dough PizzaDough
        {
			get { return pizzaDough; }
			set { pizzaDough = value; }
		}


		public double GetTotalcalories()
		{
			double totalcalories = 0;

			totalcalories += pizzaDough.GetDoughCalories();
			foreach (Topping topping in toppings)
			{
				totalcalories += topping.GetToppingCalories();

            }

			return totalcalories;
		}

		public void AddToppings(Topping topping)
		{
			if (NumberOfToppings == 10)
			{
				throw new ArgumentException(ExceptionMessages.NumberOfToppings);
			}
			toppings.Add(topping);
		}
		public override string ToString() => $"{PizzaName} - {GetTotalcalories():f2} Calories.";
    }
}
