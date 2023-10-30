

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string _Gender = "Male";
        public Tomcat(string name, int age) : base(name, age, _Gender)
        {
        }
    }
}
