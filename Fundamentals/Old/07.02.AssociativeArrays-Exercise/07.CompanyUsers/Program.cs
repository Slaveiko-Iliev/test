using Microsoft.VisualBasic;

string input = string.Empty;

Dictionary<string, List<string>> information = new Dictionary<string, List<string>>();

while ((input = Console.ReadLine()) != "End")
{
    string[] companysEmployee = input.Split(" -> ");

    string companyName = companysEmployee[0];
    string employeesId = companysEmployee[1];

    if (!information.ContainsKey(companyName))
    {
        information[companyName] = new List<string>();
    }

    if (!information[companyName].Contains(employeesId))
    {
        information[companyName].Add(employeesId);
    }
}

foreach (var company in information)
{
    Console.WriteLine($"{company.Key}");

    foreach (var item in company.Value)
    {
        Console.WriteLine($"-- {item}");
    }
}