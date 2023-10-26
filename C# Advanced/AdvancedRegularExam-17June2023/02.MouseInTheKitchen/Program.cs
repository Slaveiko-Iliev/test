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
            cupboard[i, j] = '*';
        }
    }
}

bool isMouseOff = false;
string direction = string.Empty;

while ((direction = Console.ReadLine()) != "danger")
{
    if (!IsValid(mouseRow, mouseCol, rows, cols, direction))
    {
        Console.WriteLine("No more cheese for tonight!");
        cupboard[mouseRow, mouseCol] = 'M';
        isMouseOff = true;
        break;
    }
    else
    {
        switch (direction)
        {
            case "up":
                mouseRow--;
                break;
            case "down":
                mouseRow++;
                break;
            case "left":
                mouseCol--;
                break;
            case "right":
                mouseCol++;
                break;
        }

        if (cupboard[mouseRow, mouseCol] == 'C')
        {
            cupboard[mouseRow, mouseCol] = '*';
            cheeseCount--;
            if (cheeseCount == 0)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                cupboard[mouseRow, mouseCol] = 'M';
                break;
            }
        }
        else if (cupboard[mouseRow, mouseCol] == 'T')
        {
            cupboard[mouseRow, mouseCol] = 'M';
            Console.WriteLine("Mouse is trapped!");
            isMouseOff = true;
            break;
        }
        else if (cupboard[mouseRow, mouseCol] == '@')
        {
            switch (direction)
            {
                case "up":
                    mouseRow++;
                    break;
                case "down":
                    mouseRow--;
                    break;
                case "left":
                    mouseCol++;
                    break;
                case "right":
                    mouseCol--;
                    break;
            }
            continue;
        }
    }
}

if (!isMouseOff && cheeseCount > 0)
{
    cupboard[mouseRow, mouseCol] = 'M';
    Console.WriteLine("Mouse will come back later!");
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(cupboard[i, j]);
    }
    Console.WriteLine();
}


static bool IsValid(int mouseRow, int mouseCol, int rows, int cols, string direction)
{
    switch (direction)
    {
        case "up":
            return mouseRow - 1 >= 0;
        case "down":
            return mouseRow + 1 < rows;
        case "left":
            return mouseCol - 1 >= 0;
        case "right":
            return mouseCol + 1 < cols;
        default: return false;
    }
}