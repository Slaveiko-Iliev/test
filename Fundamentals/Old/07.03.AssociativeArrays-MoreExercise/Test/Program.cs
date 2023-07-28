using System;
using System.Collections.Generic;
using System.Linq;


namespace _4._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(" <:> ")
                .ToArray();

            while (input[0] != "Once upon a time")
            {
                string name = input[0];
                string color = input[1];
                int physics = int.Parse(input[2]);

                string spec = name + "-" + color;

                // if dwarf does not exist
                if (dwarfs.ContainsKey(spec) == false)
                {
                    dwarfs.Add(spec, physics);
                }
                else
                //if 2 dwarfs have the same name and the same color,store the one with the higher physics.
                {
                    if (dwarfs[spec] < physics)
                    {
                        dwarfs[spec] = physics;
                    }

                }

                input = Console.ReadLine()
                .Split(" <:> ")
                .ToArray();
            }

            Console.WriteLine();

            foreach (var pair in dwarfs
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split("-")[1] == x.Key.Split("-")[1])
                .Count())
                )
            {

                Console.WriteLine("({0}) {1} <-> {2}",
                    pair.Key.Split('-')[1],
                    pair.Key.Split('-')[0],
                    pair.Value);
            }

        }
    }
}