int size = int.Parse(Console.ReadLine());

string[] directions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

char[,] field = new char[size, size];

int squirrelRow = -1;
int squirrelCol = -1;
int hazelnutsCount = 0;
bool isOut = false;

for (int i = 0; i < size; i++)
{
    string currentRow = Console.ReadLine();

    for (int j = 0; j < size; j++)
    {
        field[i, j] = currentRow[j];

        if (field[i, j] == 's')
        {
            squirrelRow = i;
            squirrelCol = j;
            field[i, j] = '*';
        }
    }
}
foreach (string direction in directions)
{
    if (IsValid(squirrelRow, squirrelCol, size, direction))
    {
        switch (direction)
        {
            case "up":
                squirrelRow--;
                break;
            case "down":
                squirrelRow++;
                break;
            case "left":
                squirrelCol--;
                break;
            case "right":
                squirrelCol++;
                break;
        }

        if (field[squirrelRow, squirrelCol] == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            isOut = true;
            break;
        }
        else if (field[squirrelRow, squirrelCol] == 'h')
        {
            field[squirrelRow, squirrelCol] = '*';
            hazelnutsCount++;
            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("The squirrel is out of the field.");
        isOut = true;
        break;
    }
}

if (hazelnutsCount < 3 && !isOut)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}
Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");


static bool IsValid(int squirrelRow, int squirrelCol, int size, string direction)
{
    switch (direction)
    {
        case "up":
            return squirrelRow - 1 >= 0;
        case "down":
            return squirrelRow + 1 < size;
        case "left":
            return squirrelCol - 1 >= 0;
        case "right":
            return squirrelCol + 1 < size;
        default: return false;
    }
}