using System;

namespace _02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            string[] arrayOfNumbers = new string[countOfNumbers];

            for (int i = 0; i < countOfNumbers; i++)
            {
                arrayOfNumbers[i] = Console.ReadLine();
            }

            for (int i = 0; i < arrayOfNumbers.Length / 2; i++)
            {
                string firstNumber = arrayOfNumbers[i];
                string lastNumber = arrayOfNumbers[arrayOfNumbers.Length - 1 - i];
                arrayOfNumbers[i] = lastNumber;
                arrayOfNumbers[arrayOfNumbers.Length - 1 - i] = firstNumber;
            }

            Console.Write($"{string.Join(" ", arrayOfNumbers)}");
        }
    }
}
