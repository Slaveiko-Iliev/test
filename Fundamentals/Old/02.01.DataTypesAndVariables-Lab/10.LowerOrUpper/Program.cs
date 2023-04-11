using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //for (int i = 0; i < 2; i++)
            //{
                char letter = char.Parse(Console.ReadLine());
                if (letter >= 97 && letter <= 122)
                {
                    Console.WriteLine("lower-case");
                }
                else if (letter >= 65 && letter <= 90)
                {
                    Console.WriteLine("upper-case");
                }

            //}


        }
    }
}
