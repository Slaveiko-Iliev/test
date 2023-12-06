using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (Capacity == Clients.Count)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            _clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
        {
            _loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");

            if (_clients.Count == 0)
            {
                sb.AppendLine("Clients: none");
            }
            else
            {
                List<string> clientsName = new();
                foreach (var client in _clients)
                {
                    clientsName.Add(client.Name);
                }
                sb.Append($"Clients: {string.Join(" ", clientsName)}");
                sb.AppendLine();
            }
            sb.Append($"Loans: {_loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            _clients.Remove(Client);
        }

        public double SumRates()
        {
            double result = 0;

            foreach (var loan in _loans)
            {
                result += loan.Amount * loan.InterestRate;
            }

            return result;
        }
    }
}
