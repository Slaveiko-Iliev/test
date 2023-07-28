string[] input = Console.ReadLine()
    .Split(", ");

foreach (var username in input)
{
	bool IsValid = false;

	if (username.Length >= 3 && username.Length <= 16)
	{
        IsValid = true;
    }
	
	for (int i = 0; i < username.Length && IsValid; i++)
	{
		if (Char.IsDigit(username, i) || Char.IsLetter(username, i) || username[i] == '_' || username[i] == '-')
		{
			IsValid = true;
		}
		else
		{
			IsValid = false;
		}
    }

	if (IsValid)
	{
		Console.WriteLine(username);
	}
}