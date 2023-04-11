using System;

namespace _01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a > b && a > c)
            {
                if (b > c)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                }
            }
            if (b > a && b > c)
            {
                if (a > c)
                {
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                }

            }
            if (c > a && c > b)
            {
                if (b > a)
                {
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }
            }
        }
    }
}
