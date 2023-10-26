using Froggy;

List<int> stones = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Lake lake = new(stones);

Console.WriteLine(string.Join(", ", lake));
