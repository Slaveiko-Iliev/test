using System.ComponentModel.DataAnnotations;

using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [MinLength(9)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [Range(typeof(decimal), ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal Price { get; set; }
        [Range(ProductCategoryTypeMinValue, ProductCategoryTypeMaxValue)]
        public int CategoryType { get; set; }
        public int[] Clients { get; set; } = null!;
    }
}
