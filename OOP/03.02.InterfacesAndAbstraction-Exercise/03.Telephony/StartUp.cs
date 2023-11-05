namespace _03.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            IBrowsingable smartBrowse = new Smartphone();
            ICallingable smartCall = new Smartphone();
            ICallingable stationaryPhone = new StationaryPhone();

            
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                bool IsValidNumber = true;
                
                foreach (var ch in phoneNumber)
                {
                    if (!char.IsDigit(ch))
                    {
                        Console.WriteLine("Invalid number!");
                        IsValidNumber = false;
                        break;
                    }
                }
                if (IsValidNumber)
                {
                    if (phoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartCall.Calling(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(stationaryPhone.Calling(phoneNumber));
                    }
                }
            }

            string[] adreses = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string adres in adreses)
            {
                bool IsValidAdres = true;

                foreach (var ch in adres)
                {
                    if (char.IsDigit(ch) )
                    {
                        Console.WriteLine("Invalid URL!");
                        IsValidAdres = false;
                        break;
                    }
                }
                if (IsValidAdres)
                {
                    Console.WriteLine(smartBrowse.Browsing(adres));
                }
            }
        }
    }
}
