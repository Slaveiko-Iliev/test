using System;
using System.Linq;

int jaggedRows = int.Parse(Console.ReadLine());

int[][] jagged = new int[jaggedRows][];

for (int i = 0; i < jaggedRows; i++)
{
    int[] currentRow = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

    jagged[i] = currentRow;
}

string input = string.Empty;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] commandInfo = input.Split(' ');

    int row = int.Parse(commandInfo[1]);
    int col = int.Parse(commandInfo[2]);
    int value = int.Parse(commandInfo[3]);

    bool isValidCoordinates = true;

    if (row >= 0 && row < jagged.Length)
    {
        if (col >= 0 && col < jagged[row].Length)
        {
            if (commandInfo[0] == "add")
            {
                jagged[row][col] += value;
            }
            else
            {
                jagged[row][col] -= value;
            }
        }
        else
        {
            isValidCoordinates = false;
        }
    }
    else
    {
        isValidCoordinates = false;
    }

    if (!isValidCoordinates)
    {
        Console.WriteLine("Invalid coordinates");
    }
}

for (int row = 0; row < jagged.Length; row++)
{
    Console.WriteLine(string.Join(" ", jagged[row]));
}