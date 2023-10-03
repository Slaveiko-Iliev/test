using System;
using System.Linq;

int representingLength = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries) ;

//Predicate<string> lengthMatch = x => x.Length <= representingLength;

//foreach (string name in names)
//{
//   if (lengthMatch(name))
//    {
//        Console.WriteLine($"{name}");
//    }
//}

Console.WriteLine(string.Join(
    Environment.NewLine, names
    .Where(x => x.Length <= representingLength)
    .ToArray()));