namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthdatable
    {
        public Pet(string name, string date)
        {
            Name = name;
            Date = date;
        }

        public string Name {  get; set; }
        public string Date { get ; set ; }

        public bool CheckDate(string year)
        {
            string[] petBirthday = Date
                .Split("/", StringSplitOptions.RemoveEmptyEntries);
            string petYear = petBirthday[2];

            return petYear == year;
        }
    }
}
