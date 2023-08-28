int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int capacityOfRack = int.Parse(Console.ReadLine());

Stack<int> clothingsValues = new(input);

int countOfRack;

if (clothingsValues.Any())
{
    countOfRack = 1;
}
else
{
    countOfRack = 0;
}

int capacityOfCurrentRack = capacityOfRack;

//while (clothingsValues.Any())
//{
//    if (clothingsValues.Peek() < capacityOfCurrentRack)
//    {
//        capacityOfCurrentRack -= clothingsValues.Pop();
//    }
//    else if (clothingsValues.Peek() == capacityOfCurrentRack)
//    {
//        capacityOfCurrentRack -= clothingsValues.Pop();
//        if (clothingsValues.Any())
//        {
//            countOfRack++;
//        }
//        capacityOfCurrentRack = capacityOfRack;
//    }
//    else
//    {
//        countOfRack++;
//        capacityOfCurrentRack = capacityOfRack;
//    }
//}

while (clothingsValues.Any())
{
    capacityOfCurrentRack -= clothingsValues.Peek();

    if (capacityOfCurrentRack < 0)
    {
        capacityOfCurrentRack = capacityOfRack;
        countOfRack++;
        continue;
    }

    clothingsValues.Pop();
}

    Console.WriteLine(countOfRack);