﻿using System;

namespace _01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int result = d * ((a + b) / c);
            Console.WriteLine(result);
        }
    }
}
