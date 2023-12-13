namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int _initialInterest = 4;

        public Adult(string name, string id, double income) : base(name, id, _initialInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            Interest += 2;
        }
    }
}
