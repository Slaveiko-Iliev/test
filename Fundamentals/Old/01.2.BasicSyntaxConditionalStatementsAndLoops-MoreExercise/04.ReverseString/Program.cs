using System;

namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reverseText = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char letter = text[i];
                reverseText += letter;
            }
            Console.WriteLine(reverseText);
        }
    }
}
