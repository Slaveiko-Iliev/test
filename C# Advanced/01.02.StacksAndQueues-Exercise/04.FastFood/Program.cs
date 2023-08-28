int quantityOfFood = int.Parse(Console.ReadLine());

//int[] input  = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToArray();

Queue<int> quantityOfOrder = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Console.WriteLine(quantityOfOrder.Max());

while (quantityOfOrder.Any() && quantityOfOrder.Peek() <= quantityOfFood)
{
    quantityOfFood -= quantityOfOrder.Peek();
    quantityOfOrder.Dequeue();
}

if (quantityOfOrder.Any())
{
    Console.WriteLine($"Orders left: {string.Join(" ", quantityOfOrder)}");
}
else
{
    Console.WriteLine("Orders complete");
}
