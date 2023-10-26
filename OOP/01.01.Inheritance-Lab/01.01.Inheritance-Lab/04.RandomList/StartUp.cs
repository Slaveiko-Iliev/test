

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList list = new ();

            list.Add("array");
            list.Add("list");
            list.Add("set");

            Console.WriteLine(list.RandomString());
        }
    }
}
