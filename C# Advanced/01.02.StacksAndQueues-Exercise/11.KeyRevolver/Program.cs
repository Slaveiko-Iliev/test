using System;
using System.Collections.Generic;
using System.Linq;

int priceOfBullet = int.Parse(Console.ReadLine());
int sizeOfGunBarrel = int.Parse(Console.ReadLine());
int[] bulletsInfo = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();    
int[] locksInfo = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int valueOfIntelligence = int.Parse(Console.ReadLine());

Stack<int> bullets = new (bulletsInfo);
Queue<int> locks = new (locksInfo);
bool isThereAreLocks = false;
int currentBarrel = sizeOfGunBarrel;

if (locks.Count > 0)
{
    isThereAreLocks = true;
}

while (bullets.Count > 0)
{
    if (!isThereAreLocks)
    {
        Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
        break;
    }

    if (bullets.Pop() <= locks.Peek())
    {
        locks.Dequeue();
        Console.WriteLine("Bang!");
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    currentBarrel--;
    valueOfIntelligence -= priceOfBullet;

    if (locks.Count == 0)
    {
        isThereAreLocks = false;
    }

    if (bullets.Count == 0)
    {
        break;
    }

    if (currentBarrel == 0)
    {
        Console.WriteLine("Reloading!");

        if (sizeOfGunBarrel >= bullets.Count)
        {
            currentBarrel += bullets.Count;
        }
        else
        {
            currentBarrel += sizeOfGunBarrel;
        }
    }
}

if (!isThereAreLocks && bullets.Count == 0)
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
}
else if (isThereAreLocks)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}