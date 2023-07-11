//Peter=11;George=4
//Bread=10;Milk=2;

List<Person> persons = new List<Person>();
string[] personInput = Console.ReadLine().Split(";");

for (int i = 0; i < personInput.Length; i++)
{
    string[] personInfo = personInput[i].Split("=");
    string name = personInfo[0];
    decimal money = decimal.Parse(personInfo[1]);

    Person person = new Person(name, money);
    persons.Add(person);
}

List<Product> products = new List<Product>();
string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < productInput.Length; i++)
{
    string[] productInfo = productInput[i].Split("=");
    string productName = productInfo[0];
    decimal money = decimal.Parse(productInfo[1]);

    Product product = new Product(productName, money);
    products.Add(product);
}

string input = string.Empty;

while ((input = Console.ReadLine()) != "END")
{
    string[] command = input.Split();

    string name = command[0];
    string productName = command[1];

    if (persons.Find(x => x.Name == name).Money >= products.Find(x => x.ProductName == productName).Cost)
    {
        persons.Find(x => x.Name == name).Money -= products.Find(x => x.ProductName == productName).Cost;
        persons.Find(x => x.Name == name).BagOfProducts.Add(productName);

        Console.WriteLine($"{name} bought {productName}");
    }
    else
    {
        Console.WriteLine($"{name} can't afford {productName}");
    }
}

foreach (Person person in persons)
{
    
    
    if (person.BagOfProducts.Count == 0)
    {
        Console.WriteLine($"{person.Name} - Nothing bought");
    }
    else
    {
        
        Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
    }
}



public class Product
{
    public Product(string productName, decimal cost)
    {
        ProductName = productName;
        Cost = cost;
    }

    public string ProductName { get; set; }
    public decimal Cost { get; set; }
}

public class Person
{
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new List<string>();
    }

    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<string> BagOfProducts { get; set;}
}