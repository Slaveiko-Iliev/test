Queue<int>numbers = new Queue<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray());

List <int> evenNumbers = new List<int>();

while (numbers.Any())
{
    if (numbers.Peek() % 2 == 0)
    {
        evenNumbers.Add(numbers.Dequeue());
    }
    else
    {
        numbers.Dequeue();
    }
}

Console.WriteLine(string.Join(", ", evenNumbers));