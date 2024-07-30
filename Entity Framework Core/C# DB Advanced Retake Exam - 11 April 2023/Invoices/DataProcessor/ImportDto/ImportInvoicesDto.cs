using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoicesDto
    {
        public int Id { get; set; }
        [Range(1_000_000_000, 1_500_000_000)]
        public int Number { get; set; }
        public string IssueDate { get; set; } = null!;
        public string DueDate { get; set; } = null!;
        [Range(0, int.MaxValue)]
        public decimal Amount { get; set; }
        [Range(InvoiceCurrencyTypeMinValue, InvoiceCurrencyTypeMaxValue)]
        public int CurrencyType { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;
    }
}
