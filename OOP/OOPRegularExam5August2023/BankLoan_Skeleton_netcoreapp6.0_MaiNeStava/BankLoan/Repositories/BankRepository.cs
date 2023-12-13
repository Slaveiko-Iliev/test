using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _banks;

        public BankRepository()
        {
            _banks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => _banks.AsReadOnly();

        public void AddModel(IBank model) => _banks.Add(model);

        public IBank FirstModel(string name) => _banks.FirstOrDefault(b => b.Name == name);

        public bool RemoveModel(IBank model) => _banks.Remove(model);
    }
}
