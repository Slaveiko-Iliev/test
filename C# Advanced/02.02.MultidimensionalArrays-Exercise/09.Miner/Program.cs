using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

int fieldSize = int.Parse(Console.ReadLine());
Queue<string> commands = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries));

char[,] matrix = new char[fieldSize, fieldSize];

for (int row = 0;  row < fieldSize; row++)
{
    char[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();
    
    for (int col = 0; col < fieldSize; col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

int[] currentPosition =  new int[2];
int countOfCoals = 0;

for (int row = 0; row < fieldSize; row++)
{
    for (int col = 0; col < fieldSize; col++)
    {
        if (matrix[row, col] == 'c')
        {
            countOfCoals++;
        }

        if (matrix[row, col] == 's')
        {
            currentPosition[0] = row;
            currentPosition[1] = col;
        }
    }
}

bool isEnded = false;

while(commands.Count > 0 && !isEnded)
{
    string currentCommand = commands.Dequeue();

    if (currentCommand == "left" && currentPosition[1] - 1 >= 0)
    {
        currentPosition[1]--;
    }
    else if (currentCommand == "right" && currentPosition[1] + 1 < fieldSize)
    {
        currentPosition[1]++;
    }
    else if (currentCommand == "up" && currentPosition[0] - 1 >= 0)
    {
        currentPosition[0]--;
    }
    else if (currentCommand == "down" && currentPosition[0] + 1 < fieldSize)
    {
        currentPosition[0]++;
    }

    if (matrix[currentPosition[0], currentPosition[1]] == 'e')
    {
        Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");
        isEnded = true;
        break;
    }
    else if (matrix[currentPosition[0], currentPosition[1]] == 'c')
    {
        //if (countOfCoals == 0)
        //{
        //    continue;
        //}

        countOfCoals--;
        matrix[currentPosition[0], currentPosition[1]] = '*';

        if (countOfCoals == 0)
        {
            Console.WriteLine($"You collected all coals! ({currentPosition[0]}, {currentPosition[1]})");
            isEnded = true;
            break;
        }
    }
}

if (!isEnded)
{
    Console.WriteLine($"{countOfCoals} coals left. ({currentPosition[0]}, {currentPosition[1]})");
}