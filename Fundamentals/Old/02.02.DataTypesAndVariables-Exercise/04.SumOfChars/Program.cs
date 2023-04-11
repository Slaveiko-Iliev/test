using System;

namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int i = 0; i < count; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int number = (int)letter;
                totalSum += number;

            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
