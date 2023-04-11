using System;

namespace _09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                text += letter;
            }
            Console.WriteLine(text);
        }
    }
}
