using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string middle = GetMiddle(input);
            Console.WriteLine(middle);
        }

        private static string GetMiddle(string input)
        {
            string middle = string.Empty;
            if (input.Length % 2 != 0)
            {
                middle += input[(input.Length /2)];
            }
            else
            {
                middle += input[(input.Length / 2) - 1];
                middle += input[(input.Length / 2)];
            }
            return middle;
        }
    }
}
