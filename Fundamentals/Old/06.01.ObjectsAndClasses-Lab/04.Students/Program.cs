string input = string.Empty; 

List<Student> students = new List<Student>();

while ((input = Console.ReadLine()) != "end")
{
    string[] studentInfo = input.Split();
    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    int age = int.Parse(studentInfo[2]);
    string town = studentInfo[3];

    Student student = new Student();
    student.FirstName = firstName;
    student.LastName = lastName;
    student.Age = age;
    student.Town = town;

    students.Add(student);
}

string city = Console.ReadLine();

foreach (Student student in students)
{
    if (student.Town == city)
    {
        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age { get; set; }
    public string Town { get; set; }
}


