namespace _03.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            ICallingable phone;

            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                bool IsValidNumber = true;
                                
                if (!phoneNumber.All(c => char.IsDigit(c)))
                {
                    
                    IsValidNumber = false;
                }

                if (IsValidNumber)
                {
                    if (phoneNumber.Length == 10)
                    {
                        phone = new Smartphone();
                    }
                    else
                    {
                        phone = new StationaryPhone();
                    }
                    Console.WriteLine(phone.Calling(phoneNumber));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            
            string[] adreses = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IBrowsingable smart = new Smartphone();

            foreach (string adres in adreses)
            {
                if (!adres.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine(smart.Browsing(adres));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
