using System;
using System.Collections.Generic;
using System.Linq;

int[] cupsInfo = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();
int[] bottlesInfo = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

Queue<int> cupsCapacity = new (cupsInfo);
Stack<int> filledBottles = new (bottlesInfo);
bool isThereCups = false;
int wastedLittersOfWater = 0;
int currentCup = 0;

if (cupsCapacity.Count > 0)
{
    isThereCups = true;
}

while (filledBottles.Count > 0)
{
    if (cupsCapacity.Count == 0)
    {
        isThereCups = false;
        Console.WriteLine($"Bottles: {string.Join(" ", filledBottles)}");
        Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        break;
    }

    currentCup = cupsCapacity.Peek();

    while (currentCup > 0)
    {
        currentCup -= filledBottles.Pop();

        if (currentCup < 0)
        {
            wastedLittersOfWater += Math.Abs(currentCup);
        }

        if (filledBottles.Count == 0)
        {
            break;
        }
    }

    cupsCapacity.Dequeue();
}

if (isThereCups)
{
    Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
    Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
}