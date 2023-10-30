using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string kindOfAnimal = string.Empty;

            while ((kindOfAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //string name = animalInfo[0];
                //int age = int.Parse(animalInfo[1]);
                //string gender = animalInfo[2];

                try
                {
                    switch (kindOfAnimal)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            Console.WriteLine(dog.PrintAnimal(kindOfAnimal, dog));
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            Console.WriteLine(cat.PrintAnimal(kindOfAnimal, cat));
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            Console.WriteLine(frog.PrintAnimal(kindOfAnimal, frog));
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                            Console.WriteLine(kitten.PrintAnimal(kindOfAnimal, kitten));
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(animalInfo[0], int.Parse(animalInfo[1]));
                            Console.WriteLine(tomcat.PrintAnimal(kindOfAnimal, tomcat));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
