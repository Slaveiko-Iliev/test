using System;

namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            char keyChar = (char)key;
            string message = string.Empty;

            for (int i = 0; i < numberOfLines; i++)
            {
                char currenteLetter = char.Parse(Console.ReadLine());

                currenteLetter += keyChar;
                char letter = (char)currenteLetter;
                message += letter;
            }
            Console.WriteLine(message);

            //    char key2 = char.Parse(Console.ReadLine());
            //    char key1 = (char)key;
            //    Console.WriteLine((char)(key1 + key2));
            //}
        }
    }
}
