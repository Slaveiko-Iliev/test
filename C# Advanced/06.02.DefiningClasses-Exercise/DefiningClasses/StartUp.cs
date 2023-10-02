using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> family = new ();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (age > 30)
                {
                    Person person = new Person(name, age);
                    family.Add(person);
                }
            }

            List<Person> orderedFamily = family.OrderBy(x => x.Name).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var member in orderedFamily)
            {
                stringBuilder.AppendLine($"{member.Name} - {member.Age}");
            }

            Console.WriteLine(stringBuilder);
        }
    }
}
