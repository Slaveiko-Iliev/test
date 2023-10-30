

namespace Animals
{
    public class Kitten : Cat
    {
        private const string _Gender = "Female";
        public Kitten(string name, int age) : base(name, age, _Gender)
        {
        }
    }
}
