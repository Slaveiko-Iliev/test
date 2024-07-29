using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductsClients = new HashSet<ProductClient>();
        }
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public CategoryType CategoryType { get; set; }
        public ICollection<ProductClient> ProductsClients { get; set; }
    }
}


//•	ProductsClients – collection of type ProductClient
