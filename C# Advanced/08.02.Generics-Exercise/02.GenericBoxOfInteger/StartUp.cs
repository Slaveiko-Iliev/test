namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Box<int> box = new(int.Parse(Console.ReadLine()));

                Console.WriteLine(box.ToString());
            }
        }
    }
}
