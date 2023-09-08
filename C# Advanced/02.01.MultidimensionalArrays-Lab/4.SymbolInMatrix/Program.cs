using System;

int num = int.Parse(Console.ReadLine());

char[,] matrix = new char[num, num];

for (int row = 0; row < num; row++)
{
    string currentRow = Console.ReadLine();

    for (int col = 0; col < num; col++)
    {
        matrix[row, col] = currentRow[col];
    }
}

char elementToFind = Console.ReadLine()[0];

bool isOccur = false;

for (int row = 0; row < num; row++)
{
    for (int col = 0; col < num; col++)
    {
        if (matrix[row, col] == elementToFind)
        {
            isOccur = true;
            Console.WriteLine($"({row}, {col})");
            break;
        }

        if (isOccur)
        {
            break;
        }
    }
}

if (!isOccur)
{
    Console.WriteLine($"{elementToFind} does not occur in the matrix");
}