using System;
using System.Linq;

int sizeOfSquare = int.Parse(Console.ReadLine());

int[][] square = new int[sizeOfSquare][];

for (int i = 0; i < sizeOfSquare; i++)
{
    int[] currentRow = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

    square[i] = currentRow;
}

int sumOfPrimaryDiagonal = 0;
int sumOfSecondaryDiagonal = 0;

for (int i = 0;i < square.Length; i++)
{
    sumOfPrimaryDiagonal += square[i][i];
    sumOfSecondaryDiagonal += square[i][square.Length - 1 - i];
}

int differenceBetweenSums = Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal);

Console.WriteLine(differenceBetweenSums);