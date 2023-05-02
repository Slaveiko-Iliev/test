using System;
using System.Linq;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            
                int[] initialField = new int[sizeOfField];

                int[] indexesOfAllLadybugs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                
                foreach (var indexesOfLadybugs in indexesOfAllLadybugs)
                {
                    if (indexesOfLadybugs >= 0 && indexesOfLadybugs < initialField.Length)
                    {
                        initialField[indexesOfLadybugs] = 1;
                    }
                }

                string input;

                while ((input = Console.ReadLine()) != "end")
                {
                    string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int currentLadybug = int.Parse(command[0]);
                    int flyLength = int.Parse(command[2]);

                    if (currentLadybug >= 0 && currentLadybug < initialField.Length)
                    {
                        if (initialField[currentLadybug] == 1)
                        {
                            if (command[1] == "right" && flyLength > 0 || command[1] == "left" && flyLength < 0)
                            {
                                flyLength = Math.Abs(flyLength);
                                if (currentLadybug + flyLength < initialField.Length)
                                {
                                    for (int i = currentLadybug + flyLength; i < initialField.Length; i += flyLength)
                                    {
                                        if (initialField[i] == 0)
                                        {
                                            initialField[i] = 1;
                                            break;
                                        }
                                    }
                                    initialField[currentLadybug] = 0;
                                }
                                else
                                {
                                    initialField[currentLadybug] = 0;
                                }
                            }
                            else if (command[1] == "left" && flyLength > 0 || command[1] == "right" && flyLength < 0)
                            {
                                flyLength = Math.Abs(flyLength);
                                if (currentLadybug - flyLength >= 0)
                                {
                                    for (int i = currentLadybug - flyLength; i >= 0; i -= flyLength)
                                    {
                                        if (initialField[i] == 0)
                                        {
                                            initialField[i] = 1;
                                            break;
                                        }
                                    }
                                    initialField[currentLadybug] = 0;
                                }
                                else
                                {
                                    initialField[currentLadybug] = 0;
                                }
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }

                }
                Console.WriteLine(string.Join(" ", initialField));
            
        }
    }
}
