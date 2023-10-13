using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> strings = new();

            for (int i = 0; i < number; i++)
            {
                strings.Add(Console.ReadLine());
            }

            string elementForComparison = Console.ReadLine();

            Console.WriteLine(CountOfLargerElements(strings, elementForComparison));

            static int CountOfLargerElements<T>(List<T> list, T elementForComparison)
            where T : IComparable<T>
            {
                int count = 0;

                foreach (T element in list)
                {
                    if (element.CompareTo(elementForComparison) > 0)
                    {
                        count++;
                    }
                }

                return count;
            }
        }
    }
}
