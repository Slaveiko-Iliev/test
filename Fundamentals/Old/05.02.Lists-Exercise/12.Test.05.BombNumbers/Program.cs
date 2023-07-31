List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

int[] command = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int specialNumber = command[0];
int powerOfNumber = command[1];

while (numbers.Contains(specialNumber))
{
    int indexOfSpecialNumber = numbers.IndexOf(specialNumber);

    

    
    if (indexOfSpecialNumber + powerOfNumber <= numbers.Count - 1 )
    {
        numbers.RemoveRange(indexOfSpecialNumber + 1, powerOfNumber);
    }
    else
    {
        numbers.RemoveRange(indexOfSpecialNumber + 1, numbers.Count - 1 - indexOfSpecialNumber);
    }

    numbers.RemoveAt(indexOfSpecialNumber);

    if (indexOfSpecialNumber >= powerOfNumber)
    {
        numbers.RemoveRange(indexOfSpecialNumber - powerOfNumber, powerOfNumber);
    }
    else
    {
        numbers.RemoveRange(0, indexOfSpecialNumber);
    }

    
}

int sumOfNumbers =  0;

foreach (int number in numbers)
{
    sumOfNumbers += number;
}

Console.WriteLine(sumOfNumbers);