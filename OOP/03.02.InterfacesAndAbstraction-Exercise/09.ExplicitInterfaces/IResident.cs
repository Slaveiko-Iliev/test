namespace _09.ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName();
    }
}
