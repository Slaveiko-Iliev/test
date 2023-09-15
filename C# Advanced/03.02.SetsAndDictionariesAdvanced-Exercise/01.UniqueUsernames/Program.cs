using System;
using System.Collections.Generic;

int num = int.Parse(Console.ReadLine());

HashSet<string> usernames = new HashSet<string>();

for (int i = 0; i < num; i++)
{
    usernames.Add(Console.ReadLine());
}

Console.WriteLine(string.Join(Environment.NewLine, usernames));