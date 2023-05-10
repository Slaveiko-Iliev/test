using System;
using System.Linq;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char initialBorder = char.Parse(Console.ReadLine());
            char finalBorder = char.Parse(Console.ReadLine());

            if (initialBorder > finalBorder)
            {
                char temp;
                temp = initialBorder;
                initialBorder = finalBorder;
                finalBorder = temp;
            }

            char[] chars = GetLineOfChar(initialBorder, finalBorder);
            foreach (char letter in chars)
            {
                Console.Write(letter + " ");
            }
        }

        private static char[] GetLineOfChar(char initialBorder, char finalBorder)
        {
            //string lineOfChar = string.Empty;

            char[] chars = new char[finalBorder - initialBorder -1];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(initialBorder + 1 + i);
            }

            return chars;
        }
    }
}
