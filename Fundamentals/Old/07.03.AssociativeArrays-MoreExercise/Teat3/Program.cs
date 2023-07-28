using System;
using System.Linq;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var hatColorWithNamesAndPhysics = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArray = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
                string name = inputArray[0];
                string hatColor = inputArray[1];
                int physics = int.Parse(inputArray[2]);

                if (hatColorWithNamesAndPhysics.ContainsKey(hatColor) == false)
                {
                    hatColorWithNamesAndPhysics[hatColor] = new Dictionary<string, int>();
                    hatColorWithNamesAndPhysics[hatColor].Add(name, physics);
                }

                else if (hatColorWithNamesAndPhysics.ContainsKey(hatColor) == true)
                {
                    bool haveDwarfWithTheSameName = false;
                    foreach (var kvp in hatColorWithNamesAndPhysics[hatColor])
                    {
                        string currentName = kvp.Key;
                        int currentPhysics = kvp.Value;
                        if (currentName == name)
                        {
                            haveDwarfWithTheSameName = true;
                            if (physics > currentPhysics)
                            {
                                hatColorWithNamesAndPhysics[hatColor][currentName] = physics;
                                break;
                            }
                        }
                    }

                    if (haveDwarfWithTheSameName == false)
                    {
                        hatColorWithNamesAndPhysics[hatColor].Add(name, physics);
                    }
                }
            }

            hatColorWithNamesAndPhysics = hatColorWithNamesAndPhysics
                .OrderByDescending(x => x.Value.Count())
                .ToDictionary(x => x.Key, x => x.Value);

            var finalDwarfs = new Dictionary<int, Dictionary<int, Dictionary<string, string>>>();
            int dwarfNumber = 1;
            foreach (var (color, dwarfs) in hatColorWithNamesAndPhysics)
            {
                foreach (var (name, power) in dwarfs)
                {
                    finalDwarfs[dwarfNumber] = new Dictionary<int, Dictionary<string, string>>();
                    finalDwarfs[dwarfNumber][power] = new Dictionary<string, string>();
                    finalDwarfs[dwarfNumber][power][name] = color;
                    dwarfNumber++;
                }
            }

            finalDwarfs = finalDwarfs
                .OrderByDescending(d => d.Value.Keys.Max())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (number, dwarf) in finalDwarfs)
            {
                foreach (var (power, nameAndColor) in dwarf)
                {
                    foreach (var (name, color) in nameAndColor)
                    {
                        Console.WriteLine($"({color}) {name} <-> {power}");

                    }
                }
            }
        }
    }
}