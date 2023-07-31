using System.Text;

StringBuilder rawPassword = new StringBuilder(Console.ReadLine());

string input = string.Empty;

while ((input = Console.ReadLine()) != "Done")
{
    string[] commandInfo = input
        .Split();
    string command = commandInfo[0];
	
	if (command == "TakeOdd")
    {
        TakeOddAndPrintPass(rawPassword);
    }
    else if (command == "Cut")
    {
        CutAndPrintPass(commandInfo, rawPassword);
    }
    else if (command == "Substitute")
    {
        string substring = commandInfo[1];
        string substitute = commandInfo[2];
        
        if (rawPassword.ToString().Contains(substring))
        {
            rawPassword.Replace(substring, substitute);

            Console.WriteLine(rawPassword);
        }
        else
        {
            Console.WriteLine("Nothing to replace!");
        }
    }
    ;
}

Console.WriteLine($"Your password is: {rawPassword}");


static void TakeOddAndPrintPass(StringBuilder rawPassword)
{
    for (int i = rawPassword.Length - 1; i >= 0; i--)
    {
        if (i % 2 == 0)
        {
            rawPassword.Remove(i, 1);
        }
    }
    Console.WriteLine(rawPassword);
}

static void CutAndPrintPass(string[] commandInfo, StringBuilder rawPassword)
{
    int index = int.Parse(commandInfo[1]);
    int length = int.Parse(commandInfo[2]);

    rawPassword.Remove(index, length);

    Console.WriteLine(rawPassword);
}