using System;

namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var isFound = false;

            while (!isFound)
            {
                if (num % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    isFound = true;
                }
                if (!isFound)
                {
                    num = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
