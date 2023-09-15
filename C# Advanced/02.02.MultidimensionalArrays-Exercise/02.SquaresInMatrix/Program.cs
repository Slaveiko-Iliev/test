using System;
using System.Linq;

int[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = input[0];
int cols = input[1];

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] currentRow = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

int numberOfEqual = 0;

for (int row = 0; row < rows - 1; row++)
{
    for (int col = 0; col < cols - 1; col++)
    {
        if (matrix[row, col] == matrix[row, col + 1]
            && matrix[row, col] == matrix[row + 1, col]
            && matrix[row, col] == matrix[row + 1, col + 1])
        {
            numberOfEqual++;
        }
    }
}

Console.WriteLine(numberOfEqual);