string input = string.Empty;

List<Vehicle> vehicles = new List<Vehicle>();

while ((input = Console.ReadLine()) != "End")
{
    string[] vehicleInfo = input.Split();

    string type = vehicleInfo[0];
    if (type == "car")
    {
        type = "Car";
    }
    else
    {
        type = "Truck";
    }
    string model = vehicleInfo[1];
    string color = vehicleInfo[2];
    double horsepower = int.Parse(vehicleInfo[3]);

    Vehicle vehicle = new Vehicle(type, model, color, horsepower);

    vehicles.Add(vehicle);
}

double sumOfTruckHorsepower = 0;
int truckCount = 0;
double sumOfCarHorsepower = 0;
int carCount = 0;

while ((input = Console.ReadLine()) != "Close the Catalogue")
{
    string model = input;

    foreach (Vehicle vehicle in vehicles)
    {
        if (vehicle.Model == model)
        {
            Console.WriteLine($"Type: {vehicle.Type}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
        }

        if (vehicle.Type == "Truck")
        {
            sumOfTruckHorsepower += vehicle.Horsepower;
            truckCount++;
        }
        else
        {
            sumOfCarHorsepower += vehicle.Horsepower;
            carCount++;
        }
    }
}

double averageTruckHorsepower = sumOfTruckHorsepower / truckCount;
double averageCarHorsepower = sumOfCarHorsepower / carCount;

if (carCount > 0)
{
    Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
}
else
{
    Console.WriteLine($"Cars have average horsepower of: 0.00.");
}

if (truckCount > 0)
{
    Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
}
else
{
    Console.WriteLine($"Trucks have average horsepower of: 0.00.");
}


public class Vehicle
{
    public Vehicle(string type, string model, string color, double horsepower)
    {
        this.Type = type;
        this.Model = model;
        this.Color = color;
        this.Horsepower = horsepower;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double Horsepower { get; set; }
}