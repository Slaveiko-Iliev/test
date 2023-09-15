using System;
using System.Collections.Generic;
using System.Linq;

string input = string.Empty;

Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

while ((input = Console.ReadLine()) != "Revision")
{
    string[] shopINfo = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string shop = shopINfo[0];
    string product = shopINfo[1];
    double price = double.Parse(shopINfo[2]);

    if (!shops.ContainsKey(shop))
    {
        shops.Add(shop, new Dictionary<string, double>());
    }

    shops[shop].Add(product, price);
    
}

foreach (var (shop, products) in shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
{
    Console.WriteLine($"{shop}->");

    foreach (var (product, price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}
