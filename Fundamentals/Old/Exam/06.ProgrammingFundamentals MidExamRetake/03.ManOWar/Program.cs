using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace _03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> statusOfPirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();
            List<int> statusOfWarShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();
            int maximumHealth = int.Parse(Console.ReadLine());

            string input = string.Empty;
            bool isAnyShipSinks = false;

            while ((input = Console.ReadLine()) != "Retire" && !isAnyShipSinks)
            {
                List<string> fullCommand = input
                    .Split()
                    .ToList();

                string command = fullCommand[0];

                if (command == "Fire")
                {
                    int indexOfStatusOfWarShip = int.Parse(fullCommand[1]);
                    int damageOfWarShip = int.Parse(fullCommand[2]);

                    if (IsValidIndex(statusOfWarShip, indexOfStatusOfWarShip))
                    {
                        statusOfWarShip[indexOfStatusOfWarShip] -= damageOfWarShip;

                        if (statusOfWarShip[indexOfStatusOfWarShip] <= 0)
                        {
                            isAnyShipSinks = true;
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            break;
                        }
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(fullCommand[1]);
                    int endIndex = int.Parse(fullCommand[2]);
                    int damage = int.Parse(fullCommand[3]);

                    if (!IsValidIndex(statusOfPirateShip, startIndex) ||  !IsValidIndex(statusOfPirateShip, endIndex))
                    {
                        continue;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        statusOfPirateShip[i] -= damage;

                        if (statusOfPirateShip[i]  <= 0)
                        {
                            isAnyShipSinks = true;
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            break;
                        }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(fullCommand[1]);
                    int health = int.Parse(fullCommand[2]);

                    if (!IsValidIndex(statusOfPirateShip, index))
                    {
                        continue;
                    }

                    statusOfPirateShip[index] += health;

                    if (statusOfPirateShip[index] > maximumHealth)
                    {
                        statusOfPirateShip[index] = maximumHealth;
                    }
                }
                else if (command == "Status")
                {
                    int countOfSectionsForRepair = 0;

                    foreach (var section in statusOfPirateShip)
                    {
                        if (section < maximumHealth * 0.2)
                        {
                            countOfSectionsForRepair++;
                        }
                    }

                    Console.WriteLine($"{countOfSectionsForRepair} sections need repair.");
                }
            }

            if (!isAnyShipSinks)
            {
                int pirateShipSum = shipSum(statusOfPirateShip);
                int warshipSum = shipSum(statusOfWarShip);

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }

        }
        static bool IsValidIndex (List<int> statusOfShip, int index)
        {
            if (index >= 0 && index < statusOfShip.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int shipSum (List<int> statusOfShip)
        {
            int shipSum = 0;

            foreach(var section in statusOfShip)
            {
                shipSum += section;
            }

            return shipSum;
        }
    }
}
