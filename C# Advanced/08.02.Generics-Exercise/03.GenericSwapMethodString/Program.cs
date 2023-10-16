namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> strings = new();

            for (int i = 0; i < number; i++)
            {
                strings.Add(Console.ReadLine());
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapElements(strings, firstIndex, secondIndex);

            foreach (string str in strings)
            {
                Console.WriteLine($"{str.GetType()}: {str}");
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
