using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string _name;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _loans = new List<ILoan>();
            _clients = new List<IClient>();
        }

        public string Name
        {
            get => _name;
            set
            {
                //ToDo Unicue bank name?
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int Capacity { get; protected set; }

        public IReadOnlyCollection<ILoan> Loans => _loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => _clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public void AddLoan(ILoan loan)
        {
            throw new NotImplementedException();
        }

        public string GetStatistics()
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public double SumRates()
        {
            throw new NotImplementedException();
        }
    }
}
