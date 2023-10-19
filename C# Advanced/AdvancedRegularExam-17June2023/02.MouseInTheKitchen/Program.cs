int[] matrixInfo = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixInfo[0];
int cols = matrixInfo[1];

char[,] cupboard = new char[rows, cols];
int cheeseCount = 0;
int mouseRow = -1;
int mouseCol = -1;

for (int i = 0; i < rows; i++)
{
    string currentRow = Console.ReadLine();

    for (int j = 0; j < cols; j++)
    {
        cupboard[i, j] = currentRow[j];
        if (cupboard[i, j] == 'C')
        {
            cheeseCount++;
        }
        else if (cupboard[i, j] == 'M')
        {
            mouseRow = i;
            mouseCol = j;
        }
    }
}

string input = string.Empty;

