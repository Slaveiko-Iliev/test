//2 + 5 + 10 - 2 - 1

string[] input = Console.ReadLine()
    .Split();
string[] reversedInput = input
    .Reverse()
    .ToArray();

Stack<string> operations = new Stack<string>();
Stack<int> numbers = new Stack<int>();

for (int i = 0; i < reversedInput.Length; i++)
{
    if (reversedInput[i] == "+" || reversedInput[i] == "-")
    {
        operations.Push(reversedInput[i]);
    }
    else
    {
        numbers.Push(int.Parse(reversedInput[i]));
    }
}

int sum = numbers.Pop();  //2 + 5 + 10 - 2 - 1

while (numbers.Any())
{
    if (operations.Pop() == "+")
    {
        sum += numbers.Pop();
    }
    else
    {
        sum -= numbers.Pop();
    }
}

Console.WriteLine(sum);