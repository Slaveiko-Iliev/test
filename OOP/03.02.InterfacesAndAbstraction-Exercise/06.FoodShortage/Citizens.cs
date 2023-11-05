namespace _05.BirthdayCelebrations
{
    public class Citizens : ICheckID, IBirthdatable, IBuyer
    {
        public Citizens(string name, int age, string iD, string date)
        {
            Name = name;
            Age = age;
            ID = iD;
            Date = date;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }
        public int Food { get; set; }

        public bool IsValidID(string endOfID) => (ID.Substring(ID.Length - endOfID.Length) == endOfID);
        public bool CheckDate(string year)
        {
            string[] citizensBirthday = Date
                .Split("/", StringSplitOptions.RemoveEmptyEntries);
            string citizensYear = citizensBirthday[2];

            return citizensYear == year;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
