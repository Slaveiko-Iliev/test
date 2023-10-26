using System;

int size = int.Parse(Console.ReadLine());

if (size < 3)
{
    Console.WriteLine(0);

    return;
}

char[,] matrix = new char[size, size];

for (int row = 0; row < size; row++)
{
    string chars = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = chars[col];
    }
}

int knightsRemoved = 0;

while (true)
{
    int countMostAttacking = 0;
    int rowMostAttacking = 0;
    int colMostAttacking = 0;

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            if (matrix[row, col] == 'K')
            {
                int attackedKnights = AttackedKnights(row, col, size, matrix);

                if (countMostAttacking < attackedKnights)
                {
                    countMostAttacking = attackedKnights;
                    rowMostAttacking = row;
                    colMostAttacking = col;
                }
            }
        }
    }

    if (countMostAttacking == 0)
    {
        break;
    }
    else
    {
        matrix[rowMostAttacking, colMostAttacking] = '0';
        knightsRemoved++;
    }
}

Console.WriteLine(knightsRemoved);

static int AttackedKnights(int row, int col, int size, char[,] matrix)
{
    int attackedKnights = 0;

    if (IsValid(row - 1, col - 2, size))
    {
        if (matrix[row - 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row + 1, col - 2, size))
    {
        if (matrix[row + 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row - 1, col + 2, size))
    {
        if (matrix[row - 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row + 1, col + 2, size))
    {
        if (matrix[row + 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row - 2, col - 1, size))
    {
        if (matrix[row - 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row - 2, col + 1, size))
    {
        if (matrix[row - 2, col + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row + 2, col - 1, size))
    {
        if (matrix[row + 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    if (IsValid(row + 2, col + 1, size))
    {
        if (matrix[row + 2, col + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    return attackedKnights;
}

static bool IsValid(int row, int col, int size)
{
    return
        row >= 0
        && row < size
        && col >= 0
        && col < size;
}