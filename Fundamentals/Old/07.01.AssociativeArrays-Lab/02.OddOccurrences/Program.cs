using System.Diagnostics.Metrics;

string[] input = Console.ReadLine()
    .ToLower()
    .Split();

Dictionary<string, int> counts = new Dictionary<string, int>();

for (int i = 0; i < input.Length; i++)
{
    if (!counts.ContainsKey(input[i]))
    {
        counts.Add(input[i], 0);
    }

    counts[input[i]]++;
}

foreach (var number in counts)
{
    if (number.Value % 2 != 0)
    {
        Console.Write($"{number.Key} ");
    }
}