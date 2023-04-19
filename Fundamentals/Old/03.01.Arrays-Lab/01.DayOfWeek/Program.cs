using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int number = int.Parse(Console.ReadLine());

            if (number <= dayOfWeek.Length && number > 0)
            {
                Console.WriteLine($"{dayOfWeek [number - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
