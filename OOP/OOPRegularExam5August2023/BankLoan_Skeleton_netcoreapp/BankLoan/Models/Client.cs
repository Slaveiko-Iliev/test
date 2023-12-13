using BankLoan.Models.Contracts;
using System;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string _name;
        private string _id;
        private double _income;

        protected Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Client name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public string Id
        {
            get => _id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Client’s ID cannot be null or empty.");
                }
                _id = value;
            }
        }

        // Be careful with the access modifier!
        public int Interest { get; protected set; }

        public double Income
        {
            get => _income;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Income cannot be below or equal to 0.");
                }
                _income = value;
            }
        }

        public abstract void IncreaseInterest();
    }
}
