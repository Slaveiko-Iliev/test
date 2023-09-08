using System;
using System.Linq;

int num = int.Parse(Console.ReadLine());

int[][] ints = new int[num][];

for (int i = 0; i < num; i++)
{
    int[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    ints[i] = currentRow;
}

int sumOfDiagonal = 0;

for (int i = 0;i < num; i++)
{
    sumOfDiagonal += ints[i][i];
}

Console.WriteLine(sumOfDiagonal);