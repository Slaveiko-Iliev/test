using System;

Random number = new Random();

//int PhraseIndex = num.Next(0, Phrases.Length);

int PhraseIndex = number.Next(0, Phrases.Length);

class AdvertisementMessage
{
    AdvertisementMessage()
    {
        Phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
    }

    public string[] Phrases { get; set; }

    public string[] Events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

    public string[] Authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

    public string[] Cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
}
