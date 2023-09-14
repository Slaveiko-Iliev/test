using System;
using System.Collections.Generic;

int numberOfPeople = int.Parse(Console.ReadLine());

HashSet<string> peoples = new HashSet<string>();

for (int i = 0; i < numberOfPeople; i++)
{
    peoples.Add(Console.ReadLine());
}

foreach (string people in peoples)
{
    Console.WriteLine(people);
}