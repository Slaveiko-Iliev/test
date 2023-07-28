string[] bannedWords = Console.ReadLine()
    .Split(", ");
string text = Console.ReadLine();

foreach (string word in bannedWords)
{
    text = text.Replace(word, new string('*', word.Length));
}

Console.WriteLine(text);