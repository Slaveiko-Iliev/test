namespace _05.BirthdayCelebrations
{
    public interface ICheckID
    {
        public string ID { get; set; }

        public bool IsValidID(string endOfID);
    }
}
