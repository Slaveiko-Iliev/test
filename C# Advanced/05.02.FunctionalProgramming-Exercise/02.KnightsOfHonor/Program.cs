using System;

string[] names = Console.ReadLine()
    .Split();

Action<string[]> action = Print;
action(names);

static void Print(string[] names)
{
    foreach (var name in names)
    {
        Console.WriteLine($"Sir {name}");
    }
}