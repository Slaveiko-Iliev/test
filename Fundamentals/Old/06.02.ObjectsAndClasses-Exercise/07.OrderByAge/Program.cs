string input = string.Empty;

List<Person> persons = new List<Person>();

while ((input = Console.ReadLine()) != "End")
{
    string[] persoInfo = input.Split();

    string name = persoInfo[0];
    string id = persoInfo[1];
    int age = int.Parse(persoInfo[2]);

    if (persons.FirstOrDefault(x => x.Id == id) == null )
    {
        Person person = new Person(name, id, age);
        persons.Add(person);
    }
    else
    {
        int index = persons.FindIndex(x => x.Id == id);

        persons[index].Age = age;
        persons[index].Name = name;
    }

    
}

persons = persons.OrderBy(x => x.Age).ToList();

foreach (Person person in persons)
{
    Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
}


public class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
}