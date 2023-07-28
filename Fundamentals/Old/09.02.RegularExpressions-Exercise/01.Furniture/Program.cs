using System.Text.RegularExpressions;

string pattern = @">>(?<furnitureName>\w+)<<(?<price>\d+\.\d{2}|\d+)!(?<quantity>\d*)";
string input = string.Empty;

List<Furniture> furnitures = new List<Furniture>();

while ((input = Console.ReadLine()) != "Purchase")
{
    Regex regex = new Regex(pattern);

    bool isMatch = regex.IsMatch(input);

    if (!isMatch)
    {
        continue;
    }

    Match match = regex.Match(input);

    string furnitureName = match.Groups["furnitureName"].Value;
    double price = double.Parse(match.Groups["price"].Value);
    int quantity = int.Parse(match.Groups["quantity"].Value);

    Furniture furniture = new Furniture(furnitureName, price, quantity);

    furnitures.Add(furniture);
}


Console.WriteLine("Bought furniture:");
furnitures.ForEach(furniture => Console.WriteLine($"{furniture.FurnitureName}"));

//Console.WriteLine($"Total money spend: {furnitures.ForEach(furniture => furniture.Price * furniture.Quantity).Sum())}");

//Bought furniture:
//Chair
//Sofa
//Bench
//Bed
//Total money spend: 9536.69


public class Furniture
{
    public Furniture (string furnitureName, double price, int quantity)
    {
        FurnitureName = furnitureName;
        Price = price;
        Quantity = quantity;
    }

    public string FurnitureName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
