namespace _03.Telephony
{
    public class Smartphone : ICallingable, IBrowsingable
    {
        public string Browsing(string adres) => $"Browsing: {adres}!";
        public string Calling(string phoneNumber) => $"Calling... {phoneNumber}";
    }
}
