using System.Collections.Generic;

int number = int.Parse(Console.ReadLine());
Family family = new Family();

for (int i = 0; i < number; i++)
{
    string[] input = Console.ReadLine()
        .Split();

    string name = input[0];
    int age = int.Parse(input[1]);

    Person member = new Person(name, age);

    family.AddMember(member);

}

Person oldestPerson = family.GetOldestMember();

if (oldestPerson != null)
{
    Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
}

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}

public class Family
{
    public Family()
    {
        FamilyMembers = new List<Person>();
    }

    public List <Person>FamilyMembers { get; }

    public void AddMember(Person member)
    {
        FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        Person oldestPerson = FamilyMembers.OrderByDescending(x => x.Age).FirstOrDefault();
        
        return oldestPerson;
    }
    
}