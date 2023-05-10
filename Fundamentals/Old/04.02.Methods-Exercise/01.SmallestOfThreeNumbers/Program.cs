using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallest = GetSmallest(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(smallest);
        }

        private static int GetSmallest(int firstNumber, int secondNumber, int thirdNumber)
        {
            int smallest = Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
            return smallest;
        }



        //static void Main(string[] args)
        //{
        //    int firstNumber = int.Parse(Console.ReadLine());
        //    int secondNumber = int.Parse(Console.ReadLine());
        //    int thirdNumber = int.Parse(Console.ReadLine());

        //    int smallest = GetSmallest (firstNumber, secondNumber, thirdNumber);
        //    Console.WriteLine(smallest);
        //}

        //private static int GetSmallest(int firstNumber, int secondNumber, int thirdNumber)
        //{
        //    int smallest = 0;

        //    if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
        //    {
        //        smallest = firstNumber;
        //    }
        //    else if (secondNumber <= thirdNumber && secondNumber <= firstNumber)
        //    {
        //        smallest = secondNumber;
        //    }
        //    else if (thirdNumber <= firstNumber && thirdNumber <= secondNumber)
        //    {
        //        smallest = thirdNumber;
        //    }

        //    return smallest;
        //}
    }
}
