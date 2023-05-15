using System;
using System.Drawing;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string partOfCommand = string.Empty;

                for (int i = 0; i < 3; i++)
                {
                    partOfCommand += command[i];
                }

                if (partOfCommand == "exc")
                {
                    string exchangeIndexAsString = string.Empty;
                    bool isDigit;

                    for (int j = 9; j < command.Length; j++)
                    {
                        if (isDigit = char.IsDigit(command[j]))
                        {
                            exchangeIndexAsString += command[j];
                        }
                    }

                    int exchangeIndex = int.Parse(exchangeIndexAsString);

                    if (exchangeIndex >= 0 && exchangeIndex < initialArray.Length)
                    {
                        int[] newArray = new int[initialArray.Length];
                        for (int k = 0; k < newArray.Length - 1 - exchangeIndex; k++)
                        {
                            newArray[k] = initialArray[exchangeIndex + 1 + k];
                        }

                        for (int l = 0; l <= exchangeIndex; l++)
                        {
                            newArray[newArray.Length - 1 - exchangeIndex + l] = initialArray[l];
                        }
                        initialArray = newArray;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if (partOfCommand == "max")
                {
                    char isEven = command[command.Length - 1];
                    if (isEven == 'n')
                    {
                        int indexOfMaxEven = GetMax(initialArray, "even");
                        if (indexOfMaxEven != int.MinValue)
                        {
                            Console.WriteLine(indexOfMaxEven);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else
                    {
                        int indexOfMaxOdd = GetMax(initialArray, "odd");
                        if (indexOfMaxOdd != int.MinValue)
                        {
                            Console.WriteLine(indexOfMaxOdd);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }

                }
                else if (partOfCommand == "min")
                {
                    char isEven = command[command.Length - 1];
                    if (isEven == 'n')
                    {
                        int indexOfMinEven = GetMin(initialArray, "even");
                        if (indexOfMinEven != int.MaxValue)
                        {
                            Console.WriteLine(indexOfMinEven);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else
                    {
                        int indexOfMinOdd = GetMin(initialArray, "odd");
                        if (indexOfMinOdd != int.MaxValue)
                        {
                            Console.WriteLine(indexOfMinOdd);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }
                else if (partOfCommand == "fir")
                {
                    string countOfElementAsString = string.Empty;
                    

                    for (int i = 5; i < command.Length; i++)
                    {
                        if (char.IsDigit(command[i]))
                        {
                            countOfElementAsString += command[i];
                        }
                    }

                    int countOfElement = int.Parse(countOfElementAsString);

                    if (initialArray.Length >= countOfElement)
                    {
                        
                        
                        if (command[command.Length - 1] == 'n')
                        {
                            int[] FirstEven = GetFirst(initialArray, countOfElement, "even");
                            Console.WriteLine($"[{String.Join(", ", FirstEven)}]");
                        }
                        else
                        {
                            int[] FirstOdd = GetFirst(initialArray, countOfElement, "odd");
                            Console.WriteLine($"[{String.Join(", ", FirstOdd)}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
                else if (partOfCommand == "las")
                {
                    string countOfElementAsString = string.Empty;


                    for (int i = 5; i < command.Length; i++)
                    {
                        if (char.IsDigit(command[i]))
                        {
                            countOfElementAsString += command[i];
                        }
                    }

                    int countOfElement = int.Parse(countOfElementAsString);

                    if (initialArray.Length >= countOfElement)
                    {

                        if (command[command.Length - 1] == 'n')
                        {
                            int[] FirstEven = GetLast(initialArray, countOfElement, "even");
                            Console.WriteLine($"[{String.Join(", ", FirstEven)}]");
                        }
                        else
                        {
                            int[] FirstOdd = GetLast(initialArray, countOfElement, "odd");
                            Console.WriteLine($"[{String.Join(", ", FirstOdd)}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }


            }
            Console.WriteLine($"[{string.Join(", ", initialArray)}]");
        }

        private static int GetMin(int[] initialArray, string evenOrOdd)
        {
            int indexOfMin = int.MaxValue;
            int min = int.MaxValue;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < initialArray.Length; i++)
                {
                    if (initialArray[i] % 2 == 0 && initialArray[i] <= min)
                    {
                        indexOfMin = i;
                        min = initialArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < initialArray.Length; i++)
                {
                    if (initialArray[i] % 2 != 0 && initialArray[i] <= min)
                    {
                        indexOfMin = i;
                        min = initialArray[i];
                    }
                }
            }
            return indexOfMin;
        }

        private static int GetMax(int[] initialArray, string evenOrOdd)
        {
            int indexOfMax = int.MinValue;
            int max = int.MinValue;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < initialArray.Length; i++)
                {
                    if (initialArray[i] % 2 == 0 && initialArray[i] >= max)
                    {
                        indexOfMax = i;
                        max = initialArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < initialArray.Length; i++)
                {
                    if (initialArray[i] % 2 != 0 && initialArray[i] >= max)
                    {
                        indexOfMax = i;
                        max = initialArray[i];
                    }
                }
            }
            return indexOfMax;
        }
        static int[] GetFirst (int[] initialArray, int countOfElement, string isEvenOrOdd)
        {
            int[] first = new int[countOfElement];
            int currentCount = 0;
            int firstIndex = 0;

            for (int i = 0; i < initialArray.Length && countOfElement <= first.Length; i++)
            {
                if (firstIndex >= countOfElement)
                {
                    break;
                }

                if (initialArray[i] % 2 == 0 && isEvenOrOdd == "even")
                {
                    first[firstIndex++] = initialArray[i];
                    currentCount++;
                }
                else if (initialArray[i] % 2 != 0 && isEvenOrOdd == "odd")
                {
                    first[firstIndex++] = initialArray[i];
                    currentCount++;
                }
            }

            if (currentCount < first.Length)
            {
                int[] currentFirst = new int[currentCount];
                for (int i = 0; i < currentCount; i++)
                {
                    currentFirst[i] = first[i];
                    
                }
                first = currentFirst;
            }

            return first;
            
        }

        static int[] GetLast(int[] initialArray, int countOfElement, string isEvenOrOdd)
        {
            int[] last = new int[initialArray.Length];
            int currentCount = 0;
            int lastIndex = 0;

            for (int i = initialArray.Length - 1; i >=0  && countOfElement <= last.Length && currentCount < countOfElement; i--)
            {
                if (lastIndex >= countOfElement)
                {
                    break;
                }

                if (initialArray[i] % 2 == 0 && isEvenOrOdd == "even")
                {
                    last[lastIndex++] = initialArray[i];
                    currentCount++;
                }
                else if (initialArray[i] % 2 != 0 && isEvenOrOdd == "odd")
                {
                    last[lastIndex++] = initialArray[i];
                    currentCount++;
                }
            }

            if (currentCount < last.Length)
            {
                int[] currentLast = new int[currentCount];
                for (int i = 0; i < currentCount; i++)
                {
                    currentLast[i] = last[i];
                    
                }
                last = currentLast;
            }

            int[] reversedLast = new int[last.Length];

            for (int i = reversedLast.Length - 1; i >= 0; i--)
            {
                reversedLast[reversedLast.Length - 1 - i] = last[i];
            }

            last = reversedLast;

            return last;

        }

        
    }
}
