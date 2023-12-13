namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        private const int _Capacity = 25;


        public BranchBank(string name) : base(name, _Capacity)
        {
        }
    }
}
