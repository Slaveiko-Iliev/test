
using System;

namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        { 
            get => _name;
            private set
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
            private set
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
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                _gender = value;
            }
        }

        public abstract string ProduceSound();
        //{
        //    switch (kindOfAnimal)
        //    {
        //        case "Dog":
        //            return "Woof!";
        //        case "Cat":
        //            return "Meow meow";
        //        case "Frog":
        //            return "Ribbit";
        //        case "Kitten":
        //            return "Meow";
        //        case "Tomcat":
        //            return "MEOW";
        //        default:
        //            return null;
        //    }
        //}

        public string PrintAnimal<T>(string kindOfAnimal, T animal) where T : Animal
        {
            return $"{kindOfAnimal}{Environment.NewLine}" +
                $"{animal.Name} {animal.Age} {animal.Gender}{Environment.NewLine}" +
                $"{animal.ProduceSound()}";
        }
    }
}
