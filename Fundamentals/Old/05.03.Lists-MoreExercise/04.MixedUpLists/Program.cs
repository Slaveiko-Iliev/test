using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            secondList.Reverse();

            int countOfMixing = Math.Min(firstList.Count, secondList.Count);

            List<int> mixedList = new List<int>();

            for (int i = 0; i < countOfMixing; i++)
            {
                mixedList.Add(firstList.Skip(i).First());
                mixedList.Add(secondList.Skip(i).First());
            }

            firstList.RemoveRange(0, countOfMixing);
            secondList.RemoveRange(0, countOfMixing);

            List<int> currentList = new List<int>();
            
            if (firstList.Count > secondList.Count)
            {
                currentList = firstList;
            }
            else
            {
                currentList = secondList;
            }
            
            int minElementOfResult = currentList.Min();
            int maxElementOfResult = currentList.Max();

            List<int> result = mixedList.Where(x => x > minElementOfResult &&  x < maxElementOfResult).ToList();

            result.Sort();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
