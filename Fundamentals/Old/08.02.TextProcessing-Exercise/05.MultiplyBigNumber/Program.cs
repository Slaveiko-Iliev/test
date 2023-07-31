string bigNumberAsString = Console.ReadLine();
bigNumberAsString = bigNumberAsString.TrimStart('0');
char[] bigNumberAsCharArray = bigNumberAsString.ToCharArray();
int number = int.Parse(Console.ReadLine());
if (number == 0)
{
    Console.WriteLine("0");
    return;
}
List<string> newNum = new List<string>();

int parse = 0;
for (int i = bigNumberAsCharArray.Length - 1; i >= 0; i--)
{
    parse = (int.Parse(Convert.ToString(bigNumberAsCharArray[i])) * number) + parse;
    newNum.Insert(0, (parse % 10).ToString());
    parse /= 10;
}


if (parse > 0)
    Console.WriteLine($"{parse}{string.Join("", newNum)}");
else
    Console.WriteLine($"{string.Join("", newNum)}");