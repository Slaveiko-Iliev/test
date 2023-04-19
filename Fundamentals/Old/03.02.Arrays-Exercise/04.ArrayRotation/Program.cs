using System;
using System.Linq;

namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string firstElement = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstElement;
            }
            Console.Write(string.Join(' ', array));
        }
    }
}
