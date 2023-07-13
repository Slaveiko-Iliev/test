string resourceAsInput = string.Empty;

Dictionary <string, double> resources = new Dictionary <string, double> ();

while ((resourceAsInput = Console.ReadLine()) != "stop")
{
    double quantityOfResource = double.Parse(Console.ReadLine());

    if (!resources.ContainsKey(resourceAsInput))
    {
        resources[resourceAsInput] = 0;
    }

    resources[resourceAsInput] += quantityOfResource;
}

foreach (var item in resources)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}