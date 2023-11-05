using _05.BirthdayCelebrations;

List<IBirthdatable> listOfIBirthdatable = new List<IBirthdatable>();

string input = string.Empty;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] inputInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputInfo[0] == "citizen")
    {
        IBirthdatable birthdatable = new Citizens(inputInfo[1], int.Parse(inputInfo[2]), inputInfo[3], inputInfo[4]);
        listOfIBirthdatable.Add(birthdatable);
    }
    else if (inputInfo[0] == "pet")
    {
        IBirthdatable birthdatable = new Pet(inputInfo[1], inputInfo[2]);
        listOfIBirthdatable.Add(birthdatable);
    }    
}

string year = Console.ReadLine();

foreach (var iBirthdatable in listOfIBirthdatable)
{
    if (iBirthdatable.CheckDate(year))
    {
        Console.WriteLine(iBirthdatable.Date);
    }
}







