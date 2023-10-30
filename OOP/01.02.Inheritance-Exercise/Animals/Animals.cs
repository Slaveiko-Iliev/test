

namespace Animals
{
    public abstract class Animals
    {
        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }

        public void ProduceSound()
        {

        }
    }
}
