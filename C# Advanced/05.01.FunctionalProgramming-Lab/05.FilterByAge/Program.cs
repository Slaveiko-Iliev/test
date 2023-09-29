using System.Collections.Generic;
using System;
using System.Linq;

int count = int.Parse(Console.ReadLine());

List<Person> people = ReadPeople(count);

string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
Action<Person> printer = CreatePrinter(format);
PrintFilteredPeople(people, filter, printer);

void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
{
    people.Where(filter).ToList().ForEach(printer);
}

Action<Person> CreatePrinter(string format)
{
    if (format == "name age")
    {
        return x =>
        {
            Console.WriteLine($"{x.Name} - {x.Age}");
        };
    }
    else if (format == "name")
    {
        return x =>
        {
            Console.WriteLine($"{x.Name}");
        };
    }
    else
    {
        return x =>
        {
            Console.WriteLine($"{x.Age}");
        };
    }
}

Func<Person, bool> CreateFilter(string condition, int ageThreshold)
{
    if (condition == "older")
    {
        return x => x.Age >= ageThreshold;
    }
    else
    {
        return x => x.Age < ageThreshold;
    }
}

List<Person> ReadPeople(int count)
{
    List<Person> list = new List<Person>();

    for (int i = 0; i < count; i++)
    {
        string[] personInfo = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        string name = personInfo[0];
        int age = int.Parse(personInfo[1]);

        list.Add(new Person(name, age));
    }

    return list;
}

internal class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}