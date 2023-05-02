using System;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRow = int.Parse(Console.ReadLine());

            int[] row = new int[1];
            row[0] = 1;
            Console.WriteLine(row[0]);

            for (int r = 0; r < numberOfRow - 1; r++)
            {
                int sameIndexOfRowArray = 0;
                int previousIndexOfRowArray = 0;
                int[] nextRow = new int[row.Length + 1];

                for (int i = 0; i < nextRow.Length; i++)
                {
                    if (i == 0)
                    {
                        sameIndexOfRowArray = row[i];
                    }
                    else if (i == row.Length)
                    {
                        sameIndexOfRowArray = 0;
                        previousIndexOfRowArray = row[i - 1];
                    }
                    else
                    {
                        sameIndexOfRowArray = row[i];
                        previousIndexOfRowArray = row[i - 1];
                    }
                    nextRow[i] = sameIndexOfRowArray + previousIndexOfRowArray;
                }
                Console.WriteLine(string.Join(" ", nextRow));
                row = nextRow;
            }
        }
    }
}
