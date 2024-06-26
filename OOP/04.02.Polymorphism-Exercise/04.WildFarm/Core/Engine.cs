﻿using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.IO.Interfaces;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;

    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    private readonly ICollection<IAnimal> animals;

    public Engine(
        IReader reader,
        IWriter writer,
        IAnimalFactory animalFactory,
        IFoodFactory foodFactory)
    {
        this.reader = reader;
        this.writer = writer;

        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();
    }

    public void Run()
    {
        string command;
        while ((command = reader.ReadLine()) != "End")
        {
            IAnimal animal = null;

            try
            {
                animal = CreateAnimal(command);

                IFood food = CreateFood();

                writer.WriteLine(animal.MadeSound());

                animal.Eat(food);

            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

            animals.Add(animal);
        }

        foreach (IAnimal animal in animals)
        {
            writer.WriteLine(animal);
        }
    }

    private IAnimal CreateAnimal(string command)
    {
        string[] animalArgs = command
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IAnimal animal = animalFactory.CreateAnimal(animalArgs);

        return animal;
    }

    private IFood CreateFood()
    {
        string[] foodTokens = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foodType = foodTokens[0];
        int foodQuantity = int.Parse(foodTokens[1]);

        IFood food = foodFactory.CreateFood(foodType, foodQuantity);

        return food;
    }
}
