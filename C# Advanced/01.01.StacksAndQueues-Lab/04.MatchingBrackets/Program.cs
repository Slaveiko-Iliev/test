string input = Console.ReadLine();

Stack<int> indexOfBrackets = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        indexOfBrackets.Push(i);
    }
    else if (input[i] == ')' && indexOfBrackets.Any())
    {
        Console.WriteLine(input.Substring(indexOfBrackets.Peek(), (i +1 - indexOfBrackets.Pop())));
    }
}