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

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));

int sumMatrix = 0;

//for (int row = 0; row < matrix.GetLength(0); row++)
//{
//    for (int col = 0; col < matrix.GetLength(1); col++)
//    {
//        sumMatrix += matrix[row, col];
//    }
//}

foreach (int number in matrix)
{
    sumMatrix += number;
}

Console.WriteLine(sumMatrix);