using System;
using System.Collections.Generic;
using System.Linq;

int numberOfPumps = int.Parse(Console.ReadLine());

Queue<int[]> allPumps = new();

for (int i = 0; i < numberOfPumps; i++)
{
    int[] currentPump = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    allPumps.Enqueue(currentPump);
}

int sumOfFuel = 0;
int sumOfDistance = 0;
bool isEnoughFuel = false;
int startIndex = 0;

for (int i = 0; i < numberOfPumps; i++)
{
    if (!isEnoughFuel)
    {
        sumOfFuel = 0;
        sumOfDistance = 0;
    }
    
    int currentFuel = allPumps.Peek()[0];
    int currentDistance = allPumps.Peek()[1];
    sumOfFuel += currentFuel;
    sumOfDistance += currentDistance;

    if (sumOfFuel >= sumOfDistance)
    {
        isEnoughFuel = true;
    }
    else
    {
        isEnoughFuel = false;
        startIndex = i + 1;
    }

    allPumps.Dequeue();
}

//if (startIndex > numberOfPumps - 1)
//{
//    startIndex = numberOfPumps - 1;
//}

Console.WriteLine(startIndex);
