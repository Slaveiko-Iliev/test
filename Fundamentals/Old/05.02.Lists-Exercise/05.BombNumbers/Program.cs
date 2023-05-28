using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] command = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int specialNumber = command[0];
            int powerOfNumber = command[1];

            for (int i = 0; i < numbers.Count; i++)
            {
               if (numbers[i] == specialNumber)
                {
                    int indexOfSpecialNumber = i;

                    for (int j = indexOfSpecialNumber - 1; j > indexOfSpecialNumber - 1 - powerOfNumber; j--)
                    {
                        if (j >= 0)
                        {
                            numbers.RemoveAt(j);
                        }
                    }

                    if (numbers.IndexOf(specialNumber) != -1)
                    {
                        indexOfSpecialNumber = numbers.IndexOf(specialNumber);
                    }
                    

                    for (int k = 0; k < powerOfNumber; k++)
                    {
                        if (indexOfSpecialNumber + 1 + k <= numbers.Count - 1)
                        {
                            numbers.RemoveAt((indexOfSpecialNumber + 1 + k));
                        }
                    }

                    

                    numbers.Remove(specialNumber);
                } 
                
                
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
