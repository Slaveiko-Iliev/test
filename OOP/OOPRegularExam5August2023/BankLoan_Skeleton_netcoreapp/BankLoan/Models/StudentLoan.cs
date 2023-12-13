namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int _InterestRate = 1;
        private const double _Amount = 10000;


        public StudentLoan() : base(_InterestRate, _Amount)
        {
        }
    }
}
