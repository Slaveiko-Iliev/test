

namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings strings = new StackOfStrings();

            Console.WriteLine(strings.IsEmpty());

            strings.AddRange(new List<string>() { "1", "2", "3"});

            Console.WriteLine(strings.IsEmpty());
        }
    }
}
