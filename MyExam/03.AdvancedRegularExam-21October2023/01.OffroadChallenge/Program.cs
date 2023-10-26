Stack<int> initialFuel = new ();

int[] inputInitialFuel = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

foreach (int i in inputInitialFuel)
{
    initialFuel.Push (i);
}

Queue<int> additionalConsumption = new Queue<int>();

int[] inputAdditionalConsumption = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

foreach (int i in inputAdditionalConsumption)
{
    additionalConsumption.Enqueue (i);
}

Queue<int> neededFuel = new Queue<int>();

int[] inputNeededFuel = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

foreach (int i in inputNeededFuel)
{
    neededFuel.Enqueue(i);
}

int reachedAltitudes = 0;

for (int i = 1; i <= 4; i++)
{
    int result = initialFuel.Pop() - additionalConsumption.Dequeue();

    if (result >= neededFuel.Dequeue())
    {
        Console.WriteLine($"John has reached: Altitude {i}");
        reachedAltitudes++;
    }
    else
    {
        Console.WriteLine($"John did not reach: Altitude {i}");
        break;
    }
}

string[] reachedAltitudesAsString = new string[reachedAltitudes];

if (reachedAltitudes > 0)
{
    for (int i = 1; i <= reachedAltitudesAsString.Length; i++)
    {
        reachedAltitudesAsString[i - 1] = $"Altitude {i}";
    }
}

if (reachedAltitudes > 0 && reachedAltitudes < 4)
{
    Console.WriteLine("John failed to reach the top.");
    Console.Write("Reached altitudes: ");
    Console.Write(string.Join(", ", reachedAltitudesAsString));
}
else if (reachedAltitudes == 0)
{
    Console.WriteLine($"John failed to reach the top.");
    Console.WriteLine($"John didn't reach any altitude.");
}
else if (reachedAltitudes == 4)
{
    Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
}
