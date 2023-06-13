using System;

namespace _03.Generating01Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            Generate01(arr, 0);
        }

        private static void Generate01(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;

                Generate01(arr, index + 1);
            }
        }
    }
}
