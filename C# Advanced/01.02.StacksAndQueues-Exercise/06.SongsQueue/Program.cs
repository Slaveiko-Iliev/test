using System;
using System.Collections.Generic;
using System.Linq;

string[] input = Console.ReadLine()
    .Split(", ");

Queue<string> playlist = new(input);

while (playlist.Any())
{
    string command = Console.ReadLine();

    if (command == "Play")
    {
        playlist.Dequeue();
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", playlist));
    }
    else
    {
        string songName = command.Substring(4, command.Length - 4);
        
        if (!playlist.Contains(songName))
        {
            playlist.Enqueue(songName);
        }
        else
        {
            Console.WriteLine($"{songName} is already contained!");
        }
    }
}

Console.WriteLine("No more songs!");