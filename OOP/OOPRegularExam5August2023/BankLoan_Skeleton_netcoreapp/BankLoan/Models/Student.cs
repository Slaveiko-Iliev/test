namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int _InitialInterest = 2;

        public Student(string name, string id, double income) : base(name, id, _InitialInterest, income)
        {
        }

        public override void IncreaseInterest() => Interest++;
    }
}
