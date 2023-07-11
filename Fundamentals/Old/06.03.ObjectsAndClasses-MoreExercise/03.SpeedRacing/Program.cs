using System.Collections.Generic;
using System.Xml.Schema;


int number = int.Parse(Console.ReadLine());

List<Car> cars = new List<Car>();

for (int i = 0; i < number; i++)
{
    string[] currenrCar = Console.ReadLine()
        .Split();

    string model = currenrCar[0];
    double fuelAmount = double.Parse(currenrCar[1]);
    double fuelRate = double.Parse(currenrCar[2]);

    Car car = new Car(model, fuelAmount, fuelRate);
    cars.Add(car);
}

string input = string.Empty;

while ((input = Console.ReadLine()) != "End")
{
    string[] command = input.Split();
    string model = command[1];
    double amountOfKm = double.Parse(command[2]);

    cars.Find(x => x.Model == model).Drive(amountOfKm);
}

Console.Write(String.Join(Environment.NewLine, cars));



public class Car
{
    public Car(string model, double fuelAmount, double fuelRate)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelRate = fuelRate;
        TraveledDistance = 0;
    }


    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelRate { get; set; }
    public double TraveledDistance { get; set; }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TraveledDistance}";
    }

    public void Drive(double amountOfKm)
    {
        if (amountOfKm * FuelRate > FuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelAmount -= amountOfKm * FuelRate;
            TraveledDistance += amountOfKm;
        }
    }
}
