using System;
using System.Linq;

namespace _01.StringsMashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            str = String.Concat(str.OrderBy(c => c));

            var arr = new char[n];

            GenerateArray(arr, 0, str);
        }

        private static void GenerateArray(char[] arr, int index, string str)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (char i = str[0]; i < arr.Length; i++)
            {
                arr[index] = i;

                GenerateArray(arr, index + 1, str);
            }
        }
    }
}
