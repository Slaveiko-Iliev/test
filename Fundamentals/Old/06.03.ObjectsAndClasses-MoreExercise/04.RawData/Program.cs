int number = int.Parse(Console.ReadLine());

List<Car> cars = new List<Car>(); //"<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>

for (int i = 0; i < number; i++)
{
    string[] carInfo = Console.ReadLine().Split();
    string model = carInfo[0];
    int engineSpeed = int.Parse(carInfo[1]);
    int enginePower = int.Parse(carInfo[2]);
    int cargoWeight = int.Parse(carInfo[3]);
    string cargoType = carInfo[4];

    Engine engine = new Engine(engineSpeed, enginePower);
    Cargo cargo = new Cargo(cargoWeight, cargoType);
    Car car = new Car(model, engine, cargo);

    cars.Add(car);
}

string command = Console.ReadLine();

if (command == "fragile")
{
    Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(x => x.Cargo.CargoType == command).Where(x => x.Cargo.CargoWeight < 1000)));
}
else if (command == "flamable")
{
    Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(x => x.Cargo.CargoType == command).Where(x => x.Engine.EnginePower > 250)));
}





public class Car
{
    public Car (string model, Engine engine, Cargo cargo)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
    }

    public override string ToString()
    {
        return $"{Model}";
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
}

public class Engine
{
    public Engine(int engineSpeed, int enginePower)
    {
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
    }

    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
}

public class Cargo
{
    public Cargo(int cargoWeight, string cargoType)
    {
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }

    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
}