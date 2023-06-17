using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] comands = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string manipulation = comands[0];

                if (manipulation == "exchange")
                {
                    double index = double.Parse(comands[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        line = Console.ReadLine();
                        continue;
                    }

                    numbers = ExchangeArray(numbers, index);



                }
                else if (manipulation == "max")
                {
                    MaxEvenOdd(numbers, comands[1]);
                }
                else if (manipulation == "min")
                {
                    MinEvenOdd(numbers, comands[1]);
                }
                else if (manipulation == "first")
                {
                    double counter = double.Parse(comands[1]);

                    if (counter > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        line = Console.ReadLine();
                        continue;
                    }

                    FirstElements(numbers, (int)counter, comands[2]);


                }
                else if (manipulation == "last")
                {
                    double counter = double.Parse(comands[1]);

                    if (counter > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        line = Console.ReadLine();
                        continue;
                    }

                    LastElements(numbers, (int)counter, comands[2]);
                }


                line = Console.ReadLine();
            }

            Console.Write("[");
            Console.Write(string.Join(", ", numbers));
            Console.Write("]");
            Console.WriteLine();



        }

        private static int[] ExchangeArray(int[] numbers, double index)
        {
            int[] result = new int[numbers.Length];

            for (int i = 0; i <= index; i++)
            {
                int firstDigit = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }

                numbers[numbers.Length - 1] = firstDigit;
            }

            return numbers;

        }

        private static void MaxEvenOdd(int[] numbers, string evenOrOdd)
        {
            int maxDigit = -1;
            int index = -1;
            int evenOdd = OddOrEven(evenOrOdd);


            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == evenOdd)
                {
                    if (numbers[i] >= maxDigit)
                    {
                        maxDigit = numbers[i];
                        index = i;
                    }
                }
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void MinEvenOdd(int[] numbers, string evenOrOdd)
        {
            int minDigit = int.MaxValue;
            int index = -1;
            int evenOdd = OddOrEven(evenOrOdd);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == evenOdd)
                {
                    if (numbers[i] <= minDigit)
                    {
                        minDigit = numbers[i];
                        index = i;
                    }
                }
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static int OddOrEven(string evenOrOdd)
        {
            int evenOdd;
            if (evenOrOdd == "even")
            {
                evenOdd = 0;
            }
            else
            {
                evenOdd = 1;
            }

            return evenOdd;
        }

        private static void FirstElements(int[] numbers, int counter, string evenOrOdd)
        {
            int evenOdd = OddOrEven(evenOrOdd);
            int[] firstNums = new int[counter];

            for (int i = 0; i < firstNums.Length; i++)
            {
                firstNums[i] = -1;
            }

            int numCounter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == evenOdd)
                {
                    numCounter++;
                    if (numCounter > counter)
                    {
                        break;
                    }
                    firstNums[numCounter - 1] = numbers[i];
                }
            }
            Console.Write("[");
            bool isFirst = true;

            foreach (var digit in firstNums)
            {
                if (digit == -1)
                {
                    continue;
                }

                if (isFirst)
                {
                    Console.Write(digit);
                    isFirst = false;
                }
                else
                {
                    Console.Write($", {digit}");
                }
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static void LastElements(int[] numbers, int counter, string evenOrOdd)
        {
            int evenOdd = OddOrEven(evenOrOdd);
            int[] lastNums = new int[counter];

            for (int i = 0; i < lastNums.Length; i++)
            {
                lastNums[i] = -1;
            }

            int numCounter = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == evenOdd)
                {
                    numCounter++;
                    if (numCounter > counter)
                    {
                        break;
                    }
                    lastNums[numCounter - 1] = numbers[i];
                }
            }

            lastNums = lastNums.Reverse().ToArray();
            Console.Write("[");
            bool isFirst = true;

            foreach (var digit in lastNums)
            {
                if (digit == -1)
                {
                    continue;
                }

                if (isFirst)
                {
                    Console.Write(digit);
                    isFirst = false;
                }
                else
                {
                    Console.Write($", {digit}");
                }
            }

            Console.Write("]");
            Console.WriteLine();
        }

    }
}