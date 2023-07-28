string[] input = Console.ReadLine()
    .Split();

string firstString = input[0];
string secondString = input[1];
int sumOfCharAsDigit = 0;

if (firstString.Length > secondString.Length)
{
    GetSumOfMultiplied(firstString, secondString, ref sumOfCharAsDigit);

    for (int i = firstString.Length - 1; i >= secondString.Length; i--)
    {
        sumOfCharAsDigit += firstString[i];
    }
}
else if (firstString.Length < secondString.Length)
{
    GetSumOfMultiplied(secondString, firstString, ref sumOfCharAsDigit);

    for (int i = secondString.Length - 1; i >= firstString.Length; i--)
    {
        sumOfCharAsDigit += secondString[i];
    }
}
else
{
    GetSumOfMultiplied(firstString, secondString, ref sumOfCharAsDigit);
}

Console.WriteLine(sumOfCharAsDigit);

static void GetSumOfMultiplied(string bigestString,  string smallestString, ref int sumOfCharAsDigit)
{
    for (int i = 0; i < smallestString.Length; i++)
    {
        sumOfCharAsDigit += (bigestString[i] * smallestString[i]);
    }
}