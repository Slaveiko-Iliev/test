using System;
using System.Collections.Generic;

int greenLight = int.Parse(Console.ReadLine());
int freeWindow =  int.Parse(Console.ReadLine());

string input = string.Empty;
Queue<string> carsOnCrossroads = new();
int carsPassed = 0;
char hitAt = char.MinValue;
bool isCrashHappened = false;

while ((input = Console.ReadLine()) != "END" && !isCrashHappened)
{
    if (input != "green")
    {
        carsOnCrossroads.Enqueue(input);
    }
    else if (input == "green" && carsOnCrossroads.Count > 0)
    {
        int currentGreenLight = greenLight;

        while (currentGreenLight > 0 && carsOnCrossroads.Count > 0)
        {
            string currentCar = carsOnCrossroads.Dequeue();
            currentGreenLight -= currentCar.Length;

            if (currentGreenLight >= 0)
            {
                carsPassed++;
            }
            else if (currentGreenLight + freeWindow >= currentCar.Length)
            {
                carsPassed++;
            }
            else if (currentGreenLight + freeWindow < currentCar.Length)
            {
                hitAt = currentCar[currentGreenLight + currentCar.Length +freeWindow];
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currentCar} was hit at {hitAt}.");
                isCrashHappened = true;
            }
        }
    }
}

if (!isCrashHappened)
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
}