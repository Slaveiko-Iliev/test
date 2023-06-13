using System;

namespace _02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Print(number);
        }

        static void Print(int number)
        {
            if (number <= 0)
            {
                return;
            }
            
            Console.WriteLine(new string ('*', number));
            Print(number-1);
            Console.WriteLine(new string('#', number));
        }
    }
}
