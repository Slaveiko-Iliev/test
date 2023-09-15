using System;
using System.Collections.Generic;

string reservation = string.Empty;

HashSet<string> reservations = new HashSet<string>();
HashSet<string> vipReservations = new HashSet<string>();

while ((reservation = Console.ReadLine()) != "PARTY")
{
    if (Char.IsDigit(reservation[0]))
    {
        vipReservations.Add(reservation);
    }
    else
    {
        reservations.Add(reservation);
    }
}

while ((reservation = Console.ReadLine()) != "END")
{
    if (Char.IsDigit(reservation[0]))
    {
        vipReservations.Remove(reservation);
    }
    else
    {
        reservations.Remove(reservation);
    }
}
    
int missingGuests = vipReservations.Count + reservations.Count;

Console.WriteLine(missingGuests);

foreach (var item in vipReservations)
{
    Console.WriteLine(item);
}

foreach (var item in reservations)
{
    Console.WriteLine(item);
}