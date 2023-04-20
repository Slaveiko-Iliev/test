using System;
using System.Linq;

namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool isEqual = false;

            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                

                if (i == 0)
                {
                    leftSum = 0;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        leftSum += numbers[j];
                    }
                }

                if (i == numbers.Length - 1)
                {
                    rightSum = 0;
                }
                else
                {
                    for (int k = numbers.Length - 1; k > i; k--)
                    {
                        rightSum += numbers[k];
                    }
                }


                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                    break;
                }
            }
            
            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
