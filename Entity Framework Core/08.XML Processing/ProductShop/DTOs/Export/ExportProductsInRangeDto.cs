using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType(nameof(Product))]
    public class ExportProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string? Buyer { get; set; }
    }


}
