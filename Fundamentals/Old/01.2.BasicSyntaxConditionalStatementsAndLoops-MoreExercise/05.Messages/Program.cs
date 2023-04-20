using System;

namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string messages = String.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int number = int.Parse(input);
                int digit = number % 10;
                int offset = (digit - 2) * 3;
                if (digit == 0)
                    messages += ' ';
                else if (digit > 7)
                    messages += (char)(97 + offset + input.Length);
                else
                    messages += (char)(97 + offset + input.Length - 1);
            }
            Console.WriteLine(messages);
        }
    }
}
