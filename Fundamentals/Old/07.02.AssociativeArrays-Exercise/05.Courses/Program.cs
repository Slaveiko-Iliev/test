string input = string.Empty;

Dictionary<string, List<string>> coursesInfo = new Dictionary<string, List<string>>();

while ((input = Console.ReadLine()) != "end")
{
    string[] studentInfo = input.Split(" : ");

    string courseName = studentInfo[0];
    string studentName = studentInfo[1];

    if(!coursesInfo.ContainsKey(courseName))
    {
        coursesInfo.Add(courseName, new List<string>());
    }

    coursesInfo[courseName].Add(studentName);
}

foreach (KeyValuePair<string, List<string>> item in coursesInfo)
{
    Console.WriteLine($"{item.Key}: {item.Value.Count}");
    foreach (var value in item.Value)
    {
        Console.WriteLine($"-- {value}");
    }
}