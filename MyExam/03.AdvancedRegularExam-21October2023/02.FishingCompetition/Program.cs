int size = int.Parse(Console.ReadLine());

char[,] fishingArea = new char[size, size];

int captainRow = -1;
int captainCol = -1;

for (int i = 0; i < size; i++)
{
    string currentRow = Console.ReadLine();

    for (int j = 0; j < size; j++)
    {
        fishingArea[i, j] = currentRow[j];

        if (fishingArea[i, j] == 'S')
        {
            captainRow = i;
            captainCol = j;
            fishingArea[i, j] = '-';
        }
    }
}

string direction = string.Empty;
int collectedAmount = 0;
bool isDisappear = false;

while ((direction = Console.ReadLine()) != "collect the nets")
{
    if (IsValid(captainRow, captainCol, size, direction))
    {
        switch (direction)
        {
            case "up":
                captainRow --;
                break;
            case "down":
                captainRow ++;
                break;
            case "left":
                captainCol --;
                break;
            case "right":
                captainCol ++;
                break;
        }


        if (char.IsDigit(fishingArea[captainRow, captainCol]))
        {
            collectedAmount += (int)(fishingArea[captainRow, captainCol] - 48);
            fishingArea[captainRow, captainCol] = '-';
        }
        else if (fishingArea[captainRow, captainCol] == 'W')
        {
            collectedAmount = 0;
            isDisappear = true;
            break;
        }
    }
    else
    {
        switch (direction)
        {
            case "up":
                captainRow = size - 1;
                break;
            case "down":
                captainRow = 0;
                break;
            case "left":
                captainCol = size - 1;
                break;
            case "right":
                captainCol = 0;
                break;
        }

        if (char.IsDigit(fishingArea[captainRow, captainCol]))
        {
            collectedAmount += (int)(fishingArea[captainRow, captainCol] - 48);
            fishingArea[captainRow, captainCol] = '-';
        }
        else if (fishingArea[captainRow, captainCol] == 'W')
        {
            collectedAmount = 0;
            isDisappear = true;
            break;
        }
    }
}

fishingArea[captainRow, captainCol] = 'S';

if (isDisappear)
{
    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{captainRow},{captainCol}]");
}
else if (collectedAmount >= 20)
{
    Console.WriteLine($"Success! You managed to reach the quota!");
}
else if (collectedAmount < 20)
{
    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - collectedAmount} tons of fish more.");
}

if (collectedAmount > 0)
{
    Console.WriteLine($"Amount of fish caught: {collectedAmount} tons.");
}

if (!isDisappear)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            Console.Write(fishingArea[i, j]);
        }
        Console.WriteLine();
    }
}


static bool IsValid(int captainRow, int captainCol, int size, string direction)
{
    switch (direction)
    {
        case "up":
            return captainRow - 1 >= 0;
        case "down":
            return captainRow + 1 < size;
        case "left":
            return captainCol - 1 >= 0;
        case "right":
            return captainCol + 1 < size;
        default: return false;
    }
}