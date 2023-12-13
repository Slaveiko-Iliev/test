﻿namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int _InitialInterest = 2;

        public Adult(string name, string id, double income) : base(name, id, _InitialInterest, income)
        {
        }

        public override void IncreaseInterest() => Interest += 2;
    }
}
