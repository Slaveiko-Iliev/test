using System.Collections;
using System.ComponentModel.Design;

int carsThatCanPass = int.Parse(Console.ReadLine());

string command = string.Empty;

Queue<string> cars = new Queue<string>();

int passedCars = 0;

while ((command = Console.ReadLine()) != "end")
{
    if (command == "green")
    {
        for (int i = 0; i < carsThatCanPass && cars.Any(); i++)
        {
            Console.WriteLine($"{cars.Dequeue()} passed!");
            passedCars++;
        }
    }
    else
    {
        cars.Enqueue(command);
    }
}

Console.WriteLine($"{passedCars} cars passed the crossroads.");