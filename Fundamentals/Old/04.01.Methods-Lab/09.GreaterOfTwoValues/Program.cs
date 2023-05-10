using System;

namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfValues = Console.ReadLine();

            if (typeOfValues == "int")
            {
                int valueA = int.Parse(Console.ReadLine());
                int valueB = int.Parse(Console.ReadLine());

                int greater = GetGreater(valueA, valueB);
                Console.WriteLine(greater);
            }
            else if (typeOfValues == "char")
            {
                char valueA = char.Parse(Console.ReadLine());
                char valueB = char.Parse(Console.ReadLine());

                char greater = GetGreater(valueA, valueB);
                Console.WriteLine(greater);
            }
            else if(typeOfValues == "string")
            {
                string valueA = Console.ReadLine();
                string valueB = Console.ReadLine();

                string greater = GetGreater(valueA, valueB);
                Console.WriteLine(greater);
            }
        }

        static int GetGreater (int valueA, int valueB)
        {
            if (valueA > valueB)
            {
                return valueA;
            }
            else
            {
                return valueB;
            }
        }

        static char GetGreater (char valueA, char valueB)
        {
            if (valueA > valueB)
            {
                return valueA;
            }
            else
            {
                return valueB;
            }
        }

        static string GetGreater (string valueA, string valueB)
        {
            int greater = string.Compare(valueA, valueB);

            if (greater > 0)
            {
                return valueA;
            }
            else
            {
                return valueB;
            }
        }
    }
}
