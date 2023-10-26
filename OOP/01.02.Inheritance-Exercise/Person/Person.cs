using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Person
{
    public class Person
    {
        

        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format($"Name: {Name}, Age: {Age}"));

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
