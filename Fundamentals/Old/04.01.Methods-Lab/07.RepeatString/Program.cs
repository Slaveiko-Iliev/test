using System;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int timeToRepeat = int.Parse(Console.ReadLine());
            string repeatString = GetRepeatString(input, timeToRepeat);
            Console.WriteLine(repeatString);

        }

        static string GetRepeatString(string input, int timeToRepeat)
        {
            string repeatString = string.Empty;

            for (int i = 0; i < timeToRepeat; i++)
            {
                repeatString += input;
            }
            return repeatString;
        }
    }
}
