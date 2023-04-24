using System;
using System.Linq;
using System.Numerics;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequences = int.Parse(Console.ReadLine());
            string dnaSample = Console.ReadLine();

            int bestFirstOne = int.MinValue;
            int bestSequenceSum = int.MinValue;
            int[] bestDnaSample = new int[lengthOfSequences];
            int counterOfSample = 0;
            int bestCounterOfSample = 0;

            while (dnaSample != "Clone them!")
            {
                int[] currentSample = dnaSample.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentFirstOne = int.MinValue;
                int currentSequenceSum = 0;

                for (int i = 0; i < currentSample.Length; i++)
                {
                    if (i != currentSample.Length-1 && currentSample[i] == 1 && currentSample[i+1] == 1 && currentFirstOne == int.MinValue)
                    {
                        currentFirstOne = i;
                        currentSequenceSum++;
                    }
                    else if (currentSample[i] == 1)
                    {
                        currentSequenceSum++;
                    }
                }
                counterOfSample++;

                if (bestFirstOne == int.MinValue)
                {
                    bestFirstOne = currentFirstOne;
                    bestSequenceSum = currentSequenceSum;
                    bestDnaSample = currentSample;
                    bestCounterOfSample = counterOfSample;
                }
                else if (currentFirstOne != int.MinValue && currentFirstOne < bestFirstOne)
                {
                    bestFirstOne = currentFirstOne;
                    bestSequenceSum = currentSequenceSum;
                    bestDnaSample = currentSample;
                    bestCounterOfSample = counterOfSample;
                }
                else if (currentFirstOne == bestFirstOne && currentSequenceSum > bestSequenceSum)
                {
                    bestFirstOne = currentFirstOne;
                    bestSequenceSum = currentSequenceSum;
                    bestDnaSample = currentSample;
                    bestCounterOfSample = counterOfSample;
                }
                dnaSample = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestCounterOfSample} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", bestDnaSample));
        }
    }
}
