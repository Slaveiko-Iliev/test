namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int _Capacity = 50;

        public CentralBank(string name) : base(name, _Capacity)
        {
        }
    }
}

