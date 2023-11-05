namespace _05.BirthdayCelebrations
{
    public class Robots : ICheckID
    {
        public Robots(string name, string iD)
        {
            Name = name;
            ID = iD;
        }

        public string Name { get; set; }
        public string ID { get; set; }

        public bool IsValidID(string endOfID) => (ID.Substring(ID.Length - endOfID.Length) == endOfID);
    }
}
