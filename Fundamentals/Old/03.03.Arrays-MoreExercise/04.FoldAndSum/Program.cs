using System;
using System.Linq;

namespace _04.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int[] unfoldArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = unfoldArray.Length / 4;

            int[] foldArray = new int[unfoldArray.Length / 2];

            for (int i = 0; i < 2; i +=2*k)
            {

            }
        }
    }
}
