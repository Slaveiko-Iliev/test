string input = string.Empty;

Dictionary <string, double[]> products = new Dictionary<string, double[]>();

while ((input = Console.ReadLine()) != "buy")
{
    string[] productInfo = input
        .Split();

    string product = productInfo[0];
    double price = double.Parse(productInfo[1]);
    double quantity = double.Parse(productInfo[2]);

    if (!products.ContainsKey(product) )
    {
        products[product] = new double[] { price, quantity };
    }
    else
    {
        products[product][0] = price;
        products[product][1] += quantity;
    }
}

foreach (var product in products)
{
    double totalPrice = product.Value[0] * product.Value[1];


    Console.WriteLine($"{product.Key} -> {totalPrice:f2}");
}