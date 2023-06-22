//"{type}/{brand}/{model}/{horse power / weight}"

using System.Reflection;

string input = string.Empty;

Catalog catalog = new Catalog();

while ((input = Console.ReadLine()) != "end")
{
    string[] infoInput = input.Split('/');

    string type = infoInput[0];
    string brand = infoInput[1];
    string model = infoInput[2];
    int powerWeight = int.Parse(infoInput[3]);

    if (type == "Car")
    {
        Car car = new Car
        {
            Brand = brand,
            Model = model,
            HorsePower = powerWeight
        };

        catalog.Cars.Add(car);
    }
    else
    {
        Truck truck = new Truck
        {
            Brand = brand,
            Model = model,
            Weight = powerWeight
        };

        catalog.Trucks.Add(truck);
    }
}

Console.WriteLine("Cars:");

foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
}

Console.WriteLine("Trucks:");

foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
}

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}

public class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }

}

public class Catalog
{
    public Catalog()
    {
        Cars = new List<Car>();
        Trucks = new List<Truck>();
    }
    public List<Car> Cars { get; set; }
    public List<Truck> Trucks { get;set; }
}