string[] input = Console.ReadLine()
    .Split();

foreach (string item in input)
{
	for (int i = 0; i < item.Length; i++)
	{
        Console.Write(item);
    }
}