using _04.BorderControl;

List<ICheckID> listOfPassingThrough = new List<ICheckID>();

string input = string.Empty;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] passingThroughInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    ICheckID passingThrough;

    if (passingThroughInfo.Length == 2)
    {
        passingThrough = new Robots(passingThroughInfo[0], passingThroughInfo[1]);
        listOfPassingThrough.Add(passingThrough);

    }
    else if (passingThroughInfo.Length == 3)
    {
        passingThrough = new Citizens(passingThroughInfo[0], int.Parse(passingThroughInfo[1]), passingThroughInfo[2]);
        listOfPassingThrough.Add(passingThrough);
    }

    
}

string endOfID = Console.ReadLine();

foreach (var passingThrough in listOfPassingThrough)
{
    if (passingThrough.ID.Substring(passingThrough.ID.Length - endOfID.Length) == endOfID)
    {
        Console.WriteLine(passingThrough.ID);
    }
}




