using _03.Raiding.IO.Interfaces;

namespace _03.Raiding.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
        => Console.WriteLine(obj);
}
