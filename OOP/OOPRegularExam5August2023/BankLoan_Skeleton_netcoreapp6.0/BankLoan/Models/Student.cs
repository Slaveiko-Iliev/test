namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int _initialInterest = 2;

        public Student(string name, string id, double income) : base(name, id, _initialInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            this.Interest += 1;
        }
    }
}
