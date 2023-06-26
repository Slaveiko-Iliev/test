int countOfStudents = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();

for (int i = 0; i < countOfStudents; i++)
{
    string[] input = Console.ReadLine()
        .Split();

    string firstName = input[0];
    string lastName = input[1];
    double grade = double.Parse(input[2]);

    Student student = new Student (firstName, lastName, grade);

    students.Add(student);
}

foreach (Student student in students.OrderByDescending(x => x.Grade))
{
    Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
}


public class Student
{
    public Student (string firstName, string lastName, double grade)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grade = grade;
    }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public double Grade { get; set; }
}