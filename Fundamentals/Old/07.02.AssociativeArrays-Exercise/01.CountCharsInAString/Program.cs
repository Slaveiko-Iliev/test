using System.Net.Http.Headers;

string input = Console.ReadLine();

Dictionary <char, int> countsAllCharacters = new Dictionary<char, int>();


foreach (char item in input)
{
    if (item != ' ')
    {
        if (!countsAllCharacters.ContainsKey(item))
        {
            countsAllCharacters[item] = 0;
        }

        countsAllCharacters[item] ++;
    }
}

foreach (var item in countsAllCharacters)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}