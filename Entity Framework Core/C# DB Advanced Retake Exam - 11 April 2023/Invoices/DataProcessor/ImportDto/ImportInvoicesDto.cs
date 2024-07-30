using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoicesDto
    {
        [Range(1000000000, 1500000000)]
        public int Number { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public int ClientId { get; set; }
    }
}
