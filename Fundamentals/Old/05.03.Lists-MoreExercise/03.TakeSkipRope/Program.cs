using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            List<char> nonNumbers = new List<char>();
            List<int> numbers = new List<int>();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (Char.IsDigit(encryptedMessage, i))
                {
                    numbers.Add((int)Char.GetNumericValue(encryptedMessage[i]));
                }
                else
                {
                    nonNumbers.Add(encryptedMessage[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            string result = string.Empty;

            var total = 0;

            for (int i = 0; i < skipList.Count; i++)
            {
                int skipCount = skipList[i];
                int takeCount = takeList[i];
                result += new string(nonNumbers.Skip(total).Take(takeCount).ToArray());
                total += skipCount + takeCount;
            }
            Console.WriteLine(result);

        }
    }
}
