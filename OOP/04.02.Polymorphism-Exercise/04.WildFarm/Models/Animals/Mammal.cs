﻿using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight) : base(name, weight)
        {
        }

        public string LivingRegion { get; }
    }
}
