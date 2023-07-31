using System.Text.RegularExpressions;

int number = int.Parse(Console.ReadLine());

string patternForValidate = @"(\@#+)(?<bcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(\@#+)";
string patternForFind = @"[0-9]+";

Regex validateBarcode = new Regex(patternForValidate);
Regex findProductGroup= new Regex(patternForFind);

for (int i = 0; i < number; i++)
{
    string input = Console.ReadLine();

    bool isMatch = validateBarcode.IsMatch(input);

    if (isMatch)
    {
        Match validBarcode = Regex.Match(input, patternForValidate);
        string barcode = validBarcode.Groups["bcode"].Value;

        string productGroup = string.Empty;

        bool haveDigit = findProductGroup.IsMatch(barcode);

        if (haveDigit)
        {
            MatchCollection pG = Regex.Matches(barcode, patternForFind);

            foreach (Match match in pG)
            {
                productGroup += match.ToString();
            }
        }
        else
        {
            productGroup = "00";
        }

        Console.WriteLine($"Product group: {productGroup}");
    }
    else
    {
        Console.WriteLine("Invalid barcode");
    }
}