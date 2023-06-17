using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _11._1.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] manipulationCommands = input.Split();
                var command = manipulationCommands[0];
                
                if (command == "exchange")
                {
                    int cleavageIndex = int.Parse(manipulationCommands[1]);

                    if (IsValidIndex(integers, cleavageIndex))
                    {
                        for (int i = 0; i <= cleavageIndex; i++)
                        {
                            int firstDigit = integers[0];

                            for (int j = 1; j < integers.Length; j++)
                            {
                                integers[j - 1] = integers[j];
                            }

                            integers[integers.Length - 1] = firstDigit;
                        }



                        //List<int> tempList = new List<int>();

                        //tempList.InsertRange(0, integers.Skip(cleavageIndex + 1).Take(integers.Length - 1 - cleavageIndex).ToList());
                        //tempList.InsertRange(integers.Length - cleavageIndex - 1, (integers.Take(cleavageIndex + 1)));

                        //for (int i = 0; i < integers.Length; i++)
                        //{
                        //    integers[i] = tempList[i];
                        //}



                        //int[] tempArray = new int[integers.Length];

                        //for (int i = 0; i < integers.Length - 1 - cleavageIndex; i++)
                        //{
                        //    tempArray[i] = integers[i + cleavageIndex + 1];
                        //}

                        //for (int i = 0; i <= cleavageIndex; i++)
                        //{
                        //    tempArray[tempArray.Length - 1 - cleavageIndex + i] = integers[i];
                        //}

                        //integers = tempArray;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "max")
                {
                    string argument = manipulationCommands[1];

                    int maxEvenOrOdd = int.MinValue;
                    int indexOfMaxEvenOrOdd = int.MinValue;

                    for (int i = 0; i < integers.Length; i++)
                    {
                        if (argument == "even" && IsEven(integers[i]))
                        {
                            if (integers[i] >= maxEvenOrOdd)
                            {
                                maxEvenOrOdd = integers[i];
                                indexOfMaxEvenOrOdd = i;
                            }
                        }
                        else if (argument == "odd" && !IsEven(integers[i]))
                        {
                            if (integers[i] >= maxEvenOrOdd)
                            {
                                maxEvenOrOdd = integers[i];
                                indexOfMaxEvenOrOdd = i;
                            }
                        }
                    }
                    if (maxEvenOrOdd == int.MinValue)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMaxEvenOrOdd);
                    }
                }
                else if (command == "min")
                {
                    string argument = manipulationCommands[1];

                    int minEvenOrOdd = int.MaxValue;
                    int indexOfMinEvenOrOdd = int.MinValue;

                    for (int i = 0; i < integers.Length; i++)
                    {
                        if (argument == "even" && IsEven(integers[i]))
                        {
                            if (integers[i] <= minEvenOrOdd)
                            {
                                minEvenOrOdd = integers[i];
                                indexOfMinEvenOrOdd = i;
                            }
                        }
                        else if (argument == "odd" && !IsEven(integers[i]))
                        {
                            if (integers[i] <= minEvenOrOdd)
                            {
                                minEvenOrOdd = integers[i];
                                indexOfMinEvenOrOdd = i;
                            }
                        }
                    }
                    if (minEvenOrOdd == int.MaxValue)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMinEvenOrOdd);
                    }
                }
                else if (command == "first")
                {
                    int count = int.Parse(manipulationCommands[1]);
                    string argument = manipulationCommands[2];
                    List<int> firstEvenOrOdd = new List<int>();
                    
                    if (count > integers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        for (int i = 0; i < integers.Length && count > 0; i++)
                        {
                            if (argument == "even" && IsEven(integers[i]))
                            {
                                firstEvenOrOdd.Add(integers[i]);
                                count--;
                            }
                            else if (argument == "odd" && !IsEven(integers[i]))
                            {
                                firstEvenOrOdd.Add(integers[i]);
                                count--;
                            }
                        }
                        Console.WriteLine($"[{string.Join(", ", firstEvenOrOdd)}]");
                    }
                }
                else if (command == "last")
                {
                    int count = int.Parse(manipulationCommands[1]);
                    string argument = manipulationCommands[2];
                    List<int> lastEvenOrOdd = new List<int>();

                    if (count > integers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        for (int i = integers.Length - 1; i >= 0 && count > 0; i--)
                        {
                            if (argument == "even" && IsEven(integers[i]))
                            {
                                lastEvenOrOdd.Add(integers[i]);
                                count--;
                            }
                            else if (argument == "odd" && !IsEven(integers[i]))
                            {
                                lastEvenOrOdd.Add(integers[i]);
                                count--;
                            }
                        }
                        Console.WriteLine($"[{string.Join(", ", lastEvenOrOdd)}]");
                    }
                }
            }
            Console.WriteLine($"[{string.Join(", ", integers)}]");
        }

        static bool IsValidIndex(int[] integers, int index)
        {
            if (index >= 0 && index < integers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
