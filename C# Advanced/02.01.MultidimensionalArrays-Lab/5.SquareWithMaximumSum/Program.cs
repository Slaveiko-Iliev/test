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
        .Split(", ")
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = currentRow[col];
    }
}


int biggest = int.MinValue;
int rowOfBest = int.MinValue;
int colOfBest = int.MinValue;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        int currentSum = 0;

        currentSum += matrix[row, col];
        currentSum += matrix[row, col + 1];
        currentSum += matrix[row + 1, col];
        currentSum += matrix[row + 1, col + 1];

        if (currentSum > biggest)
        {
            biggest = currentSum;
            rowOfBest = row;
            colOfBest = col;
        }
    }
}

Console.WriteLine($"{matrix[rowOfBest, colOfBest]} {matrix[rowOfBest, colOfBest + 1]}");
Console.WriteLine($"{matrix[rowOfBest + 1, colOfBest]} {matrix[rowOfBest + 1, colOfBest + 1]}");
Console.WriteLine(biggest);



