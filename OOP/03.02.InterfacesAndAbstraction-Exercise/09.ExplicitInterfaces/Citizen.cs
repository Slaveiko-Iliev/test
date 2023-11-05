namespace _09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get ; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
        string IPerson.GetName()
        {
            return Name ;
        }
        public string GetName()
        {
            return "Ihuuu" ;
        }
    }
}
