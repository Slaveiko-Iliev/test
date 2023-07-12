int number = int.Parse(Console.ReadLine());

Dictionary <string, List<string>> synonymsList = new Dictionary<string, List<string>>();

for (int i = 0; i < number; i++)
{
    string word = Console.ReadLine();
    string synonym = Console.ReadLine();

    if (!synonymsList.ContainsKey(word))
    {
        synonymsList[word] = new List<string>();
    }

    synonymsList[word].Add(synonym);
}

foreach (var item in synonymsList)
{
    Console.Write($"{item.Key} - {string.Join(", ", item.Value)}");
    Console.WriteLine();
}