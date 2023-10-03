using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            Name = name;
            Age = age;
        }

        public Person(int age) : this() 
        {
            Name = name;
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        private string name = "No name";
        private int age = 1;

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
