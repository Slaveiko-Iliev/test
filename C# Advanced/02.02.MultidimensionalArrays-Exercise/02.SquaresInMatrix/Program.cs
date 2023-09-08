using System;
using System.Linq;

int[] input = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

int rows = input[0];
int cols = input[1];

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] currentRow = Console.ReadLine()
        .Split(' ')
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
    for (int col = 0;col < cols - 1; col++)
    {
        for (int rowOfSecond = row; rowOfSecond < rows - 1; rowOfSecond++)
        {
            for (int colOfSecond = col; colOfSecond < cols - 1; colOfSecond++)
            {
                if (row != rowOfSecond && col != colOfSecond)
                {
                    if (matrix[row, col] == matrix[rowOfSecond, colOfSecond] && matrix[row, col + 1] == matrix[rowOfSecond, colOfSecond + 1])
                    {
                        if (matrix[row + 1, col] == matrix[rowOfSecond + 1, colOfSecond] && matrix[row + 1, col + 1] == matrix[rowOfSecond + 1, colOfSecond + 1])
                        {
                            numberOfEqual++;
                        }
                    }
                }
            }
        }
    }
}

Console.WriteLine(numberOfEqual*2);