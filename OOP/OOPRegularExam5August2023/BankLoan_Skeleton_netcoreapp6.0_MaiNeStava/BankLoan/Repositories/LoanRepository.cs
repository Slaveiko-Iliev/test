using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _loans;

        public LoanRepository()
        {
            _loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models => _loans.AsReadOnly();

        public void AddModel(ILoan model)
        {
            _loans.Add(model);
        }

        public ILoan FirstModel(string name) => _loans.FirstOrDefault(l => l.GetType().Name == name);

        public bool RemoveModel(ILoan model) => _loans.Remove(model);
    }
}
