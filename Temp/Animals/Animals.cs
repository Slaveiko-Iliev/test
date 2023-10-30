
using System;

namespace Animals
{
    public abstract class Animals
    {
        private string _name;
        private int _age;
        private string _gender;

        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        { 
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                _name = value;
            } 
        }
        public int Age 
        {
            get => _age;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                _age = value;
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                _gender = value;
            }
        }

        public string ProduceSound(string kindOfAnimal)
        {
            switch (kindOfAnimal)
            {
                case "Dog":
                    return "Woof!";
                case "Cat":
                    return "Meow meow";
                case "Frog":
                    return "Ribbit";
                case "Kitten":
                    return "Meow";
                case "Tomcat":
                    return "MEOW";
                default:
                    return null;
            }
        }

        public string PrintAnimal<T>(string kindOfAnimal, T animal) where T : Animals
        {
            return $"{kindOfAnimal}{Environment.NewLine}" +
                $"{animal.Name} {animal.Age} {animal.Gender}{Environment.NewLine}" +
                $"{animal.ProduceSound(kindOfAnimal)}";
        }
    }
}
