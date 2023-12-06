namespace BankLoan.Models
{
    internal class MortgageLoan : Loan
    {
        private const int _InterestRate = 3;
        private const double _Amount = 50000;

        public MortgageLoan() : base(_InterestRate, _Amount)
        {
        }
    }
}
