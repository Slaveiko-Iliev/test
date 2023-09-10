using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());

double[][] jagged = new double[rows][];

for (int row = 0; row < rows; row++)
{
    double[] jaggedRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse)
        .ToArray();

    jagged[row] = jaggedRow;
}

for (int row = 0; row < jagged.Length - 1; row++)
{
    if (jagged[row].Length == jagged[row + 1].Length)
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] *= 2;
            jagged[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] /= 2;
        }

        for (int col = 0; col < jagged[row + 1].Length; col++)
        {
            jagged[row + 1][col] /= 2;
        }
    }
}

string input = string.Empty;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] inputAsArray = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int rowPosition = int.Parse(inputAsArray[1]);
    int colPosition = int.Parse(inputAsArray[2]);
    int value = int.Parse(inputAsArray[3]);
    bool isValidIndex = false;

    if (rowPosition >= 0 && rowPosition < jagged.Length)
    {
        if (colPosition >= 0 && colPosition < jagged[rowPosition].Length)
        {
            isValidIndex = true;
        }
    }

    if (isValidIndex)
    {
        if (inputAsArray[0] == "add")
        {
            jagged[rowPosition][colPosition] += value;
        }
        else if (inputAsArray[0] == "subtract")
        {
            jagged[rowPosition][colPosition] -= value;
        }
    }
}


for (int row = 0;  row < jagged.Length; row++)
{
    Console.WriteLine(string.Join(" ", jagged[row]));
}