int[] matrixInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int row = matrixInfo[0];
int column = matrixInfo[1];

string[,] matrix = new string[row, column];

for (int i = 0; i < row; i++)
{
    string[] currentRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < column; j++)
    {
        matrix[i, j] = currentRow[j];
    }
}

int[] myPosition = new int[2];

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < column; j++)
    {
        if (matrix[i,j] == "B")
        {
            myPosition[0] = i;
            myPosition[1] = j;
        }
    }
}

string direction = string.Empty;
int touchedOpponents = 0;
int movesMade = 0;

while ((direction = Console.ReadLine()) != "Finish")
{
    if (CanIMove(matrix, myPosition, direction))
    {
        myPosition = MyNewPosition(matrix, myPosition, direction);
        if (matrix[myPosition[0], myPosition[1]] == "P")
        {
            touchedOpponents++;            
        }
        movesMade++;
        matrix[myPosition[0], myPosition[1]] = "-";
        if (touchedOpponents == 3)
        {
            break;
        }
    }
    else
    {
        continue;
    }
}


static bool CanIMove(string[,] matrix, int[] myPosition, string direction)
{
    bool isPossible = true;

    switch (direction)
    {
        case "up":
            if (myPosition[0] - 1 < 0)
            {
                isPossible = false;
            }
            else
            {
                if (matrix[myPosition[0] - 1, myPosition[1]] == "O")
                {
                    isPossible = false;
                }
            }
            break;
        case "down":
            if (myPosition[0] + 1 == matrix.GetLength(0))
            {
                isPossible = false;
            }
            else
            {
                if (matrix[myPosition[0] + 1, myPosition[1]] == "O")
                {
                    isPossible = false;
                }
            }
            break;
        case "right":
            if (myPosition[1] + 1 == matrix.GetLength(1))
            {
                isPossible = false;
            }
            else
            {
                if (matrix[myPosition[0], myPosition[1] + 1] == "O")
                {
                    isPossible = false;
                }
            }
            break;
        case "left":
            if (myPosition[1] - 1 < 0)
            {
                isPossible = false;
            }
            else
            {
                if (matrix[myPosition[0], myPosition[1] - 1] == "O")
                {
                    isPossible = false;
                }
            }
            break;
    }

    return isPossible;
}

static int[] MyNewPosition(string[,] matrix, int[] myPosition, string direction)
{
    int[] temp = myPosition;

    switch (direction)
    {
        case "up":
            temp[0]--;
            break;
        case "down":
            temp[0]++;
            break;
        case "right":
            temp[1]++;
            break;
        case "left":
            temp[1]--;
            break;
    }
    return temp;
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");