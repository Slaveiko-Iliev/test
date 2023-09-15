using System;
using System.Collections.Generic;
using System.Linq;

int[] sizeOfMatrix = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[sizeOfMatrix[0], sizeOfMatrix[1]];

int[] currPosOfP = new int[2];

for (int row = 0; row < sizeOfMatrix[0]; row++)
{
    string currentRow = Console.ReadLine();

    for (int col = 0; col < sizeOfMatrix[1]; col++)
    {
        matrix[row, col] = currentRow[col];

        if (matrix[row, col] == 'P')
        {
            currPosOfP[0] = row;
            currPosOfP[1] = col;
        }
    }
}

string command = Console.ReadLine();
bool isPlayerWin = true;
bool isPlayerOut = false;
Queue < int[]> bunnies = new Queue<int[]> ();

for (int ch = 0; ch < command.Length && isPlayerWin && !isPlayerOut; ch++)
{
    switch (command[ch])
    {
        case 'R':
            if (IsValidIndexOfP(matrix, currPosOfP, ch, command))
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                currPosOfP[1]++;

                if (matrix[currPosOfP[0], currPosOfP[1]] == 'B')
                {
                    isPlayerWin = false;
                    break;
                }

                matrix[currPosOfP[0], currPosOfP[1]] = 'P';
            }
            else
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                isPlayerOut = true;
            }
            break;
        case 'L':
            if (IsValidIndexOfP(matrix, currPosOfP, ch, command))
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                currPosOfP[1]--;

                if (matrix[currPosOfP[0], currPosOfP[1]] == 'B')
                {
                    isPlayerWin = false;
                    break;
                }

                matrix[currPosOfP[0], currPosOfP[1]] = 'P';
            }
            else
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                isPlayerOut = true;
            }

            break;
        case 'U':
            if (IsValidIndexOfP(matrix, currPosOfP, ch, command))
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                currPosOfP[0]--;

                if (matrix[currPosOfP[0], currPosOfP[1]] == 'B')
                {
                    isPlayerWin = false;
                    break;
                }

                matrix[currPosOfP[0], currPosOfP[1]] = 'P';
            }
            else
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                isPlayerOut = true;
            }
            break;
        case 'D':
            if (IsValidIndexOfP(matrix, currPosOfP, ch, command))
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                currPosOfP[0]++;

                if (matrix[currPosOfP[0], currPosOfP[1]] == 'B')
                {
                    isPlayerWin = false;
                    break;
                }
                
                matrix[currPosOfP[0], currPosOfP[1]] = 'P';
            }
            else
            {
                matrix[currPosOfP[0], currPosOfP[1]] = '.';
                isPlayerOut = true;
            }
            break;
    }

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'B')
            {
                bunnies.Enqueue(new int[] { row, col });
            }
        }
    }

    while (bunnies.Count > 0)
    {
        int[] currentBunny = bunnies.Dequeue();
        int row = currentBunny[0];
        int col = currentBunny[1];
        
        if (DidBunniesWin(matrix, row, col))
        {
            isPlayerWin = false;
        }
    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}

if (isPlayerWin)
{
    Console.WriteLine($"won: {currPosOfP[0]} {currPosOfP[1]}");
}
else
{
    Console.WriteLine($"dead: {currPosOfP[0]} {currPosOfP[1]}");
}

bool IsValidIndexOfP(char[,] matrix, int[] currentPositionOfP, int positionInCommand, string command)
{
    if (command[positionInCommand] == 'R' && currentPositionOfP[1] + 1 < matrix.GetLength(1))
    {
        return true;
    }
    else if (command[positionInCommand] == 'L' && currentPositionOfP[1] - 1 >= 0)
    {
        return true;
    }
    else if (command[positionInCommand] == 'U' && currentPositionOfP[0] - 1 >= 0)
    {
        return true;
    }
    else if (command[positionInCommand] == 'D' && currentPositionOfP[0] + 1 < matrix.GetLength(0))
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool DidBunniesWin(char[,] matrix, int row, int col)
{
    bool isBunnyTreadOn = false;


    if (col + 1 < matrix.GetLength(1))
    {
        if (matrix[row, col + 1] == '.' || (matrix[row, col + 1] == 'B'))
        {
            matrix[row, col + 1] = 'B';
        }
        else
        {
            matrix[row, col + 1] = 'B';
            isBunnyTreadOn = true;
        }
    }
    if (col - 1 >= 0)
    {
        if (matrix[row, col - 1] == '.' || (matrix[row, col - 1] == 'B'))
        {
            matrix[row, col - 1] = 'B';
        }
        else
        {
            matrix[row, col - 1] = 'B';
            isBunnyTreadOn = true;
        }
    }
    if (row + 1 < matrix.GetLength(0))
    {
        if (matrix[row + 1, col] == '.' || (matrix[row + 1, col] == 'B'))
        {
            matrix[row + 1, col] = 'B';
        }
        else
        {
            matrix[row + 1, col] = 'B';
            isBunnyTreadOn = true;
        }
    }
    if (row - 1 >= 0)
    {
        if (matrix[row - 1, col] == '.' || (matrix[row - 1, col] == 'B'))
        {
            matrix[row - 1, col] = 'B';
        }
        else
        {
            matrix[row - 1, col] = 'B';
            isBunnyTreadOn = true;
        }
    }
    if (isBunnyTreadOn)
    {
        return true;
    }
    else
    {
        return false;
    }
}