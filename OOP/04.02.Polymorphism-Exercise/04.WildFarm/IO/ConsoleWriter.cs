using _04.WildFarm.IO.Interfaces;

namespace _04.WildFarm.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
        => Console.WriteLine(obj);
}
