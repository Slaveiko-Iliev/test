using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class StartUp
    {
                
        public static void Main()
        {
            ListyIterator<string> listyIterator = new(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .ToList());

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}
