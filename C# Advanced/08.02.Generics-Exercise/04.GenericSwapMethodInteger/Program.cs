namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            List<int> numbers = new();

            for (int i = 0; i < num; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapElements(numbers, firstIndex, secondIndex);

            foreach (int number in numbers)
            {
                Console.WriteLine($"{number.GetType()}: {number}");
            }

            static void SwapElements<T>(List<T> elements, int firstIndex, int secondIndex)
            {
                T temp = elements[firstIndex];
                elements[firstIndex] = elements[secondIndex];
                elements[secondIndex] = temp;
            }
        }
    }
}
