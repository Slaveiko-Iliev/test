using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] currentCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string comArg = currentCommand[0];
                if (comArg == "merge")
                {
                    int startIndex = int.Parse(currentCommand[1]);
                    int endIndex = int.Parse(currentCommand[2]);

                    FixValidityIndex(input, ref startIndex, ref endIndex);

                    string mergedElement = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        

                        string elementToMerge = input[startIndex];
                        mergedElement +=elementToMerge;
                        input.RemoveAt(startIndex);
                    }

                    input.Insert(startIndex, mergedElement);
                }
                else if (comArg == "divide")
                {
                    int index = int.Parse(currentCommand[1]);
                    int partitions = int.Parse(currentCommand[2]);

                    string elementToDivide = input[index];

                    int partitionsLength = elementToDivide.Length / partitions;
                    int lastPartitionsLength = elementToDivide.Length - (partitions - 1) * partitionsLength;

                    input.RemoveAt(index);

                    List<string> currentDividedElement = new List<string>();

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            partitionsLength = lastPartitionsLength;
                        }

                        currentDividedElement.Add(string.Join("", elementToDivide.Skip(partitionsLength * i).Take(partitionsLength)));
                    }

                    input.InsertRange(index, currentDividedElement);




                   // for (int i = 0; i < partitions - 1; i++)
                   // {
                   //     string currentDividedElement = string.Empty;

                    //     for (int j = 0; j < partitionsLength; j++)
                    //     {
                    //         currentDividedElement += elementToDivide[0];
                    //         elementToDivide = elementToDivide.Remove(0, 1);
                    //     }

                    //     input.Insert(index + i, currentDividedElement);
                    // }

                    //input.Insert(index, elementToDivide);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

        static void FixValidityIndex ( List<string> input, ref int startIndex, ref int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (startIndex >= input.Count)
            {
                startIndex = input.Count - 1;
            }
            if (endIndex < 0)
            {
                endIndex = 0;
            }
            if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }
        }
    }
}
