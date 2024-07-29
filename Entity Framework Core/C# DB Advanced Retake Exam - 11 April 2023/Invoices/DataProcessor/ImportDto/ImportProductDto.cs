using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [MinLength(9)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
