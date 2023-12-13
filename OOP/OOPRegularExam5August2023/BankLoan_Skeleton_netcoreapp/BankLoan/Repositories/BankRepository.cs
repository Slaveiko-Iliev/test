using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _models;

        public BankRepository()
        {
            _models = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => _models;

        public void AddModel(IBank model) => _models.Add(model);

        public IBank FirstModel(string name) => _models.FirstOrDefault(x => x.Name == name);

        public bool RemoveModel(IBank model) => _models.Remove(model);
    }
}
