int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

SortedDictionary <int, int> counts = new SortedDictionary<int, int>();

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
    Console.WriteLine($"{number.Key} -> {number.Value}");
}