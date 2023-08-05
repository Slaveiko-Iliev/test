using System.Text;

string text = Console.ReadLine();

string input = string.Empty;

while ((input = Console.ReadLine()) != "Done")
{
    string[] commandInfo = input.Split();
    string command = commandInfo[0];

    if (command == "Change")
    {
        char ch = char.Parse(commandInfo[1]);
        char replacement = char.Parse(commandInfo[2]);

        text = text.Replace(ch, replacement);

        Console.WriteLine(text);
    }
    else if (command == "Includes")
    {
        string substring = commandInfo[1];

        bool IsContains = text.Contains(substring);
        Console.WriteLine(IsContains);
    }
    else if (command == "End")
    {
        string substring = commandInfo[1];

        bool IsEndWith = text.EndsWith(substring);
        Console.WriteLine(IsEndWith);
    }
    else if (command == "Uppercase")
    {
        text = text.ToUpper();
        Console.WriteLine(text);
    }
    else if (command == "FindIndex")
    {
        char ch = char.Parse(commandInfo[1]);
        int index = text.IndexOf(ch);

        if (index != -1)
        {
            Console.WriteLine(index);
        }
    }
    else if (command == "Cut")
    {
        int startIndex = int.Parse(commandInfo[1]);
        int count = int.Parse(commandInfo[2]);

        string substring = text.Substring(startIndex, count);

        Console.WriteLine(substring);
    }
}