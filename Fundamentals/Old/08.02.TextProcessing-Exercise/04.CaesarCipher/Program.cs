using System.Text;

StringBuilder textToEncrypt = new StringBuilder(Console.ReadLine());

for (int i = 0; i < textToEncrypt.Length; i++)
{
    int currentCharAsInt = textToEncrypt[i];
    currentCharAsInt += 3;
    textToEncrypt[i] = (char)currentCharAsInt;
}

Console.WriteLine(textToEncrypt.ToString());


textToEncrypt[textToEncrypt.Length - 1] = textToEncrypt[^1];