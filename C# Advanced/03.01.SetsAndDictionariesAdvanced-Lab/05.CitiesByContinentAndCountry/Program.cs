using System;
using System.Collections.Generic;

int countOfCountries = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

for (int i = 0; i < countOfCountries; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string continent = input[0];
    string country = input[1];
    string city = input[2];

    if (!continents.ContainsKey(continent))
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continents[continent].ContainsKey(country))
    {
        continents[continent][country] = new List<string>();
    }

    continents[continent][country].Add(city);
}

foreach (var (continent, countries) in continents)
{
    Console.WriteLine($"{continent}:");

    foreach (var (country, cities) in countries)
    {
        Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
    }
}