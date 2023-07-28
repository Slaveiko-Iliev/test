string firstString = Console.ReadLine();
string secondString = Console.ReadLine();

while (secondString.Contains(firstString))
{
    secondString = secondString.Replace(firstString, string.Empty);
}

Console.WriteLine(secondString);