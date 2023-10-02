using System;
using System.Collections.Generic;
using System.Linq;

int[] bound = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int lower =  bound[0];
int upper = bound[1];

string command = Console.ReadLine();

Predicate<int> specifies = x => x % 2 == 0;
Action<int, int, string> findAndPrint = FindPrint;

findAndPrint(lower, upper, command);


void FindPrint(int lower, int upper, string command)
{
    List<int> result = new List<int>();

    for (int i = lower; i <= upper; i++)
    {
        if (command == "odd")
        {
            if (!specifies(i))
            {
                result.Add(i);
            }
        }
        else
        {
            if (specifies(i))
            {
                result.Add(i);
            }
        }
    }
    Console.WriteLine(string.Join(" ", result));
}

