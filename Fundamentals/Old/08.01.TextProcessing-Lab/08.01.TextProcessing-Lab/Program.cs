string input = string.Empty;

while ((input = Console.ReadLine()) != "end")
{
    char[] inputAsChars = input
        .ToCharArray()
        .Reverse()
        .ToArray();

    

    //string reversedInput = new string(inputAsChars);

    

    Console.WriteLine($"{input} = {string.Join("", inputAsChars)}");
}