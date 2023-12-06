using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using System;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository _loans;
        private BankRepository _banks;

        public Controller()
        {
            _loans = new LoanRepository();
            _banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (!(bankTypeName == "BranchBank" || bankTypeName == "CentralBank"))
            {
                throw new ArgumentException("Invalid bank type.");
            }

            IBank bank;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
                _banks.AddModel(bank);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
                _banks.AddModel(bank);
            }

            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            throw new NotImplementedException();
        }

        public string AddLoan(string loanTypeName)
        {
            if (!(loanTypeName == "MortgageLoan" || loanTypeName == "StudentLoan"))
            {
                throw new ArgumentException("Invalid loan type.");
            }

            ILoan loan;

            if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
                _loans.AddModel(loan);
            }
            else if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
                _loans.AddModel(loan);
            }

            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            throw new NotImplementedException();
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            throw new NotImplementedException();
        }

        public string Statistics()
        {
            throw new NotImplementedException();
        }
    }
}
