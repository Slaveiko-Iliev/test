using System;

namespace _06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string  text = string.Empty;

            for (int i = 1; i <= 3; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                text += letter;
            }
            
            for (int j = text.Length - 1; j >= 0; j--)
            {
                char reverse = text[j];
                Console.Write($"{reverse} ");

            }

        }
    }
}
