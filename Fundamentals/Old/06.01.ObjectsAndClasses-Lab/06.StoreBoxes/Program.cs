//"{Serial Number} {Item Name} {Item Quantity} {itemPrice}

string input = string.Empty;

List <Box> boxes = new List <Box> ();

while ((input = Console.ReadLine()) != "end")
{
    string[] boxInfo = input.Split();

    string serialNumber = boxInfo[0];
    string itemName = boxInfo[1];
    int itemQuantity = int.Parse(boxInfo[2]);
    decimal itemPrice = decimal.Parse(boxInfo[3]);

    Item item = new Item();
    item.Name = itemName;
    item.Price = itemPrice;

    Box box = new Box
    {
        SerialNumber = serialNumber,
        Item = item,
        ItemQuantity = itemQuantity,
        PricePerBox = itemPrice * itemQuantity,
    };

    boxes.Add(box);
}

foreach (Box box in boxes.OrderByDescending(x => x.PricePerBox))
{
    Console.WriteLine(box.SerialNumber);
    Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
    Console.WriteLine($"-- ${box.PricePerBox:F2}");
}

public class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Box
{
    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int ItemQuantity { get; set; }
    public decimal PricePerBox { get; set; }
}