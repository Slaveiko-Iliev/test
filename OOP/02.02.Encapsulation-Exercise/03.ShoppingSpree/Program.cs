List<Person>persons = new ();
List<Product>products = new ();

string[] personsInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries) ;

foreach(string currentPerson in personsInput)
{
    string[] personInfo = currentPerson
        .Split("=", StringSplitOptions.RemoveEmptyEntries) ;
    string personName = personInfo[0] ;
    decimal personMoney = decimal.Parse(personInfo[1]);
    Person person = new Person(personName, personMoney) ;
    persons.Add(person);
}

string[] productsInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);

foreach (string currentProduct in productsInput)
{
    string[] productInfo = currentProduct
        .Split("=", StringSplitOptions.RemoveEmptyEntries);
    string productName = productInfo[0];
    decimal productCost = decimal.Parse(productInfo[1]);
    Product product = new Product(productName, productCost) ;
    products.Add(product);
}

string input = string.Empty ;

while ((input = Console.ReadLine()) != "END")
{

}

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
			if (string.IsNullOrEmpty (value))
			{
                throw new ArgumentException ("Name cannot be empty");
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
                throw new ArgumentException ("Money cannot be negative");
            }
            _productCost = value;
        }
    }
}

class Person
{
    private List<Product> _personProducts;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        _personProducts = new List<Product>();
    }

    public string Name { get; private set; }
    public decimal Money { get; private set; }
    public IReadOnlyList<Product> Products { get => _personProducts; }
}