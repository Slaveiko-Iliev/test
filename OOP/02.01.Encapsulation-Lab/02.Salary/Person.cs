

namespace PersonsInfo
{
    public class Person
    {
		private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
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
        public decimal Salary
        {
            get { return _salary; }
            private set { _salary = value; }
        }


        public override string ToString() => $"{FirstName} {LastName} receives {Salary:f2} leva.";

        public void IncreaseSalary(decimal percentage)
        {
            decimal increaseSalary = Salary * percentage / 100;

            if (Age < 30)
            {
                increaseSalary /= 2;
            }

            Salary += increaseSalary;
        }
    }
}
