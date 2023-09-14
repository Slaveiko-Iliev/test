using System;
using System.Collections.Generic;

string reservation = string.Empty;

SortedSet<string> reservations = new SortedSet<string>();

while ((reservation = Console.ReadLine()) != "PARTY")
{
    reservations.Add(reservation);
}

while ((reservation = Console.ReadLine()) != "END")
{
    reservations.Remove(reservation);
}

foreach (var item in reservations)
{
    Console.WriteLine(item);
}