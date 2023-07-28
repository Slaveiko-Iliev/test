using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            var dwarfs = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string name = input.Split(" <:> ")[0];
                string color = input.Split(" <:> ")[1];
                int physics = int.Parse(input.Split(" <:> ")[2]);

                if (dwarfs.ContainsKey(color))
                {
                    if (dwarfs[color].ContainsKey(name))
                    {
                        if (dwarfs[color][name] < physics)
                        {
                            dwarfs[color][name] = physics;
                        }
                    }
                    else
                    {
                        dwarfs[color].Add(name, physics);
                    }
                }
                else
                {
                    dwarfs.Add(color, new Dictionary<string, int>());
                    dwarfs[color].Add(name, physics);
                }
            }

            //foreach (var item in dwarfs)
            //{
            //    foreach (var items in dwarfs[item.Key])
            //    {
            //        if (items.Value == 0)
            //        {
            //            dwarfs[item.Key].Remove(items.Key);
            //        }
            //    }

            //    if (item.Value.Count == 0)
            //    {
            //        dwarfs.Remove(item.Key);
            //    }
            //}

            
            ;
            foreach (var item in dwarfs.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Value.Values.Count))
            {
                foreach (var items in dwarfs[item.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"({item.Key}) {items.Key} <-> {items.Value}");
                }
            }
        }
    }
}