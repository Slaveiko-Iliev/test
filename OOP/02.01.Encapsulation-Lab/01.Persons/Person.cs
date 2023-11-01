

namespace PersonsInfo
{
    public class Person
    {
		private string _firstName;
        private string _lastName;
        private int _age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
		{
			get { return _firstName; }
			private set { _firstName = value; }
		}
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        public int Age
        {
            get { return _age; }
            private set { _age = value; }
        }

        public override string ToString() => $"{FirstName} {LastName} is {Age} years old.";
    }
}
