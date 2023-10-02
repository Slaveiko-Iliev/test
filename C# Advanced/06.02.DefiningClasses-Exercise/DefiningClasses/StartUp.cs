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
            string input = string.Empty;
            List<Person> persons = new();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] userInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = userInfo[0];
                int age = int.Parse(userInfo[1]);

                Person person = new Person(name, age); 
            }
        }
    }
}
