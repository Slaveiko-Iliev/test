namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Box<string> box = new(Console.ReadLine());

                Console.WriteLine(box.ToString());
            }
        }
    }
}
