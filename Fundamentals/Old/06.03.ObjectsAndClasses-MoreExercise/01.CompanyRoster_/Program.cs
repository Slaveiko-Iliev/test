int number = int.Parse(Console.ReadLine());

List<Employee> employees = new List<Employee>();

for (int i = 0; i < number; i++)
{
    string[] input = Console.ReadLine()
        .Split();

    string name = input[0];
    double salary = double.Parse(input[1]);
    string department = input[2];

    Employee employee = new Employee(name, salary, department);
    employees.Add(employee);
}

List <double> salaryInDepartment = new List<double>();
Dictionary <string, List<double>> departments = new Dictionary <string, List<double>>();

foreach (Employee employee in employees)
{
    string newDepartment = employee.Department;
    double currentSalary = employee.Salary;

    if (!departments.ContainsKey(newDepartment))
    {
        departments[newDepartment] = new List<double>();
    }

    departments[newDepartment].Add(currentSalary);
}

string departmentMaxAverage = departments.OrderByDescending(x => x.Value.Average()).First().Key;

Console.WriteLine($"Highest Average Salary: {departmentMaxAverage}");
foreach (Employee employee in employees.Where(x => x.Department == departmentMaxAverage).OrderByDescending(x => x.Salary))
{
    Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
}


public class Employee
{
    public Employee(string name, double salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }

    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
}