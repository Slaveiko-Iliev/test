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

            int[] upArray = new int[unfoldArray.Length / 2];
            for (int i = 0; i < k; i++)
            {
                upArray[i] = unfoldArray[k - 1 - i];
            }
            for (int i = 0; i < k; i++)
            {
                upArray[i+k] = unfoldArray[4*k - 1 - i];
            }

            int[] downArray = new int[unfoldArray.Length / 2];
            for (int i = 0; i < 2*k; i++)
            {
                downArray[i] = unfoldArray[k + i];
            }

            int[] foldArray = new int[unfoldArray.Length / 2];
            for (int i = 0; i < 2 * k; i++)
            {
                foldArray[i] = upArray[i] + downArray[i];
            }

            Console.WriteLine(string.Join(' ', foldArray));
        }
    }
}
