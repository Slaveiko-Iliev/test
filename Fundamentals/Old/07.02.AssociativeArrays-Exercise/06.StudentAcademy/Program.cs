using System.Xml.Linq;

int number = int.Parse(Console.ReadLine());

Dictionary <string, List<double>> studentsTrack = new Dictionary<string, List<double>>();

for (int i = 0; i < number; i++)
{
    string studentName = Console.ReadLine();
    double studentGrade = double.Parse(Console.ReadLine());

    if (!studentsTrack.ContainsKey(studentName))
    {
        studentsTrack[studentName] = new List<double>();
    }

    studentsTrack[studentName].Add(studentGrade);
}

foreach (var item in studentsTrack)
{
    if (item.Value.Average() >= 4.50)
    {
        Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
    }
}