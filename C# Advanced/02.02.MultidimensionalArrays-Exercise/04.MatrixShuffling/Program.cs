using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string[,] matrix = new string[dimensions[0], dimensions[1]];

for (int row = 0; row < dimensions[0]; row++)
{
    string[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < dimensions[1]; col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

string input = string.Empty;
bool isValid;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    isValid = true;

    string[] commandInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    if (commandInfo[0] != "swap" || commandInfo.Length != 5)
    {
        isValid = false;
    }

    int[] coordinates = new int[4];

    for (int i = 1; i < commandInfo.Length && isValid; i++)
    {
        int number;

        bool success = int.TryParse(commandInfo[i], out number);
        if (!success)
        {
            isValid = false;
            break;
        }
        else
        {
            coordinates[i - 1] = number;
        }
    }

    if (isValid)
    {
        for (int i = 0; i < coordinates.Length; i += 2)
        {
            if (i % 2 == 0 && (coordinates[i] < 0 || coordinates[i] >= matrix.GetLength(0)))
            {
                isValid = false;
                break;
            }
            else if (i % 2 != 0 && (coordinates[i] < 0 || coordinates[i] >= matrix.GetLength(1)))
            {
                isValid = false;
                break;
            }
        }
    }

    if (isValid)
    {
        string tempValue = matrix[coordinates[0], coordinates[1]];
        matrix[coordinates[0], coordinates[1]] = matrix[coordinates[2], coordinates[3]];
        matrix[coordinates[2], coordinates[3]] = tempValue;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

