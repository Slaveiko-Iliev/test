using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemmonList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfRemoved = 0;

            while (pokemmonList.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < pokemmonList.Count)
                {
                    int valueOfIndex = pokemmonList[index];

                    sumOfRemoved += pokemmonList[index];
                    pokemmonList.RemoveAt(index);
                    IncreaseOrDecreaseElement(pokemmonList, valueOfIndex);

                }
                else if (index < 0)
                {
                    int valueOfIndex = pokemmonList[0];

                    sumOfRemoved += pokemmonList[0];
                    pokemmonList.RemoveAt(0);
                    pokemmonList.Insert(0, pokemmonList[pokemmonList.Count - 1]);
                    IncreaseOrDecreaseElement(pokemmonList, valueOfIndex);
                }
                else
                {
                    int valueOfIndex = pokemmonList[pokemmonList.Count - 1];

                    sumOfRemoved += pokemmonList[pokemmonList.Count - 1];
                    pokemmonList.RemoveAt(pokemmonList.Count - 1);
                    pokemmonList.Add(pokemmonList[0]);
                    IncreaseOrDecreaseElement(pokemmonList, valueOfIndex);
                }
            }

            Console.WriteLine(sumOfRemoved);
        }

        static void IncreaseOrDecreaseElement (List<int> pokemmonList, int valueOfIndex)
        {
            for (int i = 0; i < pokemmonList.Count; i++)
            {
                if (pokemmonList[i] <= valueOfIndex)
                {
                    pokemmonList[i] += valueOfIndex;
                }
                else
                {
                    pokemmonList[i] -= valueOfIndex;
                }
            }
        }
    }
}
