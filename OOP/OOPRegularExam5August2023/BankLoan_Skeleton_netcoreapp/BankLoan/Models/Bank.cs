using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //	All names are unique.
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => _loans;

        public IReadOnlyCollection<IClient> Clients => _clients;

        public void AddClient(IClient Client)
        {
            if (_clients.Count == Capacity)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            _clients.Add(Client);
        }

        public void AddLoan(ILoan loan) => _loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");

            if (_clients.Count == 0)
            {
                sb.AppendLine("Clients: none");
                sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {this.SumRates()}");
            }
            else
            {
                sb.Append("Clients: ");
                sb.AppendLine(string.Join(", ", _clients.Select(c => c.Name)));
                sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {this.SumRates()}");
            }

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client) => _clients.Remove(Client);

        // A dali e taka :)
        public double SumRates() => _loans.Select(l => l.InterestRate).Sum();
    }
}
