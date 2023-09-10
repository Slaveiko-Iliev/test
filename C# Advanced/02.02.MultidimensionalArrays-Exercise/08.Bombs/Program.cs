using System;
using System.Collections.Generic;
using System.Linq;

int dimensoions = int.Parse(Console.ReadLine());

int[][] matrix = new int[dimensoions][];

for (int row = 0; row < dimensoions; row++)
{
    int[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    matrix[row] = currentRow;
}

Queue<string> queue = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries));

Queue<int[]> coordinates = new Queue<int[]>();

while (queue.Count > 0)
{
    coordinates.Enqueue(queue.Dequeue()
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray());
}

while (coordinates.Count > 0)
{
    int[] currentCoordinates = coordinates.Dequeue();
    int rowOfBomb = currentCoordinates[0];
    int colOfBomb = currentCoordinates[1];
    int bombPower = matrix[rowOfBomb][colOfBomb];

    if (matrix[rowOfBomb][colOfBomb] > 0)
    {
        matrix[rowOfBomb][colOfBomb] -= bombPower;

        if (colOfBomb + 1 < dimensoions && matrix[rowOfBomb][colOfBomb + 1] > 0)
        {
            matrix[rowOfBomb][colOfBomb + 1] -= bombPower;
        }
        if (rowOfBomb + 1 < dimensoions && colOfBomb + 1 < dimensoions && matrix[rowOfBomb + 1][colOfBomb + 1] > 0)
        {
            matrix[rowOfBomb + 1][colOfBomb + 1] -= bombPower;
        }
        if (rowOfBomb + 1 < dimensoions && matrix[rowOfBomb + 1][colOfBomb] > 0)
        {
            matrix[rowOfBomb + 1][colOfBomb] -= bombPower;
        }
        if (rowOfBomb + 1 < dimensoions && colOfBomb - 1 >= 0 && matrix[rowOfBomb + 1][colOfBomb - 1] > 0)
        {
            matrix[rowOfBomb +  1][colOfBomb - 1] -= bombPower;
        }
        if (colOfBomb - 1 >= 0 && matrix[rowOfBomb][colOfBomb - 1] > 0)
        {
            matrix[rowOfBomb][colOfBomb - 1] -= bombPower;
        }
        if (rowOfBomb - 1 >= 0 && colOfBomb - 1 >= 0 && matrix[rowOfBomb - 1][colOfBomb - 1] > 0)
        {
            matrix[rowOfBomb - 1][colOfBomb - 1] -= bombPower;
        }
        if (rowOfBomb - 1 >= 0 && matrix[rowOfBomb - 1][colOfBomb] > 0)
        {
            matrix[rowOfBomb - 1][colOfBomb] -= bombPower;
        }
        if (rowOfBomb - 1 >= 0 && colOfBomb + 1 < dimensoions && matrix[rowOfBomb - 1][colOfBomb + 1] > 0)
        {
            matrix[rowOfBomb - 1][colOfBomb + 1] -= bombPower;
        }
    }
}

int aliveCells = 0;
int sumOfAliveCell = 0;

foreach (var row in matrix)
{
    foreach (var cell in row)
    {
        if (cell > 0)
        {
            aliveCells++;
            sumOfAliveCell += cell;
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfAliveCell}");

foreach (var row in matrix)
{
    Console.WriteLine(string.Join(" ", row));
}