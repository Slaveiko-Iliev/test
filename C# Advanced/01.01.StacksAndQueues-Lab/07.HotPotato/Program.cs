string[] input = Console.ReadLine()
    .Split();

int number = int.Parse(Console.ReadLine());

Queue<string> childrenNames = new Queue<string>(input);

while (childrenNames.Count > 1)
{
	for (int i = 0; i < number - 1; i++)
	{
		string currentChildren = childrenNames.Dequeue();
		childrenNames.Enqueue(currentChildren);
	}
    Console.WriteLine($"Removed {childrenNames.Dequeue()}");
}

Console.WriteLine($"Last is {string.Join("", childrenNames)}");