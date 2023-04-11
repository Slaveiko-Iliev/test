using System;
using System.Drawing;

namespace _02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());
            decimal dollars = britishPounds * 1.31m;
            Console.WriteLine($"{dollars:f3}");
        }
    }
}
