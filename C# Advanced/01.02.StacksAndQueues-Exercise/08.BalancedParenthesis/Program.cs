using System;
using System.Collections.Generic;

string sequence = Console.ReadLine();

Stack<char> leftStack = new();
bool isBalanced = false;

foreach (char ch in sequence)
    {
        if (ch == '(' || ch == '{' || ch == '[')
        {
            leftStack.Push(ch);
            isBalanced = false;
        }
        else if (leftStack.Count == 0)
        {
        isBalanced = false;
        break;
        }
        else if (leftStack.Peek() == '(' && ch == ')' || leftStack.Peek() == '{' && ch == '}' || leftStack.Peek() == '[' && ch == ']')
        {
            leftStack.Pop();
            isBalanced = true;
        }
        else
        {
            isBalanced = false;
            break;
        }
    }

if (isBalanced && leftStack.Count == 0)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}