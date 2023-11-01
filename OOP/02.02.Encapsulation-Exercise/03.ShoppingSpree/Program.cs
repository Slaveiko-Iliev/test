using _03.ShoppingSpree.Models;
using System;
using System.Security.Cryptography.X509Certificates;

List<Person>persons = new ();
List<Product>products = new ();

try
{
    string[] personsInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);

    foreach (string currentPerson in personsInput)
    {
        string[] personInfo = currentPerson
            .Split("=", StringSplitOptions.RemoveEmptyEntries);
        if (personInfo.Length < 2)
        {
            throw new ArgumentException("Name cannot be empty");
        }
        string personName = personInfo[0];
        decimal personMoney = decimal.Parse(personInfo[1]);
        Person person = new Person(personName, personMoney);
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
        Product product = new Product(productName, productCost);
        products.Add(product);
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string input = string.Empty ;

while ((input = Console.ReadLine()) != "END")
{
    string[] buyInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Person person = persons.FirstOrDefault(p => p.Name == buyInfo[0]);
    Product product = products.FirstOrDefault(p => p.ProductName == buyInfo[1]);

    if (person is not null && product is not null)
    {
        if (!person.BuyProduct(person, product))
        {
            Console.WriteLine($"{person.Name} can't afford {product.ProductName}");
        }
        else
        {
            Console.WriteLine($"{person.Name} bought {product.ProductName}");
        }
    }
}

foreach (Person person in persons)
{
    if (person.Products.Count > 0)
    {
        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products).ToString()}");
    }
    else if(person.Products.Count == 0)
    {
        Console.WriteLine($"{person.Name} - Nothing bought");
    }
}