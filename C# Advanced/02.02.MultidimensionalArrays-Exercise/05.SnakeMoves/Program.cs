using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] stairs = new char[dimensions[0], dimensions[1]];

string snake = Console.ReadLine();

int positionInSnake = 0;

for (int row = 0; row < stairs.GetLength(0); row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < stairs.GetLength(1); col++)
        {
            stairs[row, col] = snake[positionInSnake];

            if (positionInSnake == snake.Length - 1)
            {
                positionInSnake = 0;
            }
            else
            {
                positionInSnake++;
            }
        }
    }
    else
    {
        for (int col = stairs.GetLength(1) - 1; col >= 0; col--)
        {
            stairs[row, col] = snake[positionInSnake];

            if (positionInSnake == snake.Length - 1)
            {
                positionInSnake = 0;
            }
            else
            {
                positionInSnake++;
            }
        }
    }
}

for (int row = 0; row < stairs.GetLength(0); row++)
{
    for (int col = 0; col < stairs.GetLength(1); col++)
    {
        Console.Write(stairs[row, col]);
    }

    Console.WriteLine();
}

