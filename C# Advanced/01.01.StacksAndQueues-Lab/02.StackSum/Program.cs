Stack<int> numbers =  new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray());

string input = string.Empty;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] commandInfo = input
        .Split(' ');
    string command = commandInfo[0];
    int numberOne = int.Parse(commandInfo[1]);

    if (command == "add")
    {
        int numberTwo = int.Parse(commandInfo[2]);

        numbers.Push(numberOne);
        numbers.Push(numberTwo);
    }
    else if(command == "remove" && numbers.Count() >= numberOne)
    {
        for (int i = 0; i < numberOne; i++)
        {
            numbers.Pop();
        }
    }
}

Console.WriteLine($"Sum: { numbers.Sum()}");