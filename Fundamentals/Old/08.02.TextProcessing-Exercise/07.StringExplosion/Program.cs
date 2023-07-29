string input = Console.ReadLine();
int bombPower = 0;
for (int i = 0; i < input.Length; i++)
{
    if (bombPower > 0 && input[i] != '>')
    {
        input = input.Remove(i, 1);
        bombPower--;
        i--;
    }
    else if (input[i] == '>')
    {
        bombPower += int.Parse(input[i + 1].ToString());
    }
}
Console.WriteLine(input);