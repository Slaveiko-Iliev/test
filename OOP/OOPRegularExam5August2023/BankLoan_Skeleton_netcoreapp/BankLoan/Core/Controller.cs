using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using System;
using System.Linq;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (nameof(BranchBank) != bankTypeName && nameof(CentralBank) != bankTypeName)
            {
                throw new ArgumentException($"Invalid bank type.");
            }

            IBank bank = new BranchBank(name);

            if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);

            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != "Adult" && clientTypeName != "Student")
            {
                throw new ArgumentException("Invalid client type.");
            }

            IBank currentBank = banks.FirstModel(bankName);

            if (currentBank.GetType().Name == "BranchBank" && clientTypeName == "Adult" || currentBank.GetType().Name == "CentralBank" && clientTypeName == "Student")
            {
                return "Unsuitable bank.";
            }

            IClient currentClient = new Adult(clientName, id, income);

            if (clientTypeName == "Student")
            {
                currentClient = new Student(clientName, id, income);
            }

            currentBank.AddClient(currentClient);

            return $"{clientTypeName} successfully added to {bankName}.";
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != "StudentLoan" && loanTypeName != "MortgageLoan")
            {
                throw new ArgumentException("Invalid loan type.");
            }

            ILoan loan = new MortgageLoan();

            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }

            loans.AddModel(loan);

            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            var funds = 0.0;

            var bank = banks.FirstModel(bankName);

            funds += bank.Loans.Select(l => l.Amount).Sum() + bank.Clients.Select(c => c.Income).Sum();

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            if (loans.FirstModel(loanTypeName) == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            banks.FirstModel(bankName).AddLoan(loans.FirstModel(loanTypeName));

            loans.RemoveModel(loans.FirstModel(loanTypeName));

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
