using System.Linq;

string input = Console.ReadLine();  //I Love C#

//Stack<char> stringToReverse = new Stack<char>(input);

//Console.WriteLine(string.Join("",stringToReverse));

Stack<string> stack = new Stack<string>();

foreach (var ch in input)
{
    stack.Push(ch.ToString());
}

while (stack.Count > 0)
{
    Console.Write(stack.Pop());
}