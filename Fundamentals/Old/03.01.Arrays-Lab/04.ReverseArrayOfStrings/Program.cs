using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] array = Console.ReadLine().Split();
            array = array.Reverse().ToArray();
            Console.WriteLine(String.Join(' ', array));
        }
    }
}
