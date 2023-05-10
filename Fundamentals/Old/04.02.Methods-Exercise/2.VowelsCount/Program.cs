using System;

namespace _2.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCount = GetVowelsCount(input);
            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string input)
        {
            int vowelsCount = 0;

            foreach (char letter in input)
            {
                switch(letter)
                {
                    case 'a':
                    case 'A': 
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'o':
                    case 'O':
                    case 'u':
                    case 'U':
                        vowelsCount++;
                        break;
                }
            }
            return vowelsCount;
        }
    }
}
