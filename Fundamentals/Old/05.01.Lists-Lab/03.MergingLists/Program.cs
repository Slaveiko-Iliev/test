using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            
            List<int> secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> result;
            int minCount;

            if (firstNumbers.Count < secondNumbers.Count)
            {
                minCount = firstNumbers.Count;
                result = GetMergingLists(firstNumbers, secondNumbers, minCount);

                for (int i = 0; i < secondNumbers.Count - minCount; i++)
                {
                    result.Add(secondNumbers[i + minCount]);
                }
            }
            else if (firstNumbers.Count > secondNumbers.Count)
            {
                minCount = secondNumbers.Count;
                result = GetMergingLists(firstNumbers, secondNumbers, minCount);

                for (int i = 0; i < firstNumbers.Count - minCount; i++)
                {
                    result.Add(firstNumbers[i + minCount]);
                }
            }
            else 
            {
                minCount = firstNumbers.Count;
                result = GetMergingLists(firstNumbers, secondNumbers, minCount);
            }

            Console.WriteLine(string.Join(" ",result));
        }

        static List<int> GetMergingLists (List<int> firstList, List<int> secondList, int minCount)
        {
            List <int> resultList = new List<int>();

            for (int i = 0; i < minCount; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            return resultList;
        }
    }
}
