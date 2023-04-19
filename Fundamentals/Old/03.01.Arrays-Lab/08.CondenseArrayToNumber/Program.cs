using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            
            if (nums.Length > 1 )
            {
                while ( nums.Length > 1 )
                {
                    int[] condensed = new int[nums.Length - 1];

                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        condensed[i] = nums[i] + nums[i + 1];
                    }
                    nums = condensed;
                }

                Console.WriteLine(nums[0]);
            }
            else if (nums.Length == 1)
            {
                Console.WriteLine($"{nums[0]} is already condensed to number");
            }

        }
    }
}
