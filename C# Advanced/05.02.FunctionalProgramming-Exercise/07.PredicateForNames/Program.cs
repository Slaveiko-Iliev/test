using System;

int representingLength = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries) ;

Predicate<string> lengthMatch = x => x.Length <= representingLength;

foreach (string name in names)
{
   if (lengthMatch(name))
    {
        Console.WriteLine($"{name}");
    }
}