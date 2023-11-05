namespace _05.BirthdayCelebrations
{
    public class Citizens : ICheckID
    {
        public Citizens(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public DateOnly DateOnly { get; set; }

        public bool IsValidID(string endOfID) => (ID.Substring(ID.Length - endOfID.Length) == endOfID);
    }
}
