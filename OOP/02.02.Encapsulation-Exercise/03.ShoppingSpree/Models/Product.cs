namespace _03.ShoppingSpree.Models
{
    class Product
    {
        private string _productName;
        private decimal _productCost;

        public Product(string productName, decimal productCost)
        {
            ProductName = productName;
            ProductCost = productCost;
        }

        public string ProductName
        {
            get => _productName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _productName = value;
            }
        }
        public decimal ProductCost
        {
            get => _productCost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                _productCost = value;
            }
        }

        public override string ToString() => $"{ProductName}";
    }
}
