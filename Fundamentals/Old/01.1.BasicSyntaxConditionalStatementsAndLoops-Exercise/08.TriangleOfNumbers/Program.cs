using System;

namespace _08.TriangleOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int y = 1; y <= n; y++)
            {
                for (int x = 1; x <= y; x++)
                {
                    Console.Write($"{y} ");
                }
                Console.WriteLine();
            }
        }
    }
}
