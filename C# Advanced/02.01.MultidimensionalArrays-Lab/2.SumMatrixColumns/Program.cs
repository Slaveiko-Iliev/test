using System;
using System.Linq;

int[] matrixInfo = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = matrixInfo[0];
int cols = matrixInfo[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(" ")
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int sumOfColumn = 0;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        sumOfColumn += matrix[row, col];
    }

    Console.WriteLine(sumOfColumn);
}