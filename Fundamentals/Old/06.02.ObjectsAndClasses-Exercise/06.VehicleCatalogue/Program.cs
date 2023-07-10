using System.Runtime.CompilerServices;

string input = string.Empty;
List<Vehicle> vehicles = new List<Vehicle>();

while ((input = Console.ReadLine()) != "End")
{
    string[] vehicleInfo = input.Split();
    string typeOfVehicle = vehicleInfo[0];
    typeOfVehicle = char.ToUpper(typeOfVehicle[0]) + typeOfVehicle.Substring(1);
    string model = vehicleInfo[1];
    string color = vehicleInfo[2];
    double horsepower = double.Parse(vehicleInfo[3]);

    Vehicle vehicle = new Vehicle(typeOfVehicle, model, color, horsepower);
    vehicles.Add(vehicle);
}

while ((input = Console.ReadLine()) != "Close the Catalogue")
{
    string model = input;

    int index = vehicles.FindIndex(x => x.Model == model);

    Console.WriteLine($"Type: {vehicles[index].TypeOfVehicle}");
    Console.WriteLine($"Model: {vehicles[index].Model}");
    Console.WriteLine($"Color: {vehicles[index].Color}");
    Console.WriteLine($"Horsepower: {vehicles[index].Horsepower}");
}

List<Vehicle> car = vehicles.Where(x => x.TypeOfVehicle == "Car").ToList();
List<Vehicle> truck = vehicles.Where(x => x.TypeOfVehicle == "Truck").ToList();

double sumOfHorsepowerOfCar = 0;
double sumOfHorsepowerOfTruck = 0;

foreach (Vehicle vehicle in car)
{
    sumOfHorsepowerOfCar += vehicle.Horsepower;
}

foreach (Vehicle vehicle in truck)
{
    sumOfHorsepowerOfTruck += vehicle.Horsepower;
}

double averageOfHorsepowerOfCar = sumOfHorsepowerOfCar / car.Count;
double averageOfHorsepowerOfTruck = sumOfHorsepowerOfTruck / truck.Count;

if (car.Count == 0)
{
    averageOfHorsepowerOfCar = 0;
}

if (truck.Count == 0)
{
    averageOfHorsepowerOfTruck = 0;
}

Console.WriteLine($"Cars have average horsepower of: {averageOfHorsepowerOfCar:f2}.");
Console.WriteLine($"Trucks have average horsepower of: {averageOfHorsepowerOfTruck:f2}.");

public class Vehicle
{
    public Vehicle(string typeOgVehicle, string model, string color, double horsepower)
    {
        TypeOfVehicle = typeOgVehicle;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public string TypeOfVehicle { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double Horsepower { get; set; }

}