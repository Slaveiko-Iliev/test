using System;
using System.Collections.Generic;

int number = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> wardrobe = new();

for (int i = 0; i < number; i++)
{
    string[] input = Console.ReadLine()
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string color = input[0];

    string[] clothes = input[1]
        .Split(",", StringSplitOptions.RemoveEmptyEntries);

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }
    
    for (int j = 0; j < clothes.Length; j++)
    {
        if (!wardrobe[color].ContainsKey(clothes[j]))
        {
            wardrobe[color][clothes[j]] = 0;
        }
        wardrobe[color][clothes[j]]++;
    }
}

string[] lookFor = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var (color, pieceOfClothing) in wardrobe)
{
    Console.WriteLine($"{color} clothes:");

    foreach (var (curPieceOfClothing, count) in pieceOfClothing)
    {
        if (color == lookFor[0] && curPieceOfClothing == lookFor[1])
        {
            Console.WriteLine($"* {curPieceOfClothing} - {count} (found!)");
        }
        else
        {
            Console.WriteLine($"* {curPieceOfClothing} - {count}");
        }
    }
}