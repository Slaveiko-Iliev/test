namespace _03.ShoppingSpree.Models
{
    class Person
    {
        private string _name;
        private decimal _money;
        private List<Product> _personProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            _personProducts = new List<Product>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }
        public decimal Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                _money = value;
            }
        }
        public IReadOnlyList<Product> Products { get => _personProducts; }

        public bool BuyProduct(Person person, Product product)
        {
            bool isBuyProduct = false;

            if(product.ProductCost <= person.Money)
            {
                isBuyProduct = true;
                person.Money -= product.ProductCost;
                _personProducts.Add(product);
            }

            return isBuyProduct;
        }

        public override string ToString()
        {
            string productsString = _personProducts.Any()
                 ? string.Join(", ", _personProducts.Select(p => p.ProductName))
                 : "Nothing bought";

            return $"{Name} - {productsString}";
        }
    }
}
