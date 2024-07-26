using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType(nameof(CategoryProduct))]
    public class CategoriesProductsImportDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
