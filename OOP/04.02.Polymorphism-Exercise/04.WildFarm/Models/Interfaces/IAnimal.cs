﻿namespace _04.WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
    }
}