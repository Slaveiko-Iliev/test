using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

string input = string.Empty;

HashSet<string> cars = new HashSet<string>();

while ((input = Console.ReadLine().ToUpper()) != "END")
{
    string[] actionInfo = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string direction = actionInfo[0];
    string registrationPlate = actionInfo[1];

    switch (direction)
    {
        case "IN":
            cars.Add(registrationPlate);
            break;
        case "OUT":
            cars.Remove(registrationPlate);
            break;
    }
}

if (!cars.Any())
{
    Console.WriteLine("Parking Lot is Empty");
}
else
{
    foreach (string car in cars)
    {
        Console.WriteLine(car);
    }
}

