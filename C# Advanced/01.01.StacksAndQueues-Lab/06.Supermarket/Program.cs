string input = string.Empty;

Queue<string> customers = new Queue<string>();

while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        Console.WriteLine(string.Join(Environment.NewLine, customers));
        customers.Clear();
    }
    else
    {
        customers.Enqueue(input);
    }
}

Console.WriteLine($"{customers.Count()} people remaining.");