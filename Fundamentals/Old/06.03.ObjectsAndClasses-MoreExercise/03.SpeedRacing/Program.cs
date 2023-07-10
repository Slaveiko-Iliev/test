using System.Xml.Schema;

//"<Model> <FuelAmount> <FuelConsumptionFor1km>". All cars start at 0 kilometers traveled.

int number = int.Parse(Console.ReadLine());

Car cars = new Car();

public class Car
{
    public Car (string model, double fuelAmount, double fuelRate)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelRate = fuelRate;
        TraveledDistance = 0;
    }


    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelRate { get; set; }
    public double TraveledDistance { get; }
}