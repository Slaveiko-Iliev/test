using _05.BirthdayCelebrations;

List<IBuyer> buyerList = new();

int number = int.Parse(Console.ReadLine());

for (int i = 0; i < number; i++)
{
    string[] buyerInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries) ;

    string buyerName = buyerInfo[0];
    int buyerAge = int.Parse(buyerInfo[1]);
    if (buyerInfo.Length == 3)
    {
        string rebelGroup = buyerInfo[2];

        IBuyer buyer = new Rebel(buyerName, buyerAge, rebelGroup);
        buyerList.Add(buyer);
    }
    else if (buyerInfo.Length == 4)
    {
        string citizenID = buyerInfo[2];
        string citizenBirthday = buyerInfo[3];

        IBuyer buyer = new Citizens(buyerName, buyerAge, citizenID, citizenBirthday);
        buyerList.Add(buyer);
    }
}

string input = string.Empty;

while((input = Console.ReadLine()) != "End")
{
    buyerList.FirstOrDefault(buyer => buyer.Name == input)?.BuyFood();
}

Console.WriteLine(buyerList.Sum(b => b.Food));







