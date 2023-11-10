using _04.WildFarm.IO.Interfaces;

namespace _04.WildFarm.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
        => Console.ReadLine();
}
