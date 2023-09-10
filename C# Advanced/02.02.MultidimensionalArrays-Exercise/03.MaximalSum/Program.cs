using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[dimensions[0], dimensions[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

int biggestSum = int.MinValue;
int[] firstCellOfBiggest = new int[2];

for (int row = 0; row < matrix.GetLength(0) - 2; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
    {
        int currentSum = 0;

        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                currentSum += matrix[i, j];
            }
        }

        if (currentSum > biggestSum)
        {
            biggestSum = currentSum;
            firstCellOfBiggest[0] = row;
            firstCellOfBiggest[1] = col;
        }
    }
}

Console.WriteLine($"Sum = {biggestSum}");

for (int row = firstCellOfBiggest[0]; row < firstCellOfBiggest[0] + 3; row++)
{
    for (int col = firstCellOfBiggest[1]; col < firstCellOfBiggest[1] + 3; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }
    Console.WriteLine();
}