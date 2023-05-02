using System;

namespace _01.EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            int[] arrayOfSums = new int[numberOfStrings];
            

            for (int i = 0; i < numberOfStrings; i++)
            {
                char[] inputToChar = Console.ReadLine().ToCharArray();
                int currentChar = 0;
                int sumOfChar = 0;

                foreach (char character in inputToChar)
                {
                    switch (character)
                    {
                        case 'a':
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'e':
                        case 'A':
                        case 'I':
                        case 'O':
                        case 'U':
                        case 'E':
                            currentChar = character * inputToChar.Length;
                            sumOfChar += currentChar;
                            break;
                        default:
                            currentChar = character / inputToChar.Length;
                            sumOfChar += currentChar;
                            break;
                    }
                }
                arrayOfSums[i] = sumOfChar;
            }
            Array.Sort(arrayOfSums);

            foreach (var item in arrayOfSums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
