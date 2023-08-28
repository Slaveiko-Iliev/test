using System;
using System.Collections.Generic;
using System.Linq;

string sequence = Console.ReadLine();

Stack<char> leftStack = new();
Stack<char> rightStack = new();

foreach (char ch in sequence)
{
    if (ch == '(' || ch == '{' || ch == '[')
    {
        leftStack.Push(ch);
    }
    else if (ch == ')' || ch == '}' || ch == ']')
    {
        rightStack.Push(ch);
    }
}

bool isBalanced = true;

while (isBalanced && leftStack.Any())
{
    if (leftStack.Peek() == '(' && rightStack.Peek() == ')' || leftStack.Peek() == '{' && rightStack.Peek() == '}' || leftStack.Peek() == '[' && rightStack.Peek() == ']')
    {
        leftStack.Pop();
        rightStack.Pop();
    }
    else
    {
        isBalanced = false;
    }
}

if (!isBalanced)
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}

//string sequence = Console.ReadLine();

////string leftHalfSequence = sequence.Substring(0, sequence.Length / 2);
////string rightHalfSequence = sequence.Substring(sequence.Length / 2 , sequence.Length / 2);

//Stack<char> stack = new ();
//Queue<char> queue = new ();

//bool isBalanced = false;
//char left = char.MinValue;
//char right = char.MinValue;

//for (int i = 0; i < sequence.Length; i++)
//{
//    if (stack.Any())
//    {
//        left = stack.Peek();
//    }

//    if (queue.Any())
//    {
//        right = queue.Peek();
//    }

//    if (left == '[' && right == ']')
//    {
//        isBalanced = true;
//    }
//    else if (left == '{' && right == '}')
//    {
//        isBalanced = true;
//    }
//    else if (left == '(' && right == ')')
//    {
//        isBalanced = true;
//    }
//    else
//    {
//        isBalanced = false;
//        if(i % 2 == 0)
//        {
//            left = sequence[i];
//            stack.Push(left);
//        }
//        else
//        {
//            right = sequence[i];
//            queue.Enqueue(right);
//        }

//        continue;
//    }

//    stack.Pop();
//    queue.Dequeue();
//}

//if (!isBalanced)
//{
//    Console.WriteLine("NO");
//}
//else
//{
//    Console.WriteLine("YES");
//}