namespace _03.Telephony
{
    public class StationaryPhone : ICallingable
    {
        public string Calling(string phoneNumber) => $"Dialing... {phoneNumber}";
    }
}
