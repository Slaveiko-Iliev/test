namespace _05.BirthdayCelebrations
{
    public interface IBirthdatable
    {
        public string Date {  get; set; }

        public bool CheckDate(string year);
    }
}
